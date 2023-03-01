
namespace FormsApp
{
    partial class EntryForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbChamp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbEn = new System.Windows.Forms.RadioButton();
            this.rbCro = new System.Windows.Forms.RadioButton();
            this.gbLangauge = new System.Windows.Forms.GroupBox();
            this.chbIsOnline = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbLangauge.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Championship:";
            // 
            // cbChamp
            // 
            this.cbChamp.FormattingEnabled = true;
            this.cbChamp.Items.AddRange(new object[] {
            "Men\'s World Football Championship 2018",
            "Women\'s World Football Championship 2019"});
            this.cbChamp.Location = new System.Drawing.Point(152, 93);
            this.cbChamp.Margin = new System.Windows.Forms.Padding(2);
            this.cbChamp.Name = "cbChamp";
            this.cbChamp.Size = new System.Drawing.Size(239, 21);
            this.cbChamp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Language:";
            // 
            // rbEn
            // 
            this.rbEn.AutoSize = true;
            this.rbEn.Location = new System.Drawing.Point(21, 37);
            this.rbEn.Margin = new System.Windows.Forms.Padding(2);
            this.rbEn.Name = "rbEn";
            this.rbEn.Size = new System.Drawing.Size(59, 17);
            this.rbEn.TabIndex = 5;
            this.rbEn.TabStop = true;
            this.rbEn.Tag = "en";
            this.rbEn.Text = "English";
            this.rbEn.UseVisualStyleBackColor = true;
            // 
            // rbCro
            // 
            this.rbCro.AutoSize = true;
            this.rbCro.Location = new System.Drawing.Point(143, 37);
            this.rbCro.Margin = new System.Windows.Forms.Padding(2);
            this.rbCro.Name = "rbCro";
            this.rbCro.Size = new System.Drawing.Size(64, 17);
            this.rbCro.TabIndex = 6;
            this.rbCro.TabStop = true;
            this.rbCro.Tag = "hr";
            this.rbCro.Text = "Croatian";
            this.rbCro.UseVisualStyleBackColor = true;
            // 
            // gbLangauge
            // 
            this.gbLangauge.Controls.Add(this.rbEn);
            this.gbLangauge.Controls.Add(this.rbCro);
            this.gbLangauge.Location = new System.Drawing.Point(152, 118);
            this.gbLangauge.Margin = new System.Windows.Forms.Padding(2);
            this.gbLangauge.Name = "gbLangauge";
            this.gbLangauge.Padding = new System.Windows.Forms.Padding(2);
            this.gbLangauge.Size = new System.Drawing.Size(238, 81);
            this.gbLangauge.TabIndex = 7;
            this.gbLangauge.TabStop = false;
            // 
            // chbIsOnline
            // 
            this.chbIsOnline.AutoSize = true;
            this.chbIsOnline.Location = new System.Drawing.Point(152, 215);
            this.chbIsOnline.Margin = new System.Windows.Forms.Padding(2);
            this.chbIsOnline.Name = "chbIsOnline";
            this.chbIsOnline.Size = new System.Drawing.Size(136, 17);
            this.chbIsOnline.TabIndex = 9;
            this.chbIsOnline.Text = "Take data from internet";
            this.chbIsOnline.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(113, 258);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(187, 35);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Open application!";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Choose your settings!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(148, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "WELCOME!";
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 340);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbIsOnline);
            this.Controls.Add(this.gbLangauge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbChamp);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Form";
            this.gbLangauge.ResumeLayout(false);
            this.gbLangauge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbChamp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbEn;
        private System.Windows.Forms.RadioButton rbCro;
        private System.Windows.Forms.GroupBox gbLangauge;
        private System.Windows.Forms.CheckBox chbIsOnline;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}