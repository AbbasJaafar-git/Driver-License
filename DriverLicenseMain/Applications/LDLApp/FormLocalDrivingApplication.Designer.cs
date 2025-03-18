namespace DriverLicense.Applications
{
    partial class FormLocalDrivingApplication
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittingTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMShowHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLocalApplications = new System.Windows.Forms.DataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(250, 230);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(132, 24);
            this.txtFilter.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "#Records:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(289, 6);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMAppDetails,
            this.toolStripSeparator1,
            this.tSMEditApp,
            this.tSMDelete,
            this.tSMCancel,
            this.toolStripSeparator2,
            this.tSMSchedule,
            this.toolStripSeparator3,
            this.tSMIssueLicense,
            this.toolStripSeparator4,
            this.tSMShowLicense,
            this.toolStripSeparator5,
            this.tSMShowHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 270);
            this.contextMenuStrip1.Text = "Show Details";
            // 
            // tSMAppDetails
            // 
            this.tSMAppDetails.Image = global::DriverLicense.Properties.Resources.file;
            this.tSMAppDetails.Name = "tSMAppDetails";
            this.tSMAppDetails.Size = new System.Drawing.Size(292, 26);
            this.tSMAppDetails.Text = "Show Application Details";
            this.tSMAppDetails.Click += new System.EventHandler(this.tSMAppDetails_Click);
            // 
            // tSMEditApp
            // 
            this.tSMEditApp.Image = global::DriverLicense.Properties.Resources.edit;
            this.tSMEditApp.Name = "tSMEditApp";
            this.tSMEditApp.Size = new System.Drawing.Size(292, 26);
            this.tSMEditApp.Text = "Edit Application";
            this.tSMEditApp.Click += new System.EventHandler(this.tSMEditApp_Click);
            // 
            // tSMDelete
            // 
            this.tSMDelete.Image = global::DriverLicense.Properties.Resources.delete;
            this.tSMDelete.Name = "tSMDelete";
            this.tSMDelete.Size = new System.Drawing.Size(292, 26);
            this.tSMDelete.Text = "Delete Application";
            this.tSMDelete.Click += new System.EventHandler(this.tSMDelete_Click);
            // 
            // tSMCancel
            // 
            this.tSMCancel.Image = global::DriverLicense.Properties.Resources.cancel;
            this.tSMCancel.Name = "tSMCancel";
            this.tSMCancel.Size = new System.Drawing.Size(292, 26);
            this.tSMCancel.Text = "Cancel Application";
            this.tSMCancel.Click += new System.EventHandler(this.tSMCancel_Click);
            // 
            // tSMSchedule
            // 
            this.tSMSchedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittingTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.tSMSchedule.Image = global::DriverLicense.Properties.Resources.appointment;
            this.tSMSchedule.Name = "tSMSchedule";
            this.tSMSchedule.Size = new System.Drawing.Size(292, 26);
            this.tSMSchedule.Text = "Schedule Tests";
            this.tSMSchedule.Click += new System.EventHandler(this.tSMSchedule_Click);
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::DriverLicense.Properties.Resources.Vision_Test_32;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittingTestToolStripMenuItem
            // 
            this.scheduleWrittingTestToolStripMenuItem.Image = global::DriverLicense.Properties.Resources.Written_Test_32_Sechdule;
            this.scheduleWrittingTestToolStripMenuItem.Name = "scheduleWrittingTestToolStripMenuItem";
            this.scheduleWrittingTestToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.scheduleWrittingTestToolStripMenuItem.Text = "Schedule Writting Test";
            this.scheduleWrittingTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittingTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = global::DriverLicense.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(289, 6);
            // 
            // tSMIssueLicense
            // 
            this.tSMIssueLicense.Image = global::DriverLicense.Properties.Resources.id__1_;
            this.tSMIssueLicense.Name = "tSMIssueLicense";
            this.tSMIssueLicense.Size = new System.Drawing.Size(292, 26);
            this.tSMIssueLicense.Text = "Issue Driving License(First Time)";
            this.tSMIssueLicense.Click += new System.EventHandler(this.tSMIssueLicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(289, 6);
            // 
            // tSMShowLicense
            // 
            this.tSMShowLicense.Image = global::DriverLicense.Properties.Resources.id__1_1;
            this.tSMShowLicense.Name = "tSMShowLicense";
            this.tSMShowLicense.Size = new System.Drawing.Size(292, 26);
            this.tSMShowLicense.Text = "Show License";
            this.tSMShowLicense.Click += new System.EventHandler(this.tSMShowLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(289, 6);
            // 
            // tSMShowHistory
            // 
            this.tSMShowHistory.Image = global::DriverLicense.Properties.Resources.user_id__2_;
            this.tSMShowHistory.Name = "tSMShowHistory";
            this.tSMShowHistory.Size = new System.Drawing.Size(292, 26);
            this.tSMShowHistory.Text = "Show Person License history";
            this.tSMShowHistory.Click += new System.EventHandler(this.tSMShowHistory_Click);
            // 
            // dgvLocalApplications
            // 
            this.dgvLocalApplications.AllowUserToAddRows = false;
            this.dgvLocalApplications.AllowUserToDeleteRows = false;
            this.dgvLocalApplications.AllowUserToOrderColumns = true;
            this.dgvLocalApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalApplications.Location = new System.Drawing.Point(29, 260);
            this.dgvLocalApplications.Name = "dgvLocalApplications";
            this.dgvLocalApplications.ReadOnly = true;
            this.dgvLocalApplications.RowHeadersWidth = 15;
            this.dgvLocalApplications.RowTemplate.Height = 24;
            this.dgvLocalApplications.Size = new System.Drawing.Size(1236, 320);
            this.dgvLocalApplications.TabIndex = 17;
            this.dgvLocalApplications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalApplications_CellContentClick);
            this.dgvLocalApplications.SelectionChanged += new System.EventHandler(this.dgvLocalApplications_SelectionChanged);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(131, 605);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(18, 20);
            this.lblRecords.TabIndex = 16;
            this.lblRecords.Text = "0";
            this.lblRecords.Click += new System.EventHandler(this.lblRecords_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LDLAppID",
            "National No.",
            "Full Name",
            "Status"});
            this.comboBox1.Location = new System.Drawing.Point(111, 230);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filter by";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(428, 141);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(434, 32);
            this.lblMode.TabIndex = 11;
            this.lblMode.Text = "Local Driving License Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DriverLicense.Properties.Resources.local_network;
            this.pictureBox2.Location = new System.Drawing.Point(690, 77);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::DriverLicense.Properties.Resources.close__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1170, 595);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Close";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddApp
            // 
            this.btnAddApp.Image = global::DriverLicense.Properties.Resources.files;
            this.btnAddApp.Location = new System.Drawing.Point(1198, 208);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(67, 46);
            this.btnAddApp.TabIndex = 14;
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DriverLicense.Properties.Resources.our_process__2_1;
            this.pictureBox1.Location = new System.Drawing.Point(558, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormLocalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 641);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.dgvLocalApplications);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormLocalDrivingApplication";
            this.Text = "FormLocalDrivingApplication";
            this.Load += new System.EventHandler(this.FormLocalDrivingApplication_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.ToolStripMenuItem tSMIssueLicense;
        private System.Windows.Forms.ToolStripMenuItem tSMSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tSMDelete;
        private System.Windows.Forms.ToolStripMenuItem tSMEditApp;
        private System.Windows.Forms.ToolStripMenuItem tSMCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tSMAppDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvLocalApplications;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tSMShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tSMShowHistory;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittingTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}