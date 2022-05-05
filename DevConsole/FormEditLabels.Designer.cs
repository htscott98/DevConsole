namespace DevConsole
{
    partial class FormEditLabels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditLabels));
            this.FlowLayoutPanelAllLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowLayoutPanelSelectedLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelTaskName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FlowLayoutPanelAllLabels
            // 
            this.FlowLayoutPanelAllLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelAllLabels.Location = new System.Drawing.Point(12, 54);
            this.FlowLayoutPanelAllLabels.Name = "FlowLayoutPanelAllLabels";
            this.FlowLayoutPanelAllLabels.Size = new System.Drawing.Size(170, 345);
            this.FlowLayoutPanelAllLabels.TabIndex = 0;
            // 
            // FlowLayoutPanelSelectedLabels
            // 
            this.FlowLayoutPanelSelectedLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelSelectedLabels.Location = new System.Drawing.Point(202, 54);
            this.FlowLayoutPanelSelectedLabels.Name = "FlowLayoutPanelSelectedLabels";
            this.FlowLayoutPanelSelectedLabels.Size = new System.Drawing.Size(170, 345);
            this.FlowLayoutPanelSelectedLabels.TabIndex = 1;
            // 
            // LabelTaskName
            // 
            this.LabelTaskName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTaskName.Location = new System.Drawing.Point(12, 9);
            this.LabelTaskName.Name = "LabelTaskName";
            this.LabelTaskName.Size = new System.Drawing.Size(360, 42);
            this.LabelTaskName.TabIndex = 2;
            this.LabelTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEditLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.LabelTaskName);
            this.Controls.Add(this.FlowLayoutPanelSelectedLabels);
            this.Controls.Add(this.FlowLayoutPanelAllLabels);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 450);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "FormEditLabels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Load += new System.EventHandler(this.FormEditLabels_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelAllLabels;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelSelectedLabels;
        private System.Windows.Forms.Label LabelTaskName;
    }
}