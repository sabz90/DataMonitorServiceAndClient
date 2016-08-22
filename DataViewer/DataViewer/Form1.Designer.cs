namespace DataViewer
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tbServiceStatus = new System.Windows.Forms.TextBox();
            this.lbLastUpdatedText = new System.Windows.Forms.Label();
            this.lbLastUpdated = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbLog = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnManualLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Service";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(115, 17);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(103, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Service";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(24, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(739, 372);
            this.dataGridView.TabIndex = 4;
            // 
            // tbServiceStatus
            // 
            this.tbServiceStatus.Location = new System.Drawing.Point(224, 19);
            this.tbServiceStatus.Name = "tbServiceStatus";
            this.tbServiceStatus.ReadOnly = true;
            this.tbServiceStatus.Size = new System.Drawing.Size(610, 20);
            this.tbServiceStatus.TabIndex = 5;
            this.tbServiceStatus.Text = " Service not running.";
            // 
            // lbLastUpdatedText
            // 
            this.lbLastUpdatedText.AutoSize = true;
            this.lbLastUpdatedText.Location = new System.Drawing.Point(21, 62);
            this.lbLastUpdatedText.Name = "lbLastUpdatedText";
            this.lbLastUpdatedText.Size = new System.Drawing.Size(74, 13);
            this.lbLastUpdatedText.TabIndex = 6;
            this.lbLastUpdatedText.Text = "Last Updated:";
            // 
            // lbLastUpdated
            // 
            this.lbLastUpdated.AutoSize = true;
            this.lbLastUpdated.Location = new System.Drawing.Point(110, 62);
            this.lbLastUpdated.Name = "lbLastUpdated";
            this.lbLastUpdated.Size = new System.Drawing.Size(27, 13);
            this.lbLastUpdated.TabIndex = 7;
            this.lbLastUpdated.Text = "N/A";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1086, 506);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lbLog);
            this.tabPage1.Controls.Add(this.tbLog);
            this.tabPage1.Controls.Add(this.lbLastUpdated);
            this.tabPage1.Controls.Add(this.lbLastUpdatedText);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1078, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataView";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(778, 62);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(69, 13);
            this.lbLog.TabIndex = 9;
            this.lbLog.Text = "Process Log:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(781, 78);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(282, 372);
            this.tbLog.TabIndex = 8;
            // 
            // btnManualLoad
            // 
            this.btnManualLoad.Location = new System.Drawing.Point(6, 17);
            this.btnManualLoad.Name = "btnManualLoad";
            this.btnManualLoad.Size = new System.Drawing.Size(185, 23);
            this.btnManualLoad.TabIndex = 10;
            this.btnManualLoad.Text = "Load Data from Source";
            this.btnManualLoad.UseVisualStyleBackColor = true;
            this.btnManualLoad.Click += new System.EventHandler(this.btnManualLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.tbServiceStatus);
            this.groupBox1.Location = new System.Drawing.Point(223, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 48);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnManualLoad);
            this.groupBox2.Location = new System.Drawing.Point(20, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 47);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 536);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Data Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.TextBox tbServiceStatus;
        public System.Windows.Forms.Label lbLastUpdatedText;
        public System.Windows.Forms.Label lbLastUpdated;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox tbLog;
        public System.Windows.Forms.Label lbLog;
        public System.Windows.Forms.Button btnManualLoad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

