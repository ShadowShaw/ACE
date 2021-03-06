﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Core.Utils;
using Desktop.Utils;
using System.Threading.Tasks;
using Bussiness.Services;
using Bussiness;
using Bussiness.ViewModels;
using Desktop.Custom_Contols;
using Bussiness.RePricing;
using UserSettings;

namespace Desktop.Forms
{
    public partial class Main : Form
    {
        public EngineService Engine;
        public ACESettings Settings;
        private int _selectedEshopIndex;
        
        private readonly List<ChangeRecord> _consistencyChanges = new List<ChangeRecord>();
        private int _indexForChange = -1;
        private FieldType _changedType;
        private Version _aceVersion;

        private bool _activeEshopEnabled;
        private bool _loadProductEnabled;
        private bool _pricingInitEnabled;
        private bool _consistencyEnabled;
        private bool _saveChangesEnabled;
        private bool _pricingShowEnabled;
        private bool _selectProductEnabled;
        private bool _repriceEnabled;
        private bool _pricingSaveEnabled;
        
        #region pricing

        private async void BPricingInitClick(object sender, EventArgs e)
        {
            ClearPricingGrid();
            Engine.Login.GetRights();
            if (Engine.Login.Rights.Pricing)
            {
                if (Engine.Login.IsOnline() == false)
                {
                    MessageIsOffline();
                    return;
                }

                if ((String.IsNullOrEmpty(Engine.ApiToken)) || (String.IsNullOrEmpty(Engine.BaseUrl)))
                {
                    MessageEshopConfigurationMissing();
                }
                else
                {
                    try
                    {
                        DisableControlsWhenAccesingEshop();
                        bool result;
                        bPricingSave.Enabled = false;
                        bReprice.Enabled = false;
                        bPricingShow.Enabled = false;

                        statusProgress.Visible = true;
                        statusMessage.Text = TextResources.StatusLoadingLanguages;
                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        statusMessage.Text = TextResources.StatusLoadingManufacturers;
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        statusMessage.Text = TextResources.StatusLoadingCategories;
                        result = await Engine.Categories.LoadCategoriesAsync();
                        statusMessage.Text = TextResources.StatusLoadingSuppliers;
                        result = await Engine.Suppliers.LoadSuppliersAsync();
                        statusMessage.Text = TextResources.StatusLoadingProducts;
                        result = await Engine.Products.LoadProductsAsync();

                        statusProgress.Visible = false;
                        statusMessage.Text = "";
                        _selectProductEnabled = true;
                    }
                    finally
                    {
                        _pricingShowEnabled = true;
                        EnableControlsAfterAccesingEshop();
                    }
                }
            }
            else
            {
                ACERightsError();
                return;
            }

            List<string> manufacturersList = Engine.Manufacturers.GetManufacturersList();
            manufacturersList.Insert(0, TextResources.ComboAnyManufacturer);
            manufacturersList.ForEach(manufacturer => cPricingManufacturers.Items.Add(manufacturer));
            cPricingManufacturers.SelectedIndex = 0;

            List<string> suppliersList = Engine.Suppliers.GetSupplierList();
            suppliersList.Insert(0, TextResources.ComboAnySupplier);
            suppliersList.ForEach(supplier => cPricingSuppliers.Items.Add(supplier));
            cPricingSuppliers.SelectedIndex = 0;

            treePricing.Nodes.Clear();

            foreach (CategoryViewModel item in Engine.Categories.Categories)
            {
                TreeNode node = new TreeNode {Text = item.Name, Name = item.Id.ToString()};

                if (item.LevelDepth == 0)
                {
                    treePricing.Nodes.Add(node);
                }
                else
                {
                    TreeNode parent = treePricing.Nodes.Find(item.IdParent.ToString(), true).FirstOrDefault();
                    parent.Nodes.Add(node);
                }
            }
            treePricing.ExpandAll();
        }
        

        private void BRepriceClick(object sender, EventArgs e)
        {
            try
            {
                dgPricing.EndEdit();
                statusMessage.Text = TextResources.StatusRepriceInProgress;
                statusProgress.Visible = true;

                Engine.Pricing.Setup(Engine.Suppliers, Engine.PriceLists);
                
                if (rbPricingProcent.Checked)
                {
                    decimal value;
                    if (decimal.TryParse(ePricingPercent.Text, out value))
                    {
                        Engine.Pricing.ProcentReprice(Convert.ToDecimal(ePricingPercent.Text), chPricingSupplier.Checked, Settings.ActiveEshop().Suppliers);    
                    }
                    else
                    {
                        MessageBox.Show("Zadán neplatný procentní koeficient.");
                    }
                    
                }
                else
                {
                    Engine.Pricing.LimitReprice(Settings.ActiveEshop().RepriceLimits, chPricingSupplier.Checked, Settings.ActiveEshop().Suppliers);
                    //Engine.Pricing.LimitReprice(Convert.ToDecimal(ePricingLimit.Text), Convert.ToDecimal(ePricingBellowLimit.Text), Convert.ToDecimal(ePricingOverLimit.Text), chPricingSupplier.Checked);
                }

                dgPricing.EndEdit();
                dgPricing.DataSource = Engine.Pricing.GetProducts();
                dgPricing.Refresh();
                bPricingSave.Enabled = true;
            }
            finally
            {
                statusMessage.Text = String.Empty;
                statusProgress.Visible = false;
            }
        }

        private async void BPricingSaveClick(object sender, EventArgs e)
        {
            try
            {
                DisableControlsWhenAccesingEshop();

                if (Engine.Pricing.ConsistencyChanges.Count == 0)
                {
                    MessageBox.Show(TextResources.MsgNoChangesToSaveValue, TextResources.MsgNoChangesToSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ChangesView changes = new ChangesView(Engine.Pricing.ConsistencyChanges.OrderBy(i => i.Id).ToList());

                    if (changes.ShowDialog() == DialogResult.OK)
                    {
                        statusProgress.Visible = true;
                        statusMessage.Text = TextResources.StatusSavingChanges;
                        gbConsistency.Enabled = false;

                        await Task.Factory.StartNew(() => SaveChangesAsync(Engine.Pricing.ConsistencyChanges));

                        Engine.Pricing.ConsistencyChanges.Clear();

                        bool result;

                        statusProgress.Visible = true;
                        statusMessage.Text = TextResources.StatusLoadingLanguages;
                        
                        // disable controls

                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        statusMessage.Text = TextResources.StatusLoadingManufacturers;
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        statusMessage.Text = TextResources.StatusLoadingCategories;
                        result = await Engine.Categories.LoadCategoriesAsync();
                        statusMessage.Text = TextResources.StatusLoadingProducts;
                        result = await Engine.Products.LoadProductsAsync();

                        statusProgress.Visible = false;
                        statusMessage.Text = String.Empty;
                        _consistencyEnabled = true;

                        dgPricing.DataSource = null;
                    }
                }
            }
            finally
            {
                _consistencyEnabled = false;
                _saveChangesEnabled = false;
                EnableControlsAfterAccesingEshop();
            }
        }

        private void BPricingShowClick(object sender, EventArgs e)
        {
            Engine.Pricing.ConsistencyChanges.Clear();
            dgPricing.Refresh();
                
            if (treePricing.SelectedNode != null)
            {
                lPricingCategoryIndication.Text = treePricing.SelectedNode.Text;
            }

            lPricingManufacturerIndication.Text = cPricingManufacturers.SelectedItem.ToString();
            lPricingSupplierIndication.Text = cPricingSuppliers.SelectedItem.ToString(); 
            
            _indexForChange = -1;
            DataGridTools.InitGrid(dgPricing);

            DataGridTools.AddColumn(dgPricing, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgPricing, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgPricing, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgPricing, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgPricing, "IdManufacturer", TextResources.Manufacturer, true, false);
            DataGridTools.AddColumn(dgPricing, "Manufacturer", TextResources.Manufacturer);
            DataGridTools.AddColumn(dgPricing, "IdSupplier", TextResources.Supplier, true, false);
            DataGridTools.AddColumn(dgPricing, "Supplier", TextResources.Supplier);
            DataGridTools.AddNumberColumn(dgPricing, "Price", TextResources.SalePrice, false);
            DataGridTools.AddNumberColumn(dgPricing, "WholesalePrice", TextResources.WholeSalePrice, false);
            DataGridTools.AddButtonColumn(dgPricing, "Link", TextResources.LinkButton);

            int idManufacturer = 0;
            if (cPricingManufacturers.SelectedItem.ToString() != "Jakýkoliv výrobce")
            {
                idManufacturer = Convert.ToInt32(Engine.Manufacturers.GetManufacturerId(cPricingManufacturers.SelectedItem.ToString()));
            }

            int idSupplier = 0;
            if (cPricingSuppliers.SelectedItem.ToString() != "Jakýkoliv dodavatel")
            {
                idSupplier = Convert.ToInt32(Engine.Suppliers.GetSupplierId(cPricingSuppliers.SelectedItem.ToString()));
            }

            List<int> idCategories = new List<int>();
            if (treePricing.SelectedNode != null)
            {
                idCategories = Engine.Categories.GetSubcategories(Convert.ToInt32(Engine.Categories.GetCategoryId(treePricing.SelectedNode.Text)), idCategories);
                idCategories.Add(Convert.ToInt32(Engine.Categories.GetCategoryId(treePricing.SelectedNode.Text)));
            }

            List<ProductViewModel> a = Engine.Products.GetProductForRepricing(idManufacturer, idSupplier, idCategories);
            List<ProductViewModel> deepCopiedList = GenericCopier<List<ProductViewModel>>.DeepCopy(a);
            Engine.Pricing.SetProducts(deepCopiedList);
            dgPricing.DataSource = Engine.Pricing.GetProducts(); 

            lPricingManufacturerIndication.Text = cPricingManufacturers.SelectedItem.ToString();
            lPricingSupplierIndication.Text = cPricingSuppliers.SelectedItem.ToString();
            if (treePricing.SelectedNode != null)
            {
                lPricingCategoryIndication.Text = treePricing.SelectedNode.Text;
            }

            for (int i = 0; i < dgPricing.Rows.Count; i++)
            {
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["Category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgPricing.Rows[i].Cells["IdCategoryDefault"].Value));

                DataGridViewTextBoxCell manufacturerCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["Manufacturer"];
                manufacturerCell.Value = Engine.Manufacturers.GetManufacturerName(Convert.ToInt32(dgPricing.Rows[i].Cells["IdManufacturer"].Value));

                DataGridViewTextBoxCell supplierCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["Supplier"];
                supplierCell.Value = Engine.Suppliers.GetSupplierName(Convert.ToInt32(dgPricing.Rows[i].Cells["IdSupplier"].Value));
            }

            _indexForChange = 8;  //9
            _changedType = FieldType.Category;
            bReprice.Enabled = true;
        }

        #endregion

        #region GeneralFunctionality

        private void EshopSettingsSuppliersChanged(object sender, EshopEventArgs e)
        {
            if (_selectedEshopIndex > -1 && _selectedEshopIndex < (Settings.Eshops.Eshops.Count - 1))
            {
                Settings.UpdateSelectedEshop(e.Eshop, _selectedEshopIndex);
                RefreshStatusBar();
                Settings.SaveSettings();

                if (Settings.ActiveEshop() == Settings.Eshops.Eshops[_selectedEshopIndex])
                {
                    InitializeEshopConnection();
                }
            }
        }

        private void TcSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 0:
                    Settings.Values.ACETab = Enums.ACETabType.Home;
                    break;
                case 1:
                    Settings.Values.ACETab = Enums.ACETabType.Consistency;
                    break;
                case 2:
                    Settings.Values.ACETab = Enums.ACETabType.Repricing;
                    break;
                case 3:
                    Settings.Values.ACETab = Enums.ACETabType.Setup;
                    break;
                default:
                    Settings.Values.ACETab = Enums.ACETabType.Home;
                    break;
            }
        }

        private void SetTab()
        {
            switch (Settings.Values.ACETab)
            {
                case Enums.ACETabType.Consistency:
                    tc.SelectTab(1);
                    break;
                case Enums.ACETabType.Repricing:
                    tc.SelectTab(2);
                    break;
                case Enums.ACETabType.Setup:
                    tc.SelectTab(3);
                    break;
                default:
                    tc.SelectTab(0);
                    break;
            }

                
        }
        private void InitializeEshopConnection()
        {
            DisableGroupBoxOnReload();
            ClearGridsOnReload();
            if (Settings.ActiveEshop() != null)
            {
                if (Settings.ActiveEshop().Type == Enums.EshopType.Prestashop)
                {
                    if (String.IsNullOrEmpty(Settings.ActiveEshop().Password) == false && String.IsNullOrEmpty(Settings.ActiveEshop().BaseUrl) == false)
                    {
                        Engine.InitPrestaServices(Settings.ActiveEshop().BaseUrl, Settings.ActiveEshop().Password);                        
                    }
                }
            }
        }

        private void RegisterEvents()
        {
            _selectedEshopIndex = Settings.Eshops.ActiveEshopIndex;
            eshopSettings.SuppliersChanged += EshopSettingsSuppliersChanged;
        }

        private void SetVersion()
        {
            _aceVersion = GetVersion();
            Text = "ACE Desktop " + _aceVersion;
        }

        private void MessageEshopConfigurationMissing()
        {
            MessageBox.Show(TextResources.MsgEmptyConfigurationValue, TextResources.MsgEmptyConfigurationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MessageIsOffline()
        {
            MessageBox.Show(TextResources.MsgNotOnlineValue, TextResources.MsgNotOnlineTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public Main()
        {
            InitializeComponent();
            Engine = new EngineService();
            Settings = new ACESettings();
            SetTab();
            SetVersion();
            RegisterEvents();
         
            statusAgent.ForeColor = Color.Red;

            if (Settings.Eshops.Eshops.Count == 0)
            {
                MessageEshopConfigurationMissing();
            }
            else
            {
                eshopSettings.SetEshop(Settings.ActiveEshop());
            }

            InitializeEshopConnection();

            RefreshStatusBar();

            Size mainFormSize = Settings.GetSize("main");
            if (mainFormSize != new Size(0,0))
            {
                Size = mainFormSize;
            }

            DataGridTools.SetMainSettings(Settings);
            InitDisplayEshopConfiguration();
            InitStatusBar();
            ShowHomeBrowser();
            
            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
        }

        private void ShowHomeBrowser()
        {
            if (Engine.Login.IsOnline())
            {
                homeBrowser.Url = new Uri(ACESettings.HomePath);                    
            }
            else
            {
                String appdir = Path.GetDirectoryName(Application.ExecutablePath);
                String myfile = Path.Combine(appdir, "HtmlDocs/Home.html");
                homeBrowser.Url = new Uri("file:///" + myfile);
            }
        }

        private void ShowChangeLogBrowser()
        {
            if (Engine.Login.IsOnline())
            {
                homeBrowser.Url = new Uri(ACESettings.ChangeLogPath);
            }
            else
            {
                String appdir = Path.GetDirectoryName(Application.ExecutablePath);
                String myfile = Path.Combine(appdir, "HtmlDocs/ChangeLog.html");
                homeBrowser.Url = new Uri("file:///" + myfile);
            }
        }

        private void DisplayEshop()
        {
            if (_selectedEshopIndex == -1)
            {
                eshopSettings.SetEshop(null);
            }
            else
            {
                eshopSettings.SetEshop(Settings.Eshops.Eshops[_selectedEshopIndex]);
            }
        }

        private void MainLoad(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip {AutoPopDelay = 5000, InitialDelay = 1000, ReshowDelay = 500, ShowAlways = true};

            toolTip.SetToolTip(bLoadProducts, TextResources.HintLoadProducts);
            toolTip.SetToolTip(bEmptyCategory, TextResources.HintWithoutCategory);
            toolTip.SetToolTip(bEmptyManufacturer, TextResources.HintWithoutManufacturer);
            toolTip.SetToolTip(bWithoutImage, TextResources.HintWithoutImage);
            toolTip.SetToolTip(bWithoutShortDescription, TextResources.HintWithoutShortDescription);
            toolTip.SetToolTip(bWithoutLongDescription, TextResources.HintWithoutLongDescription);
            toolTip.SetToolTip(bWithoutPrice, TextResources.HintWithoutPrice);
            toolTip.SetToolTip(bWithoutWholeSalePrice, TextResources.HintWithoutWholeSalePrice);
            toolTip.SetToolTip(bWithoutWeight, TextResources.HintWithoutWeight);
            toolTip.SetToolTip(bWithoutSupplier, TextResources.HintWithoutSupplier);

        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SetSize("main", Size);
            
            foreach (DataGridViewColumn item in dgConsistency.Columns)
            {
                Settings.SetWidth(dgConsistency.Name + item.Name, item.Width);
            }

            Settings.SaveSettings();
        }

        public void ACERightsError()
        {
            MessageBox.Show(TextResources.MsgRightsErrorValue, TextResources.MsgRightsErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public void DisableGroupBoxOnReload()
        {
            gbConsistency.Enabled = false;
            gbSelectProduct.Enabled = false;
        }

        public void DisableControlsWhenAccesingEshop()
        {
            _activeEshopEnabled = cbActiveEshop.Enabled;
            _loadProductEnabled = bLoadProducts.Enabled;
            _pricingInitEnabled = bPricingInit.Enabled;
            _consistencyEnabled = gbConsistency.Enabled;
            _saveChangesEnabled = bSaveChanges.Enabled;
            _pricingShowEnabled = bPricingShow.Enabled;
            _selectProductEnabled = gbSelectProduct.Enabled;
            _repriceEnabled = bReprice.Enabled;
            _pricingSaveEnabled = bPricingSave.Enabled;
            
            cbActiveEshop.Enabled = false;
            bLoadProducts.Enabled = false;
            bPricingInit.Enabled = false;
            gbConsistency.Enabled = false;
            bSaveChanges.Enabled = false;
            bPricingShow.Enabled = false;
            gbSelectProduct.Enabled = false;
            bReprice.Enabled = false;
            bPricingSave.Enabled = false;
        }

        public void EnableControlsAfterAccesingEshop()
        {
            cbActiveEshop.Enabled = _activeEshopEnabled;
            bLoadProducts.Enabled = _loadProductEnabled;
            bPricingInit.Enabled = _pricingInitEnabled;
            gbConsistency.Enabled = _consistencyEnabled;
            bSaveChanges.Enabled = _saveChangesEnabled;
            bPricingShow.Enabled = _pricingShowEnabled;
            gbSelectProduct.Enabled = _selectProductEnabled;
            bReprice.Enabled = _repriceEnabled;
            bPricingSave.Enabled = _pricingSaveEnabled;
        }
        
        public void ClearGridsOnReload()
        {
            ClearConsistencyGrid();
            ClearPricingGrid();
        }

        private void ClearConsistencyGrid()
        {
            dgConsistency.Rows.Clear();
            dgConsistency.Refresh();
        }

        private void ClearPricingGrid()
        {
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

        private void DgConsistencyCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _indexForChange)
            {
                string value = dgConsistency[e.ColumnIndex, e.RowIndex].Value.ToString();
                int id = Convert.ToInt32(dgConsistency["id", e.RowIndex].Value);

                ChangeRecord record = new ChangeRecord {Type = RecordType.Product, Field = _changedType, Id = id, Value = value};

                _consistencyChanges.Add(record);
            }
        }

        private async void BLoadProductsClick(object sender, EventArgs e)
        {
            Engine.Login.GetRights();
            if (Engine.Login.Rights.Consistency)
            {
                if (Engine.Login.IsOnline() == false)
                {
                    MessageIsOffline();
                    return;
                }
                if ((String.IsNullOrEmpty(Engine.ApiToken)) || (String.IsNullOrEmpty(Engine.BaseUrl)))
                {
                    MessageEshopConfigurationMissing();
                }
                else
                {
                    try
                    {
                        bool result;
                        
                        DisableControlsWhenAccesingEshop();

                        statusProgress.Visible = true;
                        statusMessage.Text = "Nahrávám jazyky, prosím čekejte...";

                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        statusMessage.Text = "Nahrávám výrobce, prosím čekejte...";
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        statusMessage.Text = "Nahrávám dodavatele, prosím čekejte...";
                        result = await Engine.Suppliers.LoadSuppliersAsync();
                        statusMessage.Text = "Nahrávám kategorie, prosím čekejte...";
                        result = await Engine.Categories.LoadCategoriesAsync();
                        statusMessage.Text = "Nahrávám produkty, prosím čekejte...";
                        result = await Engine.Products.LoadProductsAsync();

                        statusProgress.Visible = false;
                        statusMessage.Text = "";
                        _consistencyEnabled = true;
                        _saveChangesEnabled = true;
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

        private void SaveChangesAsync(IEnumerable<ChangeRecord> changes)
        {
            foreach (ChangeRecord change in changes)
            {
                if (change.Type == RecordType.Product)
                {
                    ProductViewModel item = Engine.Products.GetById(change.Id);

                    if (change.Field == FieldType.Category)
                    {
                        item.IdCategoryDefault = Engine.Categories.GetCategoryId(change.Value);
                    }
                    if (change.Field == FieldType.LongDescription)
                    {
                        item.Description = change.Value;
                    }
                    if (change.Field == FieldType.Manufacturer)
                    {
                        item.IdManufacturer = Engine.Manufacturers.GetManufacturerId(change.Value);
                    }
                    if (change.Field == FieldType.Price)
                    {
                        item.Price = Convert.ToDecimal(change.Value);
                    }
                    if (change.Field == FieldType.ShortDescription)
                    {
                        item.DescriptionShort = change.Value;
                    }
                    if (change.Field == FieldType.Weight)
                    {
                        item.Weight = Convert.ToDecimal(change.Value);
                    }
                    if (change.Field == FieldType.WholesalePrice)
                    {
                        item.WholesalePrice = Convert.ToDecimal(change.Value);
                    }
                    Engine.Products.Edit(item);
                }
            }
        }

        private async void BSaveChangesClick(object sender, EventArgs e)
        {
            ChangesView changes = new ChangesView(_consistencyChanges.OrderBy(o => o.Id).ToList());
            if (_consistencyChanges.Count == 0)
            {
                MessageBox.Show(TextResources.MsgNoChangesToSaveValue, TextResources.MsgNoChangesToSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (changes.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DisableControlsWhenAccesingEshop();

                        statusProgress.Visible = true;
                        statusMessage.Text = TextResources.StatusSavingChanges;
                        gbConsistency.Enabled = false;

                        await Task.Factory.StartNew(() => SaveChangesAsync(_consistencyChanges));

                        _consistencyChanges.Clear();

                        bool result;

                        statusProgress.Visible = true;
                        statusMessage.Text = TextResources.StatusLoadingLanguages;
                        
                        result = await Engine.Languages.LoadLanguagesAsync();
                        Engine.Languages.GetActiveLanguage();
                        Engine.SetupPrestaLanguages();
                        statusMessage.Text = TextResources.StatusLoadingManufacturers;
                        result = await Engine.Manufacturers.LoadManufacturersAsync();
                        statusMessage.Text = TextResources.StatusLoadingCategories;
                        result = await Engine.Categories.LoadCategoriesAsync();
                        statusMessage.Text = TextResources.StatusLoadingProducts;
                        result = await Engine.Products.LoadProductsAsync();

                        statusProgress.Visible = false;
                        statusMessage.Text = "";
                        _consistencyEnabled = true;

                        dgConsistency.DataSource = null;
                    }
                    finally
                    {
                        _pricingSaveEnabled = false;
                        _repriceEnabled = false;
                        _pricingShowEnabled = false;
                        _selectProductEnabled = false;
                        EnableControlsAfterAccesingEshop();
                    }
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
            statusActiveEshop.Text = TextResources.StatusNoActiveEshop;
        }

        #endregion

        #region EshopConfiguration
        
        private void BPrestaTestClick(object sender, EventArgs e)
        {
            if (eshopSettings.IsValid)
            {
                if (Engine.TestPrestaAccess())
                {
                    MessageBox.Show(TextResources.MsgConnectionTestPass, TextResources.MsgConnectionTestTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(TextResources.MsgConnectionTestFail, TextResources.MsgConnectionTestTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            else
            {
                MessageBox.Show(TextResources.MsgErrorInConnectionParameters, TextResources.MsgConnectionTestTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BAddEshopClick(object sender, EventArgs e)
        {
            EshopConfiguration eshop = new EshopConfiguration();
            eshop.EshopName = "Eshop" + Settings.Eshops.Eshops.Count();
            eshop.Type = Enums.EshopType.Prestashop;
            TreeNode treeNode = new TreeNode();
            Settings.Eshops.Eshops.Add(eshop);
            treeConfiguration.Nodes.Add(treeNode);
            if (Settings.Eshops.ActiveEshopIndex == -1)
            {
                Settings.Eshops.ActiveEshopIndex = 0;
                _selectedEshopIndex = 0;
            }
            InitDisplayEshopConfiguration();
        }

        private void CbActiveEshopSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Eshops.ActiveEshopIndex = cbActiveEshop.SelectedIndex;
            if (Settings.ActiveEshop() != null)
            {
                InitializeEshopConnection();
            }
            RefreshStatusBar();
        }

        private void InitEshopList()
        {
            cbActiveEshop.Items.Clear();
            foreach (EshopConfiguration eshop in Settings.Eshops.Eshops)
            {
                cbActiveEshop.Items.Add(eshop.EshopName);
            }

            if ((Settings.Eshops.ActiveEshopIndex != -1) && (Settings.Eshops.ActiveEshopIndex < Settings.Eshops.Eshops.Count))
            {
                cbActiveEshop.SelectedIndex = Settings.Eshops.ActiveEshopIndex;
            }
        }

        private void InitDisplayEshopConfiguration()
        {
            EnableEshopSettingsControls();

            if (Settings.Eshops.Eshops.Count > 0)
            {
                InitEshopList();
                                                
                treeConfiguration.Nodes.Clear();
                foreach (EshopConfiguration eshop in Settings.Eshops.Eshops)
                {
                    TreeNode treeNode = new TreeNode(eshop.EshopName);
                    treeConfiguration.Nodes.Add(treeNode);
                }
                if ((Settings.Eshops.ActiveEshopIndex < treeConfiguration.Nodes.Count) && (Settings.Eshops.ActiveEshopIndex != -1))
                {
                    ShowNode(treeConfiguration.Nodes[Settings.Eshops.ActiveEshopIndex]);

                    treeConfiguration.SelectedNode = treeConfiguration.Nodes[Settings.Eshops.ActiveEshopIndex];
                    DisplayEshop();
                }
            }
        }

        private void EnableEshopSettingsControls()
        {
            if (Settings.Eshops.Eshops.Count < 1)
            {
                eshopSettings.DisableControls(false);
                bPrestaTest.Enabled = false;
            }
            else
            {
                eshopSettings.DisableControls(true);
                bPrestaTest.Enabled = true;
            }
        }

        private void ShowNode(TreeNode node)
        {
                EshopConfiguration eshop = Settings.Eshops.Eshops.SingleOrDefault(n => n.EshopName == node.Text);
                if (eshop != null)
                {
                    _selectedEshopIndex = Settings.Eshops.Eshops.IndexOf(eshop);
                    eshopSettings.SetEshop(eshop);
                    RefreshStatusBar();
                }
        }

        private void TreeConfigurationMouseDown(object sender, MouseEventArgs e)
        {
            TreeNode mySelectedNode = treeConfiguration.GetNodeAt(e.X, e.Y);

            if (mySelectedNode != null)
            {
                if (mySelectedNode.Parent == null)
                {
                    ShowNode(mySelectedNode);
                }
            }
        }

        private void TreeConfigurationAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.EndEdit(false);
            if (e.Label != null)
            {
                UpdateEshopName(e.Node.Index, e.Label);
                RefreshActiveEshopCombo();
            }
        }

        private void RefreshActiveEshopCombo()
        {
            EnableEshopSettingsControls();

            int index = cbActiveEshop.SelectedIndex;
            InitEshopList();
            cbActiveEshop.SelectedIndex = index;
        }

        private void UpdateEshopName(int eshopIndex, string newName)
        {
            Settings.Eshops.Eshops[eshopIndex].EshopName = newName;
        }

        private void BDelEshopClick(object sender, EventArgs e)
        {
            if (treeConfiguration.SelectedNode != null)
            {
                if (treeConfiguration.SelectedNode.Parent == null)
                {
                    DialogResult dialogResult = MessageBox.Show(String.Format("{0} {1} ?", TextResources.MsgDeleteEshopValue, treeConfiguration.SelectedNode.Text), TextResources.MsgDeleteEshopTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Settings.Eshops.ActiveEshopIndex == treeConfiguration.Nodes.IndexOf(treeConfiguration.SelectedNode))
                        {
                            Settings.Eshops.ActiveEshopIndex = -1;
                            _selectedEshopIndex = Settings.Eshops.ActiveEshopIndex;
                            DisplayEshop();
                        }

                        Settings.Eshops.Eshops.RemoveAll(n => n.EshopName == treeConfiguration.SelectedNode.Text);
                        treeConfiguration.Nodes.Remove(treeConfiguration.SelectedNode);
                        
                        RefreshActiveEshop();
                    }
                }
            }
        }

        private void RefreshActiveEshop()
        {
            EnableEshopSettingsControls();
            cbActiveEshop.SelectedIndex = Settings.Eshops.ActiveEshopIndex;
        }

        private void TreeConfigurationDoubleClick(object sender, EventArgs e)
        {
            TreeNode mySelectedNode = treeConfiguration.SelectedNode;
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


        private void BLoginClick(object sender, EventArgs e)
        {
            if (Engine.Login.Logged())
            {
                Engine.Login.Logout();
                bInitModuleInfo.Enabled = false;
                statusAgent.ForeColor = Color.Red;
            }
            else
            {
                var loginForm = new Login(Engine, Settings.DesktopUserName, Settings.DesktopPassword);
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Settings.DesktopUserName = loginForm.Username;
                    Settings.DesktopPassword = loginForm.Password;
                    bLogin.Text = TextResources.ButtonLogout;
                    statusAgent.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show(TextResources.MsgLoginRequiredValue, TextResources.MsgLoginRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            InitUserInfo();
            bInitModuleInfo.Enabled = true;
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
                lHomeCompany.Text = String.Empty;
                lHomeCredit.Text = String.Empty;
                lHomeEmail.Text = String.Empty;
                lHomeName.Text = String.Empty;
                lHomePaymentSymbol.Text = String.Empty;
                lHomeUserName.Text = String.Empty;
            }
        }

        private void InitModuleInfo()
        {
            dgHomeModules.Rows.Clear();
            dgHomeModules = Engine.Login.GetModuleInfo(dgHomeModules);
        }
        #endregion

        #region ACEMainMenu

        private void UkončitACEDesktopToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuShowHomeClick(object sender, EventArgs e)
        {
            tc.SelectedTab = tpHome;
            ShowHomeBrowser();
        }

        private void MenuShowChangeLogClick(object sender, EventArgs e)
        {
            tc.SelectedTab = tpHome;
            ShowChangeLogBrowser();
        }

        #endregion

        #region ConsistencyGrid

        private void DgConsistencyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgConsistency.Columns[e.ColumnIndex].Name == "Link")
            {
                var productId = dgConsistency[0, e.RowIndex].Value;
                Engine.OpenProductInBrowser(Convert.ToInt32(productId));
            }

            if (dgConsistency.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show(TextResources.MsgDeleteProductValue, TextResources.MsgDeleteProductTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var productId = dgConsistency[0, e.RowIndex].Value;
                    Engine.Products.DeleteProduct(Convert.ToInt32(productId));
                    ConsistencySuppliersClick(null, new EventArgs());
                }
            }
        }

        private void BEmptyCategoryClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyCategory;
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "Category", TextResources.Category, Engine.Categories.GetCategoryList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyCategory();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["Category"];
                comboCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 3;
            _changedType = FieldType.Category;
        }

        private void BEmptyManufacturerClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyManufacturer;
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "IdManufacturer", TextResources.Manufacturer, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "Manufacturer", TextResources.Manufacturer, Engine.Manufacturers.GetManufacturersList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));

                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["Manufacturer"];
                comboCell.Value = Engine.Manufacturers.GetManufacturerName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdManufacturer"].Value));
            }

            _indexForChange = 5;
            _changedType = FieldType.Manufacturer;
        }

        private void BWithoutImageClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyImage;
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyImage();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "IdImage", TextResources.ProductImage, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 5;
            _changedType = FieldType.Image;
        }

        private void BWithoutShortDescriptionClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyShortDescription;
            DataGridTools.InitGrid(dgConsistency);

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "DescriptionShort", TextResources.ShortDescription, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 4;
            _changedType = FieldType.ShortDescription;
        }

        private void BWithoutLongDescriptionClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyLongDescription;
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyLongDescription();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "Description", TextResources.Description, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 4;
            _changedType = FieldType.LongDescription;
        }

        private void BWithoutPriceClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyPrice;
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyPrice();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddNumberColumn(dgConsistency, "Price", TextResources.SalePrice, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 4;
            _changedType = FieldType.Price;
        }

        private void BWithoutWeightClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyWeight;
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWeight();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddNumberColumn(dgConsistency, "Weight", TextResources.Weight, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }
            _indexForChange = 4;
            _changedType = FieldType.Weight;
        }

        private void BWithoutWholeSalePriceClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptyWholeSalePrice;
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWholesalePrice();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddNumberColumn(dgConsistency, "WholesalePrice", TextResources.WholeSalePrice, false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));
            }

            _indexForChange = 4;
            _changedType = FieldType.WholesalePrice;
        }

        private void BConsistencySupplierClick(object sender, EventArgs e)
        {
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleEmptySupplier;
            DataGridTools.InitGrid(dgConsistency);

            dgConsistency.DataSource = Engine.Products.GetProductWithoutSupplier();

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "IdSupplier", TextResources.Supplier, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "Supplier", TextResources.Supplier, Engine.Suppliers.GetSupplierList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                textCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));

                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["Supplier"];
                comboCell.Value = Engine.Suppliers.GetSupplierName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdSupplier"].Value));
            }

            _indexForChange = 5;
            _changedType = FieldType.Supplier;
        }

        private void ConsistencySuppliersClick(object sender, EventArgs e)
        {
            foreach (SupplierConfiguration supplier in Settings.ActiveEshop().Suppliers)
            {
                if (File.Exists(supplier.PathToFile) == false)
                {
                    MessageBox.Show(string.Format("{0} Askina", TextResources.MsgNoPriceListValue), TextResources.MsgNoPriceListTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            Engine.PriceLists.LoadPriceLists(Settings.ActiveEshop().Suppliers);
                        
            _indexForChange = -1;
            lListOf.Text = TextResources.GridTitleWithoutAnySupplier;
            DataGridTools.InitGrid(dgConsistency);

            dgConsistency.DataSource = Engine.Products.GetNonAvailableProductOfSuppliers(Engine.PriceLists, Engine.Suppliers);

            DataGridTools.AddColumn(dgConsistency, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "Reference", TextResources.Reference);
            DataGridTools.AddColumn(dgConsistency, "Name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "IdCategoryDefault", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "Category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "IdSupplier", TextResources.Supplier, false);
            DataGridTools.AddColumn(dgConsistency, "Supplier", TextResources.Supplier, true, false);
            DataGridTools.AddButtonColumn(dgConsistency, "Link", TextResources.LinkButton);
            DataGridTools.AddButtonColumn(dgConsistency, "Delete", TextResources.DeleteButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdCategoryDefault"].Value));

                DataGridViewTextBoxCell supplierCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["Supplier"];
                supplierCell.Value = Engine.Suppliers.GetSupplierName(Convert.ToInt32(dgConsistency.Rows[i].Cells["IdSupplier"].Value));
            }

            _indexForChange = -1;
            _changedType = FieldType.Image;
        }

        #endregion

        private void bInitModuleInfo_Click(object sender, EventArgs e)
        {
            InitModuleInfo();
        }

    }
}
