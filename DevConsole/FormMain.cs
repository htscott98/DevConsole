using DevConsole.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{
    public partial class FormMain : Form
    {

        #region "Global Variables"

        private struct ColumnData
        {
            public string ColumnName;
            public string DataType;
            public bool IsPrimaryKey;
        }

        public static SqlConnection sqlConnection;
        public static bool newUser;
        public static UserAccess modifiedUser;
        public string devFilePath = @"C:\Users\htsco\OneDrive\DevProjects\";
        #endregion

        #region "Global Functions"

        public FormMain()
        {
            InitializeComponent();
        }

        public bool blnCloseApp = false;

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            blnCloseApp = true;
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blnCloseApp == true)
            {
                //allow application to close
            }
            else
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void ButtonDevTasks_Click(object sender, EventArgs e)
        {
            FormDevTasks f = new FormDevTasks();
            f.ShowDialog();
            ButtonRefreshData_Click(null, null);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            try
            {
                notifyIcon1.Visible = false;

                ButtonRefreshData_Click(null, null);

                this.Text = "DevConsole - " + GlobalCode.oUser.FirstName + " " + GlobalCode.oUser.LastName;

                if (GlobalCode.oUser.ErrorLogs == false && GlobalCode.oUser.Username != "htscott98")
                {
                    tabControl1.TabPages.Remove(TabErrorLogs);
                }

                if (GlobalCode.oUser.Repositories == false && GlobalCode.oUser.Username != "htscott98")
                {
                    tabControl1.TabPages.Remove(TabRepositories);
                }

                if (GlobalCode.oUser.CodeBuilder == false && GlobalCode.oUser.Username != "htscott98")
                {
                    tabControl1.TabPages.Remove(TabCodeBuilder);
                }

                if (GlobalCode.oUser.Access == false && GlobalCode.oUser.Username != "htscott98")
                {
                    tabControl1.TabPages.Remove(TabAccess);
                }

                ButtonRefreshData.Select();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

        }

        private void ButtonRefreshData_Click(object sender, EventArgs e)
        {
            FillErrorsTable(); //adding data to errors DG
            FillAccessTable(); //adding data to access DG
            FillDatabaseCombo(); //adding data to code builder combo database
            FillReposTable(); //adding data to repos DG
        }

        private void ButtonBrowseCode_Click(object sender, EventArgs e)
        {
            FormCodeSearch f = new FormCodeSearch();
            f.ShowDialog();
            ButtonRefreshData_Click(null, null);
        }


        #endregion

        #region "ErrorsTab"


        private void DataGridViewErrors_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewErrors.ClearSelection();
        }

        private void DataGridViewErrors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewErrors.SelectedRows.Count == 0)
                {
                    return;
                }


                EnableErrorControls();
                int id = Convert.ToInt32(DataGridViewErrors.SelectedRows[0].Cells["ID"].Value);
                Errors o = new Errors();
                o = Errors.GetObjectByID(id);
                if (o != null)
                {
                    TextBoxApplicationName.Text = o.ApplicationName;
                    TextBoxHelpLink.Text = o.HelpLink;
                    TextBoxInnerException.Text = o.InnerException;
                    TextBoxMessage.Text = o.Message;
                    TextBoxSource.Text = o.Source;
                    TextBoxStackTrace.Text = o.StackTrace;
                    TextBoxTimestamp.Text = o.DateTime.ToString();
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                FillErrorsTable();
            }
        }

        public void FillErrorsTable()
        {
            string sql = "SELECT ID, ApplicationName, DateTime FROM DevConsoleErrors";
            DataTable dt;
            dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), sql);
            DataGridViewErrors.DataSource = dt;
            DataGridViewErrors.ClearSelection();
            DataGridViewErrors.Update();
            SetDisplayPropertiesErrorsTable();
        }

        public void SetDisplayPropertiesErrorsTable()
        {
            DataGridViewErrors.Columns["ID"].Visible = false;
            DataGridViewErrors.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewErrors.AllowUserToAddRows = false;
            DataGridViewErrors.AllowUserToDeleteRows = false;
            DataGridViewErrors.AllowUserToResizeColumns = false;
            DataGridViewErrors.AllowUserToResizeRows = false;
            DataGridViewErrors.AllowUserToOrderColumns = false;
            DataGridViewErrors.MultiSelect = true;
            DataGridViewErrors.ReadOnly = true;
            DataGridViewErrors.RowHeadersVisible = false;
            DataGridViewErrors.AllowUserToResizeColumns = true;
            DataGridViewErrors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void ButtonDeleteSelectedErrors_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridViewErrors.SelectedRows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("Select an error to delete", MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in DataGridViewErrors.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    Errors o = new Errors();
                    o.ID = id;
                    o.DeleteRecord();
                }

                FillErrorsTable();
                GlobalCode.ShowMSGBox("Successfully deleted selected errors");
                ClearErrorControls();
                DisableErrorControls();
                return;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public void EnableErrorControls()
        {
            TextBoxApplicationName.Enabled = true;
            TextBoxHelpLink.Enabled = true;
            TextBoxInnerException.Enabled = true;
            TextBoxMessage.Enabled = true;
            TextBoxSource.Enabled = true;
            TextBoxStackTrace.Enabled = true;
            TextBoxTimestamp.Enabled = true;
        }

        public void DisableErrorControls()
        {
            TextBoxApplicationName.Enabled = false;
            TextBoxHelpLink.Enabled = false;
            TextBoxInnerException.Enabled = false;
            TextBoxMessage.Enabled = false;
            TextBoxSource.Enabled = false;
            TextBoxStackTrace.Enabled = false;
            TextBoxTimestamp.Enabled = false;
        }

        public void ClearErrorControls()
        {
            TextBoxApplicationName.Text = "";
            TextBoxHelpLink.Text = "";
            TextBoxInnerException.Text = "";
            TextBoxMessage.Text = "";
            TextBoxSource.Text = "";
            TextBoxStackTrace.Text = "";
            TextBoxTimestamp.Text = "";
        }

        private void ButtonClearErrorBoxes_Click(object sender, EventArgs e)
        {
            ClearErrorControls();
            DisableErrorControls();
        }


        #endregion

        #region "ReposTab"

        private void ComboBoxProjectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillReposTable();
        }

        private void ButtonNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                FormNewRepo f = new FormNewRepo();
                f.newRepo = true;
                f.ShowDialog();
                ButtonRefreshData_Click(null, null);


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void FillReposTable()
        {
            DataTable dt = new DataTable();
            dt = Repos.GetDataTable(ComboBoxProjectStatus.Text);

            DataGridViewRepos.DataSource = dt;

            SetDisplayPropertiesReposTable();

        }

        public void SetDisplayPropertiesReposTable()
        {
            DataGridViewRepos.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewRepos.AllowUserToAddRows = false;
            DataGridViewRepos.AllowUserToDeleteRows = false;
            DataGridViewRepos.AllowUserToResizeColumns = false;
            DataGridViewRepos.AllowUserToResizeRows = false;
            DataGridViewRepos.AllowUserToOrderColumns = false;
            DataGridViewRepos.MultiSelect = true;
            DataGridViewRepos.ReadOnly = true;
            DataGridViewRepos.RowHeadersVisible = false;
            DataGridViewRepos.AllowUserToResizeColumns = true;
            DataGridViewRepos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewRepos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewRepos.Columns["ID"].Visible = false;
            this.DataGridViewRepos.Columns["Description"].Visible = false;
        }

        private void DataGridViewRepos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewRepos.ClearSelection();
        }

        private void DataGridViewRepos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewRepos.SelectedRows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("Select a repo to open.", MessageBoxIcon.Error);
                    return;
                }


                Repos o = new Repos();
                o = Repos.GetObjectByID(Convert.ToInt32(DataGridViewRepos.SelectedRows[0].Cells["ID"].Value));
                FormNewRepo repos = new FormNewRepo();
                repos.repository = o;
                repos.newRepo = false;
                repos.ShowDialog();
                ButtonRefreshData_Click(null, null);
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }


        }

        #endregion

        #region "CodeBuilderTab"

        private void ComboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDatabase.Text == "")
            {
                ComboBoxTableName.Items.Clear();
                return;
            }

            string db = ComboBoxDatabase.Text;

            string sql = "SELECT * FROM Sys.Tables ORDER BY Name ASC";

            Assembly a = Assembly.Load("MasterCode");
            // Get the type to use.
            Type myType = a.GetType("MasterCode.Connection");
            // Get the method to call.
            MethodInfo myMethod = myType.GetMethod("Init" + ComboBoxDatabase.Text + "Connection");
            // Create an instance. 
            object obj = Activator.CreateInstance(myType);
            // Execute the method.
            sqlConnection = (SqlConnection)myMethod.Invoke(obj, null);

            DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(sqlConnection, sql);

            if (dt.Rows.Count > 0)
            {
                ComboBoxTableName.Items.Clear();
                ComboBoxTableName.Items.Add("");

                foreach (DataRow row in dt.Rows)
                {
                    ComboBoxTableName.Items.Add(row["name"].ToString());
                }

            }


        }

        private void FillDatabaseCombo()
        {
            string sql = "select * from sys. databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
            DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitServerConnection(), sql);

            if (dt.Rows.Count > 0)
            {
                ComboBoxDatabase.Items.Clear();
                ComboBoxDatabase.Items.Add("");

                foreach (DataRow row in dt.Rows)
                {
                    ComboBoxDatabase.Items.Add(row["name"].ToString());
                }
            }

        }

        private void ButtonResetBoxes_Click(object sender, EventArgs e)
        {
            ComboBoxDatabase.Text = "";
            ComboBoxTableName.Text = "";
            TextBoxClassName.Text = "";
            TextBoxNamespace.Text = "";
            comboBoxSqlClient.Text = "";
            RichTextBoxCode.Text = "";

        }

        private void ButtonBuildClass_Click(object sender, EventArgs e)
        {

            if (ComboBoxDatabase.Text == "" || ComboBoxTableName.Text == "" || TextBoxClassName.Text == "" || TextBoxNamespace.Text == "" || comboBoxSqlClient.Text == "")
            {
                return;
            }


            string singleNewLine = Environment.NewLine;
            string doubleNewLine = singleNewLine + singleNewLine;

            try
            {
                string code = "";
                code += "using System;" + singleNewLine;
                code += "using System.Data;" + singleNewLine;
                code += "using System.Collections.Generic;" + singleNewLine;
                code += "using " + TextBoxNamespace.Text + ";" + singleNewLine;
                code += "using System.Windows.Forms;" + doubleNewLine;
                code += "namespace " + TextBoxNamespace.Text + singleNewLine;
                code += "{" + doubleNewLine;

                code += "public class " + TextBoxClassName.Text + singleNewLine;
                code += "{" + doubleNewLine;

                List<ColumnData> ListOfColumns = GetColumnNamesAndDataTypes();

                code += BuildDeclarationsAndProperties(ref ListOfColumns);
                code += BuildConstructors(ref ListOfColumns);
                code += BuildOverrideStatement();

                code += "#region \" Private Methods \"\n\n";

                code += BuildSQLSelectStatement(ListOfColumns);

                code += "#endregion\n\n";
                code += "#region \" Public Methods \"\n\n";

                code += BuildReturnDT();
                code += BuildReturnObjectList();
                code += BuildInsertStatement(ref ListOfColumns);
                code += BuildUpdateStatement(ref ListOfColumns);
                code += BuildDeleteStatement(ref ListOfColumns);

                code += "}" + singleNewLine;
                code += "}";

                RichTextBoxCode.Text = "";
                RichTextBoxCode.Text = code;
                RichTextBoxCode.Focus();
                Clipboard.Clear();
                Clipboard.SetText(code);


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private List<ColumnData> GetColumnNamesAndDataTypes()
        {
            List<ColumnData> ListColumnData = new List<ColumnData>();

            string strSQL = "";

            if (ComboBoxTableName.Text.Contains(".dbo."))
            {
                string[] stringSeparators = new string[] { ".dbo." };
                strSQL = " Use " + ComboBoxTableName.Text.Split(stringSeparators, StringSplitOptions.None)[0] + " ";
            }


            strSQL += " SELECT " +
                 "c.[name] 'ColumnName', " +
                 "[DataType] = " +
                 "case " +
                 "when t.[name] = 'bit' then 'bool' " +
                 "when t.[name] = 'varchar' then 'string' " +
                 "when t.[name] = 'nvarchar' then 'string' " +
                 "when t.[name] = 'varbinary' then 'byte[]' " +
                 "when t.[name] = 'money' then 'float' " +
                 "when t.[name] = 'datetime' then 'DateTime' " +
                 "when t.[name] = 'date' then 'DateTime' " +
                 "when t.[name] = 'smalldatetime' then 'DateTime' " +
                 "when t.[name] = 'char' then 'string' " +
                 "when t.[name] = 'smallint' then 'int' " +
                 "when t.[name] = 'tinyint' then 'int' " +
                 "else t.[name] " +
                 "end, " +
                 "ISNULL(i.is_primary_key, 0) 'PrimaryKey' " +
                 "FROM sys.columns c " +
                 "INNER JOIN sys.types t ON c.user_type_id = t.user_type_id " +
                 "LEFT OUTER JOIN sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id " +
                 "LEFT OUTER JOIN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id " +
                 "WHERE c.object_id = OBJECT_ID('" + ComboBoxTableName.Text + "') ";


            Assembly a = Assembly.Load("MasterCode");
            // Get the type to use.
            Type myType = a.GetType("MasterCode.Connection");
            // Get the method to call.
            MethodInfo myMethod = myType.GetMethod("Init" + ComboBoxDatabase.Text + "Connection");
            // Create an instance. 
            object obj = Activator.CreateInstance(myType);
            // Execute the method.
            sqlConnection = (SqlConnection)myMethod.Invoke(obj, null);

            DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(sqlConnection, strSQL);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    ColumnData structCD = new ColumnData();

                    structCD.ColumnName = r["ColumnName"].ToString();
                    structCD.DataType = r["DataType"].ToString();
                    structCD.IsPrimaryKey = Convert.ToBoolean(r["PrimaryKey"].ToString());

                    ListColumnData.Add(structCD);
                }
            }

            return ListColumnData;
        }

        private string BuildDeclarationsAndProperties(ref List<ColumnData> ListOfColumns)
        {

            string code = "";

            code += "#region \" Declarations \"\n\n";

            foreach (ColumnData cd in ListOfColumns)
                code += "private " + cd.DataType + " _" + cd.ColumnName + ";\n";

            code += "\n#endregion\n";

            code += "\n";


            code += "#region \" Properties \"\n\n";
            foreach (ColumnData cd in ListOfColumns)
                code += "public " + cd.DataType + " " + cd.ColumnName + " { get { return _" + cd.ColumnName + "; } set { _" + cd.ColumnName + " = value; } } \n";


            code += "\n#endregion\n\n";


            return code;

        }

        private string BuildConstructors(ref List<ColumnData> ListOfColumns)
        {

            string code = "";

            code += "#region \" Constructors \"\n\n";

            // This first loop builds the basic constructor
            // which sets all the attributes to their default 
            // values of empty string, 0, or null.
            code += "public " + TextBoxClassName.Text + "() \n{\n";

            foreach (ColumnData cd in ListOfColumns)
            {
                code += "_" + cd.ColumnName + " = ";

                switch (cd.DataType)
                {
                    case "bool":
                        code += "false";
                        break;

                    case "DateTime":
                        code += "Convert.ToDateTime(\"1/1/1900\")";
                        break;

                    case "float":
                        code += "0.0F";
                        break;

                    case "string":
                        code += "string.Empty";
                        break;

                    case "int":
                        code += "0";
                        break;

                    case "byte[]":
                        code += "null";
                        break;

                    case "decimal":
                        code += "0";
                        break;
                }

                code += ";\n";
            }

            code += "}\n\n";


            // The second constructor will build the object
            // with row data from the table this object represents.
            code += "public " + TextBoxClassName.Text + "(DataRow row)\n{\n";

            foreach (ColumnData cd in ListOfColumns)
            {
                switch (cd.DataType)
                {
                    case "bool":
                        code += "_" + cd.ColumnName + " = Convert.ToBoolean(row[\"" + cd.ColumnName + "\"].ToString());\n";
                        break;

                    case "DateTime":
                        code += "_" + cd.ColumnName + " = Convert.ToDateTime(row[\"" + cd.ColumnName + "\"].ToString());\n";
                        break;

                    case "float":
                        code += "_" + cd.ColumnName + " = Convert.ToDouble(row[\"" + cd.ColumnName + "\"].ToString());\n";
                        break;

                    case "string":
                        code += "_" + cd.ColumnName + " = row[\"" + cd.ColumnName + "\"].ToString();\n";
                        break;

                    case "int":
                        code += "_" + cd.ColumnName + " = Convert.ToInt32(row[\"" + cd.ColumnName + "\"].ToString());\n";
                        break;

                    case "byte[]":
                        code += "_" + cd.ColumnName + " = (byte[])row[\"" + cd.ColumnName + "\"];\n";
                        break;

                    case "decimal":
                        code += "_" + cd.ColumnName + " = (Decimal)(row[\"" + cd.ColumnName + "\"]);\n";
                        break;
                }
            }
            code += "}\n\n";


            // The third constructor will build the object
            // with row DataGridViewRow from the table this object represents.
            code += "public " + TextBoxClassName.Text + "(DataGridViewRow row)\n{\n";

            foreach (ColumnData cd in ListOfColumns)
            {
                switch (cd.DataType)
                {
                    case "bool":
                        code += "_" + cd.ColumnName + " = Convert.ToBoolean(row.Cells[\"" + cd.ColumnName + "\"].Value.ToString());\n";
                        break;

                    case "DateTime":
                        code += "_" + cd.ColumnName + " = Convert.ToDateTime(row.Cells[\"" + cd.ColumnName + "\"].Value.ToString());\n";
                        break;

                    case "float":
                        code += "_" + cd.ColumnName + " = Convert.ToDouble(row.Cells[\"" + cd.ColumnName + "\"].Value.ToString());\n";
                        break;

                    case "string":
                        code += "_" + cd.ColumnName + " = row.Cells[\"" + cd.ColumnName + "\"].Value.ToString();\n";
                        break;

                    case "int":
                        code += "_" + cd.ColumnName + " = Convert.ToInt32(row.Cells[\"" + cd.ColumnName + "\"].Value.ToString());\n";
                        break;

                    case "byte[]":
                        code += "_" + cd.ColumnName + " = (byte[])row.Cells[\"" + cd.ColumnName + "\"].Value.ToString());\n";
                        break;

                    case "decimal":
                        code += "_" + cd.ColumnName + " = (Decimal)row.Cells[\"" + cd.ColumnName + "\"].Value;\n";
                        break;
                }
            }
            code += "}\n\n";

            code += "#endregion\n\n";


            return code;

        }

        private string BuildOverrideStatement()
        {

            string code = "";

            code += "#region \" Overrides \"\n\n";

            code += "public override string ToString()\n{\nreturn \"\";\n}\n\n";


            code += "#endregion\n\n";

            return code;

        }

        private string BuildSQLSelectStatement(List<ColumnData> ListOfColumns)
        {

            string code = "";

            code += "private static string GetSQLSelect()\n{\n";
            code += "string strReturnValue;\n";
            code += "strReturnValue = \" SELECT ";

            foreach (ColumnData cd in ListOfColumns)
            {
                code += cd.ColumnName + ", ";
            }
            code = code.Substring(0, code.Length - 2);
            code += " \";\n";
            code += "return strReturnValue;\n}\n\n";

            return code;

        }

        private string BuildReturnDT()
        {

            string code = "";

            code +=
                "public static DataTable GetDataTable()\n" +
                "{\n" +
                 "string strSQL = \"\";\n" +
                 "DataTable dt = null;\n\n" +
                 "try\n{\n" +
                "strSQL = GetSQLSelect() + \n" +
                "\"FROM " + ComboBoxTableName.Text + "\";\n\n" +
                "dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL);\n\n" +
                 "}\ncatch (Exception ex)\n{\nGlobalCode.ExceptionHandler(ex);\n}\n\n" +
            "return dt;\n}\n\n";

            return code;

        }

        private string BuildReturnObjectList()
        {

            string code = "";

            code +=
                "public static List<" + TextBoxClassName.Text + "> GetListOfObjects()\n" +
                "{\n" +
                 "List<" + TextBoxClassName.Text + "> objList = new List<" + TextBoxClassName.Text + ">();\n" +
                "string strSQL = \"\";\n" +
            "try\n{\n" +
                "strSQL = GetSQLSelect() + \n" +
                "\"FROM " + ComboBoxTableName.Text + "\";\n\n" +
                "DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL);\n\n" +
                "if (dt.Rows.Count > 0)\n" +
                "{\n" +
                "foreach (DataRow r in dt.Rows)\n" +
                "{\n" +
                TextBoxClassName.Text + " obj = new " + TextBoxClassName.Text + "(r);\n\n" +
                "if (obj != null)\n" +
                "objList.Add(obj);\n" +
                "}\n}\n" +
                 "}\ncatch (Exception ex)\n{\nGlobalCode.ExceptionHandler(ex);\n}\n\n" +
            "return objList;\n}\n\n";

            return code;

        }

        private string BuildInsertStatement(ref List<ColumnData> ListOfColumns)
        {
            string code = "";


            code +=
                           "public bool InsertRecord()\n{\n" +
                           "string strSQL =\"\";\n" +
                           "bool b = false;\n" +
                           "try\n{\n";

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code += "List<Microsoft.Data.SqlClient.SqlParameter> Params = new List<Microsoft.Data.SqlClient.SqlParameter>\n";
                code += "                   {\n";
            }
            else
            {
                code += "Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();\n\n";
            }


            foreach (ColumnData cd in ListOfColumns)
            {
                // We're skipping the PK. Traditionally this is
                // handled exclusively by SQL unless we have a
                // very specific need for this functionality.
                if (!cd.IsPrimaryKey)
                {
                    if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
                    {
                        code += "                   new Microsoft.Data.SqlClient.SqlParameter(\"@" + cd.ColumnName + "\", _" + cd.ColumnName;

                        // Convert non string types to string.
                        if (cd.DataType != "string")
                        {
                            code += ".ToString()";
                        }


                        code += "),\n";
                    }
                    else
                    {
                        code += "keyValuePairs.Add(\"@" + cd.ColumnName + "\", _" + cd.ColumnName;

                        // Convert non string types to string.
                        if (cd.DataType != "string")
                            code += ".ToString()";

                        code += ");\n";
                    }
                }
            }

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code = code.Remove(code.Trim().Length - 1, 1);
                code += "                   a};\n\n";
            }

            code += "strSQL = \"INSERT INTO " + ComboBoxTableName.Text + " (\"+\n\"";

            int i = 0; // Current column count.
            int MaxColumns = 7;

            foreach (ColumnData cd in ListOfColumns)
            {
                i++;

                if (!cd.IsPrimaryKey)
                {
                    code += cd.ColumnName + ",";
                }


                if (i % MaxColumns == 0)
                {
                    code += "\" +\n\"";
                    i = 0;
                }
            }

            code = code.Substring(0, code.Length - 1);
            code += ")\" +\n\" VALUES (";

            i = 0; // Reset current column count.

            foreach (ColumnData cd in ListOfColumns)
            {
                i++;

                if (!cd.IsPrimaryKey)
                {
                    code += "@" + cd.ColumnName + ",";
                }


                if (i % MaxColumns == 0)
                {
                    code += "\" +\n\"";
                    i = 0;
                }
            }

            // Access modifier.
            code = code.Substring(0, code.Length - 1) + ")\";\n";

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code += "b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL, Params);\n}\n\n";
            }
            else
            {
                code += "b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL, keyValuePairs);\n}\n\n";
            }

            code += "\ncatch (Exception ex)\n{" +
                "\nGlobalCode.ExceptionHandler(ex);\n" +
                "\nb = false;\n}\n\n" +
                "return b;\n}\n\n";

            return code;


        }

        private string BuildUpdateStatement(ref List<ColumnData> ListOfColumns)
        {
            string code = "";

            code +=
                "public bool UpdateRecord()\n{\n" +
                "string strSQL =\"\";\n" +
                "bool b = false;\n" +
                "try\n{\n";

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code += "List<Microsoft.Data.SqlClient.SqlParameter> Params = new List<Microsoft.Data.SqlClient.SqlParameter>\n";
                code += "                   {\n";
            }
            else
            {
                code += "Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();\n\n";
            }




            foreach (ColumnData cd in ListOfColumns)
            {
                if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
                {
                    code += "                   new Microsoft.Data.SqlClient.SqlParameter(\"@" + cd.ColumnName + "\", _" + cd.ColumnName;

                    // Convert non string types to string.
                    if (cd.DataType != "string")
                    {
                        code += ".ToString()";
                    }


                    code += "),\n";
                }
                else
                {
                    code += "keyValuePairs.Add(\"@" + cd.ColumnName + "\", _" + cd.ColumnName;

                    // Convert non string types to string.
                    if (cd.DataType != "string")
                        code += ".ToString()";

                    code += ");\n";
                }
            }

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code = code.Remove(code.Trim().Length - 1, 1);
                code += "                   };\n\n";
            }

            code += "strSQL = \"UPDATE " + ComboBoxTableName.Text + " \"+\n\"SET ";

            int i = 0; // Current column count.
            int MaxColumns = 5;

            foreach (ColumnData cd in ListOfColumns)
            {
                i++;

                if (!cd.IsPrimaryKey)
                    code += cd.ColumnName + "=@" + cd.ColumnName + ", ";

                if (i % MaxColumns == 0)
                {
                    code += "\" +\n\"";
                    i = 0;
                }
            }

            code = code.Substring(0, code.Length - 1) + " ";

            if (code.EndsWith(", "))
            {
                // remove , 
                code = code.Remove(code.Length - 2) + " ";
            }

            code += "\"+\n\"WHERE " + ListOfColumns[0].ColumnName + " = @" + ListOfColumns[0].ColumnName + " \";\n\n";

            if (comboBoxSqlClient.Text.ToLower().StartsWith("micro") == true)
            {
                code += "b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL, Params);\n\n}";
            }
            else
            {
                code += "b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL, keyValuePairs);\n\n}";
            }

            code += "\ncatch (Exception ex)\n{" +
            "\nGlobalCode.ExceptionHandler(ex);\n" +
            "\nb = false;\n}\n\n" +
            "return b;\n}\n\n";

            return code;


        }

        private string BuildDeleteStatement(ref List<ColumnData> ListOfColumns)
        {

            string code = "";

            code +=
                "public bool DeleteRecord()\n{\n" +
                "string strSQL = \"\";" +
                "\nbool b = false;\n\n" +
                "try\n{\n" +
                "strSQL = \"DELETE FROM " + ComboBoxTableName.Text + " \" + \n \"WHERE " + ListOfColumns[0].ColumnName + " = \" + _" + ListOfColumns[0].ColumnName + ";\n\n" +
                "b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.Init" + ComboBoxDatabase.Text + "Connection(), strSQL);\n\n}" +
                "\ncatch (Exception ex)\n{\nGlobalCode.ExceptionHandler(ex);\n}\n\nreturn b;\n}\n";

            code += "#endregion\n\n";

            return code;

        }

        #endregion

        #region "AccessTab"

        private void DataGridViewUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewUsers.ClearSelection();
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxFirstName.Text == "" || TextBoxLastName.Text == "")
                {
                    GlobalCode.ShowMSGBox("First Name and Last Name are both required fields.", MessageBoxIcon.Error);
                    return;
                }

                if (TextBoxUsername.Text == "" || TextBoxPassword.Text == "" || TextBoxVerifyPassword.Text == "")
                {
                    GlobalCode.ShowMSGBox("Username, Password, and Verify Password fields are all required fields.", MessageBoxIcon.Error);
                    return;
                }


                if (TextBoxPassword.Text != TextBoxVerifyPassword.Text)
                {
                    GlobalCode.ShowMSGBox("Password fields do not match.", MessageBoxIcon.Error);
                    return;
                }

                UserAccess o = new UserAccess();
                if (modifiedUser != null) {

                    o = modifiedUser;

                }
                o.FirstName = TextBoxFirstName.Text;
                o.LastName = TextBoxLastName.Text;
                o.DOB = TextBoxDOB.Text;
                o.PrimaryEmail = TextBoxPrimaryEmail.Text;
                o.SecondaryEmail = TextBoxSecondaryEmail.Text;
                o.PrimaryPhone = TextBoxPrimaryPhone.Text;
                o.SecondaryPhone = TextBoxSecondaryPhone.Text;
                o.Address = TextBoxAddress.Text;
                o.ErrorLogs = CheckBoxErrorLogs.Checked;
                o.Repositories = CheckBoxRepos.Checked;
                o.CodeBuilder = CheckBoxCodeBuilder.Checked;
                o.Access = CheckBoxAccess.Checked;
                o.Username = TextBoxUsername.Text;
                o.Password = TextBoxPassword.Text;

                if (newUser == true)
                {
                    o.DateAdded = DateTime.Now;
                    o.LastModified = DateTime.Now;
                }
                else
                {
                    o.LastModified = DateTime.Now;
                }

                o.Enabled = true;

                if (newUser == true)
                {
                    if (o.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        ClearAccessControls();
                        DisableAccessControls();
                        FillAccessTable();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data.", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (o.UpdateRecord(modifiedUser.ID) == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        ClearAccessControls();
                        DisableAccessControls();
                        FillAccessTable();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data.", MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }



        }

        private void ButtonNewUser_Click(object sender, EventArgs e)
        {
            newUser = true;
            EnableAccessControls();
        }

        private void DataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                newUser = false;
                EnableAccessControls();
                int id = Convert.ToInt32(DataGridViewUsers.SelectedRows[0].Cells["ID"].Value);
                modifiedUser = UserAccess.GetObjectByID(id);
                if (modifiedUser != null)
                {
                    TextBoxFirstName.Text = modifiedUser.FirstName;
                    TextBoxLastName.Text = modifiedUser.LastName;
                    TextBoxDOB.Text = modifiedUser.DOB;
                    TextBoxPrimaryEmail.Text = modifiedUser.PrimaryEmail;
                    TextBoxSecondaryEmail.Text = modifiedUser.SecondaryEmail;
                    TextBoxPrimaryPhone.Text = modifiedUser.PrimaryPhone;
                    TextBoxSecondaryPhone.Text = modifiedUser.SecondaryPhone;
                    TextBoxAddress.Text = modifiedUser.Address;
                    CheckBoxRepos.Checked = modifiedUser.Repositories;
                    CheckBoxErrorLogs.Checked = modifiedUser.ErrorLogs;
                    CheckBoxCodeBuilder.Checked = modifiedUser.CodeBuilder;
                    CheckBoxAccess.Checked = modifiedUser.Access;
                    TextBoxUsername.Text = modifiedUser.Username;
                    TextBoxPassword.Text = modifiedUser.Password;
                    TextBoxVerifyPassword.Text = modifiedUser.Password;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public void EnableAccessControls()
        {
            TextBoxFirstName.Enabled = true;
            TextBoxLastName.Enabled = true;
            TextBoxDOB.Enabled = true;
            TextBoxPrimaryEmail.Enabled = true;
            TextBoxSecondaryEmail.Enabled = true;
            TextBoxPrimaryPhone.Enabled = true;
            TextBoxSecondaryPhone.Enabled = true;
            TextBoxAddress.Enabled = true;
            GroupBoxAccess.Enabled = true;
            ButtonCancelUser.Enabled = true;
            ButtonSaveUser.Enabled = true;
            TextBoxUsername.Enabled = true;
            TextBoxPassword.Enabled = true;
            TextBoxVerifyPassword.Enabled = true;
        }

        public void DisableAccessControls()
        {
            TextBoxFirstName.Enabled = false;
            TextBoxLastName.Enabled = false;
            TextBoxDOB.Enabled = false;
            TextBoxPrimaryEmail.Enabled = false;
            TextBoxSecondaryEmail.Enabled = false;
            TextBoxPrimaryPhone.Enabled = false;
            TextBoxSecondaryPhone.Enabled = false;
            TextBoxAddress.Enabled = false;
            GroupBoxAccess.Enabled = false;
            ButtonCancelUser.Enabled = false;
            ButtonSaveUser.Enabled = false;
            TextBoxUsername.Enabled = false;
            TextBoxPassword.Enabled = false;
            TextBoxVerifyPassword.Enabled = false;
        }

        public void ClearAccessControls()
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxDOB.Text = "";
            TextBoxPrimaryEmail.Text = "";
            TextBoxSecondaryEmail.Text = "";
            TextBoxPrimaryPhone.Text = "";
            TextBoxSecondaryPhone.Text = "";
            TextBoxAddress.Text = "";
            CheckBoxErrorLogs.Checked = false;
            CheckBoxRepos.Checked = false;
            CheckBoxCodeBuilder.Checked = false;
            CheckBoxAccess.Checked = false;
            TextBoxUsername.Text = "";
            TextBoxPassword.Text = "";
            TextBoxVerifyPassword.Text = "";
        }

        public void FillAccessTable()
        {
            try
            {
                string sql = "SELECT ID, CONCAT(FirstName, ' ' ,LastName) as FullName, DateAdded FROM DevConsoleUsers WHERE Enabled = 1";
                DataTable dt;
                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), sql);
                DataGridViewUsers.DataSource = dt;
                DataGridViewUsers.ClearSelection();
                DataGridViewUsers.Update();
                SetDisplayPropertiesAccessTable();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public void SetDisplayPropertiesAccessTable()
        {
            DataGridViewUsers.Columns["ID"].Visible = false;
            DataGridViewUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DataGridViewUsers.AllowUserToAddRows = false;
            DataGridViewUsers.AllowUserToDeleteRows = false;
            DataGridViewUsers.AllowUserToResizeColumns = false;
            DataGridViewUsers.AllowUserToResizeRows = false;
            DataGridViewUsers.AllowUserToOrderColumns = false;
            DataGridViewUsers.MultiSelect = true;
            DataGridViewUsers.ReadOnly = true;
            DataGridViewUsers.RowHeadersVisible = false;
            DataGridViewUsers.AllowUserToResizeColumns = true;
            DataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridViewUsers.SelectedRows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("Select a user to delete", MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in DataGridViewUsers.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    UserAccess o = new UserAccess();
                    o.ID = id;
                    o.DeleteRecord();
                }

                FillAccessTable();
                GlobalCode.ShowMSGBox("Successfully deleted selected users");
                return;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

        }

        private void ButtonCancelUser_Click(object sender, EventArgs e)
        {
            ClearAccessControls();
            DisableAccessControls();
        }
















        #endregion


    }
}
