namespace DriverLicense
{
    partial class FormFindPerson
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
            this.ctrlPersonInfoWithFilter1 = new DriverLicense.ctrlPersonInfoWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFindPerson = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(12, 115);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(667, 281);
            this.ctrlPersonInfoWithFilter1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DriverLicense.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(567, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFindPerson
            // 
            this.lblFindPerson.AutoSize = true;
            this.lblFindPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindPerson.ForeColor = System.Drawing.Color.Red;
            this.lblFindPerson.Location = new System.Drawing.Point(238, 40);
            this.lblFindPerson.Name = "lblFindPerson";
            this.lblFindPerson.Size = new System.Drawing.Size(220, 42);
            this.lblFindPerson.TabIndex = 33;
            this.lblFindPerson.Text = "Find Person";
            // 
            // FormFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 437);
            this.Controls.Add(this.lblFindPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Name = "FormFindPerson";
            this.Text = "FormFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFindPerson;
    }
}