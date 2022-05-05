using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole.Classes
{
    public class MasterLog
    {

        #region "Declarations"
        private int _ID;
        private int _DevConsoleReposID;
        private string _LogName;
        #endregion

        #region "Properties"
        public int ID { get { return _ID; } set { _ID = value; } }
        public int DevConsoleReposID { get { return _DevConsoleReposID; } set { _DevConsoleReposID = value; } }
        public string LogName { get { return _LogName; } set { _LogName = value; } }
        #endregion

        #region "Constructors"

        public MasterLog()
        {
            _ID = 0;
            _DevConsoleReposID = 0;
            _LogName = string.Empty;
        }

        public MasterLog(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _DevConsoleReposID = Convert.ToInt32(row["DevConsoleReposID"].ToString());
            _LogName = row["LogName"].ToString();
        }

        public MasterLog(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].ToString());
            _DevConsoleReposID = Convert.ToInt32(row.Cells["DevConsoleReposID"].ToString());
            _LogName = row.Cells["LogName"].ToString();
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
            strReturnValue = "SELECT ID, DevConsoleReposID, LogName ";
            return strReturnValue;
        }

        #endregion

        #region "Public Methods"

        public static List<MasterLog> GetListOfObjects(string DevConsoleReposID)
        {
            List<MasterLog> objList = new List<MasterLog>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() + " FROM DevConsoleMasterLogsMaster WHERE DevConsoleReposID = '" + DevConsoleReposID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        MasterLog obj = new MasterLog(r);

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


        public static DataTable GetDataTable(int reposID)
        {
            string strSQL = "";
            DataTable dt = null;

            try
            {
                strSQL = GetSQLSelect() + "FROM DevConsoleMasterLogsMaster WHERE DevConsoleReposID = '" + reposID + "'";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }


        public static MasterLog GetObjectByID(int id)
        {
            MasterLog o = new MasterLog();
            string strSQL = "";

            try
            {
                strSQL = GetSQLSelect() +
                    " FROM DevConsoleMasterLogsMaster WHERE ID = " + id + "";
                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        o = new MasterLog(r);
                    }
                }


            }
            catch (Exception ex)
            {

            }

            return o;

        }

        public bool InsertRecord()
        {
            string strSQL;
            bool b = false;

            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@DevConsoleReposID", _DevConsoleReposID.ToString());
                keyValuePairs.Add("@LogName", _LogName);

                strSQL = "INSERT INTO DevConsoleMasterLogsMaster (DevConsoleReposID, LogName) " +
                    "VALUES (@DevConsoleReposID, @LogName)";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                b = false;
            }

            return b;

        }

        public bool UpdateRecord(int id)
        {
            string strSQL;
            bool b = false;

            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@LogName", _LogName);

                strSQL = "UPDATE DevConsoleMasterLogsMaster SET LogName=@LogName " +
                    "WHERE ID = " + id + "";

                b = MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                b = false;
            }

            return b;
        }

        public bool DeleteRecord()
        {
            string strSQL;
            bool b = false;

            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());

                strSQL = "DELETE FROM DevConsoleMasterLogsMaster WHERE ID = @ID";

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
