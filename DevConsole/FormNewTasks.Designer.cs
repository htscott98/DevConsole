namespace DevConsole
{
    partial class FormNewTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTasks));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabTasks = new System.Windows.Forms.TabPage();
            this.LinkNewTaskActivity = new System.Windows.Forms.LinkLabel();
            this.FlowLayoutPanelTaskActivity = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBoxTaskDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboBoxTaskList = new System.Windows.Forms.ComboBox();
            this.FlowLayoutPanelTaskLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonDeleteTask = new System.Windows.Forms.Button();
            this.ButtonCancelTask = new System.Windows.Forms.Button();
            this.ButtonSaveTask = new System.Windows.Forms.Button();
            this.CheckBoxTaskEnabled = new System.Windows.Forms.CheckBox();
            this.TextBoxTaskDisplayOrder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxTaskName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonNewTask = new System.Windows.Forms.Button();
            this.DataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.TabLists = new System.Windows.Forms.TabPage();
            this.ButtonDeleteList = new System.Windows.Forms.Button();
            this.ButtonCancelList = new System.Windows.Forms.Button();
            this.ButtonSaveList = new System.Windows.Forms.Button();
            this.CheckBoxListEnabled = new System.Windows.Forms.CheckBox();
            this.TextBoxListDisplayOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxListName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonNewList = new System.Windows.Forms.Button();
            this.DataGridViewLists = new System.Windows.Forms.DataGridView();
            this.TabLabels = new System.Windows.Forms.TabPage();
            this.FlowLayoutPanelLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelTest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxLabelBackColor = new System.Windows.Forms.ComboBox();
            this.ComboBoxLabelTextColor = new System.Windows.Forms.ComboBox();
            this.ButtonDeleteLabel = new System.Windows.Forms.Button();
            this.ButtonCancelLabel = new System.Windows.Forms.Button();
            this.ButtonSaveLabel = new System.Windows.Forms.Button();
            this.CheckBoxLabelEnabled = new System.Windows.Forms.CheckBox();
            this.TextBoxLabelDisplayOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxLabelName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonNewLabel = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTasks)).BeginInit();
            this.TabLists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLists)).BeginInit();
            this.TabLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabTasks);
            this.TabControl.Controls.Add(this.TabLists);
            this.TabControl.Controls.Add(this.TabLabels);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(760, 437);
            this.TabControl.TabIndex = 0;
            // 
            // TabTasks
            // 
            this.TabTasks.Controls.Add(this.LinkNewTaskActivity);
            this.TabTasks.Controls.Add(this.FlowLayoutPanelTaskActivity);
            this.TabTasks.Controls.Add(this.TextBoxTaskDescription);
            this.TabTasks.Controls.Add(this.label10);
            this.TabTasks.Controls.Add(this.label9);
            this.TabTasks.Controls.Add(this.ComboBoxTaskList);
            this.TabTasks.Controls.Add(this.FlowLayoutPanelTaskLabels);
            this.TabTasks.Controls.Add(this.ButtonDeleteTask);
            this.TabTasks.Controls.Add(this.ButtonCancelTask);
            this.TabTasks.Controls.Add(this.ButtonSaveTask);
            this.TabTasks.Controls.Add(this.CheckBoxTaskEnabled);
            this.TabTasks.Controls.Add(this.TextBoxTaskDisplayOrder);
            this.TabTasks.Controls.Add(this.label7);
            this.TabTasks.Controls.Add(this.TextBoxTaskName);
            this.TabTasks.Controls.Add(this.label8);
            this.TabTasks.Controls.Add(this.ButtonNewTask);
            this.TabTasks.Controls.Add(this.DataGridViewTasks);
            this.TabTasks.Location = new System.Drawing.Point(4, 25);
            this.TabTasks.Name = "TabTasks";
            this.TabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.TabTasks.Size = new System.Drawing.Size(752, 408);
            this.TabTasks.TabIndex = 0;
            this.TabTasks.Text = "Tasks";
            this.TabTasks.UseVisualStyleBackColor = true;
            // 
            // LinkNewTaskActivity
            // 
            this.LinkNewTaskActivity.ActiveLinkColor = System.Drawing.Color.Blue;
            this.LinkNewTaskActivity.LinkColor = System.Drawing.Color.Blue;
            this.LinkNewTaskActivity.Location = new System.Drawing.Point(300, 206);
            this.LinkNewTaskActivity.Name = "LinkNewTaskActivity";
            this.LinkNewTaskActivity.Size = new System.Drawing.Size(446, 22);
            this.LinkNewTaskActivity.TabIndex = 27;
            this.LinkNewTaskActivity.TabStop = true;
            this.LinkNewTaskActivity.Text = "New Activity";
            this.LinkNewTaskActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkNewTaskActivity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNewTaskActivity_LinkClicked);
            // 
            // FlowLayoutPanelTaskActivity
            // 
            this.FlowLayoutPanelTaskActivity.AutoScroll = true;
            this.FlowLayoutPanelTaskActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelTaskActivity.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowLayoutPanelTaskActivity.Location = new System.Drawing.Point(300, 231);
            this.FlowLayoutPanelTaskActivity.Name = "FlowLayoutPanelTaskActivity";
            this.FlowLayoutPanelTaskActivity.Size = new System.Drawing.Size(446, 130);
            this.FlowLayoutPanelTaskActivity.TabIndex = 26;
            // 
            // TextBoxTaskDescription
            // 
            this.TextBoxTaskDescription.Location = new System.Drawing.Point(300, 162);
            this.TextBoxTaskDescription.Multiline = true;
            this.TextBoxTaskDescription.Name = "TextBoxTaskDescription";
            this.TextBoxTaskDescription.Size = new System.Drawing.Size(446, 41);
            this.TextBoxTaskDescription.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "List";
            // 
            // ComboBoxTaskList
            // 
            this.ComboBoxTaskList.FormattingEnabled = true;
            this.ComboBoxTaskList.Location = new System.Drawing.Point(300, 116);
            this.ComboBoxTaskList.Name = "ComboBoxTaskList";
            this.ComboBoxTaskList.Size = new System.Drawing.Size(274, 24);
            this.ComboBoxTaskList.TabIndex = 16;
            // 
            // FlowLayoutPanelTaskLabels
            // 
            this.FlowLayoutPanelTaskLabels.AutoScroll = true;
            this.FlowLayoutPanelTaskLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelTaskLabels.Location = new System.Drawing.Point(300, 6);
            this.FlowLayoutPanelTaskLabels.Name = "FlowLayoutPanelTaskLabels";
            this.FlowLayoutPanelTaskLabels.Size = new System.Drawing.Size(446, 44);
            this.FlowLayoutPanelTaskLabels.TabIndex = 20;
            // 
            // ButtonDeleteTask
            // 
            this.ButtonDeleteTask.Location = new System.Drawing.Point(415, 367);
            this.ButtonDeleteTask.Name = "ButtonDeleteTask";
            this.ButtonDeleteTask.Size = new System.Drawing.Size(104, 35);
            this.ButtonDeleteTask.TabIndex = 22;
            this.ButtonDeleteTask.Text = "Delete";
            this.ButtonDeleteTask.UseVisualStyleBackColor = true;
            this.ButtonDeleteTask.Click += new System.EventHandler(this.ButtonDeleteTask_Click);
            // 
            // ButtonCancelTask
            // 
            this.ButtonCancelTask.Location = new System.Drawing.Point(525, 367);
            this.ButtonCancelTask.Name = "ButtonCancelTask";
            this.ButtonCancelTask.Size = new System.Drawing.Size(109, 35);
            this.ButtonCancelTask.TabIndex = 21;
            this.ButtonCancelTask.Text = "Cancel";
            this.ButtonCancelTask.UseVisualStyleBackColor = true;
            this.ButtonCancelTask.Click += new System.EventHandler(this.ButtonCancelTask_Click);
            // 
            // ButtonSaveTask
            // 
            this.ButtonSaveTask.Location = new System.Drawing.Point(640, 367);
            this.ButtonSaveTask.Name = "ButtonSaveTask";
            this.ButtonSaveTask.Size = new System.Drawing.Size(106, 35);
            this.ButtonSaveTask.TabIndex = 20;
            this.ButtonSaveTask.Text = "Save";
            this.ButtonSaveTask.UseVisualStyleBackColor = true;
            this.ButtonSaveTask.Click += new System.EventHandler(this.ButtonSaveTask_Click);
            // 
            // CheckBoxTaskEnabled
            // 
            this.CheckBoxTaskEnabled.AutoSize = true;
            this.CheckBoxTaskEnabled.Location = new System.Drawing.Point(625, 120);
            this.CheckBoxTaskEnabled.Name = "CheckBoxTaskEnabled";
            this.CheckBoxTaskEnabled.Size = new System.Drawing.Size(77, 20);
            this.CheckBoxTaskEnabled.TabIndex = 17;
            this.CheckBoxTaskEnabled.Text = "Enabled";
            this.CheckBoxTaskEnabled.UseVisualStyleBackColor = true;
            // 
            // TextBoxTaskDisplayOrder
            // 
            this.TextBoxTaskDisplayOrder.Location = new System.Drawing.Point(580, 72);
            this.TextBoxTaskDisplayOrder.Name = "TextBoxTaskDisplayOrder";
            this.TextBoxTaskDisplayOrder.Size = new System.Drawing.Size(166, 22);
            this.TextBoxTaskDisplayOrder.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(580, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Display Order";
            // 
            // TextBoxTaskName
            // 
            this.TextBoxTaskName.Location = new System.Drawing.Point(300, 72);
            this.TextBoxTaskName.Name = "TextBoxTaskName";
            this.TextBoxTaskName.Size = new System.Drawing.Size(274, 22);
            this.TextBoxTaskName.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Name";
            // 
            // ButtonNewTask
            // 
            this.ButtonNewTask.Location = new System.Drawing.Point(159, 367);
            this.ButtonNewTask.Name = "ButtonNewTask";
            this.ButtonNewTask.Size = new System.Drawing.Size(135, 35);
            this.ButtonNewTask.TabIndex = 11;
            this.ButtonNewTask.Text = "New Task";
            this.ButtonNewTask.UseVisualStyleBackColor = true;
            this.ButtonNewTask.Click += new System.EventHandler(this.ButtonNewTask_Click);
            // 
            // DataGridViewTasks
            // 
            this.DataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTasks.Location = new System.Drawing.Point(6, 6);
            this.DataGridViewTasks.Name = "DataGridViewTasks";
            this.DataGridViewTasks.Size = new System.Drawing.Size(288, 355);
            this.DataGridViewTasks.TabIndex = 10;
            this.DataGridViewTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewTasks_CellClick);
            this.DataGridViewTasks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewTasks_DataBindingComplete);
            // 
            // TabLists
            // 
            this.TabLists.Controls.Add(this.ButtonDeleteList);
            this.TabLists.Controls.Add(this.ButtonCancelList);
            this.TabLists.Controls.Add(this.ButtonSaveList);
            this.TabLists.Controls.Add(this.CheckBoxListEnabled);
            this.TabLists.Controls.Add(this.TextBoxListDisplayOrder);
            this.TabLists.Controls.Add(this.label2);
            this.TabLists.Controls.Add(this.TextBoxListName);
            this.TabLists.Controls.Add(this.label1);
            this.TabLists.Controls.Add(this.ButtonNewList);
            this.TabLists.Controls.Add(this.DataGridViewLists);
            this.TabLists.Location = new System.Drawing.Point(4, 24);
            this.TabLists.Name = "TabLists";
            this.TabLists.Padding = new System.Windows.Forms.Padding(3);
            this.TabLists.Size = new System.Drawing.Size(752, 409);
            this.TabLists.TabIndex = 1;
            this.TabLists.Text = "Lists";
            this.TabLists.UseVisualStyleBackColor = true;
            // 
            // ButtonDeleteList
            // 
            this.ButtonDeleteList.Location = new System.Drawing.Point(366, 225);
            this.ButtonDeleteList.Name = "ButtonDeleteList";
            this.ButtonDeleteList.Size = new System.Drawing.Size(104, 35);
            this.ButtonDeleteList.TabIndex = 9;
            this.ButtonDeleteList.Text = "Delete";
            this.ButtonDeleteList.UseVisualStyleBackColor = true;
            this.ButtonDeleteList.Click += new System.EventHandler(this.ButtonDeleteList_Click);
            // 
            // ButtonCancelList
            // 
            this.ButtonCancelList.Location = new System.Drawing.Point(476, 225);
            this.ButtonCancelList.Name = "ButtonCancelList";
            this.ButtonCancelList.Size = new System.Drawing.Size(109, 35);
            this.ButtonCancelList.TabIndex = 8;
            this.ButtonCancelList.Text = "Cancel";
            this.ButtonCancelList.UseVisualStyleBackColor = true;
            this.ButtonCancelList.Click += new System.EventHandler(this.ButtonCancelList_Click);
            // 
            // ButtonSaveList
            // 
            this.ButtonSaveList.Location = new System.Drawing.Point(591, 225);
            this.ButtonSaveList.Name = "ButtonSaveList";
            this.ButtonSaveList.Size = new System.Drawing.Size(104, 35);
            this.ButtonSaveList.TabIndex = 7;
            this.ButtonSaveList.Text = "Save";
            this.ButtonSaveList.UseVisualStyleBackColor = true;
            this.ButtonSaveList.Click += new System.EventHandler(this.ButtonSaveList_Click);
            // 
            // CheckBoxListEnabled
            // 
            this.CheckBoxListEnabled.AutoSize = true;
            this.CheckBoxListEnabled.Location = new System.Drawing.Point(576, 183);
            this.CheckBoxListEnabled.Name = "CheckBoxListEnabled";
            this.CheckBoxListEnabled.Size = new System.Drawing.Size(77, 20);
            this.CheckBoxListEnabled.TabIndex = 6;
            this.CheckBoxListEnabled.Text = "Enabled";
            this.CheckBoxListEnabled.UseVisualStyleBackColor = true;
            // 
            // TextBoxListDisplayOrder
            // 
            this.TextBoxListDisplayOrder.Location = new System.Drawing.Point(366, 181);
            this.TextBoxListDisplayOrder.Name = "TextBoxListDisplayOrder";
            this.TextBoxListDisplayOrder.Size = new System.Drawing.Size(166, 22);
            this.TextBoxListDisplayOrder.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Display Order";
            // 
            // TextBoxListName
            // 
            this.TextBoxListName.Location = new System.Drawing.Point(366, 137);
            this.TextBoxListName.Name = "TextBoxListName";
            this.TextBoxListName.Size = new System.Drawing.Size(329, 22);
            this.TextBoxListName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // ButtonNewList
            // 
            this.ButtonNewList.Location = new System.Drawing.Point(159, 367);
            this.ButtonNewList.Name = "ButtonNewList";
            this.ButtonNewList.Size = new System.Drawing.Size(135, 35);
            this.ButtonNewList.TabIndex = 1;
            this.ButtonNewList.Text = "New List";
            this.ButtonNewList.UseVisualStyleBackColor = true;
            this.ButtonNewList.Click += new System.EventHandler(this.ButtonNewList_Click);
            // 
            // DataGridViewLists
            // 
            this.DataGridViewLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewLists.Location = new System.Drawing.Point(6, 6);
            this.DataGridViewLists.Name = "DataGridViewLists";
            this.DataGridViewLists.Size = new System.Drawing.Size(288, 355);
            this.DataGridViewLists.TabIndex = 0;
            this.DataGridViewLists.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLists_CellClick);
            this.DataGridViewLists.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewLists_DataBindingComplete);
            // 
            // TabLabels
            // 
            this.TabLabels.Controls.Add(this.FlowLayoutPanelLabels);
            this.TabLabels.Controls.Add(this.LabelTest);
            this.TabLabels.Controls.Add(this.label6);
            this.TabLabels.Controls.Add(this.label5);
            this.TabLabels.Controls.Add(this.ComboBoxLabelBackColor);
            this.TabLabels.Controls.Add(this.ComboBoxLabelTextColor);
            this.TabLabels.Controls.Add(this.ButtonDeleteLabel);
            this.TabLabels.Controls.Add(this.ButtonCancelLabel);
            this.TabLabels.Controls.Add(this.ButtonSaveLabel);
            this.TabLabels.Controls.Add(this.CheckBoxLabelEnabled);
            this.TabLabels.Controls.Add(this.TextBoxLabelDisplayOrder);
            this.TabLabels.Controls.Add(this.label3);
            this.TabLabels.Controls.Add(this.TextBoxLabelName);
            this.TabLabels.Controls.Add(this.label4);
            this.TabLabels.Controls.Add(this.ButtonNewLabel);
            this.TabLabels.Location = new System.Drawing.Point(4, 24);
            this.TabLabels.Name = "TabLabels";
            this.TabLabels.Padding = new System.Windows.Forms.Padding(3);
            this.TabLabels.Size = new System.Drawing.Size(752, 409);
            this.TabLabels.TabIndex = 2;
            this.TabLabels.Text = "Labels";
            this.TabLabels.UseVisualStyleBackColor = true;
            // 
            // FlowLayoutPanelLabels
            // 
            this.FlowLayoutPanelLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelLabels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowLayoutPanelLabels.Location = new System.Drawing.Point(6, 6);
            this.FlowLayoutPanelLabels.Name = "FlowLayoutPanelLabels";
            this.FlowLayoutPanelLabels.Size = new System.Drawing.Size(283, 355);
            this.FlowLayoutPanelLabels.TabIndex = 26;
            // 
            // LabelTest
            // 
            this.LabelTest.Location = new System.Drawing.Point(475, 326);
            this.LabelTest.Name = "LabelTest";
            this.LabelTest.Size = new System.Drawing.Size(109, 35);
            this.LabelTest.TabIndex = 25;
            this.LabelTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Background Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Text Color";
            // 
            // ComboBoxLabelBackColor
            // 
            this.ComboBoxLabelBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxLabelBackColor.FormattingEnabled = true;
            this.ComboBoxLabelBackColor.Location = new System.Drawing.Point(542, 135);
            this.ComboBoxLabelBackColor.Name = "ComboBoxLabelBackColor";
            this.ComboBoxLabelBackColor.Size = new System.Drawing.Size(179, 23);
            this.ComboBoxLabelBackColor.TabIndex = 15;
            this.ComboBoxLabelBackColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxLabelBackColor_DrawItem);
            this.ComboBoxLabelBackColor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLabelBackColor_SelectedIndexChanged);
            // 
            // ComboBoxLabelTextColor
            // 
            this.ComboBoxLabelTextColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxLabelTextColor.FormattingEnabled = true;
            this.ComboBoxLabelTextColor.Location = new System.Drawing.Point(332, 135);
            this.ComboBoxLabelTextColor.Name = "ComboBoxLabelTextColor";
            this.ComboBoxLabelTextColor.Size = new System.Drawing.Size(184, 23);
            this.ComboBoxLabelTextColor.TabIndex = 14;
            this.ComboBoxLabelTextColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxLabelTextColor_DrawItem);
            this.ComboBoxLabelTextColor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLabelTextColor_SelectedIndexChanged);
            // 
            // ButtonDeleteLabel
            // 
            this.ButtonDeleteLabel.Location = new System.Drawing.Point(332, 225);
            this.ButtonDeleteLabel.Name = "ButtonDeleteLabel";
            this.ButtonDeleteLabel.Size = new System.Drawing.Size(104, 35);
            this.ButtonDeleteLabel.TabIndex = 20;
            this.ButtonDeleteLabel.Text = "Delete";
            this.ButtonDeleteLabel.UseVisualStyleBackColor = true;
            this.ButtonDeleteLabel.Click += new System.EventHandler(this.ButtonDeleteLabel_Click);
            // 
            // ButtonCancelLabel
            // 
            this.ButtonCancelLabel.Location = new System.Drawing.Point(475, 225);
            this.ButtonCancelLabel.Name = "ButtonCancelLabel";
            this.ButtonCancelLabel.Size = new System.Drawing.Size(109, 35);
            this.ButtonCancelLabel.TabIndex = 19;
            this.ButtonCancelLabel.Text = "Cancel";
            this.ButtonCancelLabel.UseVisualStyleBackColor = true;
            this.ButtonCancelLabel.Click += new System.EventHandler(this.ButtonCancelLabel_Click);
            // 
            // ButtonSaveLabel
            // 
            this.ButtonSaveLabel.Location = new System.Drawing.Point(617, 225);
            this.ButtonSaveLabel.Name = "ButtonSaveLabel";
            this.ButtonSaveLabel.Size = new System.Drawing.Size(104, 35);
            this.ButtonSaveLabel.TabIndex = 18;
            this.ButtonSaveLabel.Text = "Save";
            this.ButtonSaveLabel.UseVisualStyleBackColor = true;
            this.ButtonSaveLabel.Click += new System.EventHandler(this.ButtonSaveLabel_Click);
            // 
            // CheckBoxLabelEnabled
            // 
            this.CheckBoxLabelEnabled.AutoSize = true;
            this.CheckBoxLabelEnabled.Location = new System.Drawing.Point(593, 183);
            this.CheckBoxLabelEnabled.Name = "CheckBoxLabelEnabled";
            this.CheckBoxLabelEnabled.Size = new System.Drawing.Size(77, 20);
            this.CheckBoxLabelEnabled.TabIndex = 17;
            this.CheckBoxLabelEnabled.Text = "Enabled";
            this.CheckBoxLabelEnabled.UseVisualStyleBackColor = true;
            // 
            // TextBoxLabelDisplayOrder
            // 
            this.TextBoxLabelDisplayOrder.Location = new System.Drawing.Point(332, 181);
            this.TextBoxLabelDisplayOrder.Name = "TextBoxLabelDisplayOrder";
            this.TextBoxLabelDisplayOrder.Size = new System.Drawing.Size(184, 22);
            this.TextBoxLabelDisplayOrder.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Display Order";
            // 
            // TextBoxLabelName
            // 
            this.TextBoxLabelName.Location = new System.Drawing.Point(330, 91);
            this.TextBoxLabelName.Name = "TextBoxLabelName";
            this.TextBoxLabelName.Size = new System.Drawing.Size(391, 22);
            this.TextBoxLabelName.TabIndex = 13;
            this.TextBoxLabelName.TextChanged += new System.EventHandler(this.TextBoxLabelName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name";
            // 
            // ButtonNewLabel
            // 
            this.ButtonNewLabel.Location = new System.Drawing.Point(154, 367);
            this.ButtonNewLabel.Name = "ButtonNewLabel";
            this.ButtonNewLabel.Size = new System.Drawing.Size(135, 35);
            this.ButtonNewLabel.TabIndex = 11;
            this.ButtonNewLabel.Text = "New Label";
            this.ButtonNewLabel.UseVisualStyleBackColor = true;
            this.ButtonNewLabel.Click += new System.EventHandler(this.ButtonNewLabel_Click);
            // 
            // FormNewTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormNewTasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevConsole";
            this.Shown += new System.EventHandler(this.FormNewTasks_Shown);
            this.TabControl.ResumeLayout(false);
            this.TabTasks.ResumeLayout(false);
            this.TabTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTasks)).EndInit();
            this.TabLists.ResumeLayout(false);
            this.TabLists.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLists)).EndInit();
            this.TabLabels.ResumeLayout(false);
            this.TabLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabTasks;
        private System.Windows.Forms.TabPage TabLists;
        private System.Windows.Forms.TabPage TabLabels;
        private System.Windows.Forms.DataGridView DataGridViewLists;
        private System.Windows.Forms.Button ButtonNewList;
        private System.Windows.Forms.TextBox TextBoxListName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSaveList;
        private System.Windows.Forms.CheckBox CheckBoxListEnabled;
        private System.Windows.Forms.TextBox TextBoxListDisplayOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonCancelList;
        private System.Windows.Forms.Button ButtonDeleteList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxLabelBackColor;
        private System.Windows.Forms.ComboBox ComboBoxLabelTextColor;
        private System.Windows.Forms.Button ButtonDeleteLabel;
        private System.Windows.Forms.Button ButtonCancelLabel;
        private System.Windows.Forms.Button ButtonSaveLabel;
        private System.Windows.Forms.CheckBox CheckBoxLabelEnabled;
        private System.Windows.Forms.TextBox TextBoxLabelDisplayOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxLabelName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonNewLabel;
        private System.Windows.Forms.Label LabelTest;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelLabels;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelTaskLabels;
        private System.Windows.Forms.Button ButtonDeleteTask;
        private System.Windows.Forms.Button ButtonCancelTask;
        private System.Windows.Forms.Button ButtonSaveTask;
        private System.Windows.Forms.CheckBox CheckBoxTaskEnabled;
        private System.Windows.Forms.TextBox TextBoxTaskDisplayOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBoxTaskName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonNewTask;
        private System.Windows.Forms.DataGridView DataGridViewTasks;
        private System.Windows.Forms.TextBox TextBoxTaskDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ComboBoxTaskList;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelTaskActivity;
        private System.Windows.Forms.LinkLabel LinkNewTaskActivity;
    }
}