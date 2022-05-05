namespace DevConsole
{
    partial class FormTaskFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskFilters));
            this.FlowLayoutPanelSelectedLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowLayoutPanelAllLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonClearFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FlowLayoutPanelSelectedLabels
            // 
            this.FlowLayoutPanelSelectedLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelSelectedLabels.Location = new System.Drawing.Point(188, 77);
            this.FlowLayoutPanelSelectedLabels.Name = "FlowLayoutPanelSelectedLabels";
            this.FlowLayoutPanelSelectedLabels.Size = new System.Drawing.Size(170, 331);
            this.FlowLayoutPanelSelectedLabels.TabIndex = 3;
            // 
            // FlowLayoutPanelAllLabels
            // 
            this.FlowLayoutPanelAllLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelAllLabels.Location = new System.Drawing.Point(12, 77);
            this.FlowLayoutPanelAllLabels.Name = "FlowLayoutPanelAllLabels";
            this.FlowLayoutPanelAllLabels.Size = new System.Drawing.Size(170, 331);
            this.FlowLayoutPanelAllLabels.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "All Labels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Label Filters";
            // 
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(12, 29);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(346, 25);
            this.TextBoxFilter.TabIndex = 8;
            this.TextBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Text";
            // 
            // ButtonClearFilters
            // 
            this.ButtonClearFilters.Location = new System.Drawing.Point(12, 414);
            this.ButtonClearFilters.Name = "ButtonClearFilters";
            this.ButtonClearFilters.Size = new System.Drawing.Size(345, 35);
            this.ButtonClearFilters.TabIndex = 14;
            this.ButtonClearFilters.Text = "Clear All Filters";
            this.ButtonClearFilters.UseVisualStyleBackColor = true;
            this.ButtonClearFilters.Click += new System.EventHandler(this.ButtonClearFilters_Click);
            // 
            // FormTaskFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 461);
            this.Controls.Add(this.ButtonClearFilters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FlowLayoutPanelSelectedLabels);
            this.Controls.Add(this.FlowLayoutPanelAllLabels);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTaskFilters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormTaskFilters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelSelectedLabels;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelAllLabels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonClearFilters;
    }
}