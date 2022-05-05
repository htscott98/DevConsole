using System;
using System.Data;
using System.Collections.Generic;
using DevConsole;
using System.Windows.Forms;

namespace DevConsole
{

    public class DevTaskLabels
    {

        #region " Declarations "

        private int _ID;
        private string _Name;
        private string _TextColor;
        private string _BackColor;
        private string _DisplayOrder;
        private bool _Enabled;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string TextColor { get { return _TextColor; } set { _TextColor = value; } }
        public string BackColor { get { return _BackColor; } set { _BackColor = value; } }
        public string DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }

        #endregion

        #region " Constructors "

        public DevTaskLabels()
        {
            _ID = 0;
            _Name = string.Empty;
            _TextColor = string.Empty;
            _BackColor = string.Empty;
            _DisplayOrder = string.Empty;
            _Enabled = false;
        }

        public DevTaskLabels(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _Name = row["Name"].ToString();
            _TextColor = row["TextColor"].ToString();
            _BackColor = row["BackColor"].ToString();
            _DisplayOrder = row["DisplayOrder"].ToString();
            _Enabled = Convert.ToBoolean(row["Enabled"].ToString());
        }

        public DevTaskLabels(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _Name = row.Cells["Name"].Value.ToString();
            _TextColor = row.Cells["TextColor"].Value.ToString();
            _BackColor = row.Cells["BackColor"].Value.ToString();
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
            strReturnValue = " SELECT ID, Name, TextColor, BackColor, DisplayOrder, Enabled ";
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
                "FROM DevConsoleDevTaskLabels " +
                "ORDER BY CONVERT(int,DisplayOrder) ASC";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            return dt;
        }

        public static List<DevTaskLabels> GetListOfObjects()
        {
            List<DevTaskLabels> objList = new List<DevTaskLabels>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskLabels " +
                "ORDER BY CONVERT(int, DisplayOrder) ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DevTaskLabels obj = new DevTaskLabels(r);

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

        public static DevTaskLabels GetObjectByID(string labelID)
        {
            DevTaskLabels obj = new DevTaskLabels();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleDevTaskLabels WHERE ID = '" + labelID + "'";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new DevTaskLabels(r);

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
                keyValuePairs.Add("@TextColor", _TextColor);
                keyValuePairs.Add("@BackColor", _BackColor);
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder);
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "INSERT INTO DevConsoleDevTaskLabels (" +
                "Name,TextColor,BackColor,DisplayOrder,Enabled)" +
                " VALUES (@Name,@TextColor,@BackColor,@DisplayOrder,@Enabled)";
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
                keyValuePairs.Add("@TextColor", _TextColor);
                keyValuePairs.Add("@BackColor", _BackColor);
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder);
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "UPDATE DevConsoleDevTaskLabels " +
                "SET Name=@Name, TextColor=@TextColor, BackColor=@BackColor, DisplayOrder=@DisplayOrder, " +
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

        public bool DeleteRecord()
        {
            string strSQL = "";
            bool b = false;

            try
            {
                strSQL = "DELETE FROM DevConsoleDevTaskLabels " +
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