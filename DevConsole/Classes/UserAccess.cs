using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{
    public class UserAccess
    {
        #region "Declarations"
        private int _ID;
        private string _FirstName;
        private string _LastName;
        private string _DOB;
        private string _PrimaryEmail;
        private string _SecondaryEmail;
        private string _PrimaryPhone;
        private string _SecondaryPhone;
        private string _Address;
        private bool _ErrorLogs;
        private bool _Repositories;
        private bool _CodeBuilder;
        private bool _Access;
        private DateTime _DateAdded;
        private DateTime _LastModified;
        private bool _Enabled;
        private string _Username;
        private string _Password;
        #endregion

        #region "Properties"
        public int ID { get { return _ID; } set { _ID = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string DOB { get { return _DOB; } set { _DOB = value; } }
        public string PrimaryEmail { get { return _PrimaryEmail; } set { _PrimaryEmail = value; } }
        public string SecondaryEmail { get { return _SecondaryEmail; } set { _SecondaryEmail = value; } }
        public string PrimaryPhone { get { return _PrimaryPhone; } set { _PrimaryPhone = value; } }
        public string SecondaryPhone { get { return _SecondaryPhone; } set { _SecondaryPhone = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public bool ErrorLogs { get { return _ErrorLogs; } set { _ErrorLogs = value; } }
        public bool Repositories { get { return _Repositories; } set { _Repositories = value; } }
        public bool CodeBuilder { get { return _CodeBuilder; } set { _CodeBuilder = value; } }
        public bool Access { get { return _Access; } set { _Access = value; } }
        public DateTime DateAdded { get { return _DateAdded; } set { _DateAdded = value; } }
        public DateTime LastModified { get { return _LastModified; } set { _LastModified = value; } }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }
        public string Username { get { return _Username; } set { _Username = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        #endregion

        #region "Constructors"

        public UserAccess()
        {
            _ID = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _DOB = string.Empty;
            _PrimaryEmail = string.Empty;
            _SecondaryEmail = string.Empty;
            _PrimaryPhone = string.Empty;
            _SecondaryPhone = string.Empty;
            _Address = string.Empty;
            _ErrorLogs = false;
            _Repositories = false;
            _CodeBuilder = false;
            _Access = false;
            _DateAdded = Convert.ToDateTime("1/1/1900");
            _LastModified = Convert.ToDateTime("1/1/1900");
            _Enabled = false;
            _Username = string.Empty;
            _Password = string.Empty;
        }

        public UserAccess(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _FirstName = row["FirstName"].ToString();
            _LastName = row["LastName"].ToString();
            _DOB = row["DOB"].ToString();
            _PrimaryEmail = row["PrimaryEmail"].ToString();
            _SecondaryEmail = row["SecondaryEmail"].ToString();
            _PrimaryPhone = row["PrimaryPhone"].ToString();
            _SecondaryPhone = row["SecondaryPhone"].ToString();
            _Address = row["Address"].ToString();
            _ErrorLogs = Convert.ToBoolean(row["ErrorLogs"].ToString());
            _Repositories = Convert.ToBoolean(row["Repositories"].ToString());
            _CodeBuilder = Convert.ToBoolean(row["CodeBuilder"].ToString());
            _Access = Convert.ToBoolean(row["Access"].ToString());
            _DateAdded = Convert.ToDateTime(row["DateAdded"].ToString());
            _LastModified = Convert.ToDateTime(row["LastModified"].ToString());
            _Enabled = Convert.ToBoolean(row["Enabled"].ToString());
            _Username = row["Username"].ToString();
            _Password = row["Password"].ToString();
        }

        public UserAccess(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].ToString());
            _FirstName = row.Cells["FirstName"].ToString();
            _LastName = row.Cells["LastName"].ToString();
            _DOB = row.Cells["DOB"].ToString();
            _PrimaryEmail = row.Cells["PrimaryEmail"].ToString();
            _SecondaryEmail = row.Cells["SecondaryEmail"].ToString();
            _PrimaryPhone = row.Cells["PrimaryPhone"].ToString();
            _SecondaryPhone = row.Cells["SecondaryPhone"].ToString();
            _Address = row.Cells["Address"].ToString();
            _ErrorLogs = Convert.ToBoolean(row.Cells["ErrorLogs"].ToString());
            _Repositories = Convert.ToBoolean(row.Cells["Repositories"].ToString());
            _CodeBuilder = Convert.ToBoolean(row.Cells["CodeBuilder"].ToString());
            _Access = Convert.ToBoolean(row.Cells["Access"].ToString());
            _DateAdded = Convert.ToDateTime(row.Cells["DateAdded"].ToString());
            _LastModified = Convert.ToDateTime(row.Cells["LastModified"].ToString());
            _Enabled = Convert.ToBoolean(row.Cells["Enabled"].ToString());
            _Username = row.Cells["Username"].ToString();
            _Password = row.Cells["Password"].ToString();
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
            strReturnValue = "SELECT ID, FirstName, LastName, DOB, PrimaryEmail, SecondaryEmail, PrimaryPhone, SecondaryPhone, Address, ErrorLogs, Repositories, CodeBuilder, Access, DateAdded, LastModified, Enabled, Username, Password";
            return strReturnValue;
        }

        #endregion

        #region "Public Methods"

        public static UserAccess GetObjectByID(int id)
        {
            UserAccess o = new UserAccess();
            string strSQL = "";

            try
            {
                strSQL = GetSQLSelect() + 
                    " FROM DevConsoleUsers WHERE ID = " + id + "";
                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        o = new UserAccess(r);
                    }
                }


            }
            catch (Exception ex)
            {

            }

            return o;
        }

        public static UserAccess CheckLogin(string username, string password)
        {
            UserAccess o = new UserAccess();
            string strSQL = "";

            username = username.Trim().Replace("'","");
            password = password.Trim().Replace("'", "");

            try
            {
                strSQL = GetSQLSelect() +
                    " FROM DevConsoleUsers WHERE Username = '" + username + "' AND Password = '" + password + "'";
                DataTable dt = MasterCode.Execute.ExecuteSelectReturnDT(MasterCode.Connection.InitPRDConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        o = new UserAccess(r);
                    }
                }
                else
                {
                    o = null;
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
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

                keyValuePairs.Add("@FirstName", _FirstName);
                keyValuePairs.Add("@LastName", _LastName);
                keyValuePairs.Add("@DOB", _DOB);
                keyValuePairs.Add("@PrimaryEmail", _PrimaryEmail);
                keyValuePairs.Add("@SecondaryEmail", _SecondaryEmail);
                keyValuePairs.Add("@PrimaryPhone", _PrimaryPhone);
                keyValuePairs.Add("@SecondaryPhone", _SecondaryPhone);
                keyValuePairs.Add("@Address", _Address);
                keyValuePairs.Add("@ErrorLogs", _ErrorLogs.ToString());
                keyValuePairs.Add("@Repositories", _Repositories.ToString());
                keyValuePairs.Add("@CodeBuilder", _CodeBuilder.ToString());
                keyValuePairs.Add("@Access", _Access.ToString());
                keyValuePairs.Add("@DateAdded", _DateAdded.ToString());
                keyValuePairs.Add("@LastModified", _LastModified.ToString());
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                keyValuePairs.Add("@Username", _Username);
                keyValuePairs.Add("@Password", _Password);

                strSQL = "INSERT INTO DevConsoleUsers (FirstName, LastName, DOB, PrimaryEmail, SecondaryEmail, PrimaryPhone, SecondaryPhone," +
                    " Address, ErrorLogs, Repositories, CodeBuilder, Access, DateAdded, LastModified, Enabled, Username, Password) " +
                    "VALUES (@FirstName, @LastName, @DOB, @PrimaryEmail, @SecondaryEmail, @PrimaryPhone, @SecondaryPhone, @Address, " +
                    "@ErrorLogs, @Repositories, @CodeBuilder, @Access, @DateAdded, @LastModified, @Enabled, @Username, @Password)";

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

                keyValuePairs.Add("@FirstName", _FirstName);
                keyValuePairs.Add("@LastName", _LastName);
                keyValuePairs.Add("@DOB", _DOB);
                keyValuePairs.Add("@PrimaryEmail", _PrimaryEmail);
                keyValuePairs.Add("@SecondaryEmail", _SecondaryEmail);
                keyValuePairs.Add("@PrimaryPhone", _PrimaryPhone);
                keyValuePairs.Add("@SecondaryPhone", _SecondaryPhone);
                keyValuePairs.Add("@Address", _Address);
                keyValuePairs.Add("@ErrorLogs", _ErrorLogs.ToString());
                keyValuePairs.Add("@Repositories", _Repositories.ToString());
                keyValuePairs.Add("@CodeBuilder", _CodeBuilder.ToString());
                keyValuePairs.Add("@Access", _Access.ToString());
                keyValuePairs.Add("@DateAdded", _DateAdded.ToString());
                keyValuePairs.Add("@LastModified", _LastModified.ToString());
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                keyValuePairs.Add("@Username", _Username);
                keyValuePairs.Add("@Password", _Password);

                strSQL = "UPDATE DevConsoleUsers SET FirstName=@FirstName, LastName=@LastName, DOB=@DOB, PrimaryEmail=@PrimaryEmail, " +
                    "SecondaryEmail=@SecondaryEmail, PrimaryPhone=@PrimaryPhone, SecondaryPhone=@SecondaryPhone, Address=@Address, " +
                    "ErrorLogs=@ErrorLogs, Repositories=@Repositories, CodeBuilder=@CodeBuilder, Access=@Access," +
                    " DateAdded=@DateAdded, LastModified=@LastModified, Enabled=@Enabled, Username=@Username, Password=@Password " +
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

                strSQL = "DELETE FROM DevConsoleUsers WHERE ID = @ID";

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
