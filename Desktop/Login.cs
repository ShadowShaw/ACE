using Core.Data;
using Core.Security;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Bussiness;

namespace Desktop
{
    public partial class Login : Form
    {
        LoginService ls;
        public Login()
        {
            InitializeComponent();
            ls = new LoginService();
        }
        
        private void bOk_Click(object sender, EventArgs e)
        {
            if (ls.checkDesktopLogin(eUserName.Text.Trim(), ePassword.Text.Trim()))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Nesprávné uživatelské jméno, či heslo.");
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
   }
}
