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
using PrestaAccesor.Accesors;
using Desktop.UserSettings;
using PrestaAccesor.Entities;
using Core;
using Core.Data;
using Core.Models;
using Core.Security;
using Desktop.Utils;
using Core.Utils;
using Core.ViewModels;
using System.Xml.Serialization;
using System.Diagnostics;
using Core.Interfaces;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;

        public Version ACEVersion;
        List<ChangeRecord> Changes = new List<ChangeRecord>();
        public EngineService Engine;
        public ACESettings mainSettings;

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
            this.statusAgent.ForeColor = Color.Red;

            mainSettings = new ACESettings();

            if (File.Exists("Eshops.xml"))
            {
                mainSettings.LoadEshops();
                Engine.InitPrestaServices(mainSettings.Eshops.Eshops[0].BaseUrl, mainSettings.Eshops.Eshops[0].Password);
                ePrestaToken.Text = mainSettings.Eshops.Eshops[0].Password;
                ePrestaUrl.Text = mainSettings.Eshops.Eshops[0].BaseUrl;
            }
            else
            {
                Engine.InitPrestaServices("", "");
                MessageBox.Show("Nenalezen soubor s konfigurací připojení k eshopům. Prosím nastavte připojení.", "Nenalezen soubor s konfigurací připojení k eshopům.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (File.Exists("Columns.xml"))
            {
                mainSettings.LoadColumnWidth();
            }


            if (File.Exists("Sizes.xml"))
            {
                mainSettings.LoadFormSizes();
                this.Size = mainSettings.GetSize("main");
            }

            if (File.Exists("ACEDesktop.xml"))
            {
                mainSettings.LoadValues();
            }

            DataGridTools.SetMainSettings(mainSettings);
            InitDisplayEshopConfiguration();
            
            this.homeBrowser.Url = new Uri(ACESettings.ChangeLogPath);
            
            // Lenght of edit boxes.
            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
            
            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
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
            if (Engine.Login.logged)
            {
                Engine.Login.logout();
                this.statusAgent.ForeColor = Color.Red;
            }
            else
            {
                var LoginForm = new Login(Engine, mainSettings.DesktopUserName, mainSettings.DesktopPassword);
                if (LoginForm.ShowDialog() == DialogResult.OK)
                {
                    this.mainSettings.DesktopUserName = LoginForm.username;
                    this.mainSettings.DesktopPassword = LoginForm.password;
                    this.bLogin.Text = "Odhlášení";
                    this.statusAgent.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Pro použití ACE se musíte přihlásit.", "Vyžadováno přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Information);
             //       this.Close();
                }
            }
            this.InitUserInfo();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainSettings.SetSize("main", this.Size);
            mainSettings.SaveFormSizes();
            mainSettings.SaveEshops();
            mainSettings.SaveValues();
            foreach (DataGridViewColumn item in dgConsistency.Columns)
            {
                mainSettings.SetWidth(dgConsistency.Name + item.Name, item.Width);
            }

            mainSettings.SaveColumnWidth();
        }

        private void bSavePresta_Click(object sender, EventArgs e)
        {
            string token = UITools.GetStringFromEditBox(ePrestaToken);
            string url = UITools.GetBaseUrlFromEditBox(ePrestaUrl);

            ePrestaUrl.Text = url;
            ePrestaToken.Text = token;
            Engine.SetupPrestaServices(url, token);
            
            mainSettings.Eshops.Eshops[0].BaseUrl = Engine.BaseUrl;
            mainSettings.Eshops.Eshops[0].Password = Engine.ApiToken;
            mainSettings.SaveEshops();
            MessageBox.Show("Nastavení bylo uloženo.", "Uložení nastavení", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bEmptyCategory_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
            lListOf.Text = "Zobrazuji produkty s prázdnou kategorii.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "category", TextResources.Category, Engine.Categories.GetCategoryList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            IndexForChange = -1;
            lListOf.Text = "Zobrazuji produkty s prázdným výrobcem.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_manufacturer", TextResources.Manufacturer, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "manufacturer", TextResources.Manufacturer, Engine.Manufacturers.GetManufacturersList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            IndexForChange = -1;
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
            IndexForChange = -1;
            lListOf.Text = "Zobrazuji produkty s prázdným krátkým popisem.";
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "description_short", TextResources.ShortDescription, false);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 4;
            ChangedType = FieldType.shortDescription;
        }

        private void bWithoutLongDescription_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
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

            IndexForChange = 4;
            ChangedType = FieldType.longDescription;
        }

        private void bWithoutPrice_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
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

            IndexForChange = 4;
            ChangedType = FieldType.price;
        }

        private void bWithoutWeight_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
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
            IndexForChange = 4;
            ChangedType = FieldType.weight;
        }
        
        private void bWithoutWholeSalePrice_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
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

            IndexForChange = 4;
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
            if ((String.IsNullOrEmpty(Engine.ApiToken)) || (String.IsNullOrEmpty(Engine.BaseUrl)))
            {
                MessageBox.Show("Adresa eshopu, nebo API Token jsou prázdné.", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Engine.Languages.LoadLanguages();
                Engine.Languages.GetActiveLanguage();
                Engine.SetupPrestaLanguages();
                Engine.Manufacturers.LoadManufacturersAsync(statusProgress, statusMessage);
                Engine.Categories.LoadCategoriesAsync();
                Engine.Products.LoadProductsAsync(statusProgress, statusMessage, gbConsistency);
            }
        }

        private void bSaveChanges_Click(object sender, EventArgs e)
        {
            ChangesView changes = new ChangesView(Changes);
            if (Changes.Count == 0)
            {
                MessageBox.Show("Nejsou žádné změny k zápisu.", "Žádné změny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (changes.ShowDialog() == DialogResult.OK)
                {
                    foreach (ChangeRecord change in Changes)
                    {
                        if (change.Type == RecordType.product)
                        {
                            ProductViewModel item = Engine.Products.GetById(change.Id);

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
                    }
                    Changes.Clear();
                    Engine.Products.LoadProductsAsync(statusProgress, statusMessage, gbConsistency);
                    //zkontrolovat zapis
                    dgConsistency.DataSource = null;
                    //refresh gridu
                }
                else
                {
                    //do nothing
                }
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

        private void bAddEshop_Click(object sender, EventArgs e)
        {
            EshopConfiguration eshop = new EshopConfiguration();
            eshop.EshopName = "Eshop" + mainSettings.Eshops.Eshops.Count();
            if (cbEshopType.SelectedIndex == 0)
            {
                eshop.Type = EshopType.Prestashop;
            }
            TreeNode treeNode = new TreeNode();
            mainSettings.Eshops.Eshops.Add(eshop);
            treeConfiguration.Nodes.Add(treeNode);
        }

        private void InitDisplayEshopConfiguration()
        {
            cbEshopType.SelectedIndex = 0;
            foreach (EshopConfiguration eshop in mainSettings.Eshops.Eshops)
            {
                TreeNode treeNode = new TreeNode(eshop.EshopName);
                treeConfiguration.Nodes.Add(treeNode);
            }
        }

        private void treeConfiguration_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode mySelectedNode;
            mySelectedNode = treeConfiguration.GetNodeAt(e.X, e.Y);
            if (mySelectedNode != null)
            {
                treeConfiguration.SelectedNode = mySelectedNode;
                treeConfiguration.LabelEdit = true;
                if (!mySelectedNode.IsEditing)
                {
                    mySelectedNode.BeginEdit();
                }
            }
        }

        private void treeConfiguration_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.EndEdit(false);
        }

        private void bDelEshop_Click(object sender, EventArgs e)
        {
            if (treeConfiguration.SelectedNode != null)
            {
                if (treeConfiguration.SelectedNode.Parent == null)
                {
                    MessageBox.Show("Chcete opravdu odstranit konfiguraci eshopu: " + treeConfiguration.SelectedNode.Text, "Odstranit konfiguraci eshopu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    mainSettings.Eshops.Eshops.RemoveAll(n => n.EshopName == treeConfiguration.SelectedNode.Text);
                    treeConfiguration.Nodes.Remove(treeConfiguration.SelectedNode);
                }
            }
        }

        private void treeConfiguration_DoubleClick(object sender, EventArgs e)
        {
            if (treeConfiguration.SelectedNode != null)
            {
                if (treeConfiguration.SelectedNode.Parent == null)
                {
                    EshopConfiguration eshop = mainSettings.Eshops.Eshops.Where(n => n.EshopName == treeConfiguration.SelectedNode.Text).SingleOrDefault();
                    if (eshop != null)
                    {
                        if (eshop.Type == EshopType.Prestashop)
                        {
                            cbTypeEshop.SelectedIndex = 0;
                            ePrestaUrl.Text = eshop.BaseUrl;
                            ePrestaToken.Text = eshop.Password;
                        }
                    }
                }
            }
        }

        private void menuShowHome_Click(object sender, EventArgs e)
        {
            this.tc.SelectedTab = this.tpHome;
            this.homeBrowser.Url = new Uri(ACESettings.HomePath);
        }

        private void menuShowChangeLog_Click(object sender, EventArgs e)
        {
            this.tc.SelectedTab = this.tpHome;
            this.homeBrowser.Url = new Uri(ACESettings.ChangeLogPath);
        }

        private void dgConsistency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgConsistency.Columns["link"].Index)
            {
                return;
            }
                        
            var productId = dgConsistency[0, e.RowIndex].Value;
            Engine.OpenProductInBrowser(System.Convert.ToInt32(productId));
        }

        private void InitUserInfo()
        {
            if (Engine.Login.logged)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    UserProfile currentUser = uow.Users.GetAll().Where(x => x.Id == Engine.Login.loggedUserId).FirstOrDefault();
                    lHomeCompany.Text = currentUser.CompanyName;
                    lHomeCredit.Text = currentUser.Credit.ToString("C");
                    lHomeEmail.Text = currentUser.Email;
                    lHomeName.Text = currentUser.FirstName + " " + currentUser.LastName;
                    lHomePaymentSymbol.Text = currentUser.PaymentSymbol;
                    lHomeUserName.Text = currentUser.UserName;
                }
            }
            else 
            {
                lHomeCompany.Text = "";
                lHomeCredit.Text = "";
                lHomeEmail.Text = "";
                lHomeName.Text = "";
                lHomePaymentSymbol.Text = "";
                lHomeUserName.Text = ""; 
            }
        }
    }
}
