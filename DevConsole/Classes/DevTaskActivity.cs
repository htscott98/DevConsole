using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class DevTaskActivity
    {

        #region " Declarations "

        private int _ID;
        private int _TaskID;
        private string _Activity;
        private DateTime _Timestamp;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public int TaskID { get { return _TaskID; } set { _TaskID = value; } }
        public string Activity { get { return _Activity; } set { _Activity = value; } }
        public DateTime Timestamp { get { return _Timestamp; } set { _Timestamp = value; } }

        #endregion

        #region " Constructors "

        public DevTaskActivity()
        {
            _ID = 0;
            _TaskID = 0;
            _Activity = string.Empty;
            _Timestamp = Convert.ToDateTime("1/1/1900");
        }

        public DevTaskActivity(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _TaskID = Convert.ToInt32(row["TaskID"].ToString());
            _Activity = row["Activity"].ToString();
            _Timestamp = Convert.ToDateTime(row["Timestamp"].ToString());
        }

        public DevTaskActivity(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _TaskID = Convert.ToInt32(row.Cells["TaskID"].Value.ToString());
            _Activity = row.Cells["Activity"].Value.ToString();
            _Timestamp = Convert.ToDateTime(row.Cells["Timestamp"].Value.ToString());
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
            strReturnValue = " SELECT ID, TaskID, Activity, Timestamp ";
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
                "FROM DevConsoleDevTaskActivity";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<DevTaskActivity> GetListOfObjects()
        {
            List<DevTaskActivity> objList = new List<DevTaskActivity>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskActivity";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskActivity obj = new DevTaskActivity(r);

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

        public static List<DevTaskActivity> GetListOfObjectsByTaskID(string taskID)
        {
            List<DevTaskActivity> objList = new List<DevTaskActivity>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskActivity " +
                "WHERE TaskID = '" + taskID + "' " +
                "ORDER BY Timestamp DESC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskActivity obj = new DevTaskActivity(r);

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

        public bool InsertRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@TaskID", _TaskID.ToString());
                keyValuePairs.Add("@Activity", _Activity);
                keyValuePairs.Add("@Timestamp", _Timestamp.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskActivity (" +
                "TaskID,Activity,Timestamp)" +
                " VALUES (@TaskID,@Activity,@Timestamp)";
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
                keyValuePairs.Add("@TaskID", _TaskID.ToString());
                keyValuePairs.Add("@Activity", _Activity);
                keyValuePairs.Add("@Timestamp", _Timestamp.ToString());
                strSQL = "UPDATE DevConsoleDevTaskActivity " +
                "SET TaskID=@TaskID, Activity=@Activity, Timestamp=@Timestamp " +
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
                strSQL = "DELETE FROM DevConsoleDevTaskActivity " +
                 "WHERE ID = " + _ID;

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