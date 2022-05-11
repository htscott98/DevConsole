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
                PopulateActivityForTask();

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateActivityForTask()
        {
            try
            {
                List<DevTaskActivity> devTaskActivity = DevTaskActivity.GetListOfObjectsByTaskID(task.ID.ToString());

                foreach (DevTaskActivity activity in devTaskActivity)
                {
                    Label dateLabel = new Label();
                    dateLabel.Margin = new Padding(0);
                    dateLabel.Padding = new Padding(0);
                    dateLabel.Width = Convert.ToInt32(Math.Round(FlowLayoutPanelTaskActivity.Width * .90, 0, MidpointRounding.AwayFromZero));
                    dateLabel.Text = activity.Timestamp.ToString();
                    dateLabel.Font = new Font("Arial", 12, FontStyle.Bold);

                    FlowLayoutPanelTaskActivity.Controls.Add(dateLabel);

                    Label activityLabel = new Label();
                    activityLabel.Margin = new Padding(0);
                    activityLabel.Padding = new Padding(0);
                    activityLabel.Width = Convert.ToInt32(Math.Round(FlowLayoutPanelTaskActivity.Width * .90, 0, MidpointRounding.AwayFromZero));
                    activityLabel.Text = activity.Activity;

                    FlowLayoutPanelTaskActivity.Controls.Add(activityLabel);

                }


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
