namespace DevConsole
{
    partial class FormEventLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEventLogs));
            this.DataGridViewMainLogs = new System.Windows.Forms.DataGridView();
            this.DataGridViewSubLogs = new System.Windows.Forms.DataGridView();
            this.ButtonManageLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMainLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSubLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewMainLogs
            // 
            this.DataGridViewMainLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMainLogs.Location = new System.Drawing.Point(12, 53);
            this.DataGridViewMainLogs.Name = "DataGridViewMainLogs";
            this.DataGridViewMainLogs.Size = new System.Drawing.Size(374, 396);
            this.DataGridViewMainLogs.TabIndex = 8;
            this.DataGridViewMainLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMainLogs_CellClick);
            // 
            // DataGridViewSubLogs
            // 
            this.DataGridViewSubLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewSubLogs.Location = new System.Drawing.Point(398, 53);
            this.DataGridViewSubLogs.Name = "DataGridViewSubLogs";
            this.DataGridViewSubLogs.Size = new System.Drawing.Size(374, 396);
            this.DataGridViewSubLogs.TabIndex = 9;
            // 
            // ButtonManageLogs
            // 
            this.ButtonManageLogs.Location = new System.Drawing.Point(12, 12);
            this.ButtonManageLogs.Name = "ButtonManageLogs";
            this.ButtonManageLogs.Size = new System.Drawing.Size(143, 35);
            this.ButtonManageLogs.TabIndex = 12;
            this.ButtonManageLogs.Text = "Manage Logs";
            this.ButtonManageLogs.UseVisualStyleBackColor = true;
            this.ButtonManageLogs.Click += new System.EventHandler(this.ButtonManageLogs_Click);
            // 
            // FormEventLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ButtonManageLogs);
            this.Controls.Add(this.DataGridViewSubLogs);
            this.Controls.Add(this.DataGridViewMainLogs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormEventLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormEventLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMainLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSubLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DataGridViewMainLogs;
        private System.Windows.Forms.DataGridView DataGridViewSubLogs;
        private System.Windows.Forms.Button ButtonManageLogs;
    }
}