using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{
    public partial class FormTaskActivity : Form
    {

        public DevTaskTasks task;

        public FormTaskActivity()
        {
            InitializeComponent();
        }

        private void FormTaskActivity_Load(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                {
                    this.Close();
                    return;
                }

                LabelTaskName.Text = task.Name;


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                {
                    return;
                }

                if (RichTextBoxActivity.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must enter new acitivity before saving", MessageBoxIcon.Warning);
                    return;
                }


                DevTaskActivity activity = new DevTaskActivity();
                activity.TaskID = task.ID;
                activity.Activity = RichTextBoxActivity.Text;
                activity.Timestamp = DateTime.Now;

                if (activity.InsertRecord() == true)
                {
                    GlobalCode.ShowMSGBox("Successfully saved new activity");
                    this.Close();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to save new activity", MessageBoxIcon.Error);
                    return;
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }
    }
}
