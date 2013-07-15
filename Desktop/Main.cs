using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Core.Presta;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;

        public Main()
        {
            InitializeComponent();
            coreX = new CoreX();
            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
            if (File.Exists("manufacturers.txt"))
            {
                var u = File.ReadAllLines("manufacturers.txt").ToList();
                foreach (string s in u)
                {
                    cManufacturers.Items.Add(s);
                }

                cManufacturers.SelectedIndex = 0;
            }
        }
        
        
        private void bSave_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.saveProducts(saveDialog.FileName);
            }
        }

        private void openZverac_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openProducts(openDialog.FileName);
                statusAgent.Enabled = true;
                dgView.DataSource = coreX.getProducts();
            }
        }

        private void openAskino_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openAskino(openDialog.FileName);
                statusPresta.Enabled = true;
                dgView.DataSource = coreX.getAskino();
            }
        }

        private void openNoviko_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openNoviko(openDialog.FileName);
                statusLogin.Enabled = true;
                dgView.DataSource = coreX.getNoviko();
            }
        }

        private void bConsistencyNoviko_Click(object sender, EventArgs e)
        {
            if ((statusAgent.Enabled) && (statusLogin.Enabled))
            {
                dgView.DataSource = coreX.checkConsistenceNoviko();
            }
            else
            {
                //ShowMessage("Otevřete ceníky Zveráče a Novika");
            }
        }

        private void bConsistencyAskino_Click(object sender, EventArgs e)
        {
            if ((statusAgent.Enabled) && (statusPresta.Enabled))
            {
                dgView.DataSource = coreX.checkConsistencyAskino();
            }
            else
            {
                //ShowMessage("Otevřete ceníky Zveráče a Askina");
            }
        }

        private void importManufactures_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.importManufactures(openDialog.FileName);
            }
        }

        private string getOperation(string text)
        {
            string operation = text.Substring(0, 1);
            return operation;
        }

        private void bReprice_Click(object sender, EventArgs e)
        {
            //if (rAskino.Checked)
            //{
            //    coreX.repriceAskino(eReprice.Text, cManufacturers.SelectedIndex);
            //}

            //if (rNoviko.Checked)
            //{
            //    coreX.repriceNoviko(eReprice.Text, cManufacturers.SelectedIndex);
            //}

            dgView.DataSource = coreX.getProducts();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            //var LoginForm = new Login();
            //if (LoginForm.ShowDialog() == DialogResult.OK)
            //{
     
            //}
            //else
            //{
            //    MessageBox.Show("Pro použití ACE se musíte přihlásit.");
            //    this.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RESTAccessor acc = new RESTAccessor("", "");
            var a = acc.Receive("");
            var b = acc.GetManufacturer("1");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //homeBrowser.Document = ""
        }

        private void bReprice_Click_1(object sender, EventArgs e)
        {

        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void status_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lPrestaUrl_Click(object sender, EventArgs e)
        {

        }

        private void lPrestaToken_Click(object sender, EventArgs e)
        {

        }

        private void ePrestaToken_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbJoomlaSetup_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lSupplier_Click(object sender, EventArgs e)
        {

        }

        private void eReprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
