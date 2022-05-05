using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConsole
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxUsername.Text == "" || TextBoxPassword.Text == "")
                {
                    GlobalCode.ShowMSGBox("Enter a username and password to login", MessageBoxIcon.Error);
                    return;
                }


                string username = TextBoxUsername.Text;
                string password = TextBoxPassword.Text;

                UserAccess o = new UserAccess();
                o = UserAccess.CheckLogin(username, password);

                if (o != null)
                {
                    GlobalCode.oUser = o;
                    FormMain formMain = new FormMain();
                    this.Hide();
                    MasterCode.Log.InsertMasterLogging(("13", username));
                    formMain.Show();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to find account that matches. Try again", MessageBoxIcon.Error);
                    TextBoxUsername.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxUsername.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }


        }
    }
}
