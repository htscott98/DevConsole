using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class DevTaskTasks
    {

        #region " Declarations "

        private int _ID;
        private string _Name;
        private string _DisplayOrder;
        private int _TaskListID;
        private string _Description;
        private bool _Enabled;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }
        public int TaskListID { get { return _TaskListID; } set { _TaskListID = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }

        #endregion

        #region " Constructors "

        public DevTaskTasks()
        {
            _ID = 0;
            _Name = string.Empty;
            _DisplayOrder = string.Empty;
            _TaskListID = 0;
            _Description = string.Empty;
            _Enabled = false;
        }

        public DevTaskTasks(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _Name = row["Name"].ToString();
            _DisplayOrder = row["DisplayOrder"].ToString();
            _TaskListID = Convert.ToInt32(row["TaskListID"].ToString());
            _Description = row["Description"].ToString();
            _Enabled = Convert.ToBoolean(row["Enabled"].ToString());
        }

        public DevTaskTasks(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _Name = row.Cells["Name"].Value.ToString();
            _DisplayOrder = row.Cells["DisplayOrder"].Value.ToString();
            _TaskListID = Convert.ToInt32(row.Cells["TaskListID"].Value.ToString());
            _Description = row.Cells["Description"].Value.ToString();
            _Enabled = Convert.ToBoolean(row.Cells["Enabled"].Value.ToString());
        }

        #endregion

        #region " Overrides "

        public override string ToString()
        {
            return "";
        }

        #endregion

        #region " Private Methods "

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = " SELECT ID, Name, DisplayOrder, TaskListID, Description, Enabled ";
            return strReturnValue;
        }

        #endregion

        #region " Public Methods "

        public static DataTable GetDataTable()
        {
            string strSQL = "";
            DataTable dt = null;

            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskTasks " +
                "ORDER BY Convert(int, DisplayOrder) ASC";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<DevTaskTasks> GetListOfObjects()
        {
            List<DevTaskTasks> objList = new List<DevTaskTasks>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskTasks";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskTasks obj = new DevTaskTasks(r);

                        if (obj != null)
                            objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return objList;
        }

        public static List<DevTaskTasks> GetListOfObjectsByListID(string listID)
        {
            List<DevTaskTasks> objList = new List<DevTaskTasks>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskTasks " +
                "WHERE Enabled = 1 AND TaskListID = " + listID + " " +
                "ORDER BY Convert(int, DisplayOrder) ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskTasks obj = new DevTaskTasks(r);

                        if (obj != null)
                            objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return objList;
        }

        public static DevTaskTasks GetObjectByID(string taskID)
        {
            DevTaskTasks obj = new DevTaskTasks();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskTasks WHERE ID = '" + taskID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new DevTaskTasks(r);

                        if (obj != null)
                        {
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return obj;
        }

        public bool InsertRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@Name", _Name);
                keyValuePairs.Add("@DisplayOrder", "0");
                keyValuePairs.Add("@TaskListID", _TaskListID.ToString());
                keyValuePairs.Add("@Description", _Description);
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskTasks (" +
                "Name,DisplayOrder,TaskListID,Description,Enabled)" +
                " VALUES (@Name,@DisplayOrder,@TaskListID,@Description,@Enabled)";
                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);
            }


            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);

                b = false;
            }

            return b;
        }

        public bool UpdateRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@Name", _Name);
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder);
                keyValuePairs.Add("@TaskListID", _TaskListID.ToString());
                keyValuePairs.Add("@Description", _Description);
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "UPDATE DevConsoleDevTaskTasks " +
                "SET Name=@Name, DisplayOrder=@DisplayOrder, TaskListID=@TaskListID, Description=@Description, " +
                "Enabled=@Enabled " +
                "WHERE ID = @ID ";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);

                b = false;
            }

            return b;
        }

        public bool UpdateTaskList()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@TaskListID", _TaskListID.ToString());
                strSQL = "UPDATE DevConsoleDevTaskTasks " +
                "SET TaskListID=@TaskListID " +
                "WHERE ID = @ID ";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);

                b = false;
            }

            return b;
        }

        public bool UpdateDisplayOrder()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder);
                strSQL = "UPDATE DevConsoleDevTaskTasks " +
                "SET DisplayOrder=@DisplayOrder " +
                "WHERE ID = @ID ";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);

                b = false;
            }

            return b;
        }

        public bool DeleteRecord()
        {
            string strSQL = "";
            bool b = false;

            try
            {
                strSQL = "DELETE FROM DevConsoleDevTaskTasks " +
                 "WHERE ID = " + _ID;

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return b;
        }

        public bool DeleteRecordByTaskListID()
        {
            string strSQL = "";
            bool b = false;

            try
            {
                strSQL = "DELETE FROM DevConsoleDevTaskTasks " +
                 "WHERE TaskListID = " + _TaskListID;

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return b;
        }
        #endregion

    }
}