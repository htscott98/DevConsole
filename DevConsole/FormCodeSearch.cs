using DevConsole.Classes;
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
    public partial class FormCodeSearch : Form
    {

        public int DevConsoleReposID;

        public FormCodeSearch()
        {
            InitializeComponent();
        }

        private void FormCodeSearch_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            List<Repos> repos = Repos.GetListOfObjects();

            ComboBoxSoftware.Items.Clear();
            ComboBoxSoftware.Items.Add("");

            foreach (Repos repo in repos)
            {
                ComboBoxSoftware.Items.Add(repo);
            }

            ComboBoxSoftware.Text = "";

        }

        private void PopulateTextBox(string name, string id)
        {
            try
            {

                TextBoxCode.Text = "";

                RepoCode repoCode = RepoCode.GetObjectByNameAndID(name, id);

                if (repoCode != null)
                {
                    TextBoxCode.Text = repoCode.Code;
                    return;
                }

                List<RepoCode> code = RepoCode.GetListOfObjectsByRepoID(id);

                foreach (RepoCode codeValue in code)
                {
                    TextBoxCode.Text += codeValue;
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ComboBoxSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBoxCode.Text = "";
            ListBoxForms.Items.Clear();

            if (ComboBoxSoftware.Text == "")
            {
                return;
            }

            Repos repo = new Repos();
            repo = (Repos)ComboBoxSoftware.SelectedItem;

            if (repo != null)
            {
                List<RepoCode> codeList = RepoCode.GetListOfObjectsByRepoID(repo.ID.ToString());

                foreach (RepoCode code in codeList)
                {

                    ListBoxForms.Items.Add(code);
                }
            }

        }

        private void ListBoxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepoCode repo = new RepoCode();
            repo = (RepoCode)ListBoxForms.SelectedItem;

            if (repo != null)
            {
                TextBoxCode.Text = "";
                TextBoxCode.Text = repo.Code;
            }

        }
    }
}
