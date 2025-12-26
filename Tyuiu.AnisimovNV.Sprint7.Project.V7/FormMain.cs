using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.AnisimovNV.Sprint7.Project.V7.Lib;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7
{
    public partial class FormMain : Form
    {
        private DataService ds = new DataService();
        private string[,] data;
        private string currentFilePath = "";

        public FormMain()
        {
            InitializeComponent();
            SetupDataGridView();
            UpdateStatus("Готово");
            data = new string[0, 0]; // Или new string[1, 1] — главное, чтобы не было null
        }

        private void SetupDataGridView()
        {
            dataGridViewApartments_NVA.ColumnCount = 11;
            dataGridViewApartments_NVA.Columns[0].HeaderText = "Подъезд";
            dataGridViewApartments_NVA.Columns[1].HeaderText = "Квартира";
            dataGridViewApartments_NVA.Columns[2].HeaderText = "Общ. площадь";
            dataGridViewApartments_NVA.Columns[3].HeaderText = "Жил. площадь";
            dataGridViewApartments_NVA.Columns[4].HeaderText = "Комнат";
            dataGridViewApartments_NVA.Columns[5].HeaderText = "Фамилия";
            dataGridViewApartments_NVA.Columns[6].HeaderText = "Дата прописки";
            dataGridViewApartments_NVA.Columns[7].HeaderText = "Семья";
            dataGridViewApartments_NVA.Columns[8].HeaderText = "Дети";
            dataGridViewApartments_NVA.Columns[9].HeaderText = "Задолженность";
            dataGridViewApartments_NVA.Columns[10].HeaderText = "Примечание";

            foreach (DataGridViewColumn column in dataGridViewApartments_NVA.Columns)
            {
                column.Width = 80;
            }
        }

        private void UpdateStatus(string message)
        {
            toolStripStatusLabel_NVA.Text = message;
        }

        private void LoadDataToGrid(string[,] data)
        {
            dataGridViewApartments_NVA.Rows.Clear();
            if (data.GetLength(0) == 0) return;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                dataGridViewApartments_NVA.Rows.Add();
                for (int j = 0; j < data.GetLength(1) && j < 11; j++)
                {
                    dataGridViewApartments_NVA.Rows[i - 1].Cells[j].Value = data[i, j];
                }
            }
            UpdateStatus($"Загружено: {data.GetLength(0) - 1} записей");
        }

        // Обработчики событий
        private void открытьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentFilePath = dialog.FileName;
                        data = ds.LoadFromFile(currentFilePath);
                        LoadDataToGrid(data);
                        UpdateStatus($"Открыт файл: {Path.GetFileName(currentFilePath)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Обновляем данные из грида
                int rowCount = dataGridViewApartments_NVA.Rows.Count - 1; // -1 для пропуска пустой строки
                if (rowCount <= 0) return;

                string[,] updatedData = new string[rowCount + 1, 11];

                // Копируем заголовки
                for (int j = 0; j < 11; j++)
                {
                    updatedData[0, j] = data[0, j];
                }

                // Копируем данные из грида
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        var value = dataGridViewApartments_NVA.Rows[i].Cells[j].Value;
                        updatedData[i + 1, j] = value?.ToString() ?? "";
                    }
                }

                ds.SaveToFile(currentFilePath, updatedData);
                UpdateStatus("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьКакToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                dialog.FileName = "apartments.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = dialog.FileName;
                    сохранитьToolStripMenuItem_NVA_Click(sender, e);
                }
            }
        }

        private void выходToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            using (FormAbout aboutForm = new FormAbout())
            {
                aboutForm.ShowDialog();
            }
        }

        private void руководствоToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            string guide = @"
РУКОВОДСТВО ПОЛЬЗОВАТЕЛЯ

1. Загрузка данных:
   - Файл → Открыть (выберите CSV файл с данными)

2. Работа с данными:
   - Можно редактировать данные прямо в таблице
   - Для сохранения изменений: Файл → Сохранить
   
3. Поиск:
   - Операции → Поиск по фамилии (введите часть фамилии)
   
4. Статистика и визуализация:
   - Операции → Показать статистику (откроется гистограмма)
   
5. Фильтрация:
   - Операции → Фильтр: с задолженностью
   
6. Сортировка:
   - Операции → Сортировка по фамилии
   
7. Добавление записи:
   - Операции → Добавить запись (заполните поля в новой строке)
   
8. Сброс фильтров:
   - Операции → Сброс фильтров (вернет исходные данные)
";
            MessageBox.Show(guide, "Руководство пользователя",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void статистикаToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            {
                if (data == null || data.GetLength(0) <= 1)
                {
                    MessageBox.Show("Сначала загрузите данные", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var stats = ds.GetStatistics(data);
                string message = "СТАТИСТИКА:\n" + string.Join("\n", stats);

                MessageBox.Show(message, "Статистика",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void фильтрЗадолженностьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data == null || data.GetLength(0) <= 1)
            {
                MessageBox.Show("Сначала загрузите данные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Простая фильтрация прямо в гриде
            for (int i = dataGridViewApartments_NVA.Rows.Count - 2; i >= 0; i--)
            {
                var debtCell = dataGridViewApartments_NVA.Rows[i].Cells[9].Value?.ToString();
                if (debtCell != "True")
                {
                    dataGridViewApartments_NVA.Rows.RemoveAt(i);
                }
            }
            UpdateStatus($"Показаны только квартиры с задолженностью");
        }

        private void сортировкаПоФамилииToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data == null || data.GetLength(0) <= 1)
            {
                MessageBox.Show("Сначала загрузите данные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Простая сортировка через LINQ
            var rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridViewApartments_NVA.Rows)
            {
                if (!row.IsNewRow) rows.Add(row);
            }

            rows.Sort((x, y) =>
                string.Compare(
                    x.Cells[5].Value?.ToString() ?? "",
                    y.Cells[5].Value?.ToString() ?? "",
                    StringComparison.OrdinalIgnoreCase
                )
            );

            dataGridViewApartments_NVA.Rows.Clear();
            foreach (var row in rows)
            {
                dataGridViewApartments_NVA.Rows.Add(row.Cells[0].Value, row.Cells[1].Value,
                    row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value,
                    row.Cells[6].Value, row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value,
                    row.Cells[10].Value);
            }
            UpdateStatus("Отсортировано по фамилии");
        }

        private void добавитьЗаписьToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            dataGridViewApartments_NVA.Rows.Add();
            UpdateStatus("Добавлена новая запись для заполнения");
        }

        private void поискToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            string surname = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите фамилию для поиска:", "Поиск", "", -1, -1);

            if (string.IsNullOrWhiteSpace(surname)) return;

            var indexes = ds.SearchBySurname(data, surname);

            if (indexes.Length == 0)
            {
                MessageBox.Show("Записи не найдены", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridViewApartments_NVA.ClearSelection();
            foreach (int index in indexes)
            {
                dataGridViewApartments_NVA.Rows[index - 1].Selected = true;
            }
            dataGridViewApartments_NVA.FirstDisplayedScrollingRowIndex = indexes[0] - 1;
            UpdateStatus($"Найдено: {indexes.Length} записей");
        }

        private void сбросФильтровToolStripMenuItem_NVA_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                LoadDataToGrid(data);
                UpdateStatus("Фильтры сброшены");
            }
        }
    }
}