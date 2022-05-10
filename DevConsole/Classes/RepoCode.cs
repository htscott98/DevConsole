using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class RepoCode
    {

        #region " Declarations "

        private int _ID;
        private int _DevConsoleReposID;
        private string _FormName;
        private string _Code;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public int DevConsoleReposID { get { return _DevConsoleReposID; } set { _DevConsoleReposID = value; } }
        public string FormName { get { return _FormName; } set { _FormName = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }

        #endregion

        #region " Constructors "

        public RepoCode()
        {
            _ID = 0;
            _DevConsoleReposID = 0;
            _FormName = string.Empty;
            _Code = string.Empty;
        }

        public RepoCode(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _DevConsoleReposID = Convert.ToInt32(row["DevConsoleReposID"].ToString());
            _FormName = row["FormName"].ToString();
            _Code = row["Code"].ToString();
        }

        public RepoCode(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _DevConsoleReposID = Convert.ToInt32(row.Cells["DevConsoleReposID"].Value.ToString());
            _FormName = row.Cells["FormName"].Value.ToString();
            _Code = row.Cells["Code"].Value.ToString();
        }

        #endregion

        #region " Overrides "

        public override string ToString()
        {
            return _FormName;
        }

        #endregion

        #region " Private Methods "

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = " SELECT ID, DevConsoleReposID, FormName, Code ";
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
                "FROM DevConsoleCode";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<RepoCode> GetListOfObjectsByRepoID(string repoID)
        {
            List<RepoCode> objList = new List<RepoCode>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleCode WHERE DevConsoleReposID = '" + repoID + "' " +
                "ORDER BY FormName ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        RepoCode obj = new RepoCode(r);

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


        public static RepoCode GetObjectByNameAndID(string repoName, string repoID)
        {
            RepoCode obj = new RepoCode();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleCode WHERE DevConsoleReposID = '" + repoID + "' AND FormName LIKE '%" + repoName + "%' ";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new RepoCode(r);

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

                keyValuePairs.Add("@DevConsoleReposID", _DevConsoleReposID.ToString());
                keyValuePairs.Add("@FormName", _FormName);
                keyValuePairs.Add("@Code", _Code);
                strSQL = "INSERT INTO DevConsoleCode (" +
                "DevConsoleReposID,FormName,Code)" +
                " VALUES (@DevConsoleReposID,@FormName,@Code)";
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
                keyValuePairs.Add("@DevConsoleReposID", _DevConsoleReposID.ToString());
                keyValuePairs.Add("@FormName", _FormName);
                keyValuePairs.Add("@Code", _Code);
                strSQL = "UPDATE DevConsoleCode " +
                "SET DevConsoleReposID=@DevConsoleReposID, FormName=@FormName, Code=@Code " +
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
                strSQL = "DELETE FROM DevConsoleCode " +
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