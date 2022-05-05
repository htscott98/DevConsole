namespace DevConsole
{
    partial class FormNewProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewProcess));
            this.TextBoxScript = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxScriptName = new System.Windows.Forms.TextBox();
            this.TextBoxScriptLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonSaveProcess = new System.Windows.Forms.Button();
            this.ButtonCancelProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxScript
            // 
            this.TextBoxScript.Location = new System.Drawing.Point(12, 28);
            this.TextBoxScript.Name = "TextBoxScript";
            this.TextBoxScript.Size = new System.Drawing.Size(460, 242);
            this.TextBoxScript.TabIndex = 0;
            this.TextBoxScript.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Script";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // TextBoxScriptName
            // 
            this.TextBoxScriptName.Location = new System.Drawing.Point(12, 292);
            this.TextBoxScriptName.Name = "TextBoxScriptName";
            this.TextBoxScriptName.Size = new System.Drawing.Size(460, 22);
            this.TextBoxScriptName.TabIndex = 3;
            // 
            // TextBoxScriptLocation
            // 
            this.TextBoxScriptLocation.Enabled = false;
            this.TextBoxScriptLocation.Location = new System.Drawing.Point(12, 336);
            this.TextBoxScriptLocation.Name = "TextBoxScriptLocation";
            this.TextBoxScriptLocation.Size = new System.Drawing.Size(460, 22);
            this.TextBoxScriptLocation.TabIndex = 5;
            this.TextBoxScriptLocation.Text = "C:\\Users\\htsco\\OneDrive\\DevProjects\\DevConsole\\DevConsole\\Scripts\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location";
            // 
            // ButtonSaveProcess
            // 
            this.ButtonSaveProcess.Location = new System.Drawing.Point(245, 414);
            this.ButtonSaveProcess.Name = "ButtonSaveProcess";
            this.ButtonSaveProcess.Size = new System.Drawing.Size(135, 35);
            this.ButtonSaveProcess.TabIndex = 23;
            this.ButtonSaveProcess.Text = "Save Process";
            this.ButtonSaveProcess.UseVisualStyleBackColor = true;
            // 
            // ButtonCancelProcess
            // 
            this.ButtonCancelProcess.Location = new System.Drawing.Point(104, 414);
            this.ButtonCancelProcess.Name = "ButtonCancelProcess";
            this.ButtonCancelProcess.Size = new System.Drawing.Size(135, 35);
            this.ButtonCancelProcess.TabIndex = 24;
            this.ButtonCancelProcess.Text = "Cancel Process";
            this.ButtonCancelProcess.UseVisualStyleBackColor = true;
            // 
            // FormNewProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.ButtonCancelProcess);
            this.Controls.Add(this.ButtonSaveProcess);
            this.Controls.Add(this.TextBoxScriptLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxScriptName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxScript);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FormNewProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBoxScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxScriptName;
        private System.Windows.Forms.TextBox TextBoxScriptLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonSaveProcess;
        private System.Windows.Forms.Button ButtonCancelProcess;
    }
}