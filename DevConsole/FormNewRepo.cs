using DevConsole.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{
    public partial class FormNewRepo : Form
    {
        public FormNewRepo()
        {
            InitializeComponent();
        }

        public bool newRepo;
        public Repos repository;

        private void FormNewRepo_Load(object sender, EventArgs e)
        {
            try
            {
                if (newRepo == true)
                {
                    ButtonOpen.Visible = false;
                    ButtonLogs.Visible = false;
                }
                else
                {
                    if (repository != null)
                    {
                        TextBoxName.Text = repository.Name;
                        TextBoxDescription.Text = repository.Description;
                        ComboBoxStatus.Text = repository.Status;
                        ComboBoxType.Text = repository.Type;
                        TextBoxLocation.Text = repository.Location;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (newRepo == true)
                {
                    Repos o = new Repos();
                    o.Name = TextBoxName.Text;
                    o.Location = TextBoxLocation.Text;
                    o.Status = ComboBoxStatus.Text;
                    o.Type = ComboBoxType.Text;
                    o.Description = TextBoxDescription.Text;

                    if (o.InsertRecord() == true)
                    {

                        GlobalCode.ShowMSGBox("Successfully added new repo");
                        this.Close();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to create repo.", MessageBoxIcon.Error);
                        return;
                    }


                }
                else
                {
                    Repos o = new Repos();
                    o.Name = TextBoxName.Text;
                    o.Location = TextBoxLocation.Text;
                    o.Status = ComboBoxStatus.Text;
                    o.Type = ComboBoxType.Text;
                    o.Description = TextBoxDescription.Text;

                    if (o.UpdateRecord(repository.ID) == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully updated repo.");
                        this.Close();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to update repo.", MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string DevRootDir = @"C:\Users\htsco\Desktop\Development\Dev\";

                if (Directory.Exists(DevRootDir + TextBoxName.Text))
                {
                    if (GlobalCode.ShowMSGBox("A local copy Of " + TextBoxName.Text + " already exists." + Environment.NewLine + Environment.NewLine + "Would you Like To open it?", MessageBoxIcon.Question, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OpenSolution(DevRootDir + TextBoxName.Text);
                    }
                }
                else
                {

                    Process p = new Process();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "cmd.exe";
                    info.RedirectStandardInput = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;
                    p.StartInfo = info;
                    p.Start();


                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("git clone " + TextBoxLocation.Text + " " + DevRootDir + TextBoxName.Text);

                        }
                    }

                    p.WaitForExit();
                    p.Close();

                    if (GlobalCode.ShowMSGBox("Open " + TextBoxName.Text + "?", MessageBoxIcon.Question, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OpenSolution(DevRootDir + TextBoxName.Text);
                    }

                }

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void OpenSolution(string path)
        {
            var mySolution = Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);
            Process.Start(new ProcessStartInfo(mySolution[0].ToString()) { UseShellExecute = true });
            System.Threading.Thread.Sleep(5000);
        }


        private void ButtonLogs_Click(object sender, EventArgs e)
        {
            FormEventLogs f = new FormEventLogs();
            f.DevConsoleReposID = repository.ID;
            f.ShowDialog();
        }

    }
}
