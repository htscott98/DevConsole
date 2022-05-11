using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            RefreshOldAndNewList();
        }

        private void PopulateLists(string listID = null)
        {
            try
            {

                if (listID == null)
                {
                    List<DevTaskLists> devTaskLists = DevTaskLists.GetListOfObjectsEnabled();

                    foreach (DevTaskLists list in devTaskLists)
                    {
                        FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                        layoutPanel.Margin = new Padding(0, 0, 0, 0);
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
                        layoutPanel.AllowDrop = true;
                        layoutPanel.Name = list.ID.ToString();
                        layoutPanel.DragOver += LayoutPanel_DragOver;
                        layoutPanel.DragEnter += LayoutPanel_DragEnter;
                        layoutPanel.DragDrop += LayoutPanel_DragDrop;
                        layoutPanel.DragLeave += LayoutPanel_DragLeave;

                        FlowLayoutPanelMain.Controls.Add(layoutPanel);


                        PopulateTasks(list.ID.ToString(), list.Name, layoutPanel);


                    }

                }
                else
                {
                    DevTaskLists devTaskLists = DevTaskLists.GetObjectByID(listID);

                    Control[] control = FlowLayoutPanelMain.Controls.Find(listID, false);

                    FlowLayoutPanel layoutPanel = null;

                    if (control.Length == 1)
                    {
                        layoutPanel = (FlowLayoutPanel)control[0];
                    }

                    PopulateTasks(devTaskLists.ID.ToString(), devTaskLists.Name, layoutPanel);

                }



                

                

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void LayoutPanel_DragLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = SystemColors.Control;
        }

        private void LayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                MyWrapper wrapper = (MyWrapper)e.Data.GetData(typeof(MyWrapper));

                Control list = sender as Control;
                string listID = list.Name;

                if (listID == "Garbage")
                {
                    GlobalCode.newList = listID;
                    DeleteTask(wrapper.Control, null);
                    list.BackColor = SystemColors.Control;
                }
                else
                {

                    list.Controls.Add(wrapper.Control);

                    Point p = list.PointToClient(new Point(e.X, e.Y));
                    var item = list.GetChildAtPoint(p);
                    var index = list.Controls.GetChildIndex(item, false);

                    if (index <= 0)
                    {
                        index = 1;
                    }

                    list.Controls.SetChildIndex(wrapper.Control, index);

                    foreach (Control control in list.Controls)
                    {
                        if (list.Controls.IndexOf(control) == 0)
                        {
                            continue;
                        }

                        DevTaskTasks taskPosition = new DevTaskTasks();
                        taskPosition.ID = Convert.ToInt32(control.Name);
                        taskPosition.DisplayOrder = list.Controls.IndexOf(control).ToString();
                        taskPosition.UpdateDisplayOrder();
                    }


                    string taskID = wrapper.Control.Name;

                    DevTaskTasks devTaskTasks = new DevTaskTasks();
                    devTaskTasks.ID = Convert.ToInt32(taskID);
                    devTaskTasks.TaskListID = Convert.ToInt32(listID);

                    if (devTaskTasks.UpdateTaskList() == true)
                    {
                        GlobalCode.newList = listID;

                        RefreshOldAndNewList();
                    }

                }


                



            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void LayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = Color.LightBlue;
            e.Effect = DragDropEffects.Copy;
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
                    taskLayout.MouseDown += TaskLayout_MouseDown;
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
                    height = labelLayout.Height;
                    labelLayout.Size = new Size(taskLayout.Width, height);
                    labelLayout.MouseDown += ParentDrag;

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
                    taskheaderLabel.TextAlign = ContentAlignment.MiddleLeft;
                    taskheaderLabel.MouseDown += ParentDrag;

                    taskLayout.Controls.Add(taskheaderLabel);

                    Button newActivityButton = new Button();
                    newActivityButton.Text = "New Activity";
                    newActivityButton.FlatAppearance.BorderSize = 0;
                    newActivityButton.FlatStyle = FlatStyle.Flat;
                    height = newActivityButton.Height;
                    newActivityButton.Size = new Size((taskLayout.Width / 2) - 1, height);
                    newActivityButton.Margin = new Padding(0);
                    newActivityButton.Padding = new Padding(0);
                    newActivityButton.ForeColor = Color.Blue;
                    newActivityButton.Name = task.ID.ToString();
                    newActivityButton.Click += AddActivity;

                    taskLayout.Controls.Add(newActivityButton);

                    Button editTaskButton = new Button();
                    editTaskButton.Text = "Edit Task";
                    editTaskButton.FlatAppearance.BorderSize = 0;
                    editTaskButton.FlatStyle = FlatStyle.Flat;
                    height = editTaskButton.Height;
                    editTaskButton.Size = new Size((taskLayout.Width / 2) - 1, height);
                    editTaskButton.Margin = new Padding(0);
                    editTaskButton.Padding = new Padding(0);
                    editTaskButton.ForeColor = Color.Green;
                    editTaskButton.Name = task.ID.ToString();
                    editTaskButton.Click += EditTask;

                    taskLayout.Controls.Add(editTaskButton);



                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ParentDrag(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            GlobalCode.oldList = control.Parent.Parent.Name;
            control.DoDragDrop(new MyWrapper(control.Parent), DragDropEffects.All);
        }

        private void TaskLayout_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            GlobalCode.oldList = control.Parent.Name;
            control.DoDragDrop(new MyWrapper(control), DragDropEffects.All);
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

                    RefreshOldAndNewList();
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
                GlobalCode.oldList = taskTask.TaskListID.ToString();
                f.ShowDialog();
                RefreshOldAndNewList();

                //FormDevTasks_Shown(null, null);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void RefreshOldAndNewList()
        {

            try
            {

                if (GlobalCode.oldList == null && GlobalCode.newList == null)
                {
                    FormDevTasks_Shown(null, null);
                }

                if (GlobalCode.oldList == GlobalCode.newList)
                {
                    GlobalCode.oldList = null;
                }

                if (string.IsNullOrEmpty(GlobalCode.oldList) == false) {

                    Control[] oldListControls = FlowLayoutPanelMain.Controls.Find(GlobalCode.oldList, false);

                    if (oldListControls.Length == 1)
                    {
                        oldListControls[0].Controls.Clear();
                        oldListControls[0].BackColor = SystemColors.Control;
                        PopulateLists(oldListControls[0].Name);
                    }

                }


                if (string.IsNullOrEmpty(GlobalCode.newList) == false) {

                    Control[] newListControls = FlowLayoutPanelMain.Controls.Find(GlobalCode.newList, false);

                    if (newListControls.Length == 1)
                    {
                        newListControls[0].Controls.Clear();
                        newListControls[0].BackColor = SystemColors.Control;
                        PopulateLists(newListControls[0].Name);
                    }

                }

                GlobalCode.oldList = null;
                GlobalCode.newList = null;

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
                GlobalCode.oldList = taskTask.TaskListID.ToString();
                f.ShowDialog();
                RefreshOldAndNewList();

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

        internal partial class MyWrapper
        {
            private Control _control;

            public MyWrapper(Control control)
            {
                _control = control;
            }

            public Control Control
            {
                get
                {
                    return _control;
                }
            }
        }


    }
}
