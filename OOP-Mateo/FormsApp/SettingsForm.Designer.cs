
namespace FormsApp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.chbIsOnline = new System.Windows.Forms.CheckBox();
            this.gbLangauge = new System.Windows.Forms.GroupBox();
            this.rbEn = new System.Windows.Forms.RadioButton();
            this.rbCro = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbChamp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbLangauge.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbIsOnline
            // 
            resources.ApplyResources(this.chbIsOnline, "chbIsOnline");
            this.chbIsOnline.Name = "chbIsOnline";
            this.chbIsOnline.UseVisualStyleBackColor = true;
            // 
            // gbLangauge
            // 
            resources.ApplyResources(this.gbLangauge, "gbLangauge");
            this.gbLangauge.Controls.Add(this.rbEn);
            this.gbLangauge.Controls.Add(this.rbCro);
            this.gbLangauge.Name = "gbLangauge";
            this.gbLangauge.TabStop = false;
            // 
            // rbEn
            // 
            resources.ApplyResources(this.rbEn, "rbEn");
            this.rbEn.Name = "rbEn";
            this.rbEn.TabStop = true;
            this.rbEn.Tag = "en";
            this.rbEn.UseVisualStyleBackColor = true;
            // 
            // rbCro
            // 
            resources.ApplyResources(this.rbCro, "rbCro");
            this.rbCro.Name = "rbCro";
            this.rbCro.TabStop = true;
            this.rbCro.Tag = "hr";
            this.rbCro.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbChamp
            // 
            resources.ApplyResources(this.cbChamp, "cbChamp");
            this.cbChamp.FormattingEnabled = true;
            this.cbChamp.Items.AddRange(new object[] {
            resources.GetString("cbChamp.Items"),
            resources.GetString("cbChamp.Items1")});
            this.cbChamp.Name = "cbChamp";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chbIsOnline);
            this.Controls.Add(this.gbLangauge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbChamp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "SettingsForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.gbLangauge.ResumeLayout(false);
            this.gbLangauge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chbIsOnline;
        private System.Windows.Forms.GroupBox gbLangauge;
        private System.Windows.Forms.RadioButton rbEn;
        private System.Windows.Forms.RadioButton rbCro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}