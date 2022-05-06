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
    public partial class FormManageLogs : Form
    {
        public FormManageLogs()
        {
            InitializeComponent();
        }

        public bool newMasterLog;
        public int DevConsoleRepoID;


        private void ButtonSaveMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxMasterLog.Text == "")
                {
                    GlobalCode.ShowMSGBox("You must enter a name for the master log.", MessageBoxIcon.Error);
                    return;
                }


                if (newMasterLog == true)
                {
                    MasterLog o = new MasterLog();
                    o.DevConsoleReposID = DevConsoleRepoID;
                    o.LogName = TextBoxMasterLog.Text;

                    if (o.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully added master log.");
                        DisableMasterControls();
                        FillMasterTable();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to add master log.", MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    MasterLog o = new MasterLog();
                    o.LogName = TextBoxMasterLog.Text;

                    if (o.UpdateRecord(Convert.ToInt32(DataGridViewMainLogs.SelectedRows[0].Cells["ID"].Value)) == true)
                    {
                        GlobalCode.ShowMSGBox("Successfully updated master log.");
                        DisableMasterControls();
                        FillMasterTable();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Failed to update master log.", MessageBoxIcon.Error);
                        return;
                    }


                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void ButtonNewMaster_Click(object sender, EventArgs e)
        {
            newMasterLog = true;
            ButtonDeleteMaster.Enabled = false;
            TextBoxMasterLog.Text = "";
            TextBoxMasterLog.Enabled = true;
            ButtonSaveMaster.Enabled = true;
            ButtonGenerateLog.Enabled = true;
        }

        public void FillMasterTable()
        {
            DataTable dt = new DataTable();
            dt = MasterLog.GetDataTable(DevConsoleRepoID);
            DataGridViewMainLogs.DataSource = dt;
            SetMasterProperties();
        }

        public void SetMasterProperties()
        {
            DataGridViewMainLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewMainLogs.AllowUserToAddRows = false;
            DataGridViewMainLogs.AllowUserToDeleteRows = false;
            DataGridViewMainLogs.AllowUserToResizeColumns = false;
            DataGridViewMainLogs.AllowUserToResizeRows = false;
            DataGridViewMainLogs.AllowUserToOrderColumns = false;
            DataGridViewMainLogs.MultiSelect = true;
            DataGridViewMainLogs.ReadOnly = true;
            DataGridViewMainLogs.RowHeadersVisible = false;
            DataGridViewMainLogs.ColumnHeadersVisible = false;
            DataGridViewMainLogs.AllowUserToResizeColumns = true;
            DataGridViewMainLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewMainLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.DataGridViewMainLogs.Columns["ID"].Visible = false;
            this.DataGridViewMainLogs.Columns["DevConsoleReposID"].Visible = false;
        }

        public void DisableMasterControls()
        {
            TextBoxMasterLog.Text = "";
            TextBoxMasterLog.Enabled = false;
            ButtonDeleteMaster.Enabled = false;
            ButtonSaveMaster.Enabled = false;
            ButtonGenerateLog.Enabled = false;
        }

        private void FormManageLogs_Load(object sender, EventArgs e)
        {
            FillMasterTable();
        }

        private void DataGridViewMainLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewMainLogs.ClearSelection();
        }

        

        private void DataGridViewMainLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewMainLogs.SelectedRows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("Select a master log to edit");
                    return;
                }


                newMasterLog = false;
                MasterLog masterLog = new MasterLog();
                masterLog = MasterLog.GetObjectByID(Convert.ToInt32(DataGridViewMainLogs.SelectedRows[0].Cells["ID"].Value));
                ButtonDeleteMaster.Enabled = true;
                ButtonSaveMaster.Enabled = true;
                ButtonGenerateLog.Enabled = true;
                TextBoxMasterLog.Text = masterLog.LogName;
                TextBoxMasterLog.Enabled = true;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        

        private void ButtonDeleteMaster_Click(object sender, EventArgs e)
        {
            try
            {
                MasterLog o = new MasterLog();
                o.ID = Convert.ToInt32(DataGridViewMainLogs.SelectedRows[0].Cells["ID"].Value);

                if (o.DeleteRecord() == true)
                {
                    GlobalCode.ShowMSGBox("Successfully deleted master log");
                    FillMasterTable();
                    DisableMasterControls();
                    return;

                }
                else
                {
                    GlobalCode.ShowMSGBox("Failed to delete master log.", MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

        }

        

        private void FormManageLogs_Shown(object sender, EventArgs e)
        {
            DataGridViewMainLogs.ClearSelection();
        }

        private void ButtonGenerateLog_Click(object sender, EventArgs e)
        {

            if (DataGridViewMainLogs.SelectedRows.Count == 0)
            {
                return;
            }

            string id = "\"" + DataGridViewMainLogs.SelectedRows[0].Cells["ID"].Value.ToString() + "\"";
            string logName = DataGridViewMainLogs.SelectedRows[0].Cells["LogName"].Value.ToString();

            Clipboard.SetText("MasterCode.Log.InsertMasterLogging((" + id + ",\"REPLACE_ME\")); /*" + logName + "*/");

            GlobalCode.ShowMSGBox("Log has been generated and copied to clipboard");

        }
    }
}
