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
    public partial class FormNewTasks : Form
    {
        public DevTaskTasks taskTask;
        public DevTaskLists taskList;
        public DevTaskLabels taskLabel;


        public FormNewTasks()
        {
            InitializeComponent();
        }

        #region Main

        private void FormNewTasks_Shown(object sender, EventArgs e)
        {
            DisableTaskControls();
            DisableListControls();
            DisableLabelControls();
            PopulateGrids();
            PopulateTaskListComboBox();
            PopulateLabelColorBoxes();
            DataGridViewLists.ClearSelection();
            DataGridViewTasks.ClearSelection();


            if (taskTask != null)
            {
                PopulateTaskInfo();
            }

        }

        private void PopulateGrids()
        {
            //Populating Tasks start
            DataTable dtTasks = DevTaskTasks.GetDataTable();
            DataGridViewTasks.DataSource = dtTasks;
            SetTaskDisplayProperties();
            //Populating Tasks stop

            //Populating Lists start
            DataTable dt = DevTaskLists.GetDataTable();
            DataGridViewLists.DataSource = dt;
            SetListDisplayProperties();

            if (dt.Rows.Count == 0)
            {
                TabControl.TabPages.Remove(TabTasks);
            }
            else
            {

                if (!TabControl.TabPages.Contains(TabTasks))
                {
                    TabControl.TabPages.Add(TabTasks);
                }
            }

            //Populating Lists stop

            //Populating Labels start
            FlowLayoutPanelLabels.Controls.Clear();
            List<DevTaskLabels> listLabels = DevTaskLabels.GetListOfObjects();
            foreach (DevTaskLabels listLabel in listLabels)
            {
                Label label = new Label();
                label.Text = listLabel.Name;
                label.Name = listLabel.ID.ToString();
                label.Margin = new Padding(2, 2, 0, 0);
                label.Size = new Size(109, 35);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.ForeColor = Color.FromName(listLabel.TextColor);
                label.BackColor = Color.FromName(listLabel.BackColor);
                label.Click += Label_Click;
                FlowLayoutPanelLabels.Controls.Add(label);
            }
            //Populating Labels stop


        }

        #endregion

        #region Tasks

        private void LinkNewTaskActivity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (taskTask == null)
            {
                return;
            }

            FormTaskActivity f = new FormTaskActivity();
            f.task = taskTask;
            f.ShowDialog();
            FormNewTasks_Shown(null, null);
        }

        private void PopulateLabelsForTask()
        {
            FlowLayoutPanelTaskLabels.Controls.Clear();

            Button button = new Button();
            button.Text = "+";
            button.Size = new Size(50,35);
            button.Font = new Font(button.Font.FontFamily, 14, FontStyle.Bold);
            button.Click += Button_Click;
            FlowLayoutPanelTaskLabels.Controls.Add(button);


            List<DevTaskAttachedLabels> attachedLabels = DevTaskAttachedLabels.GetListOfObjectsByTaskID(taskTask.ID.ToString());

            foreach (DevTaskAttachedLabels attachedLabel in attachedLabels)
            {
                DevTaskLabels labelAdd = DevTaskLabels.GetObjectByID(attachedLabel.LabelID.ToString());

                Label label = new Label();
                label.Text = labelAdd.Name;
                label.Name = labelAdd.ID.ToString();
                label.Margin = new Padding(2, 2, 0, 0);
                label.Size = new Size(109, 35);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.ForeColor = Color.FromName(labelAdd.TextColor);
                label.BackColor = Color.FromName(labelAdd.BackColor);
                label.Click += Button_Click;
                FlowLayoutPanelTaskLabels.Controls.Add(label);

            }


        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskTask == null)
                {
                    return;
                }

                FormEditLabels f = new FormEditLabels();
                f.devTask = taskTask;
                f.ShowDialog();
                PopulateLabelsForTask();

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void DataGridViewTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewTasks.SelectedRows.Count == 0)
                {
                    return;
                }

                string taskID = DataGridViewTasks.SelectedRows[0].Cells["ID"].Value.ToString();


                taskTask = DevTaskTasks.GetObjectByID(taskID);

                if (taskTask != null)
                {

                    PopulateTaskInfo();

                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateTaskInfo()
        {
            if (taskTask == null)
            {
                return;
            }


            DisableTaskControls();
            EnableTaskControls();
            TextBoxTaskName.Text = taskTask.Name;
            DevTaskLists devTaskLists = new DevTaskLists();
            devTaskLists = DevTaskLists.GetObjectByID(taskTask.TaskListID.ToString());
            ComboBoxTaskList.Text = devTaskLists.Name;
            TextBoxTaskDisplayOrder.Text = taskTask.DisplayOrder;
            CheckBoxTaskEnabled.Checked = taskTask.Enabled;
            TextBoxTaskDescription.Text = taskTask.Description;
            PopulateLabelsForTask();
            PopulateActivityForTask();
        }

        private void PopulateActivityForTask()
        {
            try
            {
                List<DevTaskActivity> devTaskActivity = DevTaskActivity.GetListOfObjectsByTaskID(taskTask.ID.ToString());

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

        private void ButtonDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskTask == null)
                {
                    return;
                }

                DevTaskTasks devTask = new DevTaskTasks();
                devTask.ID = taskTask.ID;

                if (devTask.DeleteRecord() == true)
                {

                    DevTaskAttachedLabels attachedLabels = new DevTaskAttachedLabels();
                    attachedLabels.TaskID = taskTask.ID;
                    attachedLabels.DeleteRecordByTaskID();

                    GlobalCode.ShowMSGBox("Successfully deleted task");
                    taskTask = null;
                    FormNewTasks_Shown(null, null);
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

        private void DataGridViewTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewTasks.ClearSelection();
        }

        private void ButtonNewTask_Click(object sender, EventArgs e)
        {
            DisableTaskControls();
            EnableTaskControls();
            TextBoxTaskName.Focus();
            ButtonDeleteTask.Enabled = false;
            FlowLayoutPanelTaskActivity.Enabled = false;

            taskTask = null;
        }

        private void ButtonSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxTaskName.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must enter a task name before saving", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                    return;
                }

                if (ComboBoxTaskList.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must select a task list before saving", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                    return;
                }


                DevTaskTasks devTask = new DevTaskTasks();

                if (taskTask != null)
                {
                    devTask.ID = taskTask.ID;
                }


                devTask.Name = TextBoxTaskName.Text;
                devTask.DisplayOrder = TextBoxTaskDisplayOrder.Text;
                DevTaskLists devTaskLists = new DevTaskLists();
                devTaskLists = (DevTaskLists)ComboBoxTaskList.SelectedItem;
                devTask.TaskListID = devTaskLists.ID;
                devTask.Enabled = CheckBoxTaskEnabled.Checked;
                devTask.Description = TextBoxTaskDescription.Text;


                if (taskTask != null)
                {
                    if (devTask.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully updated task");
                        taskTask = null;
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to update task. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (devTask.InsertRecord() == true)
                    {
                        DevTaskActivity devTaskActivity = new DevTaskActivity();
                        GlobalCode.ShowMSGBox("Successfully added new task");
                        taskTask = null;
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to add new task. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }



            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                GlobalCode.ShowMSGBox("An unexpected error occurred. Try again");
            }
        }

        private void PopulateTaskListComboBox()
        {
            ComboBoxTaskList.Items.Clear();

            List<DevTaskLists> devTaskLists = DevTaskLists.GetListOfObjects();

            ComboBoxTaskList.Items.Add("");

            foreach (DevTaskLists taskList in devTaskLists)
            {
                ComboBoxTaskList.Items.Add(taskList);
            }

        }

        private void SetTaskDisplayProperties()
        {
            DataGridViewTasks.Columns["ID"].Visible = false;
            DataGridViewTasks.Columns["TaskListID"].Visible = false;
            DataGridViewTasks.Columns["Description"].Visible = false;
            DataGridViewTasks.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewTasks.AllowUserToAddRows = false;
            DataGridViewTasks.AllowUserToDeleteRows = false;
            DataGridViewTasks.AllowUserToResizeColumns = false;
            DataGridViewTasks.AllowUserToResizeRows = false;
            DataGridViewTasks.AllowUserToOrderColumns = false;
            DataGridViewTasks.MultiSelect = true;
            DataGridViewTasks.ReadOnly = true;
            DataGridViewTasks.RowHeadersVisible = false;
            DataGridViewTasks.AllowUserToResizeColumns = true;
            DataGridViewTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisableTaskControls()
        {
            FlowLayoutPanelTaskLabels.Enabled = false;
            FlowLayoutPanelTaskLabels.Controls.Clear();
            TextBoxTaskName.Enabled = false;
            TextBoxTaskName.Text = "";
            TextBoxTaskDisplayOrder.Enabled = false;
            TextBoxTaskDisplayOrder.Text = "";
            TextBoxTaskDescription.Text = "";
            TextBoxTaskDescription.Enabled = false;
            ComboBoxTaskList.Enabled = false;
            ComboBoxTaskList.Text = "";
            CheckBoxTaskEnabled.Checked = false;
            CheckBoxTaskEnabled.Enabled = false;
            FlowLayoutPanelTaskActivity.Enabled = false;
            FlowLayoutPanelTaskActivity.Controls.Clear();
            ButtonSaveTask.Enabled = false;
            ButtonCancelTask.Enabled = false;
            ButtonDeleteTask.Enabled = false;
        }

        private void EnableTaskControls()
        {
            FlowLayoutPanelTaskLabels.Enabled = true;
            TextBoxTaskName.Enabled = true;
            TextBoxTaskDisplayOrder.Enabled = true;
            TextBoxTaskDescription.Enabled = true;
            ComboBoxTaskList.Enabled = true;
            CheckBoxTaskEnabled.Checked = true;
            CheckBoxTaskEnabled.Enabled = true;
            FlowLayoutPanelTaskActivity.Enabled = true;
            ButtonSaveTask.Enabled = true;
            ButtonCancelTask.Enabled = true;
            ButtonDeleteTask.Enabled = true;
        }

        private void ButtonCancelTask_Click(object sender, EventArgs e)
        {
            DisableTaskControls();
            DataGridViewTasks_DataBindingComplete(null, null);
            taskTask = null;
        }


        #endregion

        #region Lists
        private void DataGridViewLists_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewLists.ClearSelection();
        }
        private void ButtonSaveList_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxListName.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must enter a list name before saving", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                    return;
                }


                DevTaskLists devTaskLists = new DevTaskLists();

                if (taskList != null)
                {
                    devTaskLists.ID = taskList.ID;
                }

                devTaskLists.Name = TextBoxListName.Text;
                devTaskLists.DisplayOrder = TextBoxListDisplayOrder.Text;
                devTaskLists.Enabled = CheckBoxListEnabled.Checked;


                if (taskList != null)
                {
                    if (devTaskLists.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully updated list");
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to update list. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (devTaskLists.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully added new list");
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to add new list. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }


                taskList = null;


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                GlobalCode.ShowMSGBox("An unexpected error occurred. Try again");
            }
        }
        private void DisableListControls()
        {
            TextBoxListName.Text = "";
            TextBoxListName.Enabled = false;
            TextBoxListDisplayOrder.Text = "";
            TextBoxListDisplayOrder.Enabled = false;
            CheckBoxListEnabled.Checked = false;
            CheckBoxListEnabled.Enabled = false;
            ButtonSaveList.Enabled = false;
            ButtonCancelList.Enabled = false;
            ButtonDeleteList.Enabled = false;
        }

        private void EnableListControls()
        {
            TextBoxListName.Enabled = true;
            TextBoxListDisplayOrder.Enabled = true;
            CheckBoxListEnabled.Enabled = true;
            CheckBoxListEnabled.Checked = true;
            ButtonSaveList.Enabled = true;
            ButtonCancelList.Enabled= true;
            ButtonDeleteList.Enabled= true;
        }
        private void SetListDisplayProperties()
        {
            DataGridViewLists.Columns["ID"].Visible = false;
            DataGridViewLists.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewLists.AllowUserToAddRows = false;
            DataGridViewLists.AllowUserToDeleteRows = false;
            DataGridViewLists.AllowUserToResizeColumns = false;
            DataGridViewLists.AllowUserToResizeRows = false;
            DataGridViewLists.AllowUserToOrderColumns = false;
            DataGridViewLists.MultiSelect = true;
            DataGridViewLists.ReadOnly = true;
            DataGridViewLists.RowHeadersVisible = false;
            DataGridViewLists.AllowUserToResizeColumns = true;
            DataGridViewLists.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewLists.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ButtonNewList_Click(object sender, EventArgs e)
        {
            DisableListControls();
            EnableListControls();
            TextBoxListName.Focus();
            ButtonDeleteList.Enabled = false;

            taskList = null;

        }
        private void DataGridViewLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewLists.SelectedRows.Count == 0)
                {
                    return;
                }

                string listID = DataGridViewLists.SelectedRows[0].Cells["ID"].Value.ToString();


                taskList = DevTaskLists.GetObjectByID(listID);

                if (taskList != null)
                {
                    DisableListControls();
                    EnableListControls();
                    TextBoxListName.Text = taskList.Name;
                    TextBoxListDisplayOrder.Text = taskList.DisplayOrder;
                    CheckBoxListEnabled.Checked = taskList.Enabled;

                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }
        private void ButtonCancelList_Click(object sender, EventArgs e)
        {
            DisableListControls();
            taskList = null;
            DataGridViewLists_DataBindingComplete(null, null);
        }

        private void ButtonDeleteList_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskList == null)
                {
                    return;
                }

                DevTaskLists devTaskLists = new DevTaskLists();
                devTaskLists.ID = taskList.ID;

                if (devTaskLists.DeleteRecord() == true)
                {

                    DevTaskTasks devTaskTasks = new DevTaskTasks();
                    devTaskTasks.TaskListID = taskList.ID;
                    devTaskTasks.DeleteRecordByTaskListID();

                    GlobalCode.ShowMSGBox("Successfully deleted list");
                    FormNewTasks_Shown(null, null);
                }
                else
                {
                    GlobalCode.ShowMSGBox("Failed to delete list. Try again", MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }


        #endregion

        #region Labels

        private void Label_Click(object sender, EventArgs e)
        {
            try
            {

                var selectedLabel = sender as Label;

                string labelID = selectedLabel.Name;

                taskLabel = DevTaskLabels.GetObjectByID(labelID);

                if (taskLabel != null)
                {
                    EnableLabelControls();
                    TextBoxLabelName.Text = taskLabel.Name;
                    TextBoxLabelDisplayOrder.Text = taskLabel.DisplayOrder;
                    ComboBoxLabelBackColor.Text = taskLabel.BackColor;
                    ComboBoxLabelTextColor.Text = taskLabel.TextColor;
                    CheckBoxLabelEnabled.Checked = taskLabel.Enabled;
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }



        }

        public void DisableLabelControls()
        {
            TextBoxLabelName.Text = "";
            TextBoxLabelName.Enabled = false;
            TextBoxLabelDisplayOrder.Text = "";
            TextBoxLabelDisplayOrder.Enabled = false;
            ComboBoxLabelBackColor.Enabled = false;
            ComboBoxLabelBackColor.Text = "";
            ComboBoxLabelTextColor.Enabled = false;
            ComboBoxLabelTextColor.Text = "";
            CheckBoxLabelEnabled.Enabled = false;
            CheckBoxLabelEnabled.Checked = false;
            ButtonDeleteLabel.Enabled = false;
            ButtonCancelLabel.Enabled = false;
            ButtonSaveLabel.Enabled = false;
            LabelTest.BackColor = Color.Transparent;
            LabelTest.ForeColor = Color.Black;
        }

        public void EnableLabelControls()
        {
            TextBoxLabelName.Enabled = true;
            TextBoxLabelDisplayOrder.Enabled = true;
            ComboBoxLabelBackColor.Enabled = true;
            ComboBoxLabelTextColor.Enabled = true;
            CheckBoxLabelEnabled.Enabled = true;
            CheckBoxLabelEnabled.Checked = true;
            ButtonDeleteLabel.Enabled = true;
            ButtonCancelLabel.Enabled = true;
            ButtonSaveLabel.Enabled = true;
        }

        private void PopulateLabelColorBoxes()
        {
            ComboBoxLabelBackColor.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();


            ComboBoxLabelTextColor.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();


        }

        private void ComboBoxLabelTextColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = ComboBoxLabelTextColor.GetItemText(ComboBoxLabelTextColor.Items[e.Index]);
                var color = (Color)ComboBoxLabelTextColor.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, ComboBoxLabelTextColor.Font, r2,
                    ComboBoxLabelTextColor.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }

        private void ComboBoxLabelBackColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = ComboBoxLabelBackColor.GetItemText(ComboBoxLabelBackColor.Items[e.Index]);
                var color = (Color)ComboBoxLabelBackColor.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, ComboBoxLabelBackColor.Font, r2,
                    ComboBoxLabelBackColor.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }

        private void ComboBoxLabelTextColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fc = ComboBoxLabelTextColor.SelectedItem;
            LabelTest.ForeColor = Color.FromName(((Color)fc).Name);

        }

        private void ComboBoxLabelBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fc = ComboBoxLabelBackColor.SelectedItem;
            LabelTest.BackColor = Color.FromName(((Color)fc).Name);

        }

        private void ButtonNewLabel_Click(object sender, EventArgs e)
        {
            DisableLabelControls();
            EnableLabelControls();
            TextBoxLabelName.Focus();
            ButtonDeleteLabel.Enabled = false;

            taskLabel = null;
        }

        private void TextBoxLabelName_TextChanged(object sender, EventArgs e)
        {
            LabelTest.Text = TextBoxLabelName.Text;
        }

        private void ButtonCancelLabel_Click(object sender, EventArgs e)
        {
            DisableLabelControls();
        }

        private void ButtonSaveLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxLabelName.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must enter a label name before saving", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                    return;
                }


                DevTaskLabels devTaskLabels = new DevTaskLabels();

                if (taskLabel != null)
                {
                    devTaskLabels.ID = taskLabel.ID;
                }

                devTaskLabels.Name = TextBoxLabelName.Text;
                devTaskLabels.TextColor = ComboBoxLabelTextColor.Text;
                devTaskLabels.BackColor = ComboBoxLabelBackColor.Text;
                devTaskLabels.DisplayOrder = TextBoxLabelDisplayOrder.Text;
                devTaskLabels.Enabled = CheckBoxLabelEnabled.Checked;


                if (taskLabel != null)
                {
                    if (devTaskLabels.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully updated label");
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to update label. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (devTaskLabels.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully added new label");
                        FormNewTasks_Shown(null, null);
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to add new label. Try again", MessageBoxIcon.Warning);
                        return;
                    }
                }


                taskLabel = null;


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                GlobalCode.ShowMSGBox("An unexpected error occurred. Try again");
            }
        }

        private void ButtonDeleteLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskLabel == null)
                {
                    return;
                }

                DevTaskLabels devTaskLabels = new DevTaskLabels();
                devTaskLabels.ID = taskLabel.ID;

                if (devTaskLabels.DeleteRecord() == true)
                {

                    DevTaskAttachedLabels attachedLabels = new DevTaskAttachedLabels();
                    attachedLabels.LabelID = taskLabel.ID;

                    attachedLabels.DeleteRecordByLabelID();

                    GlobalCode.ShowMSGBox("Successfully deleted label");
                    FormNewTasks_Shown(null, null);
                }
                else
                {
                    GlobalCode.ShowMSGBox("Failed to delete label. Try again", MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }







        #endregion

        
    }
}
