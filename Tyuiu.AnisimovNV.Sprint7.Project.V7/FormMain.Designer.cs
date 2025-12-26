namespace Tyuiu.AnisimovNV.Sprint7.Project.V7
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem фильтрЗадолженностьToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem сортировкаПоФамилииToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem сбросФильтровToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗаписьToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem_NVA;
        private System.Windows.Forms.ToolStripMenuItem руководствоToolStripMenuItem_NVA;
        private System.Windows.Forms.DataGridView dataGridViewApartments_NVA;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_NVA;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрЗадолженностьToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаПоФамилииToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.сбросФильтровToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗаписьToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоToolStripMenuItem_NVA = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewApartments_NVA = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_NVA = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_NVA)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.операцииToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem_NVA,
            this.сохранитьToolStripMenuItem_NVA,
            this.сохранитьКакToolStripMenuItem_NVA,
            this.выходToolStripMenuItem_NVA});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem_NVA
            // 
            this.открытьToolStripMenuItem_NVA.Name = "открытьToolStripMenuItem_NVA";
            this.открытьToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem_NVA.Text = "Открыть";
            this.открытьToolStripMenuItem_NVA.Click += new System.EventHandler(this.открытьToolStripMenuItem_NVA_Click);
            // 
            // сохранитьToolStripMenuItem_NVA
            // 
            this.сохранитьToolStripMenuItem_NVA.Name = "сохранитьToolStripMenuItem_NVA";
            this.сохранитьToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem_NVA.Text = "Сохранить";
            this.сохранитьToolStripMenuItem_NVA.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_NVA_Click);
            // 
            // сохранитьКакToolStripMenuItem_NVA
            // 
            this.сохранитьКакToolStripMenuItem_NVA.Name = "сохранитьКакToolStripMenuItem_NVA";
            this.сохранитьКакToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.сохранитьКакToolStripMenuItem_NVA.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem_NVA.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_NVA_Click);
            // 
            // выходToolStripMenuItem_NVA
            // 
            this.выходToolStripMenuItem_NVA.Name = "выходToolStripMenuItem_NVA";
            this.выходToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem_NVA.Text = "Выход";
            this.выходToolStripMenuItem_NVA.Click += new System.EventHandler(this.выходToolStripMenuItem_NVA_Click);
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem_NVA,
            this.статистикаToolStripMenuItem_NVA,
            this.фильтрЗадолженностьToolStripMenuItem_NVA,
            this.сортировкаПоФамилииToolStripMenuItem_NVA,
            this.сбросФильтровToolStripMenuItem_NVA,
            this.добавитьЗаписьToolStripMenuItem_NVA});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // поискToolStripMenuItem_NVA
            // 
            this.поискToolStripMenuItem_NVA.Name = "поискToolStripMenuItem_NVA";
            this.поискToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.поискToolStripMenuItem_NVA.Text = "Поиск по фамилии";
            this.поискToolStripMenuItem_NVA.Click += new System.EventHandler(this.поискToolStripMenuItem_NVA_Click);
            // 
            // статистикаToolStripMenuItem_NVA
            // 
            this.статистикаToolStripMenuItem_NVA.Name = "статистикаToolStripMenuItem_NVA";
            this.статистикаToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.статистикаToolStripMenuItem_NVA.Text = "Показать статистику";
            this.статистикаToolStripMenuItem_NVA.Click += new System.EventHandler(this.статистикаToolStripMenuItem_NVA_Click);
            // 
            // фильтрЗадолженностьToolStripMenuItem_NVA
            // 
            this.фильтрЗадолженностьToolStripMenuItem_NVA.Name = "фильтрЗадолженностьToolStripMenuItem_NVA";
            this.фильтрЗадолженностьToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.фильтрЗадолженностьToolStripMenuItem_NVA.Text = "Фильтр: с задолженностью";
            this.фильтрЗадолженностьToolStripMenuItem_NVA.Click += new System.EventHandler(this.фильтрЗадолженностьToolStripMenuItem_NVA_Click);
            // 
            // сортировкаПоФамилииToolStripMenuItem_NVA
            // 
            this.сортировкаПоФамилииToolStripMenuItem_NVA.Name = "сортировкаПоФамилииToolStripMenuItem_NVA";
            this.сортировкаПоФамилииToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.сортировкаПоФамилииToolStripMenuItem_NVA.Text = "Сортировка по фамилии";
            this.сортировкаПоФамилииToolStripMenuItem_NVA.Click += new System.EventHandler(this.сортировкаПоФамилииToolStripMenuItem_NVA_Click);
            // 
            // сбросФильтровToolStripMenuItem_NVA
            // 
            this.сбросФильтровToolStripMenuItem_NVA.Name = "сбросФильтровToolStripMenuItem_NVA";
            this.сбросФильтровToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.сбросФильтровToolStripMenuItem_NVA.Text = "Сброс фильтров";
            this.сбросФильтровToolStripMenuItem_NVA.Click += new System.EventHandler(this.сбросФильтровToolStripMenuItem_NVA_Click);
            // 
            // добавитьЗаписьToolStripMenuItem_NVA
            // 
            this.добавитьЗаписьToolStripMenuItem_NVA.Name = "добавитьЗаписьToolStripMenuItem_NVA";
            this.добавитьЗаписьToolStripMenuItem_NVA.Size = new System.Drawing.Size(210, 22);
            this.добавитьЗаписьToolStripMenuItem_NVA.Text = "Добавить запись";
            this.добавитьЗаписьToolStripMenuItem_NVA.Click += new System.EventHandler(this.добавитьЗаписьToolStripMenuItem_NVA_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem_NVA,
            this.руководствоToolStripMenuItem_NVA});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem_NVA
            // 
            this.оПрограммеToolStripMenuItem_NVA.Name = "оПрограммеToolStripMenuItem_NVA";
            this.оПрограммеToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem_NVA.Text = "О программе";
            this.оПрограммеToolStripMenuItem_NVA.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_NVA_Click);
            // 
            // руководствоToolStripMenuItem_NVA
            // 
            this.руководствоToolStripMenuItem_NVA.Name = "руководствоToolStripMenuItem_NVA";
            this.руководствоToolStripMenuItem_NVA.Size = new System.Drawing.Size(180, 22);
            this.руководствоToolStripMenuItem_NVA.Text = "Руководство";
            this.руководствоToolStripMenuItem_NVA.Click += new System.EventHandler(this.руководствоToolStripMenuItem_NVA_Click);
            // 
            // dataGridViewApartments_NVA
            // 
            this.dataGridViewApartments_NVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApartments_NVA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewApartments_NVA.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewApartments_NVA.Name = "dataGridViewApartments_NVA";
            this.dataGridViewApartments_NVA.Size = new System.Drawing.Size(984, 482);
            this.dataGridViewApartments_NVA.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_NVA});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_NVA
            // 
            this.toolStripStatusLabel_NVA.Name = "toolStripStatusLabel_NVA";
            this.toolStripStatusLabel_NVA.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel_NVA.Text = "Готово";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 506);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewApartments_NVA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Учет квартир и жильцов | Домоуправление";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_NVA)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}