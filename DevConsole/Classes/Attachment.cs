using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class Attachment
    {

        #region " Declarations "

        private int _ID;
        private int _TaskID;
        private byte[] _Image;
        private DateTime _Timestamp;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public int TaskID { get { return _TaskID; } set { _TaskID = value; } }
        public byte[] Image { get { return _Image; } set { _Image = value; } }
        public DateTime Timestamp { get { return _Timestamp; } set { _Timestamp = value; } }

        #endregion

        #region " Constructors "

        public Attachment()
        {
            _ID = 0;
            _TaskID = 0;
            _Image = null;
            _Timestamp = Convert.ToDateTime("1/1/1900");
        }

        public Attachment(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _TaskID = Convert.ToInt32(row["TaskID"].ToString());
            _Image = (byte[])row["Image"];
            _Timestamp = Convert.ToDateTime(row["Timestamp"].ToString());
        }

        public Attachment(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _TaskID = Convert.ToInt32(row.Cells["TaskID"].Value.ToString());
            _Image = (byte[])row.Cells["Image"].Value;
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
            strReturnValue = " SELECT ID, TaskID, Image, Timestamp ";
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
                "FROM DevConsoleDevTaskAttachments";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<Attachment> GetListOfObjectsByTaskID(string taskID)
        {
            List<Attachment> objList = new List<Attachment>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskAttachments WHERE TaskID = '" + taskID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Attachment obj = new Attachment(r);

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
                keyValuePairs.Add("@Image", _Image.ToString());
                keyValuePairs.Add("@Timestamp", _Timestamp.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskAttachments (" +
                "TaskID,Image,Timestamp)" +
                " VALUES (@TaskID,CONVERT(VARBINARY(max),@Image),@Timestamp)";
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

                keyValuePairs.Add("@TaskID", _TaskID.ToString());
                keyValuePairs.Add("@Image", _Image.ToString());
                keyValuePairs.Add("@Timestamp", _Timestamp.ToString());
                strSQL = "UPDATE DevConsoleDevTaskAttachments " +
                "SET TaskID=@TaskID, Image=@Image, Timestamp=@Timestamp " +
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
                strSQL = "DELETE FROM DevConsoleDevTaskAttachments " +
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