using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class DevTaskAttachedLabels
    {

        #region " Declarations "

        private int _ID;
        private int _TaskID;
        private int _LabelID;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public int TaskID { get { return _TaskID; } set { _TaskID = value; } }
        public int LabelID { get { return _LabelID; } set { _LabelID = value; } }

        #endregion

        #region " Constructors "

        public DevTaskAttachedLabels()
        {
            _ID = 0;
            _TaskID = 0;
            _LabelID = 0;
        }

        public DevTaskAttachedLabels(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _TaskID = Convert.ToInt32(row["TaskID"].ToString());
            _LabelID = Convert.ToInt32(row["LabelID"].ToString());
        }

        public DevTaskAttachedLabels(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _TaskID = Convert.ToInt32(row.Cells["TaskID"].Value.ToString());
            _LabelID = Convert.ToInt32(row.Cells["LabelID"].Value.ToString());
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
            strReturnValue = " SELECT ID, TaskID, LabelID ";
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
                "FROM DevConsoleDevTaskAttachedLabels";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<DevTaskAttachedLabels> GetListOfObjects()
        {
            List<DevTaskAttachedLabels> objList = new List<DevTaskAttachedLabels>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskAttachedLabels";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskAttachedLabels obj = new DevTaskAttachedLabels(r);

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

        public static List<DevTaskAttachedLabels> GetListOfObjectsByTaskID(string taskID)
        {
            List<DevTaskAttachedLabels> objList = new List<DevTaskAttachedLabels>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskAttachedLabels " +
                "WHERE TaskID = '" + taskID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskAttachedLabels obj = new DevTaskAttachedLabels(r);

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
                keyValuePairs.Add("@LabelID", _LabelID.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskAttachedLabels (" +
                "TaskID,LabelID)" +
                " VALUES (@TaskID,@LabelID)";
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
                keyValuePairs.Add("@LabelID", _LabelID.ToString());
                strSQL = "UPDATE DevConsoleDevTaskAttachedLabels " +
                "SET TaskID=@TaskID, LabelID=@LabelID " +
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
                strSQL = "DELETE FROM DevConsoleDevTaskAttachedLabels " +
                 "WHERE ID = " + _ID;

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return b;
        }

        public bool DeleteRecordByTaskIDAndLabelID()
        {
            string strSQL = "";
            bool b = false;

            try
            {

                strSQL = "DELETE FROM DevConsoleDevTaskAttachedLabels " +
                 "WHERE TaskID = " + _TaskID + " AND LabelID = " + _LabelID;

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return b;
        }

        public bool DeleteRecordByLabelID()
        {
            string strSQL = "";
            bool b = false;

            try
            {

                strSQL = "DELETE FROM DevConsoleDevTaskAttachedLabels " +
                 "WHERE LabelID = " + _LabelID;

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return b;
        }

        public bool DeleteRecordByTaskID()
        {
            string strSQL = "";
            bool b = false;

            try
            {

                strSQL = "DELETE FROM DevConsoleDevTaskAttachedLabels " +
                 "WHERE TaskID = " + _TaskID;

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