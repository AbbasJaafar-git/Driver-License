namespace DriverLicense.Applications.LDLApp
{
    partial class FormShowLDLAppInfo
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
            this.ctrlDrivingLicenseApp1 = new DriverLicense.Applications.LDLApp.Controls.ctrlDrivingLicenseApp();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApp1
            // 
            this.ctrlDrivingLicenseApp1.Location = new System.Drawing.Point(30, 31);
            this.ctrlDrivingLicenseApp1.Name = "ctrlDrivingLicenseApp1";
            this.ctrlDrivingLicenseApp1.Size = new System.Drawing.Size(913, 389);
            this.ctrlDrivingLicenseApp1.TabIndex = 0;
            this.ctrlDrivingLicenseApp1.Load += new System.EventHandler(this.ctrlDrivingLicenseApp1_Load);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DriverLicense.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(838, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormShowLDLAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDrivingLicenseApp1);
            this.Name = "FormShowLDLAppInfo";
            this.Text = "FormShowLDLAppInfo";
            this.Load += new System.EventHandler(this.FormShowLDLAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlDrivingLicenseApp ctrlDrivingLicenseApp1;
        private System.Windows.Forms.Button btnClose;
    }
}