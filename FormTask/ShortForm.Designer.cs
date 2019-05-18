namespace FormTask
{
    partial class ShortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.People = new System.Windows.Forms.TextBox();
            this.Beds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.DateTimePicker();
            this.To = new System.Windows.Forms.DateTimePicker();
            this.Ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Services = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // People
            // 
            this.People.Location = new System.Drawing.Point(7, 25);
            this.People.Name = "People";
            this.People.Size = new System.Drawing.Size(256, 20);
            this.People.TabIndex = 28;
            // 
            // Beds
            // 
            this.Beds.Location = new System.Drawing.Point(7, 80);
            this.Beds.Name = "Beds";
            this.Beds.Size = new System.Drawing.Size(256, 20);
            this.Beds.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во людей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кол-во кроватей";
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(7, 145);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(256, 20);
            this.From.TabIndex = 4;
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(7, 200);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(256, 20);
            this.To.TabIndex = 5;
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(7, 465);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(256, 34);
            this.Ok.TabIndex = 6;
            this.Ok.Text = "Применить ";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата прибытия и выезда";
            // 
            // Services
            // 
            this.Services.FormattingEnabled = true;
            this.Services.Items.AddRange(new object[] {
            "Сейф в номере",
            "Пополнение мини-бара",
            "Куртизанки на ночь",
            "Личный автомобиль"});
            this.Services.Location = new System.Drawing.Point(7, 322);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(256, 94);
            this.Services.TabIndex = 26;
            this.Services.SelectedIndexChanged += new System.EventHandler(this.Services_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Доп. услуги";
            // 
            // ShortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Services);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Beds);
            this.Controls.Add(this.People);
            this.Name = "ShortForm";
            this.Text = "Окно изменений";
            this.Load += new System.EventHandler(this.ShortForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox People;
        private System.Windows.Forms.TextBox Beds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker From;
        private System.Windows.Forms.DateTimePicker To;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox Services;
        private System.Windows.Forms.Label label4;
    }
}