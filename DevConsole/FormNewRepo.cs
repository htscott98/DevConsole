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
                Process.Start(new ProcessStartInfo(repository.Location + @"\" + repository.Name + ".sln") { UseShellExecute = true });
                return;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonLogs_Click(object sender, EventArgs e)
        {
            FormEventLogs f = new FormEventLogs();
            f.DevConsoleReposID = repository.ID;
            f.ShowDialog();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {

            if (newRepo == false)
            {
                return;
            }
            
            TextBoxLocation.Text = @"C:\Users\htsco\OneDrive\DevProjects\" + TextBoxName.Text;
        }
    }
}
