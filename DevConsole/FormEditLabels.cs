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
    public partial class FormEditLabels : Form
    {

        public DevTaskTasks devTask;

        public FormEditLabels()
        {
            InitializeComponent();
        }

        private void FormEditLabels_Load(object sender, EventArgs e)
        {
            try
            {
                if (devTask == null)
                {
                    this.Close();
                }

                LabelTaskName.Text = devTask.Name;

                PopulateLabels();


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateLabels()
        {
            PopulateSelectedLabels();
            PopulateAvailableLabels();
        }

        private void PopulateSelectedLabels()
        {
            FlowLayoutPanelSelectedLabels.Controls.Clear();

            List<DevTaskAttachedLabels> attachedLabels = DevTaskAttachedLabels.GetListOfObjectsByTaskID(devTask.ID.ToString());

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
                label.Click += RemoveLabel;
                FlowLayoutPanelSelectedLabels.Controls.Add(label);

            }

        }

        private void RemoveLabel(object sender, EventArgs e)
        {
            try
            {

                var selectedLabel = sender as Label;

                string labelID = selectedLabel.Name;

                DevTaskAttachedLabels removeLabel = new DevTaskAttachedLabels();
                removeLabel.LabelID = Convert.ToInt32(labelID);
                removeLabel.TaskID = devTask.ID;

                if (removeLabel.DeleteRecordByTaskIDAndLabelID() == true)
                {
                    PopulateLabels();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to delete label. Try again", MessageBoxIcon.Warning);
                }




            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void PopulateAvailableLabels()
        {
            FlowLayoutPanelAllLabels.Controls.Clear();
            List<DevTaskLabels> listLabels = DevTaskLabels.GetListOfObjects();

            List<DevTaskAttachedLabels> attachedLabels = DevTaskAttachedLabels.GetListOfObjectsByTaskID(devTask.ID.ToString());

            foreach (DevTaskLabels listLabel in listLabels)
            {

                var found = attachedLabels.Find(x => x.LabelID == listLabel.ID);

                if (found != null)
                {
                    continue;
                }

                Label label = new Label();
                label.Text = listLabel.Name;
                label.Name = listLabel.ID.ToString();
                label.Margin = new Padding(2, 2, 0, 0);
                label.Size = new Size(109, 35);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.ForeColor = Color.FromName(listLabel.TextColor);
                label.BackColor = Color.FromName(listLabel.BackColor);
                label.Click += AddLabel;
                FlowLayoutPanelAllLabels.Controls.Add(label);
            }
        }

        private void AddLabel(object sender, EventArgs e)
        {
            try
            {

                var selectedLabel = sender as Label;

                string labelID = selectedLabel.Name;

                DevTaskAttachedLabels addLabel = new DevTaskAttachedLabels();
                addLabel.LabelID = Convert.ToInt32(labelID);
                addLabel.TaskID = devTask.ID;

                if (addLabel.InsertRecord() == true)
                {
                    PopulateLabels();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to add label. Try again", MessageBoxIcon.Warning);
                }




            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

    }
}
