namespace DevConsole
{
    partial class FormDevTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevTasks));
            this.ButtonNew = new System.Windows.Forms.Button();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.FlowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonFilters = new System.Windows.Forms.Button();
            this.ButtonClearFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonNew
            // 
            this.ButtonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNew.Location = new System.Drawing.Point(637, 12);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(135, 35);
            this.ButtonNew.TabIndex = 0;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRefresh.Location = new System.Drawing.Point(496, 12);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(135, 35);
            this.ButtonRefresh.TabIndex = 1;
            this.ButtonRefresh.Text = "Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // FlowLayoutPanelMain
            // 
            this.FlowLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanelMain.AutoScroll = true;
            this.FlowLayoutPanelMain.BackColor = System.Drawing.SystemColors.Control;
            this.FlowLayoutPanelMain.Location = new System.Drawing.Point(12, 53);
            this.FlowLayoutPanelMain.Name = "FlowLayoutPanelMain";
            this.FlowLayoutPanelMain.Size = new System.Drawing.Size(760, 396);
            this.FlowLayoutPanelMain.TabIndex = 2;
            this.FlowLayoutPanelMain.WrapContents = false;
            // 
            // ButtonFilters
            // 
            this.ButtonFilters.Location = new System.Drawing.Point(12, 12);
            this.ButtonFilters.Name = "ButtonFilters";
            this.ButtonFilters.Size = new System.Drawing.Size(135, 35);
            this.ButtonFilters.TabIndex = 6;
            this.ButtonFilters.Text = "Filters (0)";
            this.ButtonFilters.UseVisualStyleBackColor = true;
            this.ButtonFilters.Click += new System.EventHandler(this.ButtonFilters_Click);
            // 
            // ButtonClearFilters
            // 
            this.ButtonClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonClearFilters.ForeColor = System.Drawing.Color.White;
            this.ButtonClearFilters.Location = new System.Drawing.Point(153, 12);
            this.ButtonClearFilters.Name = "ButtonClearFilters";
            this.ButtonClearFilters.Size = new System.Drawing.Size(35, 35);
            this.ButtonClearFilters.TabIndex = 7;
            this.ButtonClearFilters.Text = "X";
            this.ButtonClearFilters.UseVisualStyleBackColor = false;
            this.ButtonClearFilters.Click += new System.EventHandler(this.ButtonClearFilters_Click);
            // 
            // FormDevTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ButtonClearFilters);
            this.Controls.Add(this.ButtonFilters);
            this.Controls.Add(this.FlowLayoutPanelMain);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.ButtonNew);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDevTasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormDevTasks_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelMain;
        private System.Windows.Forms.Button ButtonFilters;
        private System.Windows.Forms.Button ButtonClearFilters;
    }
}