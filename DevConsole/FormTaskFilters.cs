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
    public partial class FormTaskFilters : Form
    {

        public FormTaskFilters()
        {
            InitializeComponent();
        }

        private void FormTaskFilters_Load(object sender, EventArgs e)
        {
            PopulateTextbox();
            PopulateLabels();
        }

        private void PopulateTextbox()
        {
            TextBoxFilter.Text = GlobalCode.stringFilter;
        }

        private void PopulateLabels()
        {
            PopulateSelectedLabels();
            PopulateAvailableLabels();
        }

        private void PopulateAvailableLabels()
        {
            FlowLayoutPanelAllLabels.Controls.Clear();
            List<DevTaskLabels> listLabels = DevTaskLabels.GetListOfObjects();

            foreach (DevTaskLabels listLabel in listLabels)
            {

                if (GlobalCode.labelFilters.Contains(listLabel.ID.ToString()))
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

        private void PopulateSelectedLabels()
        {
            FlowLayoutPanelSelectedLabels.Controls.Clear();

            List<DevTaskLabels> listLabels = DevTaskLabels.GetListOfObjects();

            foreach (DevTaskLabels labels in listLabels)
            {

                if (GlobalCode.labelFilters.Contains(labels.ID.ToString()))
                {
                    Label label = new Label();
                    label.Text = labels.Name;
                    label.Name = labels.ID.ToString();
                    label.Margin = new Padding(2, 2, 0, 0);
                    label.Size = new Size(109, 35);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.FromName(labels.TextColor);
                    label.BackColor = Color.FromName(labels.BackColor);
                    label.Click += RemoveLabel;
                    FlowLayoutPanelSelectedLabels.Controls.Add(label);
                }

            }

        }

        private void AddLabel(object sender, EventArgs e)
        {
            try
            {

                var selectedLabel = sender as Label;

                string labelID = selectedLabel.Name;

                GlobalCode.labelFilters.Add(labelID);

                PopulateLabels();
            
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void RemoveLabel(object sender, EventArgs e)
        {
            try
            {

                var selectedLabel = sender as Label;

                string labelID = selectedLabel.Name;

                GlobalCode.labelFilters.Remove(labelID);

                PopulateLabels();




            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            GlobalCode.stringFilter = TextBoxFilter.Text;
        }

        private void ButtonClearFilters_Click(object sender, EventArgs e)
        {
            GlobalCode.labelFilters.Clear();
            GlobalCode.stringFilter = "";
            FormTaskFilters_Load(null, null);
        }
    }
}
