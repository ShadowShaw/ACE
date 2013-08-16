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
using Desktop.Tools;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;

        public Version ACEVersion;
        List<ChangeRecord> Changes = new List<ChangeRecord>();
        public EngineService Engine;
        private MainSettings mainSettings;

        private int IndexForChange = -1;
        private FieldType ChangedType;
        
        public Main()
        {
            InitializeComponent();
            coreX = new CoreX();
            Engine = new EngineService();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            ACEVersion = assemblyName.Version;

            this.Text = "ACE Desktop " + ACEVersion.ToString();

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
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.bLoadProducts, TextResources.hLoadProducts);
            toolTip.SetToolTip(this.bEmptyCategory, TextResources.hEmptyCategory);
            toolTip.SetToolTip(this.bEmptyManufacturer, TextResources.hEmptyManufacturer);
            toolTip.SetToolTip(this.bWithoutImage, TextResources.hWithoutImage);
            toolTip.SetToolTip(this.bWithoutShortDescription, TextResources.hWithoutShortDescription);
            toolTip.SetToolTip(this.bWithoutLongDescription, TextResources.hWithoutLongDescription);
            toolTip.SetToolTip(this.bWithoutPrice, TextResources.hWithoutPrice);
            toolTip.SetToolTip(this.bWithoutWholeSalePrice, TextResources.hWithoutWholeSalePrice);
            toolTip.SetToolTip(this.bWithoutWeight, TextResources.hWithoutWeight);
            
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
            MessageBox.Show("Nastavení bylo uloženo.", "Uložení nastavení", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bEmptyCategory_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdnou kategorii.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "category", TextResources.Category, Engine.Categories.GetCategoryList(), false);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyCategory();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["category"];
                comboCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 3;
            ChangedType = FieldType.category;
        }

        private void bEmptyManufacturer_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným výrobcem.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_manufacturer", TextResources.Manufacturer, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "manufacturer", TextResources.Manufacturer, Engine.Manufacturers.GetManufacturersList(), false);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));

                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["manufacturer"];
                comboCell.Value = Engine.Manufacturers.GetManufacturerName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_manufacturer"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.manufacturer;
        }

        private void bWithoutImage_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez obrázku.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyImage();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_image", TextResources.ProductImage, false);
            
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.image;
        }

        private void bWithoutShortDescription_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným krátkým popisem.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            dgConsistency.Columns["id_category_default"].Visible = false;
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "description_short", TextResources.ShortDescription, false);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.shortDescription;
        }

        private void bWithoutLongDescription_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným dlouhým popisem.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyLongDescription();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "description", TextResources.Description, false);
           
            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.longDescription;
        }

        private void bWithoutPrice_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez maloobchodní ceny.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyPrice();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "price", TextResources.SalePrice, false);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.price;
        }

        private void bWithoutWeight_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez udané váhy.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWeight();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "weight", TextResources.Weight, false);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };
            IndexForChange = 5;
            ChangedType = FieldType.weight;
        }
        
        private void bWithoutWholeSalePrice_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez velkoobchodní ceny.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWholesalePrice();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "wholesale_price", TextResources.WholeSalePrice, false);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.wholesalePrice;

        }

        private void dgConsistency_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == IndexForChange)
            {
                string value = dgConsistency[e.ColumnIndex, e.RowIndex].Value.ToString();
                int id = System.Convert.ToInt32(dgConsistency["id", e.RowIndex].Value);

                ChangeRecord record = new ChangeRecord();
                record.Type = RecordType.product;
                record.Field = ChangedType;
                record.Id = id;
                record.Value = value;

                Changes.Add(record);
            }
        }

        private void bLoadProducts_Click(object sender, EventArgs e)
        {
            if ((Engine.ApiToken == "") || (Engine.BaseUrl == ""))
            {
                MessageBox.Show("Adresa eshopu, nebo API Token jsou prázdné.", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Engine.Manufacturers.LoadManufacturersAsync(statusProgress, statusMessage);
                Engine.Categories.LoadCategoriesAsync();
                Engine.Products.LoadProductsAsync(statusProgress, statusMessage, gbConsistency);
            }
        }

        private void bSaveChanges_Click(object sender, EventArgs e)
        {
            ChangesView changes = new ChangesView(Changes);
            if (changes.ShowDialog() == DialogResult.OK)
            {
                // write changes
            }
            else
            {
                //do nothing
            }
        }

        private void bPrestaTest_Click(object sender, EventArgs e)
        {
            if (Engine.TestPrestaAccess())
            {
                MessageBox.Show("Server eshopu odpovídá.", "Test připojení", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Server eshopu neodpovídá.", "Test připojení", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuShowChangeLog_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            this.homeBrowser.Url = new Uri(String.Format("file:///{0}/HtmlDocs/ChangeLog.html", curDir));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ChangeRecord record = new ChangeRecord();
            record.Type = RecordType.product;
            record.Field = FieldType.category;
            record.Id = 1;
            record.Value = "Test";

            Changes.Add(record);

            ChangeRecord record2 = new ChangeRecord();
            record2.Type = RecordType.product;
            record2.Field = ChangedType;
            record2.Id = 2;
            record2.Value = "value";

            Changes.Add(record2);
            
            ChangesView changes = new ChangesView(Changes);
            if (changes.ShowDialog() == DialogResult.OK)
            {
                // write changes

                foreach (ChangeRecord change in Changes)
                {
                    if (change.Type == RecordType.product)
                    {
                        product item = Engine.Products.GetById(change.Id);
                        if (change.Field == FieldType.category)
                        {
                            item.id_category_default = Engine.Categories.GetCategoryId(change.Value);
                        }
                        if (change.Field == FieldType.longDescription)
                        {
                            item.description = change.Value;
                        }
                        if (change.Field == FieldType.manufacturer)
                        {
                            item.id_manufacturer = Engine.Manufacturers.GetManufacturerId(change.Value);
                        }
                        if (change.Field == FieldType.price)
                        {
                            item.price = System.Convert.ToDecimal(change.Value);
                        }
                        if (change.Field == FieldType.shortDescription)
                        {
                            item.description_short = change.Value;
                        }
                        if (change.Field == FieldType.weight)
                        {
                            item.weight = System.Convert.ToDecimal(change.Value);
                        }
                        if (change.Field == FieldType.wholesalePrice)
                        {
                            item.wholesale_price = System.Convert.ToDecimal(change.Value);
                        }
                        Engine.Products.Edit(item);
                    }
                    //zjistit typ zaznamu
                    //ziskat aktualni
                    //zmenit hodnoty
                    //zapsat hodnoty
                }
            }
            else
            {
                //do nothing
            }
        }
    }
}
