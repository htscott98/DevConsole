using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class DevTaskLists
    {

        #region " Declarations "

        private int _ID;
        private string _Name;
        private string _DisplayOrder;
        private bool _Enabled;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }

        #endregion

        #region " Constructors "

        public DevTaskLists()
        {
            _ID = 0;
            _Name = string.Empty;
            _DisplayOrder = string.Empty;
            _Enabled = false;
        }

        public DevTaskLists(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _Name = row["Name"].ToString();
            _DisplayOrder = row["DisplayOrder"].ToString();
            _Enabled = Convert.ToBoolean(row["Enabled"].ToString());
        }

        public DevTaskLists(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _Name = row.Cells["Name"].Value.ToString();
            _DisplayOrder = row.Cells["DisplayOrder"].Value.ToString();
            _Enabled = Convert.ToBoolean(row.Cells["Enabled"].Value.ToString());
        }

        #endregion

        #region " Overrides "

        public override string ToString()
        {
            return _Name;
        }

        #endregion

        #region " Private Methods "

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = " SELECT ID, Name, DisplayOrder, Enabled ";
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
                "FROM DevConsoleDevTaskLists " +
                "ORDER BY CONVERT(int,DisplayOrder) ASC";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<DevTaskLists> GetListOfObjects()
        {
            List<DevTaskLists> objList = new List<DevTaskLists>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskLists " +
                "ORDER BY CONVERT(int,DisplayOrder) ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskLists obj = new DevTaskLists(r);

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

        public static List<DevTaskLists> GetListOfObjectsEnabled()
        {
            List<DevTaskLists> objList = new List<DevTaskLists>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskLists " +
                "WHERE Enabled = 1 " +
                "ORDER BY CONVERT(int,DisplayOrder) ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskLists obj = new DevTaskLists(r);

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

        public static DevTaskLists GetObjectByID(string listID)
        {
            DevTaskLists obj = new DevTaskLists();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskLists WHERE ID = '" + listID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new DevTaskLists(r);

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
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder);
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskLists (" +
                "Name,DisplayOrder,Enabled)" +
                " VALUES (@Name,@DisplayOrder,@Enabled)";
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
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "UPDATE DevConsoleDevTaskLists " +
                "SET Name=@Name, DisplayOrder=@DisplayOrder, Enabled=@Enabled " +
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
                strSQL = "DELETE FROM DevConsoleDevTaskLists " +
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