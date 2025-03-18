namespace DriverLicense.Licenses
{
    partial class FormInternationalLicenses
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
            this.lblMode = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.dgvIntApplications = new System.Windows.Forms.DataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMShowHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(376, 143);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(523, 32);
            this.lblMode.TabIndex = 22;
            this.lblMode.Text = "International Driving License Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DriverLicense.Properties.Resources.International_323;
            this.pictureBox2.Location = new System.Drawing.Point(707, 77);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DriverLicense.Properties.Resources.our_process__2_1;
            this.pictureBox1.Location = new System.Drawing.Point(575, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(242, 199);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(132, 24);
            this.txtFilter.TabIndex = 31;
            this.txtFilter.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "#Records:";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::DriverLicense.Properties.Resources.close__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1162, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 27;
            this.button2.Text = "Close";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddApp
            // 
            this.btnAddApp.Image = global::DriverLicense.Properties.Resources.files;
            this.btnAddApp.Location = new System.Drawing.Point(1190, 177);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(67, 46);
            this.btnAddApp.TabIndex = 26;
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // dgvIntApplications
            // 
            this.dgvIntApplications.AllowUserToAddRows = false;
            this.dgvIntApplications.AllowUserToDeleteRows = false;
            this.dgvIntApplications.AllowUserToOrderColumns = true;
            this.dgvIntApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvIntApplications.Location = new System.Drawing.Point(21, 229);
            this.dgvIntApplications.Name = "dgvIntApplications";
            this.dgvIntApplications.ReadOnly = true;
            this.dgvIntApplications.RowHeadersWidth = 15;
            this.dgvIntApplications.RowTemplate.Height = 24;
            this.dgvIntApplications.Size = new System.Drawing.Size(1236, 320);
            this.dgvIntApplications.TabIndex = 29;
            this.dgvIntApplications.SelectionChanged += new System.EventHandler(this.dgvIntApplications_SelectionChanged);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(123, 574);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(18, 20);
            this.lblRecords.TabIndex = 28;
            this.lblRecords.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Int. License ID",
            "Driver ID"});
            this.comboBox1.Location = new System.Drawing.Point(103, 199);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter by";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMAppDetails,
            this.toolStripSeparator3,
            this.tSMShowLicense,
            this.toolStripSeparator5,
            this.tSMShowHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 94);
            this.contextMenuStrip1.Text = "Show Details";
            // 
            // tSMAppDetails
            // 
            this.tSMAppDetails.Image = global::DriverLicense.Properties.Resources.file;
            this.tSMAppDetails.Name = "tSMAppDetails";
            this.tSMAppDetails.Size = new System.Drawing.Size(265, 26);
            this.tSMAppDetails.Text = "Show Person Details";
            this.tSMAppDetails.Click += new System.EventHandler(this.tSMAppDetails_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(262, 6);
            // 
            // tSMShowLicense
            // 
            this.tSMShowLicense.Image = global::DriverLicense.Properties.Resources.id__1_1;
            this.tSMShowLicense.Name = "tSMShowLicense";
            this.tSMShowLicense.Size = new System.Drawing.Size(265, 26);
            this.tSMShowLicense.Text = "Show License Details";
            this.tSMShowLicense.Click += new System.EventHandler(this.tSMShowLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(262, 6);
            // 
            // tSMShowHistory
            // 
            this.tSMShowHistory.Image = global::DriverLicense.Properties.Resources.user_id__2_;
            this.tSMShowHistory.Name = "tSMShowHistory";
            this.tSMShowHistory.Size = new System.Drawing.Size(265, 26);
            this.tSMShowHistory.Text = "Show Person License history";
            this.tSMShowHistory.Click += new System.EventHandler(this.tSMShowHistory_Click);
            // 
            // FormInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 608);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.dgvIntApplications);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormInternationalLicenses";
            this.Text = "FormInternationalLicenses";
            this.Load += new System.EventHandler(this.FormInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.DataGridView dgvIntApplications;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMAppDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tSMShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tSMShowHistory;
    }
}