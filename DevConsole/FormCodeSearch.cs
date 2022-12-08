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
using static System.Windows.Forms.LinkLabel;

namespace DevConsole
{
    public partial class FormCodeSearch : Form
    {

        public int DevConsoleReposID;
        public int listPosition;
        public List<int> allPositions;

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

        private void ComboBoxSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBoxCode.Text = "";
            TextBoxFind.Text = "";
            LabelListCount.Text = "";
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
            TextBoxFind.Text = "";
            LabelListCount.Text = "";
            RepoCode repo = new RepoCode();
            repo = (RepoCode)ListBoxForms.SelectedItem;

            if (repo != null)
            {
                TextBoxCode.Text = "";
                string[] array = repo.Code.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                int codeLine = 1;
                foreach (string item in array)
                {
                    TextBoxCode.AppendText(codeLine.ToString() + ". " + item);
                    TextBoxCode.AppendText("\n");
                    codeLine++;
                }
            }

        }

        private void ButtonAllCode_Click(object sender, EventArgs e)
        {
            try
            {

                if (ComboBoxSoftware.Text == "")
                {

                    TextBoxCode.Text = "";

                    List<Repos> repos = Repos.GetListOfObjects();

                    foreach (Repos repo in repos)
                    {
                        List<RepoCode> codeList = RepoCode.GetListOfObjectsByRepoID(repo.ID.ToString());

                        foreach (RepoCode code in codeList)
                        {

                            TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 14, FontStyle.Bold);
                            TextBoxCode.AppendText("START: " + repo.Name + " (" + code.FormName + ")\n");
                            TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 10, FontStyle.Regular);


                            string[] array = code.Code.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                            int codeLine = 1;
                            foreach (string item in array)
                            {
                                TextBoxCode.AppendText(codeLine.ToString() + ". " + item);
                                TextBoxCode.AppendText("\n");
                                codeLine++;
                            }
                            TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 14, FontStyle.Bold);
                            TextBoxCode.AppendText("END: " + repo.Name + " (" + code.FormName + ")\n\n");
                        }
                    }
                }
                else
                {
                    TextBoxCode.Text = "";

                    Repos selectedRepo = new Repos();
                    selectedRepo = (Repos)ComboBoxSoftware.SelectedItem;

                    Repos repo = Repos.GetObjectByID(selectedRepo.ID);

                    List<RepoCode> codeList = RepoCode.GetListOfObjectsByRepoID(repo.ID.ToString());

                    foreach (RepoCode code in codeList)
                    {
                        TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 14, FontStyle.Bold);
                        TextBoxCode.AppendText("START: " + repo.Name + " (" + code.FormName + ")\n");
                        TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 10, FontStyle.Regular);

                        string[] array = code.Code.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        int codeLine = 1;
                        foreach (string item in array)
                        {
                            TextBoxCode.AppendText(codeLine.ToString() + ". " + item);
                            TextBoxCode.AppendText("\n");
                            codeLine++;
                        }
                        TextBoxCode.SelectionFont = new Font(TextBoxCode.Font.Name, 14, FontStyle.Bold);
                        TextBoxCode.AppendText("END: " + repo.Name + " (" + code.FormName + ")\n\n");
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonFindCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxCode.Text == "")
                {
                    return;
                }

                if (TextBoxFind.Text == "")
                {
                    LabelListCount.Text = "";
                }

                if (allPositions != null)
                {

                    allPositions.Clear();

                }

                TextBoxCode.Select(0, 0);
                TextBoxCode.ScrollToCaret();
                listPosition = 0;
                clearHighlights(TextBoxCode);
                allPositions = FindAll(TextBoxCode, TextBoxFind.Text, 0);
                GoToPosition();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        void clearHighlights(RichTextBox rtb)
        {
            int cursorPos = rtb.SelectionStart;
            rtb.Select(0, rtb.TextLength);
            rtb.SelectionColor = Color.Black;
            rtb.Select(cursorPos, 0);
        }

        public List<int> FindAll(RichTextBox rtb, string txtToSearch, int searchStart)
        {
            List<int> found = new List<int>();
            if (txtToSearch.Length <= 0) return found;

            int pos = rtb.Find(txtToSearch, searchStart, RichTextBoxFinds.None);
            while (pos >= 0)
            {
                found.Add(pos);
                pos = rtb.Find(txtToSearch, pos + txtToSearch.Length, RichTextBoxFinds.None);
            }
            return found;
        }

        public void GoToPosition()
        {
            if (TextBoxFind.Text == "" || TextBoxCode.Text == "")
            {
                return;
            }


            TextBoxCode.Select(allPositions[listPosition], TextBoxFind.Text.Length);
            TextBoxCode.SelectionColor = Color.OrangeRed;
            TextBoxCode.ScrollToCaret();

            if (allPositions.Count > 0)
            {
                LabelListCount.Text = (listPosition + 1).ToString() + "/" + allPositions.Count.ToString() + " instances found";
            }
        }

        public void NextPosition()
        {
            if (listPosition == allPositions.Count - 1)
            {
                return;
            }

            TextBoxCode.SelectionColor = Color.Black;

            listPosition++;
            GoToPosition();
        }

        public void LastPosition()
        {
            if (listPosition == 0)
            {
                return;
            }

            TextBoxCode.SelectionColor = Color.Black;

            listPosition--;
            GoToPosition();
        }

        private void ButtonNextInstance_Click(object sender, EventArgs e)
        {
            NextPosition();
        }

        private void ButtonLastInstance_Click(object sender, EventArgs e)
        {
            LastPosition();
        }
    }
}
