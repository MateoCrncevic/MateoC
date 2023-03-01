
namespace FormsApp
{
    partial class PlayerDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblCaptaincy = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(41, 22);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(38, 76);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "label1";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Image = global::FormsApp.Properties.Resources.Favorite_16x;
            this.lblIcon.Location = new System.Drawing.Point(16, 101);
            this.lblIcon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(13, 13);
            this.lblIcon.TabIndex = 2;
            this.lblIcon.Text = "_";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCaptaincy
            // 
            this.lblCaptaincy.AutoSize = true;
            this.lblCaptaincy.Location = new System.Drawing.Point(2, 45);
            this.lblCaptaincy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaptaincy.Name = "lblCaptaincy";
            this.lblCaptaincy.Size = new System.Drawing.Size(35, 13);
            this.lblCaptaincy.TabIndex = 3;
            this.lblCaptaincy.Text = "label1";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(2, 22);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(35, 13);
            this.lblNumber.TabIndex = 4;
            this.lblNumber.Text = "label1";
            // 
            // pbIcon
            // 
            this.pbIcon.ImageLocation = "";
            this.pbIcon.Location = new System.Drawing.Point(118, 42);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(75, 84);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIcon.TabIndex = 5;
            this.pbIcon.TabStop = false;
            // 
            // PlayerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblCaptaincy);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlayerDisplay";
            this.Size = new System.Drawing.Size(196, 129);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerDisplay_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblCaptaincy;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}
