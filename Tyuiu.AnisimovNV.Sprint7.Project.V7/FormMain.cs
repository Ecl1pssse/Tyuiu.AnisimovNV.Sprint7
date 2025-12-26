using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.AnisimovNV.Sprint7.Project.V7.Lib;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7
{
    public partial class FormMain : Form
    {
        private DataService ds = new DataService();
        private string[,] data = new string[0, 0];
        private string currentFilePath = "";

        public FormMain()
        {
            InitializeComponent();
            SetupDataGridView();
            UpdateStatus("Готово");
        }

        private void SetupDataGridView()
        {
            dataGridViewApartments_NVA.ColumnCount = 11;
            string[] headers = {
                "Подъезд", "Квартира", "Общ. площадь", "Жил. площадь",
                "Комнат", "Фамилия", "Дата прописки", "Семья",
                "Дети", "Задолженность", "Примечание"
            };
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridViewApartments_NVA.Columns[i].HeaderText = headers[i];
                dataGridViewApartments_NVA.Columns[i].Width = 80;
            }
        }

        private void UpdateStatus(string msg) => toolStripStatusLabel_NVA.Text = msg;

        private void LoadDataToGrid(string[,] data)
        {
            dataGridViewApartments_NVA.Rows.Clear();
            if (data.GetLength(0) == 0) return;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                dataGridViewApartments_NVA.Rows.Add();
                for (int j = 0; j < 11 && j < data.GetLength(1); j++)
                {
                    dataGridViewApartments_NVA.Rows[i - 1].Cells[j].Value = data[i, j];
                }
            }
            UpdateStatus($"Загружено: {data.GetLength(0) - 1} записей");
        }

        // === МЕНЮ ===
        private void открытьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog { Filter = "CSV (*.csv)|*.csv" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentFilePath = d.FileName;
                        data = ds.LoadFromFile(currentFilePath);
                        LoadDataToGrid(data);
                        UpdateStatus($"Открыт: {Path.GetFileName(currentFilePath)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                сохранитьКакToolStripMenuItem_NVA_Click(sender, e);
                return;
            }

            try
            {
                int rowCount = dataGridViewApartments_NVA.Rows.Count - 1;
                if (rowCount <= 0) return;

                string[,] updated = new string[rowCount + 1, 11];
                // Копируем заголовки
                for (int j = 0; j < 11; j++)
                {
                    updated[0, j] = (data.GetLength(0) > 0 && data.GetLength(1) > j) ? data[0, j] : "";
                }

                // Копируем данные с защитой
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (j < dataGridViewApartments_NVA.Columns.Count &&
                            i < dataGridViewApartments_NVA.Rows.Count &&
                            j < dataGridViewApartments_NVA.Rows[i].Cells.Count)
                        {
                            var v = dataGridViewApartments_NVA.Rows[i].Cells[j].Value;
                            updated[i + 1, j] = v?.ToString() ?? "";
                        }
                        else
                        {
                            updated[i + 1, j] = "";
                        }
                    }
                }

                ds.SaveToFile(currentFilePath, updated);
                UpdateStatus("Сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьКакToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog d = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "apartments.csv" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = d.FileName;
                    сохранитьToolStripMenuItem_NVA_Click(sender, e);
                }
            }
        }

        private void выходToolStripMenuItem_NVA_Click(object sender, EventArgs e) => Application.Exit();

        private void оПрограммеToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (FormAbout f = new FormAbout()) f.ShowDialog();
        }

        private void руководствоToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
РУКОВОДСТВО:
• Файл → Открыть — загрузить CSV
• Редактируйте данные в таблице
• Файл → Сохранить — сохранить изменения
• Операции → Поиск, Статистика, Фильтр и т.д.
• Помощь → О программе
", "Руководство", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === ФУНКЦИИ ===
        private void статистикаToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data.GetLength(0) <= 1) { MessageBox.Show("Нет данных"); return; }
            string msg = "СТАТИСТИКА:\n" + string.Join("\n", ds.GetStatistics(data));
            MessageBox.Show(msg, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void фильтрЗадолженностьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data.GetLength(0) <= 1) { MessageBox.Show("Нет данных"); return; }
            var filtered = ds.FilterByDebt(data, true);
            LoadDataToGrid(filtered);
            UpdateStatus($"С долгом: {filtered.GetLength(0) - 1}");
        }

        private void сортировкаПоФамилииToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data.GetLength(0) <= 1) { MessageBox.Show("Нет данных"); return; }
            var sorted = ds.SortData(data, 5, true);
            LoadDataToGrid(sorted);
            UpdateStatus("Сортировка по фамилии");
        }

        private void сбросФильтровToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            LoadDataToGrid(data);
            UpdateStatus("Фильтры сброшены");
        }

        private void добавитьЗаписьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data.GetLength(0) == 0) { MessageBox.Show("Сначала загрузите данные"); return; }
            dataGridViewApartments_NVA.Rows.Add();
            UpdateStatus("Новая строка готова");
        }

        private void поискToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data.GetLength(0) <= 1) { MessageBox.Show("Нет данных"); return; }
            string surname = Microsoft.VisualBasic.Interaction.InputBox("Фамилия:", "Поиск");
            if (string.IsNullOrWhiteSpace(surname)) return;
            int[] indexes = ds.SearchBySurname(data, surname);
            if (indexes.Length == 0) { MessageBox.Show("Не найдено"); return; }
            dataGridViewApartments_NVA.ClearSelection();
            foreach (int i in indexes) dataGridViewApartments_NVA.Rows[i - 1].Selected = true;
            UpdateStatus($"Найдено: {indexes.Length}");
        }

        // === КНОПКИ ===
        private void buttonSearch_NVA_Click(object sender, EventArgs e) => поискToolStripMenuItem_NVA_Click(sender, e);
        private void buttonStatistics_NVA_Click(object sender, EventArgs e) => статистикаToolStripMenuItem_NVA_Click(sender, e);
        private void buttonFilterDebt_NVA_Click(object sender, EventArgs e) => фильтрЗадолженностьToolStripMenuItem_NVA_Click(sender, e);
        private void buttonSortSurname_NVA_Click(object sender, EventArgs e) => сортировкаПоФамилииToolStripMenuItem_NVA_Click(sender, e);
        private void buttonResetFilters_NVA_Click(object sender, EventArgs e) => сбросФильтровToolStripMenuItem_NVA_Click(sender, e);
        private void buttonAddRecord_NVA_Click(object sender, EventArgs e) => добавитьЗаписьToolStripMenuItem_NVA_Click(sender, e);
    }
}