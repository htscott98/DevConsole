namespace DevConsole
{
    partial class FormTaskActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskActivity));
            this.LabelTaskName = new System.Windows.Forms.Label();
            this.RichTextBoxActivity = new System.Windows.Forms.RichTextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.FlowLayoutPanelTaskActivity = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelTaskName
            // 
            this.LabelTaskName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTaskName.Location = new System.Drawing.Point(12, 9);
            this.LabelTaskName.Name = "LabelTaskName";
            this.LabelTaskName.Size = new System.Drawing.Size(460, 42);
            this.LabelTaskName.TabIndex = 3;
            this.LabelTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RichTextBoxActivity
            // 
            this.RichTextBoxActivity.Location = new System.Drawing.Point(12, 54);
            this.RichTextBoxActivity.Name = "RichTextBoxActivity";
            this.RichTextBoxActivity.Size = new System.Drawing.Size(460, 131);
            this.RichTextBoxActivity.TabIndex = 4;
            this.RichTextBoxActivity.Text = "";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(366, 191);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(106, 35);
            this.ButtonSave.TabIndex = 21;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(254, 191);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(106, 35);
            this.ButtonCancel.TabIndex = 22;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FlowLayoutPanelTaskActivity
            // 
            this.FlowLayoutPanelTaskActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelTaskActivity.Location = new System.Drawing.Point(12, 232);
            this.FlowLayoutPanelTaskActivity.Name = "FlowLayoutPanelTaskActivity";
            this.FlowLayoutPanelTaskActivity.Size = new System.Drawing.Size(460, 217);
            this.FlowLayoutPanelTaskActivity.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Activity History";
            // 
            // FormTaskActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FlowLayoutPanelTaskActivity);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.RichTextBoxActivity);
            this.Controls.Add(this.LabelTaskName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FormTaskActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormTaskActivity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTaskName;
        private System.Windows.Forms.RichTextBox RichTextBoxActivity;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelTaskActivity;
        private System.Windows.Forms.Label label1;
    }
}