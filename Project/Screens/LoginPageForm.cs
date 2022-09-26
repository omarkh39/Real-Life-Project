using System;
using System.Windows.Forms;

namespace Project
{
    public partial class LoginPageForm : Form
    {
        private HomeScreenForm _homeScreenForm;

        private const string UserName = "admin";
        private const string Password = "admin";

        public LoginPageForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Logger.LogTransactionWritter("Login Form Initilized");
            UserNameTextbox.Text = UserName;
            PasswordTextbox.Text = Password;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {

            if (UserNameTextbox.Text.Equals(UserName) && PasswordTextbox.Text.Equals(Password))
            {
                Logger.LogTransactionWritter("User:  " + UserNameTextbox.Text + "  Logged in Sucessfully");
                _homeScreenForm = new HomeScreenForm(this);
                _homeScreenForm.Show();
                this.Hide();
            }
            else
            {
                Logger.LogTransactionWritter("Logged Failed Attempt");
                MessageBox.Show("Log in Failed", "Error");
            }
        }

        private void LoginPageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LogTransactionWritter("User:  " + UserNameTextbox.Text + "  Is Closing The Application");
        }
    }

}
