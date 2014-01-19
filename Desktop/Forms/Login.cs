using Bussiness;
using Bussiness.Services;
using System;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class Login : Form
    {
        private readonly EngineService engine;
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Login(EngineService engine, string username, string password)
        {
            InitializeComponent();
            this.engine = engine;
            eUserName.MaxLength = 15;
            ePassword.MaxLength = 25;
            eUserName.Text = username;
            ePassword.Text = password;
        }
        
        private void BOkClick(object sender, EventArgs e)
        {
            if (engine.Login.CheckDesktopLogin(eUserName.Text.Trim(), ePassword.Text.Trim()))
            {
                Username = eUserName.Text;
                Password = ePassword.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(TextResources.MsgLoginFailedValue, TextResources.MsgLoginFailedTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
   }
}
