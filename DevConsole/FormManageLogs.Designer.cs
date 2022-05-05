namespace DevConsole
{
    partial class FormManageLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageLogs));
            this.DataGridViewMainLogs = new System.Windows.Forms.DataGridView();
            this.ButtonNewMaster = new System.Windows.Forms.Button();
            this.ButtonDeleteMaster = new System.Windows.Forms.Button();
            this.ButtonSaveMaster = new System.Windows.Forms.Button();
            this.TextBoxMasterLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonGenerateLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMainLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewMainLogs
            // 
            this.DataGridViewMainLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMainLogs.Location = new System.Drawing.Point(12, 28);
            this.DataGridViewMainLogs.Name = "DataGridViewMainLogs";
            this.DataGridViewMainLogs.Size = new System.Drawing.Size(505, 421);
            this.DataGridViewMainLogs.TabIndex = 10;
            this.DataGridViewMainLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMainLogs_CellClick);
            this.DataGridViewMainLogs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewMainLogs_DataBindingComplete);
            // 
            // ButtonNewMaster
            // 
            this.ButtonNewMaster.Location = new System.Drawing.Point(608, 56);
            this.ButtonNewMaster.Name = "ButtonNewMaster";
            this.ButtonNewMaster.Size = new System.Drawing.Size(79, 35);
            this.ButtonNewMaster.TabIndex = 4;
            this.ButtonNewMaster.Text = "New";
            this.ButtonNewMaster.UseVisualStyleBackColor = true;
            this.ButtonNewMaster.Click += new System.EventHandler(this.ButtonNewMaster_Click);
            // 
            // ButtonDeleteMaster
            // 
            this.ButtonDeleteMaster.Enabled = false;
            this.ButtonDeleteMaster.Location = new System.Drawing.Point(523, 56);
            this.ButtonDeleteMaster.Name = "ButtonDeleteMaster";
            this.ButtonDeleteMaster.Size = new System.Drawing.Size(79, 35);
            this.ButtonDeleteMaster.TabIndex = 3;
            this.ButtonDeleteMaster.Text = "Delete";
            this.ButtonDeleteMaster.UseVisualStyleBackColor = true;
            this.ButtonDeleteMaster.Click += new System.EventHandler(this.ButtonDeleteMaster_Click);
            // 
            // ButtonSaveMaster
            // 
            this.ButtonSaveMaster.Enabled = false;
            this.ButtonSaveMaster.Location = new System.Drawing.Point(693, 56);
            this.ButtonSaveMaster.Name = "ButtonSaveMaster";
            this.ButtonSaveMaster.Size = new System.Drawing.Size(79, 35);
            this.ButtonSaveMaster.TabIndex = 2;
            this.ButtonSaveMaster.Text = "Save";
            this.ButtonSaveMaster.UseVisualStyleBackColor = true;
            this.ButtonSaveMaster.Click += new System.EventHandler(this.ButtonSaveMaster_Click);
            // 
            // TextBoxMasterLog
            // 
            this.TextBoxMasterLog.Enabled = false;
            this.TextBoxMasterLog.Location = new System.Drawing.Point(523, 28);
            this.TextBoxMasterLog.Name = "TextBoxMasterLog";
            this.TextBoxMasterLog.Size = new System.Drawing.Size(249, 22);
            this.TextBoxMasterLog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Logs";
            // 
            // ButtonGenerateLog
            // 
            this.ButtonGenerateLog.Enabled = false;
            this.ButtonGenerateLog.Location = new System.Drawing.Point(523, 97);
            this.ButtonGenerateLog.Name = "ButtonGenerateLog";
            this.ButtonGenerateLog.Size = new System.Drawing.Size(249, 35);
            this.ButtonGenerateLog.TabIndex = 15;
            this.ButtonGenerateLog.Text = "Generate Log";
            this.ButtonGenerateLog.UseVisualStyleBackColor = true;
            this.ButtonGenerateLog.Click += new System.EventHandler(this.ButtonGenerateLog_Click);
            // 
            // FormManageLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ButtonGenerateLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxMasterLog);
            this.Controls.Add(this.ButtonSaveMaster);
            this.Controls.Add(this.ButtonNewMaster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonDeleteMaster);
            this.Controls.Add(this.DataGridViewMainLogs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormManageLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormManageLogs_Load);
            this.Shown += new System.EventHandler(this.FormManageLogs_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMainLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DataGridViewMainLogs;
        private System.Windows.Forms.Button ButtonDeleteMaster;
        private System.Windows.Forms.Button ButtonSaveMaster;
        private System.Windows.Forms.TextBox TextBoxMasterLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonNewMaster;
        private System.Windows.Forms.Button ButtonGenerateLog;
    }
}