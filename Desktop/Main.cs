using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Core.Bussiness;
using PrestaAccesor.Serializers;
using Desktop.UserSettings;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;
        public EngineService Engine;
        private MainSettings mainSettings;

        public Main()
        {
            InitializeComponent();
            coreX = new CoreX();
            Engine = new EngineService();

            // Loading settings from configuration.
            mainSettings = new MainSettings();
            ePrestaToken.Text = mainSettings.PrestaApiToken;
            ePrestaUrl.Text = mainSettings.PrestaShopUrl;
            Engine.PrestaSetup(mainSettings.PrestaShopUrl, mainSettings.PrestaApiToken);

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

        private static void PopulateTree(TreeView tree, ICollection<TreeItem> items)
        {
            tree.Nodes.Clear();
            List<TreeNode> roots = new List<TreeNode>();
            roots.Add(tree.Nodes.Add("-1", "Kategorie Eshopu"));
            foreach (TreeItem item in items)
            {
                if (item.Level == roots.Count)
                {
                    roots.Add(roots[roots.Count - 1].LastNode);
                }

                roots[item.Level].Nodes.Add(item.Id.ToString(), item.Name);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PopulateTree(CategoryTree, Engine.CreateCategoryTreeList());
            CategoryTree.ExpandAll();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //homeBrowser.Document = ""
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            var LoginForm = new Login(Engine);
            if (LoginForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("Pro použití ACE se musíte přihlásit.");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode x = CategoryTree.SelectedNode;
            int a = System.Convert.ToInt32(x.Name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var m_productsAccesor = new ProductsAccesor(Engine.ShopUrl + "api/", Engine.ApiToken, "");
            var a = m_productsAccesor.GetAll();
            var aa = m_productsAccesor.GetIds();
            var aaa = m_productsAccesor.Get(2);
        }

        private void Main_Leave(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainSettings.Save();
        }

        private void bSavePresta_Click(object sender, EventArgs e)
        {
            Engine.PrestaSetup(ePrestaUrl.Text, ePrestaToken.Text);
            mainSettings.PrestaShopUrl = ePrestaUrl.Text;
            mainSettings.PrestaApiToken = ePrestaToken.Text;
            mainSettings.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgConsistency.DataSource = Engine.GetProductWithEmptyCategory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dgConsistency.DataSource = Engine.GetProductWithEmptyManufacturer();
        }
    }
}
