using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Desktop.UserSettings;
using Desktop.Utils;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft;
using Bussiness.Services;
using Bussiness;
using Bussiness.ViewModels;

using Core.Models;

namespace Desktop
{
    public partial class Main : Form
    {
        public EngineService Engine;
        public ACESettings mainSettings;
        
        List<ChangeRecord> ConsistencyChanges = new List<ChangeRecord>();
        private int IndexForChange = -1;
        private FieldType ChangedType;
        private Version ACEVersion;
        
        #region pricing

        private async void bPricingInit_Click(object sender, EventArgs e)
        {
            Engine.Login.GetRights();
            if (Engine.Login.Rights.Pricing)
            {
                if ((String.IsNullOrEmpty(Engine.ApiToken)) || (String.IsNullOrEmpty(Engine.BaseUrl)))
                {
                    MessageBox.Show("Adresa eshopu, nebo API Token jsou prázdné.", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        DisableControlsWhenAccesingEshop();
                        bool result;

                        this.statusProgress.Visible = true;
                        this.statusMessage.Text = "Nahrávám jazyky, prosím čekejte...";
                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        this.statusMessage.Text = "Nahrávám výrobce, prosím čekejte...";
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        this.statusMessage.Text = "Nahrávám kategorie, prosím čekejte...";
                        result = await Engine.Categories.LoadCategoriesAsync();
                        this.statusMessage.Text = "Nahrávám dodavatele, prosím čekejte...";
                        result = await Engine.Suppliers.LoadSuppliersAsync();
                        this.statusMessage.Text = "Nahrávám produkty, prosím čekejte...";
                        result = await Engine.Products.LoadProductsAsync();

                        this.statusProgress.Visible = false;
                        this.statusMessage.Text = "";
                        this.gbSelectProduct.Enabled = true;
                    }
                    finally
                    {
                        EnableControlsAfterAccesingEshop();
                    }
                }
            }
            else
            {
                ACERightsError();
                return;
            }

            List<string> manufacturersList; // = new List<string>();
            manufacturersList = Engine.Manufacturers.GetManufacturersList();
            manufacturersList.Insert(0, "Jakýkoliv výrobce");
            cPricingManufacturers.Items.AddRange(manufacturersList.ToArray());
            cPricingManufacturers.SelectedIndex = 0;

            List<string> suppliersList; // = new List<string>();
            suppliersList = Engine.Suppliers.GetSupplierList();
            suppliersList.Insert(0, "Jakýkoliv dodavatel");
            cPricingSuppliers.Items.AddRange(suppliersList.ToArray());
            cPricingSuppliers.SelectedIndex = 0;

            treePricing.Nodes.Clear();
            
            //todo
            //foreach (category item in Engine.Categories.Categories.ToList())
            //{
            //    TreeNode node = new TreeNode();
            //    node.Text = item.name;
            //    node.Name = item.id.ToString();
                    
            //    if (item.level_depth == 0)
            //    {
            //        treePricing.Nodes.Add(node);
            //    }
            //    else
            //    {
            //        TreeNode parent = treePricing.Nodes.Find(item.id_parent.ToString(), true).FirstOrDefault();
            //        parent.Nodes.Add(node);
            //    }
            //}
            //treePricing.ExpandAll();
        }
        
        private void bReprice_Click_1(object sender, EventArgs e)
        {
            if (rbPricingProcent.Checked)
            { 
            }
        }

        private void bPricingSave_Click(object sender, EventArgs e)
        {
            try
            {
                DisableControlsWhenAccesingEshop();
            }
            finally
            {
                EnableControlsAfterAccesingEshop();
            }
            //ChangesView changes = new ChangesView(ConsistencyChanges);
            //if (ConsistencyChanges.Count == 0)
            //{
            //    MessageBox.Show("Nejsou žádné změny k zápisu.", "Žádné změny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    if (changes.ShowDialog() == DialogResult.OK)
            //    {
            //        this.statusProgress.Visible = true;
            //        this.statusMessage.Text = "Ukladám změny, prosím čekejte...";
            //        this.gbConsistency.Enabled = false;

            //        await Task.Factory.StartNew(() => this.SaveChangesAsync(ConsistencyChanges));

            //        ConsistencyChanges.Clear();

            //        bool result;

            //        this.statusProgress.Visible = true;
            //        this.statusMessage.Text = "NahrĂĄvĂĄm jazyky, prosĂ­m Ä?ekejte...";
            //        this.gbConsistency.Enabled = false;

            //        result = await Engine.Languages.LoadLanguagesAsync();
            //        Engine.Languages.GetActiveLanguage();
            //        Engine.SetupPrestaLanguages();
            //        this.statusMessage.Text = "NahrĂĄvĂĄm vĂ˝robce, prosĂ­m Ä?ekejte...";
            //        result = await Engine.Manufacturers.LoadManufacturersAsync();
            //        this.statusMessage.Text = "NahrĂĄvĂĄm kategorie, prosĂ­m Ä?ekejte...";
            //        result = await Engine.Categories.LoadCategoriesAsync();
            //        this.statusMessage.Text = "NahrĂĄvĂĄm produkty, prosĂ­m Ä?ekejte...";
            //        result = await Engine.Products.LoadProductsAsync();

            //        this.statusProgress.Visible = false;
            //        this.statusMessage.Text = "";
            //        this.gbConsistency.Enabled = true;

            //        dgConsistency.DataSource = null;
            //    }
            //    else
            //    {
            //        //do nothing
            //    }
            //}
        }

        private void bPricingShow_Click(object sender, EventArgs e)
        {
            if (treePricing.SelectedNode != null)
            {
                lPricingCategoryIndication.Text = treePricing.SelectedNode.Text;
            }

            lPricingManufacturerIndication.Text = cPricingManufacturers.SelectedItem.ToString();
            lPricingSupplierIndication.Text = cPricingSuppliers.SelectedItem.ToString(); 
            
            IndexForChange = -1;
            DataGridTools.InitGrid(dgPricing);

            DataGridTools.AddColumn(dgPricing, "id", TextResources.Id);
            DataGridTools.AddColumn(dgPricing, "name", TextResources.Name);
            DataGridTools.AddColumn(dgPricing, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddComboBoxColumn(dgPricing, "category", TextResources.Category, Engine.Categories.GetCategoryList(), true);
            DataGridTools.AddColumn(dgPricing, "id_manufacturer", TextResources.Manufacturer, true, false);
            DataGridTools.AddComboBoxColumn(dgPricing, "manufacturer", TextResources.Manufacturer, Engine.Manufacturers.GetManufacturersList(), true);
            DataGridTools.AddColumn(dgPricing, "id_supplier", TextResources.Supplier, true, false);
            DataGridTools.AddComboBoxColumn(dgPricing, "supplier", TextResources.Supplier, Engine.Suppliers.GetSupplierList(), true);
            DataGridTools.AddColumn(dgPricing, "price", TextResources.SalePrice, true);
            DataGridTools.AddColumn(dgPricing, "wholesale_price", TextResources.WholeSalePrice, true);
            DataGridTools.AddButtonColumn(dgPricing, "link", TextResources.LinkButton);

            int idManufacturer = 0;
            if (cPricingManufacturers.SelectedItem.ToString() != "Jakýkoliv výrobce")
            {
                idManufacturer = System.Convert.ToInt32(Engine.Manufacturers.GetManufacturerId(cPricingManufacturers.SelectedItem.ToString()));
            }

            int idSupplier = 0;
            if (cPricingSuppliers.SelectedItem.ToString() != "Jakýkoliv dodavatel")
            {
                idSupplier = System.Convert.ToInt32(Engine.Suppliers.GetSupplierId(cPricingSuppliers.SelectedItem.ToString()));
            }

            List<int> idCategories = new List<int>();
            if (treePricing.SelectedNode != null)
            {
                idCategories = Engine.Categories.GetSubcategories(System.Convert.ToInt32(Engine.Categories.GetCategoryId(treePricing.SelectedNode.Text)), idCategories);
                idCategories.Add(System.Convert.ToInt32(Engine.Categories.GetCategoryId(treePricing.SelectedNode.Text)));
            }

            dgPricing.DataSource = Engine.Products.GetProductForRepricing(idManufacturer, idSupplier, idCategories);

            lPricingManufacturerIndication.Text = cPricingManufacturers.SelectedItem.ToString();
            lPricingSupplierIndication.Text = cPricingSuppliers.SelectedItem.ToString();
            if (treePricing.SelectedNode != null)
            {
                lPricingCategoryIndication.Text = treePricing.SelectedNode.Text;
            }

            for (int i = 0; i < dgPricing.Rows.Count; i++)
            {
                DataGridViewComboBoxCell categoryCell = (DataGridViewComboBoxCell)dgPricing.Rows[i].Cells["category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_category_default"].Value));

                DataGridViewComboBoxCell manufacturerCell = (DataGridViewComboBoxCell)dgPricing.Rows[i].Cells["manufacturer"];
                manufacturerCell.Value = Engine.Manufacturers.GetManufacturerName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_manufacturer"].Value));

                DataGridViewComboBoxCell supplierCell = (DataGridViewComboBoxCell)dgPricing.Rows[i].Cells["supplier"];
                supplierCell.Value = Engine.Suppliers.GetSupplierName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_supplier"].Value));
            };

            IndexForChange = 3;
            ChangedType = FieldType.category;

        }

        #endregion

        #region GeneralFunctionality

        public Main()
        {
            InitializeComponent();
            Engine = new EngineService();
            mainSettings = new ACESettings();

            ACEVersion = GetVersion();
            this.Text = "ACE Desktop " + ACEVersion.ToString();
            this.statusAgent.ForeColor = Color.Red;

            if (mainSettings.Eshops.ActiveEshopIndex == -1)
            {
                Engine.InitPrestaServices("", "");
                MessageBox.Show(TextResources.msgEmptyConfigurationValue, TextResources.msgEmptyConfigurationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Engine.InitPrestaServices(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].BaseUrl, mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].Password);
                ePrestaToken.Text = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].Password;
                ePrestaUrl.Text = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].BaseUrl;
                this.statusActiveEshop.Text = "Aktivní eshop: " + mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].EshopName;
            }

            Size mainFormSize = mainSettings.GetSize("main");
            if (mainFormSize != new Size(0,0))
            {
                this.Size = mainFormSize;
            }

            DataGridTools.SetMainSettings(mainSettings);
            InitDisplayEshopConfiguration();
            InitModuleInfo();
            InitStatusBar();
            
            this.homeBrowser.Url = new Uri(ACESettings.ChangeLogPath);

            // Lenght of edit boxes.
            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;

            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
        }

        private void DisplaySuppliers()
        {
            chAskinoSetup.Checked = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].UseAskino;
            chNovikoSetup.Checked = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].UseNoviko;
            if (String.IsNullOrEmpty(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].AskinoFilePath))
            {
                lAskinoPath.Text = TextResources.labelPathToAskinoPriceList;
            }
            else
            {
                lAskinoPath.Text = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].AskinoFilePath;
            }

            if (String.IsNullOrEmpty(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].NovikoFilePath))
            {
                lNovikoPath.Text = TextResources.labelPathToNovikoPriceList;
            }
            else
            {
                lNovikoPath.Text = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].NovikoFilePath;
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

            toolTip.SetToolTip(this.bLoadProducts, TextResources.hintLoadProducts);
            toolTip.SetToolTip(this.bEmptyCategory, TextResources.hintEmptyCategory);
            toolTip.SetToolTip(this.bEmptyManufacturer, TextResources.hintEmptyManufacturer);
            toolTip.SetToolTip(this.bWithoutImage, TextResources.hintWithoutImage);
            toolTip.SetToolTip(this.bWithoutShortDescription, TextResources.hintWithoutShortDescription);
            toolTip.SetToolTip(this.bWithoutLongDescription, TextResources.hintWithoutLongDescription);
            toolTip.SetToolTip(this.bWithoutPrice, TextResources.hintWithoutPrice);
            toolTip.SetToolTip(this.bWithoutWholeSalePrice, TextResources.hintWithoutWholeSalePrice);
            toolTip.SetToolTip(this.bWithoutWeight, TextResources.hintWithoutWeight);
            toolTip.SetToolTip(this.bWithoutSupplier, TextResources.hintWithoutSupplier);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainSettings.SetSize("main", this.Size);
            
            foreach (DataGridViewColumn item in dgConsistency.Columns)
            {
                mainSettings.SetWidth(dgConsistency.Name + item.Name, item.Width);
            }

            mainSettings.SaveSettings();
        }

        public void ACERightsError()
        {
            MessageBox.Show("K této akci nemáte potřebné oprávnění. Objednejte danný modul.", "Chyba práv", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public void DisableGroupBoxOnReload()
        {
            gbConsistency.Enabled = false;
            gbSelectProduct.Enabled = false;
        }

        public void DisableControlsWhenAccesingEshop()
        {
            cbActiveEshop.Enabled = false;
        }

        public void EnableControlsAfterAccesingEshop()
        {
            cbActiveEshop.Enabled = true;
        }


        public void ClearGridsOnReload()
        {
            dgConsistency.Rows.Clear();
            dgConsistency.Refresh();

            dgPricing.Rows.Clear();
            dgPricing.Refresh();
        }


        private Version GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            return assemblyName.Version;
        }



        #endregion

        #region PageConsistency

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

                ConsistencyChanges.Add(record);
            }
        }

        private async void bLoadProducts_Click(object sender, EventArgs e)
        {
            Engine.Login.GetRights();
            if (Engine.Login.Rights.Consistency)
            {
                if ((String.IsNullOrEmpty(Engine.ApiToken)) || (String.IsNullOrEmpty(Engine.BaseUrl)))
                {
                    MessageBox.Show("Adresa eshopu, nebo API Token jsou prázdné.", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        bool result;
                        
                        DisableControlsWhenAccesingEshop();

                        this.statusProgress.Visible = true;
                        this.statusMessage.Text = "Nahrávám jazyky, prosím čekejte...";
                        this.gbConsistency.Enabled = false;

                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        this.statusMessage.Text = "Nahrávám výrobce, prosím čekejte...";
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        this.statusMessage.Text = "Nahrávám dodavatele, prosím čekejte...";
                        result = await Engine.Suppliers.LoadSuppliersAsync();
                        this.statusMessage.Text = "Nahrávám kategorie, prosím čekejte...";
                        result = await Engine.Categories.LoadCategoriesAsync();
                        this.statusMessage.Text = "Nahrávám produkty, prosím čekejte...";
                        result = await Engine.Products.LoadProductsAsync();

                        this.statusProgress.Visible = false;
                        this.statusMessage.Text = "";
                        this.gbConsistency.Enabled = true;
                        if (mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].UseAskino)
                        {
                            this.bConsistencyAskino.Enabled = true;
                        }
                        if (mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].UseNoviko)
                        {
                            this.bConsistencyNoviko.Enabled = true;
                        }
                    }
                    finally
                    {
                        EnableControlsAfterAccesingEshop();
                    }
                }
            }
            else
            {
                ACERightsError();
            }
        }

        private void SaveChangesAsync(List<ChangeRecord> changes)
        {
            foreach (ChangeRecord change in changes)
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
        }

        private async void bSaveChanges_Click(object sender, EventArgs e)
        {
            ChangesView changes = new ChangesView(ConsistencyChanges);
            if (ConsistencyChanges.Count == 0)
            {
                MessageBox.Show("Nejsou žádné změny k zápisu.", "Žádné změny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (changes.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DisableControlsWhenAccesingEshop();

                        this.statusProgress.Visible = true;
                        this.statusMessage.Text = "Ukladám změny, prosím čekejte...";
                        this.gbConsistency.Enabled = false;

                        await Task.Factory.StartNew(() => this.SaveChangesAsync(ConsistencyChanges));

                        ConsistencyChanges.Clear();

                        bool result;

                        this.statusProgress.Visible = true;
                        this.statusMessage.Text = "NahrĂĄvĂĄm jazyky, prosĂ­m Ä?ekejte...";
                        this.gbConsistency.Enabled = false;

                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        this.statusMessage.Text = "NahrĂĄvĂĄm vĂ˝robce, prosĂ­m Ä?ekejte...";
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        this.statusMessage.Text = "NahrĂĄvĂĄm kategorie, prosĂ­m Ä?ekejte...";
                        result = await Engine.Categories.LoadCategoriesAsync();
                        this.statusMessage.Text = "NahrĂĄvĂĄm produkty, prosĂ­m Ä?ekejte...";
                        result = await Engine.Products.LoadProductsAsync();

                        this.statusProgress.Visible = false;
                        this.statusMessage.Text = "";
                        this.gbConsistency.Enabled = true;

                        dgConsistency.DataSource = null;
                    }
                    finally
                    {
                        EnableControlsAfterAccesingEshop();
                    }
                }
                else
                {
                    //do nothing
                }
            }
        }
        #endregion

        #region StatusBar

        private void InitStatusBar()
        {
            RefreshStatusBar();
        }

        private void RefreshStatusBar()
        {
            statusAskino.Visible = false;
            statusNoviko.Visible = false;

            //TODO error kdyz je to prazdne
            if (mainSettings.Eshops.ActiveEshopIndex != -1)
            {
                if (File.Exists(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].AskinoFilePath) == true)
                {
                    statusAskino.Visible = true;
                }

                if (File.Exists(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].NovikoFilePath) == true)
                {
                    statusNoviko.Visible = true;
                }
            }
        }

        #endregion

        #region EshopConfiguration

        private void bSavePresta_Click(object sender, EventArgs e)
        {
            string token = UITools.GetStringFromEditBox(ePrestaToken);
            string url = UITools.GetBaseUrlFromEditBox(ePrestaUrl);

            ePrestaUrl.Text = url;
            ePrestaToken.Text = token;
            Engine.SetupPrestaServices(url, token);

            TreeNode mySelectedNode;
            mySelectedNode = treeConfiguration.SelectedNode;
            for (int i = 0; i < treeConfiguration.Nodes.Count; i++)
            {
                if (treeConfiguration.Nodes[i].Text == mySelectedNode.Text)
                {
                    mainSettings.Eshops.Eshops[i].EshopName = treeConfiguration.Nodes[i].Text;
                    mainSettings.Eshops.Eshops[i].BaseUrl = Engine.BaseUrl;
                    mainSettings.Eshops.Eshops[i].Password = Engine.ApiToken;
                    mainSettings.Eshops.Eshops[i].Type = EshopType.Prestashop;
                    mainSettings.Eshops.Eshops[i].UseAskino = chAskinoSetup.Checked;
                    mainSettings.Eshops.Eshops[i].UseNoviko = chNovikoSetup.Checked;
                }
            }

            //InitEshopList();

            mainSettings.SaveSettings();
            //MessageBox.Show("Nastavení bylo uloženo.", "Uložení nastavení", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            eshop.Type = EshopType.Prestashop;
            TreeNode treeNode = new TreeNode();
            mainSettings.Eshops.Eshops.Add(eshop);
            treeConfiguration.Nodes.Add(treeNode);
            if (mainSettings.Eshops.ActiveEshopIndex == -1)
            {
                mainSettings.Eshops.ActiveEshopIndex = 0;
            }
            InitDisplayEshopConfiguration();
        }

        private void cbActiveEshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainSettings.Eshops.ActiveEshopIndex = cbActiveEshop.SelectedIndex;
            this.statusActiveEshop.Text = "Aktivní eshop: " + mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].EshopName;
            Engine.SetupPrestaServices(mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].BaseUrl, mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].Password);
            DisableGroupBoxOnReload();
            ClearGridsOnReload();
        }

        private void InitEshopList()
        {
            cbActiveEshop.Items.Clear();
            foreach (EshopConfiguration eshop in mainSettings.Eshops.Eshops)
            {
                cbActiveEshop.Items.Add(eshop.EshopName);
            }

            if (mainSettings.Eshops.ActiveEshopIndex != -1)
            {
                cbActiveEshop.SelectedIndex = mainSettings.Eshops.ActiveEshopIndex;
            }
        }

        private void InitDisplayEshopConfiguration()
        {
            if (mainSettings.Eshops.Eshops.Count > 0)
            {
                InitEshopList();
                                                
                treeConfiguration.Nodes.Clear();
                foreach (EshopConfiguration eshop in mainSettings.Eshops.Eshops)
                {
                    TreeNode treeNode = new TreeNode(eshop.EshopName);
                    treeConfiguration.Nodes.Add(treeNode);
                }
                ShowNode(treeConfiguration.Nodes[mainSettings.Eshops.ActiveEshopIndex]);

                treeConfiguration.SelectedNode = treeConfiguration.Nodes[mainSettings.Eshops.ActiveEshopIndex];

                DisplaySuppliers();
            }
        }

        private void ShowNode(TreeNode node)
        {
                EshopConfiguration eshop = mainSettings.Eshops.Eshops.Where(n => n.EshopName == node.Text).SingleOrDefault();
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

        private void treeConfiguration_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode mySelectedNode;
            mySelectedNode = treeConfiguration.GetNodeAt(e.X, e.Y);

            if (mySelectedNode != null)
            {
                if (mySelectedNode.Parent == null)
                {
                    ShowNode(mySelectedNode);
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
            TreeNode mySelectedNode;
            mySelectedNode = treeConfiguration.SelectedNode;
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

        #endregion

        #region ACEHome


        private void bLogin_Click(object sender, EventArgs e)
        {
            if (Engine.Login.Logged())
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
            this.InitModuleInfo();
        }


        private void InitUserInfo()
        {
            if (Engine.Login.Logged())
            {
                lHomeCompany.Text = Engine.Login.CurrentUser.CompanyName;
                lHomeCredit.Text = Engine.Login.CurrentUser.Credit.ToString("C");
                lHomeEmail.Text = Engine.Login.CurrentUser.Email;
                lHomeName.Text = Engine.Login.CurrentUser.FirstName + " " + Engine.Login.CurrentUser.LastName;
                lHomePaymentSymbol.Text = Engine.Login.CurrentUser.PaymentSymbol;
                lHomeUserName.Text = Engine.Login.CurrentUser.UserName;
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

        private void InitModuleInfo()
        {
            dgHomeModules.Rows.Clear();
            dgHomeModules = Engine.Login.GetModuleInfo(dgHomeModules);
        }
        #endregion

        #region ACEMainMenu

        private void ukončitACEDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        #endregion

        #region ConsistencyGrid

        private void dgConsistency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgConsistency.Columns["link"].Index)
            {
                return;
            }

            var productId = dgConsistency[0, e.RowIndex].Value;
            Engine.OpenProductInBrowser(System.Convert.ToInt32(productId));
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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

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
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = 4;
            ChangedType = FieldType.wholesalePrice;
        }

        private void bConsistencySupplier_Click(object sender, EventArgs e)
        {
            IndexForChange = -1;
            lListOf.Text = "Zobrazuji produkty bez zadaného dodavatele.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWholesalePrice();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_supplier", TextResources.Supplier, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "supplier", TextResources.Supplier, Engine.Suppliers.GetSupplierList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));

                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["supplier"];
                comboCell.Value = Engine.Manufacturers.GetManufacturerName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_supplier"].Value));
            };

            IndexForChange = 5;
            ChangedType = FieldType.manufacturer;
        }

        #endregion

        private void bOpenAskino_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //Engine.askinoPriceList.OpenPriceListCSV(openDialog.FileName);
                mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].AskinoFilePath = openDialog.FileName;
                statusAskino.Visible = true;
            }
        }

        private void bOpenNoviko_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].NovikoFilePath = openDialog.FileName;
                //Engine.novikoPriceList.OpenPriceListCSV(openDialog.FileName);
                statusNoviko.Visible = true;
            }
        }
        
        private void bConsistencyNoviko_Click_1(object sender, EventArgs e)
        {
            string path = mainSettings.Eshops.Eshops[mainSettings.Eshops.ActiveEshopIndex].NovikoFilePath;
            if (File.Exists(path))
            {
                //Engine.novikoPriceList.OpenPriceListCSV(path);
            }
            else
            {
                MessageBox.Show("Ćeník není k dispozici, otevřete ceník Novika", "Ćeník není k dispozici", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IndexForChange = -1;
            lListOf.Text = "Zobrazuji produkty jenž dodavatelé již nedodávají.";
            DataGridTools.InitGrid(dgConsistency);
            List<long?> listOfSuppliers = new List<long?>();
            listOfSuppliers.Add(Engine.Suppliers.GetAskinoId());
            listOfSuppliers.Add(Engine.Suppliers.GetNovikoId());
            //dgConsistency.DataSource = Engine.Products.GetNonAvailableProductOfSuppliers(listOfSuppliers, Engine.novikoPriceList.GetPriceList());
            
            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_supplier", TextResources.Supplier, false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);
            DataGridTools.AddButtonColumn(dgConsistency, "delete", TextResources.DeleteButton);
                        
            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));
            };

            IndexForChange = -1;
            ChangedType = FieldType.image;

            //call chceck consistency s produkty a cenikem novika
            //call chceck consistency s produkty a cenikem askina
        }

        private void ePrestaUrl_Leave(object sender, EventArgs e)
        {
            bSavePresta_Click(this, null);
        }
        
    }
}
