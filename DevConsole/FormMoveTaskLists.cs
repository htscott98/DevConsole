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
    public partial class FormMoveTaskLists : Form
    {

        public DevTaskTasks task;

        public FormMoveTaskLists()
        {
            InitializeComponent();
        }

        private void FormMoveTaskLists_Load(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                {
                    this.Close();
                }

                LabelTaskName.Text = task.Name;

                PopulateTaskListComboBox();

                DevTaskLists devTaskLists = new DevTaskLists();
                devTaskLists = DevTaskLists.GetObjectByID(task.TaskListID.ToString());
                ComboBoxTaskList.Text = devTaskLists.Name;

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateTaskListComboBox()
        {
            ComboBoxTaskList.Items.Clear();

            List<DevTaskLists> devTaskLists = DevTaskLists.GetListOfObjects();

            foreach (DevTaskLists taskList in devTaskLists)
            {
                ComboBoxTaskList.Items.Add(taskList);
            }

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                DevTaskLists devTaskLists = new DevTaskLists();
                devTaskLists = (DevTaskLists)ComboBoxTaskList.SelectedItem;
                task.TaskListID = devTaskLists.ID;

                if (task.UpdateTaskList() == true)
                {
                    this.Close();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to update task list", MessageBoxIcon.Error);
                    return;
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
    }
}
