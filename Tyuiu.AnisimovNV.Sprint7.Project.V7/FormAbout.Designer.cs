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
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle_NVA = new System.Windows.Forms.Label();
            this.labelInfo_NVA = new System.Windows.Forms.Label();
            this.buttonOK_NVA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.labelTitle_NVA.AutoSize = true;
            this.labelTitle_NVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle_NVA.Location = new System.Drawing.Point(12, 9);
            this.labelTitle_NVA.Name = "labelTitle_NVA";
            this.labelTitle_NVA.Size = new System.Drawing.Size(267, 20);
            this.labelTitle_NVA.TabIndex = 0;
            this.labelTitle_NVA.Text = "Учет квартир и жильцов v1.0";
            this.labelInfo_NVA.AutoSize = true;
            this.labelInfo_NVA.Location = new System.Drawing.Point(13, 48);
            this.labelInfo_NVA.Name = "labelInfo_NVA";
            this.labelInfo_NVA.Size = new System.Drawing.Size(256, 65);
            this.labelInfo_NVA.TabIndex = 1;
            this.labelInfo_NVA.Text = "Разработчик: Анисимов Н.В.\r\nГруппа: ИИПб-23-2\r\nВариант: 7\r\nПредмет: Домоуправление\r\n2024";
            this.buttonOK_NVA.Location = new System.Drawing.Point(203, 130);
            this.buttonOK_NVA.Name = "buttonOK_NVA";
            this.buttonOK_NVA.Size = new System.Drawing.Size(75, 23);
            this.buttonOK_NVA.TabIndex = 2;
            this.buttonOK_NVA.Text = "OK";
            this.buttonOK_NVA.UseVisualStyleBackColor = true;
            this.buttonOK_NVA.Click += new System.EventHandler(this.buttonOK_NVA_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 165);
            this.Controls.Add(this.buttonOK_NVA);
            this.Controls.Add(this.labelInfo_NVA);
            this.Controls.Add(this.labelTitle_NVA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}