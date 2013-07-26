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
using PrestaAccesor.Entities;
using Core;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;
        public EngineService Engine;
        private MainSettings mainSettings;

        private VersionService Version = new VersionService();

        public Main()
        {
            InitializeComponent();
            coreX = new CoreX();
            Engine = new EngineService();

            this.Text = "ACE Desktop " + Version.AssemblyVersion;

            // Loading settings from configuration.
            mainSettings = new MainSettings();
            ePrestaToken.Text = mainSettings.PrestaApiToken;
            ePrestaUrl.Text = mainSettings.PrestaBaseUrl;
            Engine.PrestaSetup(mainSettings.PrestaBaseUrl, mainSettings.PrestaApiToken);

            // Lenght of edit boxes.
            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
            
            // Old Code.
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
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainSettings.Save();
        }

        private void bSavePresta_Click(object sender, EventArgs e)
        {
            string token = UITools.GetStringFromEditBox(ePrestaToken);
            string url = UITools.GetBaseUrlFromEditBox(ePrestaUrl);

            ePrestaUrl.Text = url;
            ePrestaToken.Text = token;
            Engine.PrestaSetup(url, token);
            mainSettings.PrestaBaseUrl = Engine.BaseUrl;
            mainSettings.PrestaApiToken = Engine.ApiToken;
            mainSettings.Save();
        }

        private void bEmptyCategory4_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyCategory();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
        }

        private void bEmptyManufacturer_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "id_manufacturer", TextResources.Manufacturer);
        }

        private void bWithoutImage_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyImage();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "id_image", TextResources.ProductImage);
        }

        private void bWithoutShortDescription_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "description_short", TextResources.ShortDescription);
        }

        private void bWithoutLongDescription_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyLongDescription();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "description", TextResources.Description);
        }

        private void bWithoutPrice_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyPrice();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "price", TextResources.SalePrice);
        }

        private void bWithoutWeight_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWeight();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "weight", TextResources.Weight);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Engine.Products.LoadProductsAsync(statusProgress, statusMessage);
            gbConsistency.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void bWithoutWholeSalePrice_Click(object sender, EventArgs e)
        {
            dgConsistency.Columns.Clear();
            dgConsistency.AutoGenerateColumns = false;
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWholesalePrice();

            AddColumnToDataGrid(dgConsistency, 0, "id", TextResources.Id);
            AddColumnToDataGrid(dgConsistency, 1, "name", TextResources.Name);
            AddColumnToDataGrid(dgConsistency, 2, "id_category_default", TextResources.Category);
            AddColumnToDataGrid(dgConsistency, 3, "wholesale_price", TextResources.WholeSalePrice);
        }
        
        private void AddColumnToDataGrid(DataGridView grid, int index, string dataProperty, string header)
        {
            grid.Columns.Add(dataProperty, header);
            grid.Columns[index].DataPropertyName = dataProperty;
        }
    }
}
