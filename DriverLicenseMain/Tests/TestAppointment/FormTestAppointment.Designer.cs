namespace DriverLicense.Tests.TestAppointment
{
    partial class FormTestAppointment
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
            this.components = new System.ComponentModel.Container();
            this.lblTestMode = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.tSMEditAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.pbTestMode = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseApp1 = new DriverLicense.Applications.LDLApp.Controls.ctrlDrivingLicenseApp();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestMode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestMode
            // 
            this.lblTestMode.AutoSize = true;
            this.lblTestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestMode.ForeColor = System.Drawing.Color.Red;
            this.lblTestMode.Location = new System.Drawing.Point(380, 144);
            this.lblTestMode.Name = "lblTestMode";
            this.lblTestMode.Size = new System.Drawing.Size(323, 32);
            this.lblTestMode.TabIndex = 12;
            this.lblTestMode.Text = "Vision Test Appointment";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointments.Location = new System.Drawing.Point(30, 627);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(1029, 168);
            this.dgvAppointments.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 805);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "#Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(127, 805);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(18, 20);
            this.lblRecords.TabIndex = 20;
            this.lblRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Appointments";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMEditAppointment,
            this.tSMTakeTest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 56);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DriverLicense.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(964, 801);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Image = global::DriverLicense.Properties.Resources.AddAppointment_32;
            this.btnAddAppointment.Location = new System.Drawing.Point(1003, 579);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(56, 42);
            this.btnAddAppointment.TabIndex = 18;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // tSMEditAppointment
            // 
            this.tSMEditAppointment.Image = global::DriverLicense.Properties.Resources.edit_32;
            this.tSMEditAppointment.Name = "tSMEditAppointment";
            this.tSMEditAppointment.Size = new System.Drawing.Size(141, 26);
            this.tSMEditAppointment.Text = "Edit";
            this.tSMEditAppointment.Click += new System.EventHandler(this.tSMEditAppointment_Click);
            // 
            // tSMTakeTest
            // 
            this.tSMTakeTest.Image = global::DriverLicense.Properties.Resources.Test_32;
            this.tSMTakeTest.Name = "tSMTakeTest";
            this.tSMTakeTest.Size = new System.Drawing.Size(141, 26);
            this.tSMTakeTest.Text = "Take Test";
            this.tSMTakeTest.Click += new System.EventHandler(this.tSMTakeTest_Click);
            // 
            // pbTestMode
            // 
            this.pbTestMode.Image = global::DriverLicense.Properties.Resources.driving_test_512;
            this.pbTestMode.Location = new System.Drawing.Point(470, 12);
            this.pbTestMode.Name = "pbTestMode";
            this.pbTestMode.Size = new System.Drawing.Size(157, 114);
            this.pbTestMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestMode.TabIndex = 11;
            this.pbTestMode.TabStop = false;
            // 
            // ctrlDrivingLicenseApp1
            // 
            this.ctrlDrivingLicenseApp1.Location = new System.Drawing.Point(12, 190);
            this.ctrlDrivingLicenseApp1.Name = "ctrlDrivingLicenseApp1";
            this.ctrlDrivingLicenseApp1.Size = new System.Drawing.Size(1077, 389);
            this.ctrlDrivingLicenseApp1.TabIndex = 13;
            this.ctrlDrivingLicenseApp1.Load += new System.EventHandler(this.ctrlDrivingLicenseApp1_Load);
            // 
            // FormTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 853);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.ctrlDrivingLicenseApp1);
            this.Controls.Add(this.pbTestMode);
            this.Controls.Add(this.lblTestMode);
            this.Name = "FormTestAppointment";
            this.Text = "FormTestAppointment";
            this.Load += new System.EventHandler(this.FormTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestMode;
        private System.Windows.Forms.Label lblTestMode;
        private Applications.LDLApp.Controls.ctrlDrivingLicenseApp ctrlDrivingLicenseApp1;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMEditAppointment;
        private System.Windows.Forms.ToolStripMenuItem tSMTakeTest;
    }
}