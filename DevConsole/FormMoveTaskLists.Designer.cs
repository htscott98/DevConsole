namespace DevConsole
{
    partial class FormMoveTaskLists
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMoveTaskLists));
            this.ComboBoxTaskList = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelTaskName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComboBoxTaskList
            // 
            this.ComboBoxTaskList.FormattingEnabled = true;
            this.ComboBoxTaskList.Location = new System.Drawing.Point(12, 76);
            this.ComboBoxTaskList.Name = "ComboBoxTaskList";
            this.ComboBoxTaskList.Size = new System.Drawing.Size(260, 25);
            this.ComboBoxTaskList.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "List";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(31, 107);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(109, 35);
            this.ButtonCancel.TabIndex = 25;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(146, 107);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(106, 35);
            this.ButtonSave.TabIndex = 24;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelTaskName
            // 
            this.LabelTaskName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTaskName.Location = new System.Drawing.Point(12, 9);
            this.LabelTaskName.Name = "LabelTaskName";
            this.LabelTaskName.Size = new System.Drawing.Size(260, 47);
            this.LabelTaskName.TabIndex = 26;
            this.LabelTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMoveTaskLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.LabelTaskName);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ComboBoxTaskList);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormMoveTaskLists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormMoveTaskLists_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxTaskList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label LabelTaskName;
    }
}