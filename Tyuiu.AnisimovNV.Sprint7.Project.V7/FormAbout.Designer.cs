namespace Tyuiu.AnisimovNV.Sprint7.Project.V7
{
    partial class FormAbout
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle_NVA;
        private System.Windows.Forms.Label labelInfo_NVA;
        private System.Windows.Forms.Button buttonOK_NVA;

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
            labelTitle_NVA = new Label();
            labelInfo_NVA = new Label();
            buttonOK_NVA = new Button();
            SuspendLayout();
            // 
            // labelTitle_NVA
            // 
            labelTitle_NVA.AutoSize = true;
            labelTitle_NVA.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle_NVA.Location = new Point(14, 10);
            labelTitle_NVA.Margin = new Padding(4, 0, 4, 0);
            labelTitle_NVA.Name = "labelTitle_NVA";
            labelTitle_NVA.Size = new Size(255, 20);
            labelTitle_NVA.TabIndex = 0;
            labelTitle_NVA.Text = "Учет квартир и жильцов v1.0";
            // 
            // labelInfo_NVA
            // 
            labelInfo_NVA.AutoSize = true;
            labelInfo_NVA.Location = new Point(15, 55);
            labelInfo_NVA.Margin = new Padding(4, 0, 4, 0);
            labelInfo_NVA.Name = "labelInfo_NVA";
            labelInfo_NVA.Size = new Size(223, 75);
            labelInfo_NVA.TabIndex = 1;
            labelInfo_NVA.Text = "Разработчик: Анисимов Н.В.\r\nГруппа: ИИПб-25-1\r\nВариант задания: 7\r\nПредметная область: Домоуправление\r\nДата создания: 2025";
            labelInfo_NVA.Click += labelInfo_NVA_Click;
            // 
            // buttonOK_NVA
            // 
            buttonOK_NVA.Location = new Point(237, 150);
            buttonOK_NVA.Margin = new Padding(4, 3, 4, 3);
            buttonOK_NVA.Name = "buttonOK_NVA";
            buttonOK_NVA.Size = new Size(88, 27);
            buttonOK_NVA.TabIndex = 2;
            buttonOK_NVA.Text = "OK";
            buttonOK_NVA.UseVisualStyleBackColor = true;
            buttonOK_NVA.Click += buttonOK_NVA_Click;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 190);
            Controls.Add(buttonOK_NVA);
            Controls.Add(labelInfo_NVA);
            Controls.Add(labelTitle_NVA);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе";
            Load += FormAbout_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}