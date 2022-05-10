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
            this.TextBoxCode = new System.Windows.Forms.RichTextBox();
            this.ComboBoxSoftware = new System.Windows.Forms.ComboBox();
            this.ListBoxForms = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxCode.Location = new System.Drawing.Point(271, 12);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.ReadOnly = true;
            this.TextBoxCode.Size = new System.Drawing.Size(501, 437);
            this.TextBoxCode.TabIndex = 1;
            this.TextBoxCode.Text = "";
            // 
            // ComboBoxSoftware
            // 
            this.ComboBoxSoftware.FormattingEnabled = true;
            this.ComboBoxSoftware.Location = new System.Drawing.Point(12, 12);
            this.ComboBoxSoftware.Name = "ComboBoxSoftware";
            this.ComboBoxSoftware.Size = new System.Drawing.Size(253, 25);
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
            // FormCodeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ListBoxForms);
            this.Controls.Add(this.ComboBoxSoftware);
            this.Controls.Add(this.TextBoxCode);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormCodeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCodeSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox TextBoxCode;
        private System.Windows.Forms.ComboBox ComboBoxSoftware;
        private System.Windows.Forms.ListBox ListBoxForms;
    }
}