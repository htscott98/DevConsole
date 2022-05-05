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
    public partial class FormDevTasks : Form
    {
        public FormDevTasks()
        {
            InitializeComponent();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            FormNewTasks f = new FormNewTasks();
            f.ShowDialog();
            FormDevTasks_Shown(null, null);
        }

        private void PopulateLists()
        {
            try
            {
                List<DevTaskLists> devTaskLists = DevTaskLists.GetListOfObjectsEnabled();

                foreach (DevTaskLists list in devTaskLists)
                {
                    FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                    layoutPanel.Margin = new Padding(0,0,0,0);
                    layoutPanel.Padding = new Padding(0);
                    int height = FlowLayoutPanelMain.Height;
                    layoutPanel.MinimumSize = new Size(FlowLayoutPanelMain.Width / 5, height);
                    layoutPanel.MaximumSize = new Size(FlowLayoutPanelMain.Width / 3, height);
                    layoutPanel.Size = new Size(FlowLayoutPanelMain.Width / devTaskLists.Count, height);
                    layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                    layoutPanel.HorizontalScroll.Visible = false;
                    layoutPanel.HorizontalScroll.Enabled = false;
                    layoutPanel.HorizontalScroll.Maximum = 0;
                    layoutPanel.AutoScroll = true;

                    FlowLayoutPanelMain.Controls.Add(layoutPanel);


                    PopulateTasks(list.ID.ToString(), list.Name, layoutPanel);


                }

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateTasks(string listID, string listName, FlowLayoutPanel layoutPanel)
        {
            try
            {
                List<DevTaskTasks> devTasks = DevTaskTasks.GetListOfObjectsByListID(listID);

                Label headerLabel = new Label();
                headerLabel.Font = new Font("Arial", 14, FontStyle.Bold);
                headerLabel.Padding = new Padding(0);
                headerLabel.Margin = new Padding(0, 4, 0, 4);
                int height = layoutPanel.Height;
                height = headerLabel.Height;
                headerLabel.BorderStyle = BorderStyle.None;
                headerLabel.Size = new Size(layoutPanel.Width - 2, height);
                

                layoutPanel.Controls.Add(headerLabel);

                int countTasks = 0;

                if (devTasks.Count == 0)
                {
                    headerLabel.Text = listName + " - 0";
                }

                foreach (DevTaskTasks task in devTasks)
                {

                    if (string.IsNullOrEmpty(GlobalCode.stringFilter) == false)
                    {

                        if (task.Name.Contains(GlobalCode.stringFilter) == false)
                        {
                            headerLabel.Text = listName + " - " + countTasks.ToString();
                            continue;
                        }

                    }


                    FlowLayoutPanel taskLayout = new FlowLayoutPanel();
                    taskLayout.Margin = new Padding(4,2,0,2);
                    taskLayout.Padding = new Padding(0);
                    taskLayout.BackColor = SystemColors.ControlLight;
                    taskLayout.BorderStyle = BorderStyle.FixedSingle;
                    taskLayout.Name = task.ID.ToString();
                    taskLayout.DoubleClick += EditTask;
                    height = taskLayout.Height;
                    taskLayout.MinimumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .90, 0, MidpointRounding.ToZero)), height);
                    taskLayout.MaximumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .90, 0, MidpointRounding.ToZero)), 0);
                    taskLayout.AutoSize = true;

                    countTasks++;

                    layoutPanel.Controls.Add(taskLayout);


                    FlowLayoutPanel labelLayout = new FlowLayoutPanel();
                    labelLayout.AutoSize = true;
                    labelLayout.Margin = new Padding(0);
                    labelLayout.Padding = new Padding(0);
                    labelLayout.BorderStyle = BorderStyle.None;
                    labelLayout.Name = task.ID.ToString();
                    labelLayout.DoubleClick += EditTask;
                    height = labelLayout.Height;
                    labelLayout.Size = new Size(taskLayout.Width, height);

                    taskLayout.Controls.Add(labelLayout);

                    List<DevTaskAttachedLabels> attachedLabels = DevTaskAttachedLabels.GetListOfObjectsByTaskID(task.ID.ToString());

                    if (attachedLabels.Count == 0)
                    {

                        Button button = new Button();
                        button.Text = "+";
                        button.Name = task.ID.ToString();
                        button.Size = new Size(50, 35);
                        button.Font = new Font(button.Font.FontFamily, 14, FontStyle.Bold);
                        button.Click += EditLabels;

                        labelLayout.Controls.Add(button);
                    }

                    bool keepTaskLayout = false;
                    bool noLabels = false;

                    if (attachedLabels.Count == 0)
                    {
                        noLabels = true;
                    }

                    foreach (DevTaskAttachedLabels attachedLabel in attachedLabels)
                    {
                        DevTaskLabels labelAdd = DevTaskLabels.GetObjectByID(attachedLabel.LabelID.ToString());

                        if (GlobalCode.labelFilters.Count > 0)
                        {
                            if (GlobalCode.labelFilters.Contains(labelAdd.ID.ToString()) == false)
                            {
                                continue;
                            }
                            else
                            {
                                keepTaskLayout = true;
                            }
                        }
                        else
                        {
                            keepTaskLayout = true;
                        }

                        Label label = new Label();
                        label.Text = labelAdd.Name;
                        label.Name = task.ID.ToString();
                        label.Margin = new Padding(2, 2, 0, 0);
                        label.Size = new Size(109, 35);
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.ForeColor = Color.FromName(labelAdd.TextColor);
                        label.BackColor = Color.FromName(labelAdd.BackColor);
                        label.Click += EditLabels;
                        labelLayout.Controls.Add(label);

                    }

                    if (keepTaskLayout == false && noLabels == false)
                    {
                        layoutPanel.Controls.Remove(taskLayout);
                        countTasks--;
                    }

                    if (GlobalCode.labelFilters.Count > 0 && noLabels == true)
                    {
                        layoutPanel.Controls.Remove(taskLayout);
                        countTasks--;
                    }

                    headerLabel.Text = listName + " - " + countTasks.ToString();

                    Label taskheaderLabel = new Label();
                    taskheaderLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                    taskheaderLabel.Text = task.Name;
                    taskheaderLabel.BorderStyle = BorderStyle.None;
                    height = taskheaderLabel.Height;
                    taskheaderLabel.Size = new Size(taskLayout.Width, height);
                    taskheaderLabel.Padding = new Padding(0);
                    taskheaderLabel.Margin = new Padding(0, 10, 0, 10);
                    taskheaderLabel.Name = task.ID.ToString();
                    taskheaderLabel.DoubleClick += EditTask;
                    taskheaderLabel.TextAlign = ContentAlignment.MiddleLeft;

                    taskLayout.Controls.Add(taskheaderLabel);

                    Button newActivityButton = new Button();
                    newActivityButton.Text = "New Activity";
                    newActivityButton.FlatAppearance.BorderSize = 0;
                    newActivityButton.FlatStyle = FlatStyle.Flat;
                    height = newActivityButton.Height;
                    newActivityButton.Size = new Size((taskLayout.Width / 3) - 1, height);
                    newActivityButton.Margin = new Padding(0);
                    newActivityButton.Padding = new Padding(0);
                    newActivityButton.ForeColor = Color.Blue;
                    newActivityButton.Name = task.ID.ToString();
                    newActivityButton.Click += AddActivity;

                    taskLayout.Controls.Add(newActivityButton);

                    Button moveListButton = new Button();
                    moveListButton.Text = "Move Lists";
                    moveListButton.FlatAppearance.BorderSize = 0;
                    moveListButton.FlatStyle = FlatStyle.Flat;
                    height = moveListButton.Height;
                    moveListButton.Size = new Size((taskLayout.Width / 3) - 1, height);
                    moveListButton.Margin = new Padding(0);
                    moveListButton.Padding = new Padding(0);
                    moveListButton.ForeColor = Color.DarkGreen;
                    moveListButton.Name = task.ID.ToString();
                    moveListButton.Click += MoveList;

                    taskLayout.Controls.Add(moveListButton);

                    Button deleteButton = new Button();
                    deleteButton.Text = "Delete Task";
                    deleteButton.FlatAppearance.BorderSize = 0;
                    deleteButton.FlatStyle = FlatStyle.Flat;
                    height = deleteButton.Height;
                    deleteButton.Size = new Size((taskLayout.Width / 3) - 1, height);
                    deleteButton.Margin = new Padding(0);
                    deleteButton.Padding = new Padding(0);
                    deleteButton.ForeColor = Color.Crimson;
                    deleteButton.Name = task.ID.ToString();
                    deleteButton.Click += DeleteTask;

                    taskLayout.Controls.Add(deleteButton);

                    

                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void MoveList(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if (control == null)
                {
                    return;
                }

                DevTaskTasks devTask = new DevTaskTasks();
                devTask = DevTaskTasks.GetObjectByID(control.Name);

                FormMoveTaskLists move = new FormMoveTaskLists();
                move.task = devTask;
                move.ShowDialog();

                FormDevTasks_Shown(null, null);


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void AddActivity(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if (control == null)
                {
                    return;
                }

                DevTaskTasks devTask = new DevTaskTasks();
                devTask = DevTaskTasks.GetObjectByID(control.Name);

                FormTaskActivity activity = new FormTaskActivity();
                activity.task = devTask;
                activity.ShowDialog();


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void DeleteTask(object sender, EventArgs e)
        {
            try
            {

                if (GlobalCode.ShowMSGBox("Are you sure you wish to delete this task?", MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Control control = (Control)sender;

                if (control == null)
                {
                    return;
                }

                DevTaskTasks devTask = new DevTaskTasks();
                devTask.ID = Convert.ToInt32(control.Name);

                if (devTask.DeleteRecord() == true)
                {

                    DevTaskAttachedLabels attachedLabels = new DevTaskAttachedLabels();
                    attachedLabels.TaskID = Convert.ToInt32(control.Name);
                    attachedLabels.DeleteRecordByTaskID();

                    FormDevTasks_Shown(null, null);
                }
                else
                {
                    GlobalCode.ShowMSGBox("Failed to delete task. Try again", MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void EditTask(object sender, EventArgs e)
        {
            try
            {
                Control sent = sender as Control;

                DevTaskTasks taskTask = DevTaskTasks.GetObjectByID(sent.Name);

                if (taskTask == null)
                {
                    return;
                }

                FormNewTasks f = new FormNewTasks();
                f.taskTask = taskTask;
                f.ShowDialog();
                FormDevTasks_Shown(null, null);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void EditLabels(object sender, EventArgs e)
        {
            try
            {
                Control sent = sender as Control;

                DevTaskTasks taskTask = DevTaskTasks.GetObjectByID(sent.Name);

                if (taskTask == null)
                {
                    return;
                }

                FormEditLabels f = new FormEditLabels();
                f.devTask = taskTask;
                f.ShowDialog();
                FormDevTasks_Shown(null, null);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void FormDevTasks_Shown(object sender, EventArgs e)
        {
            FlowLayoutPanelMain.Controls.Clear();
            
            int countFilters = GlobalCode.labelFilters.Count;

            if (string.IsNullOrEmpty(GlobalCode.stringFilter) == false)
            {
                countFilters++;
            }

            ButtonFilters.Text = "Filters (" + countFilters.ToString() + ")";

            if (countFilters > 0)
            {
                ButtonClearFilters.Visible = true;
            }
            else
            {
                ButtonClearFilters.Visible = false;
            }

            PopulateLists();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            FormDevTasks_Shown(null, null);
        }

        private void ButtonFilters_Click(object sender, EventArgs e)
        {
            FormTaskFilters f = new FormTaskFilters();
            f.ShowDialog();
            FormDevTasks_Shown(null, null);
        }

        private void ButtonClearFilters_Click(object sender, EventArgs e)
        {
            GlobalCode.labelFilters.Clear();
            GlobalCode.stringFilter = "";

            FormDevTasks_Shown(null, null);

        }
    }
}
