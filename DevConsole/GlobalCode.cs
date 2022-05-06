using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{

    class GlobalCode
    {

        public static List<string> labelFilters = new List<string>();
        public static string stringFilter;

        public static string oldList;
        public static string newList;


        public static UserAccess oUser;

        public static DialogResult ShowMSGBox(string strText,
            MessageBoxIcon Icon = MessageBoxIcon.Information,
            MessageBoxButtons Buttons = MessageBoxButtons.OK,
            MessageBoxDefaultButton DefaulButton = MessageBoxDefaultButton.Button1)
        {
            DialogResult diaResult;
            diaResult = MessageBox.Show(strText, Application.ProductName, Buttons, Icon, DefaulButton);
            return diaResult;
        }

        public static void ExceptionHandler(Exception ex)
        {

            using (var cnn = MasterCode.Connection.InitPRDConnection())
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ApplicationName", Application.ProductName);
                keyValuePairs.Add("@HelpLink", ex.HelpLink);
                keyValuePairs.Add("@InnerException", Convert.ToString(ex.InnerException));
                keyValuePairs.Add("@Message", ex.Message);
                keyValuePairs.Add("@Source", ex.Source);
                keyValuePairs.Add("@StackTrace", ex.StackTrace);
                keyValuePairs.Add("@DateTime", DateTime.Now.ToString());

                string sqlStatement = "INSERT INTO DevConsoleErrors(ApplicationName, HelpLink, InnerException, Message, Source, StackTrace, DateTime) " +
                    "VALUES(@ApplicationName, @HelpLink, @InnerException, @Message, @Source, @StackTrace, @DateTime)";

                MasterCode.Execute.ExecuteStatementReturnBool(MasterCode.Connection.InitPRDConnection(), sqlStatement, keyValuePairs);


            }
        }


    }
}
