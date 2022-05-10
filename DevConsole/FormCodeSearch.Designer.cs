namespace DevConsole
{
    partial class FormCodeSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCodeSearch));
            this.ComboBoxSoftware = new System.Windows.Forms.ComboBox();
            this.ListBoxForms = new System.Windows.Forms.ListBox();
            this.TextBoxCode = new System.Windows.Forms.RichTextBox();
            this.ButtonAllCode = new System.Windows.Forms.Button();
            this.TextBoxFind = new System.Windows.Forms.TextBox();
            this.ButtonFindCode = new System.Windows.Forms.Button();
            this.ButtonLastInstance = new System.Windows.Forms.Button();
            this.ButtonNextInstance = new System.Windows.Forms.Button();
            this.LabelListCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComboBoxSoftware
            // 
            this.ComboBoxSoftware.FormattingEnabled = true;
            this.ComboBoxSoftware.Location = new System.Drawing.Point(12, 12);
            this.ComboBoxSoftware.Name = "ComboBoxSoftware";
            this.ComboBoxSoftware.Size = new System.Drawing.Size(174, 25);
            this.ComboBoxSoftware.TabIndex = 2;
            this.ComboBoxSoftware.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSoftware_SelectedIndexChanged);
            // 
            // ListBoxForms
            // 
            this.ListBoxForms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxForms.FormattingEnabled = true;
            this.ListBoxForms.IntegralHeight = false;
            this.ListBoxForms.ItemHeight = 17;
            this.ListBoxForms.Location = new System.Drawing.Point(12, 43);
            this.ListBoxForms.Name = "ListBoxForms";
            this.ListBoxForms.Size = new System.Drawing.Size(253, 406);
            this.ListBoxForms.TabIndex = 3;
            this.ListBoxForms.SelectedIndexChanged += new System.EventHandler(this.ListBoxForms_SelectedIndexChanged);
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxCode.Location = new System.Drawing.Point(271, 43);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.ReadOnly = true;
            this.TextBoxCode.Size = new System.Drawing.Size(501, 406);
            this.TextBoxCode.TabIndex = 4;
            this.TextBoxCode.Text = "";
            // 
            // ButtonAllCode
            // 
            this.ButtonAllCode.Location = new System.Drawing.Point(192, 11);
            this.ButtonAllCode.Name = "ButtonAllCode";
            this.ButtonAllCode.Size = new System.Drawing.Size(73, 25);
            this.ButtonAllCode.TabIndex = 5;
            this.ButtonAllCode.Text = "All Code";
            this.ButtonAllCode.UseVisualStyleBackColor = true;
            this.ButtonAllCode.Click += new System.EventHandler(this.ButtonAllCode_Click);
            // 
            // TextBoxFind
            // 
            this.TextBoxFind.Location = new System.Drawing.Point(271, 12);
            this.TextBoxFind.Name = "TextBoxFind";
            this.TextBoxFind.Size = new System.Drawing.Size(185, 25);
            this.TextBoxFind.TabIndex = 6;
            // 
            // ButtonFindCode
            // 
            this.ButtonFindCode.Location = new System.Drawing.Point(462, 12);
            this.ButtonFindCode.Name = "ButtonFindCode";
            this.ButtonFindCode.Size = new System.Drawing.Size(71, 25);
            this.ButtonFindCode.TabIndex = 7;
            this.ButtonFindCode.Text = "Find";
            this.ButtonFindCode.UseVisualStyleBackColor = true;
            this.ButtonFindCode.Click += new System.EventHandler(this.ButtonFindCode_Click);
            // 
            // ButtonLastInstance
            // 
            this.ButtonLastInstance.Location = new System.Drawing.Point(539, 12);
            this.ButtonLastInstance.Name = "ButtonLastInstance";
            this.ButtonLastInstance.Size = new System.Drawing.Size(73, 25);
            this.ButtonLastInstance.TabIndex = 8;
            this.ButtonLastInstance.Text = "<<<";
            this.ButtonLastInstance.UseVisualStyleBackColor = true;
            this.ButtonLastInstance.Click += new System.EventHandler(this.ButtonLastInstance_Click);
            // 
            // ButtonNextInstance
            // 
            this.ButtonNextInstance.Location = new System.Drawing.Point(618, 12);
            this.ButtonNextInstance.Name = "ButtonNextInstance";
            this.ButtonNextInstance.Size = new System.Drawing.Size(73, 25);
            this.ButtonNextInstance.TabIndex = 9;
            this.ButtonNextInstance.Text = ">>>";
            this.ButtonNextInstance.UseVisualStyleBackColor = true;
            this.ButtonNextInstance.Click += new System.EventHandler(this.ButtonNextInstance_Click);
            // 
            // LabelListCount
            // 
            this.LabelListCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelListCount.Location = new System.Drawing.Point(697, 12);
            this.LabelListCount.Name = "LabelListCount";
            this.LabelListCount.Size = new System.Drawing.Size(75, 24);
            this.LabelListCount.TabIndex = 10;
            this.LabelListCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCodeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.LabelListCount);
            this.Controls.Add(this.ButtonNextInstance);
            this.Controls.Add(this.ButtonLastInstance);
            this.Controls.Add(this.ButtonFindCode);
            this.Controls.Add(this.TextBoxFind);
            this.Controls.Add(this.ButtonAllCode);
            this.Controls.Add(this.TextBoxCode);
            this.Controls.Add(this.ListBoxForms);
            this.Controls.Add(this.ComboBoxSoftware);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormCodeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCodeSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ComboBoxSoftware;
        private System.Windows.Forms.ListBox ListBoxForms;
        private System.Windows.Forms.RichTextBox TextBoxCode;
        private System.Windows.Forms.Button ButtonAllCode;
        private System.Windows.Forms.TextBox TextBoxFind;
        private System.Windows.Forms.Button ButtonFindCode;
        private System.Windows.Forms.Button ButtonLastInstance;
        private System.Windows.Forms.Button ButtonNextInstance;
        private System.Windows.Forms.Label LabelListCount;
    }
}