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
    public partial class FormEventLogs : Form
    {
        public FormEventLogs()
        {
            InitializeComponent();
        }

        public int DevConsoleReposID;

        private void ButtonManageLogs_Click(object sender, EventArgs e)
        {
            FormManageLogs f = new FormManageLogs();
            f.DevConsoleRepoID = DevConsoleReposID;
            f.ShowDialog();
            FillMasterTable();
            
        }

        private void FormEventLogs_Load(object sender, EventArgs e)
        {
            
            try
            {
                FillMasterTable();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public void SetMasterTableDisplayProperties()
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
            DataGridViewMainLogs.AllowUserToResizeColumns = true;
            DataGridViewMainLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewMainLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewMainLogs.Columns["DevConsoleReposID"].Visible = false;
        }

        public void FillMasterTable()
        {
            try
            {
                List<MasterLog> masterLogs = new List<MasterLog>();
                masterLogs = MasterLog.GetListOfObjects(DevConsoleReposID.ToString());

                DataGridViewMainLogs.DataSource = masterLogs;
                SetMasterTableDisplayProperties();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

        }

        private void DataGridViewMainLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillLogTable();
        }

        private void FillLogTable()
        {
            int id = Convert.ToInt32(DataGridViewMainLogs.SelectedRows[0].Cells["ID"].Value);


            string sql = "SELECT Value, Timestamp FROM DevConsoleMasterLogs WHERE DevConsoleMasterID = '" + id + "' ORDER BY Timestamp DESC";
            DataTable dt;
            dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), sql);
            DataGridViewSubLogs.DataSource = dt;
            DataGridViewSubLogs.ClearSelection();
            DataGridViewSubLogs.Update();
            SetSubTableDisplayProperties();



        }

        private void SetSubTableDisplayProperties()
        {
            DataGridViewSubLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewSubLogs.AllowUserToAddRows = false;
            DataGridViewSubLogs.AllowUserToDeleteRows = false;
            DataGridViewSubLogs.AllowUserToResizeColumns = false;
            DataGridViewSubLogs.AllowUserToResizeRows = false;
            DataGridViewSubLogs.AllowUserToOrderColumns = false;
            DataGridViewSubLogs.MultiSelect = true;
            DataGridViewSubLogs.ReadOnly = true;
            DataGridViewSubLogs.RowHeadersVisible = false;
            DataGridViewSubLogs.AllowUserToResizeColumns = true;
            DataGridViewSubLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewSubLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
