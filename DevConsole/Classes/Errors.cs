using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DevConsole
{
    public class Errors
    {
        #region "Declarations"
        private int _ID;
        private string _ApplicationName;
        private string _HelpLink;
        private string _InnerException;
        private string _Message;
        private string _Source;
        private string _StackTrace;
        private DateTime _DateTime;
        #endregion

        #region "Properties"
        public int ID { get { return _ID; } set { _ID = value; } }
        public string ApplicationName { get { return _ApplicationName; } set { _ApplicationName = value; } }
        public string HelpLink { get { return _HelpLink; } set { _HelpLink = value; } }
        public string InnerException { get { return _InnerException; } set { _InnerException = value; } }
        public string Message { get { return _Message; } set { _Message = value; } }
        public string Source { get { return _Source; } set { _Source = value; } }
        public string StackTrace { get { return _StackTrace; } set { _StackTrace = value; } }
        public DateTime DateTime { get { return _DateTime; } set { _DateTime = value; } }
        #endregion

        #region "Constructors"

        public Errors()
        {
            _ID = 0;
            _ApplicationName = string.Empty;
            _HelpLink = string.Empty;
            _InnerException = string.Empty;
            _Message = string.Empty;
            _Source = string.Empty;
            _StackTrace = string.Empty;
            _DateTime = Convert.ToDateTime("1/1/1900");
        }

        public Errors(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _ApplicationName = row["ApplicationName"].ToString();
            _HelpLink = row["HelpLink"].ToString();
            _InnerException = row["InnerException"].ToString();
            _Message = row["Message"].ToString();
            _Source = row["Source"].ToString();
            _StackTrace = row["StackTrace"].ToString();
            _DateTime = Convert.ToDateTime(row["DateTime"].ToString());
        }

        public Errors(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].ToString());
            _ApplicationName = row.Cells["ApplicationName"].ToString();
            _HelpLink = row.Cells["HelpLink"].ToString();
            _InnerException = row.Cells["InnerException"].ToString();
            _Message = row.Cells["Message"].ToString();
            _Source = row.Cells["Source"].ToString();
            _StackTrace = row.Cells["StackTrace"].ToString();
            _DateTime = Convert.ToDateTime(row.Cells["DateTime"].ToString());
        }

        #endregion

        #region "Overrides"

        public override string ToString()
        {
            return "";
        }

        #endregion

        #region "Private Methods"

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = "SELECT ID, ApplicationName, HelpLink, InnerException, Message, Source, StackTrace, DateTime ";
            return strReturnValue;
        }

        #endregion

        #region "Public Methods"

        public static Errors GetObjectByID(int id)
        {
            Errors o = new Errors();
            string strSQL = "";

            try
            {
                strSQL = GetSQLSelect() +
                    " FROM DevConsoleErrors WHERE ID = " + id + "";
                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(),strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        o = new Errors(r);
                    }
                }


            }
            catch (Exception ex)
            {

            }

            return o;

        }

        public bool DeleteRecord()
        {
            string strSQL;
            bool b = false;

            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());

                strSQL = "DELETE FROM DevConsoleErrors WHERE ID = @ID";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                b = false;
            }

            return b;
        }


        #endregion
    }
}

