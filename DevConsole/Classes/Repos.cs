using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole.Classes
{
    public class Repos
    {
        #region "Declarations"
        private int _ID;
        private string _Name;
        private string _Location;
        private string _Type;
        private string _Status;
        private string _Description;
        #endregion

        #region "Properties"
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Location { get { return _Location; } set { _Location = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        #endregion

        #region "Constructors"

        public Repos()
        {
            _ID = 0;
            _Name = string.Empty;
            _Location = string.Empty;
            _Type = string.Empty;
            _Status = string.Empty;
            _Description = string.Empty;
        }

        public Repos(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _Name = row["Name"].ToString();
            _Location = row["Location"].ToString();
            _Type = row["Type"].ToString();
            _Status = row["Status"].ToString();
            _Description = row["Description"].ToString();
        }

        public Repos(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].ToString());
            _Name = row.Cells["Name"].ToString();
            _Location = row.Cells["Location"].ToString();
            _Type = row.Cells["Type"].ToString();
            _Status = row.Cells["Status"].ToString();
            _Description = row.Cells["Description"].ToString();
        }

        #endregion

        #region "Overrides"

        public override string ToString()
        {
            return _Name;
        }

        #endregion

        #region "Private Methods"

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = "SELECT ID, Name, Location, Type, Status, Description ";
            return strReturnValue;
        }

        #endregion

        #region "Public Methods"

        public static DataTable GetDataTable(string status)
        {
            string strSQL = "";
            DataTable dt = null;

            try
            {
                strSQL = GetSQLSelect() + "FROM DevConsoleRepos WHERE Status LIKE '" + status + "%'";

                dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

            }
            catch (Exception ex)
            {
                
            }

            return dt;
        }

        public static List<Repos> GetListOfObjects()
        {
            List<Repos> objList = new List<Repos>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM DevConsoleRepos ORDER BY Name ASC";

                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Repos obj = new Repos(r);

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


        public static Repos GetObjectByID(int id)
        {
            Repos o = new Repos();
            string strSQL = "";

            try
            {
                strSQL = GetSQLSelect() +
                    " FROM DevConsoleRepos WHERE ID = " + id + "";
                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        o = new Repos(r);
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

                keyValuePairs.Add("@Name", _Name);
                keyValuePairs.Add("@Location", _Location);
                keyValuePairs.Add("@Type", _Type);
                keyValuePairs.Add("@Status", _Status);
                keyValuePairs.Add("@Description", _Description);

                strSQL = "INSERT INTO DevConsoleRepos (Name, Location, Type, Status, Description) " +
                    "VALUES (@Name, @Location, @Type, @Status, @Description)";

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

                keyValuePairs.Add("@Name", _Name);
                keyValuePairs.Add("@Location", _Location);
                keyValuePairs.Add("@Type", _Type);
                keyValuePairs.Add("@Status", _Status);
                keyValuePairs.Add("@Description", _Description);

                strSQL = "UPDATE DevConsoleRepos SET Name=@Name, Location=@Location, Type=@Type, Status=@Status, " +
                    "Description=@Description " +
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

                strSQL = "DELETE FROM DevConsoleRepos WHERE ID = @ID";

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
