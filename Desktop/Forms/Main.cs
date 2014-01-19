using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Desktop.UserSettings;
using Desktop.Utils;
using System.Threading.Tasks;
using Bussiness.Services;
using Bussiness;
using Bussiness.ViewModels;
using Bussiness.UserSettings;
using Desktop.Custom_Contols;

namespace Desktop.Forms
{
    public partial class Main : Form
    {
        public EngineService Engine;
        public ACESettings MainSettings;
        private int selectedEshopIndex;
        
        private readonly List<ChangeRecord> consistencyChanges = new List<ChangeRecord>();
        private int indexForChange = -1;
        private FieldType changedType;
        private readonly Version aceVersion;
        
        #region pricing

        private async void BPricingInitClick(object sender, EventArgs e)
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

            List<string> manufacturersList;
            manufacturersList = Engine.Manufacturers.GetManufacturersList();
            manufacturersList.Insert(0, "Jakýkoliv výrobce");
            cPricingManufacturers.Items.AddRange(manufacturersList.ToArray());
            cPricingManufacturers.SelectedIndex = 0;

            List<string> suppliersList; 
            suppliersList = Engine.Suppliers.GetSupplierList();
            suppliersList.Insert(0, "Jakýkoliv dodavatel");
            cPricingSuppliers.Items.AddRange(suppliersList.ToArray());
            cPricingSuppliers.SelectedIndex = 0;

            treePricing.Nodes.Clear();

            foreach (CategoryViewModel item in Engine.Categories.Categories)
            {
                TreeNode node = new TreeNode();
                node.Text = item.name;
                node.Name = item.id.ToString();

                if (item.level_depth == 0)
                {
                    treePricing.Nodes.Add(node);
                }
                else
                {
                    TreeNode parent = treePricing.Nodes.Find(item.id_parent.ToString(), true).FirstOrDefault();
                    parent.Nodes.Add(node);
                }
            }
            treePricing.ExpandAll();
        }
        

        private void BRepriceClick(object sender, EventArgs e)
        {
            if (chPricingSupplier.Checked)
            {
                Engine.Pricing.UpdatePrices();
            }

            if (rbPricingProcent.Checked)
            {
                Engine.Pricing.ProcentReprice(Convert.ToDecimal(ePricingPercent.Text));
            }
            else
            {
                Engine.Pricing.LimitReprice(Convert.ToDecimal(ePricingLimit.Text), Convert.ToDecimal(ePricingBellowLimit), Convert.ToDecimal(ePricingOverLimit.Text));
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
            
            indexForChange = -1;
            DataGridTools.InitGrid(dgPricing);

            DataGridTools.AddColumn(dgPricing, "id", TextResources.Id);
            DataGridTools.AddColumn(dgPricing, "name", TextResources.Name);
            DataGridTools.AddColumn(dgPricing, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgPricing, "category", TextResources.Category);
            DataGridTools.AddColumn(dgPricing, "id_manufacturer", TextResources.Manufacturer, true, false);
            DataGridTools.AddColumn(dgPricing, "manufacturer", TextResources.Manufacturer);
            DataGridTools.AddColumn(dgPricing, "id_supplier", TextResources.Supplier, true, false);
            DataGridTools.AddColumn(dgPricing, "supplier", TextResources.Supplier);
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
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_category_default"].Value));

                DataGridViewTextBoxCell manufacturerCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["manufacturer"];
                manufacturerCell.Value = Engine.Manufacturers.GetManufacturerName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_manufacturer"].Value));

                DataGridViewTextBoxCell supplierCell = (DataGridViewTextBoxCell)dgPricing.Rows[i].Cells["supplier"];
                supplierCell.Value = Engine.Suppliers.GetSupplierName(System.Convert.ToInt32(dgPricing.Rows[i].Cells["id_supplier"].Value));
            };

            indexForChange = 8;  //9
            changedType = FieldType.category;
        }

        #endregion

        #region GeneralFunctionality

        private void eshopSettings_SuppliersChanged(object sender, EshopEventArgs e)
        {
            MainSettings.UpdateSelectedEshop(e.Eshop, selectedEshopIndex);
            RefreshStatusBar();
            MainSettings.SaveSettings();

            if (MainSettings.ActiveEshop() == MainSettings.Eshops.Eshops[selectedEshopIndex])
            {
                InitializeEshopConnection();
            }
        }
                
        private void InitializeEshopConnection()
        {
            DisableGroupBoxOnReload();
            ClearGridsOnReload();
            if (MainSettings.ActiveEshop() != null)
            {
                if (MainSettings.ActiveEshop().Type == EshopType.Prestashop)
                {
                    Engine.InitPrestaServices(MainSettings.ActiveEshop().BaseUrl, MainSettings.ActiveEshop().Password);
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            Engine = new EngineService();
            MainSettings = new ACESettings();
            selectedEshopIndex = MainSettings.Eshops.ActiveEshopIndex;
            eshopSettings.SuppliersChanged += new SupplierEventHandler(this.eshopSettings_SuppliersChanged);
         
            aceVersion = GetVersion();
            this.Text = "ACE Desktop " + aceVersion.ToString();
            this.statusAgent.ForeColor = Color.Red;

            if (MainSettings.Eshops.Eshops.Count == 0)
            {
                MessageBox.Show(TextResources.MsgEmptyConfigurationValue, TextResources.MsgEmptyConfigurationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                eshopSettings.SetEshop(MainSettings.ActiveEshop());
            }

            InitializeEshopConnection();

            RefreshStatusBar();

            Size mainFormSize = MainSettings.GetSize("main");
            if (mainFormSize != new Size(0,0))
            {
                this.Size = mainFormSize;
            }

            DataGridTools.SetMainSettings(MainSettings);
            InitDisplayEshopConfiguration();
            InitModuleInfo();
            InitStatusBar();
            
            this.homeBrowser.Url = new Uri(ACESettings.ChangeLogPath);
            
            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
        }

        private void DisplayEshop()
        {
            if (selectedEshopIndex == -1)
            {
                eshopSettings.SetEshop(null);
            }
            else
            {
                eshopSettings.SetEshop(MainSettings.Eshops.Eshops[selectedEshopIndex]);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.bLoadProducts, TextResources.HintLoadProducts);
            toolTip.SetToolTip(this.bEmptyCategory, TextResources.HintEmptyCategory);
            toolTip.SetToolTip(this.bEmptyManufacturer, TextResources.HintEmptyManufacturer);
            toolTip.SetToolTip(this.bWithoutImage, TextResources.HintWithoutImage);
            toolTip.SetToolTip(this.bWithoutShortDescription, TextResources.HintWithoutShortDescription);
            toolTip.SetToolTip(this.bWithoutLongDescription, TextResources.HintWithoutLongDescription);
            toolTip.SetToolTip(this.bWithoutPrice, TextResources.HintWithoutPrice);
            toolTip.SetToolTip(this.bWithoutWholeSalePrice, TextResources.HintWithoutWholeSalePrice);
            toolTip.SetToolTip(this.bWithoutWeight, TextResources.HintWithoutWeight);
            toolTip.SetToolTip(this.bWithoutSupplier, TextResources.HintWithoutSupplier);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainSettings.SetSize("main", this.Size);
            
            foreach (DataGridViewColumn item in dgConsistency.Columns)
            {
                MainSettings.SetWidth(dgConsistency.Name + item.Name, item.Width);
            }

            MainSettings.SaveSettings();
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
            bLoadProducts.Enabled = false;
            bPricingInit.Enabled = false;
        }

        public void EnableControlsAfterAccesingEshop()
        {
            cbActiveEshop.Enabled = true;
            bLoadProducts.Enabled = true;
            bPricingInit.Enabled = true;
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
            if (e.ColumnIndex == indexForChange)
            {
                string value = dgConsistency[e.ColumnIndex, e.RowIndex].Value.ToString();
                int id = System.Convert.ToInt32(dgConsistency["id", e.RowIndex].Value);

                ChangeRecord record = new ChangeRecord();
                record.Type = RecordType.product;
                record.Field = changedType;
                record.Id = id;
                record.Value = value;

                consistencyChanges.Add(record);
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
            ChangesView changes = new ChangesView(consistencyChanges);
            if (consistencyChanges.Count == 0)
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

                        await Task.Factory.StartNew(() => this.SaveChangesAsync(consistencyChanges));

                        consistencyChanges.Clear();

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
            statusActiveEshop.Text = "Aktivní eshop: žádný";

            statusAskino.Visible = false;
            statusNoviko.Visible = false;

            if (MainSettings.Eshops.ActiveEshopIndex != -1)
            {
                statusActiveEshop.Text = "Aktivní eshop: " + MainSettings.ActiveEshop().EshopName;

                if (File.Exists(MainSettings.ActiveEshop().Suppliers[MainSettings.ActiveEshop().AskinoIndex()].SupplierFileName) == true)
                {
                    statusAskino.Visible = true;
                }

                if (File.Exists(MainSettings.ActiveEshop().Suppliers[MainSettings.ActiveEshop().NovikoIndex()].SupplierFileName) == true)
                {
                    statusNoviko.Visible = true;
                }
            }
        }

        #endregion

        #region EshopConfiguration
        
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
            eshop.EshopName = "Eshop" + MainSettings.Eshops.Eshops.Count();
            eshop.Type = EshopType.Prestashop;
            TreeNode treeNode = new TreeNode();
            MainSettings.Eshops.Eshops.Add(eshop);
            treeConfiguration.Nodes.Add(treeNode);
            if (MainSettings.Eshops.ActiveEshopIndex == -1)
            {
                MainSettings.Eshops.ActiveEshopIndex = 0;
                selectedEshopIndex = 0;
            }
            InitDisplayEshopConfiguration();
        }

        private void cbActiveEshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainSettings.Eshops.ActiveEshopIndex = cbActiveEshop.SelectedIndex;
            if (MainSettings.ActiveEshop() != null)
            {
                InitializeEshopConnection();
            }
            RefreshStatusBar();
        }

        private void InitEshopList()
        {
            cbActiveEshop.Items.Clear();
            foreach (EshopConfiguration eshop in MainSettings.Eshops.Eshops)
            {
                cbActiveEshop.Items.Add(eshop.EshopName);
            }

            if ((MainSettings.Eshops.ActiveEshopIndex != -1) && (MainSettings.Eshops.ActiveEshopIndex < MainSettings.Eshops.Eshops.Count))
            {
                cbActiveEshop.SelectedIndex = MainSettings.Eshops.ActiveEshopIndex;
            }
        }

        private void InitDisplayEshopConfiguration()
        {
            if (MainSettings.Eshops.Eshops.Count > 0)
            {
                InitEshopList();
                                                
                treeConfiguration.Nodes.Clear();
                foreach (EshopConfiguration eshop in MainSettings.Eshops.Eshops)
                {
                    TreeNode treeNode = new TreeNode(eshop.EshopName);
                    treeConfiguration.Nodes.Add(treeNode);
                }
                if ((MainSettings.Eshops.ActiveEshopIndex < treeConfiguration.Nodes.Count) && (MainSettings.Eshops.ActiveEshopIndex != -1))
                {
                    ShowNode(treeConfiguration.Nodes[MainSettings.Eshops.ActiveEshopIndex]);

                    treeConfiguration.SelectedNode = treeConfiguration.Nodes[MainSettings.Eshops.ActiveEshopIndex];
                    DisplayEshop();
                }
            }
        }

        private void ShowNode(TreeNode node)
        {
                EshopConfiguration eshop = MainSettings.Eshops.Eshops.Where(n => n.EshopName == node.Text).SingleOrDefault();
                if (eshop != null)
                {
                    selectedEshopIndex = MainSettings.Eshops.Eshops.IndexOf(eshop);
                    eshopSettings.SetEshop(eshop);
                    RefreshStatusBar();
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
            if (e.Label != null)
            {
                UpdateEshopName(e.Node.Index, e.Label);
                RefreshActiveEshopCombo();
            }
        }

        private void RefreshActiveEshopCombo()
        {
            int index = cbActiveEshop.SelectedIndex;
            InitEshopList();
            cbActiveEshop.SelectedIndex = index;
        }

        private void UpdateEshopName(int eshopIndex, string newName)
        {
            MainSettings.Eshops.Eshops[eshopIndex].EshopName = newName;
        }

        private void bDelEshop_Click(object sender, EventArgs e)
        {
            if (treeConfiguration.SelectedNode != null)
            {
                if (treeConfiguration.SelectedNode.Parent == null)
                {
                    DialogResult dialogResult = MessageBox.Show(String.Format("{0} {1} ?", TextResources.MsgDeleteEshopValue, treeConfiguration.SelectedNode.Text), TextResources.MsgDeleteEshopTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (MainSettings.Eshops.ActiveEshopIndex == treeConfiguration.Nodes.IndexOf(treeConfiguration.SelectedNode))
                        {
                            MainSettings.Eshops.ActiveEshopIndex = -1;
                            selectedEshopIndex = MainSettings.Eshops.ActiveEshopIndex;
                            DisplayEshop();
                        }

                        MainSettings.Eshops.Eshops.RemoveAll(n => n.EshopName == treeConfiguration.SelectedNode.Text);
                        treeConfiguration.Nodes.Remove(treeConfiguration.SelectedNode);
                        
                        RefreshActiveEshop();
                    }
                }
            }
        }

        private void RefreshActiveEshop()
        {
            cbActiveEshop.SelectedIndex = MainSettings.Eshops.ActiveEshopIndex;
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
                Engine.Login.Logout();
                this.statusAgent.ForeColor = Color.Red;
            }
            else
            {
                var LoginForm = new Login(Engine, MainSettings.DesktopUserName, MainSettings.DesktopPassword);
                if (LoginForm.ShowDialog() == DialogResult.OK)
                {
                    this.MainSettings.DesktopUserName = LoginForm.Username;
                    this.MainSettings.DesktopPassword = LoginForm.Password;
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
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgConsistency.Columns[e.ColumnIndex].Name == "link")
            {
                var productId = dgConsistency[0, e.RowIndex].Value;
                Engine.OpenProductInBrowser(System.Convert.ToInt32(productId));
            }

            if (dgConsistency.Columns[e.ColumnIndex].Name == "delete")
            {
                DialogResult dialogResult = MessageBox.Show(TextResources.MsgDeleteProductValue, TextResources.MsgDeleteProductTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var productId = dgConsistency[0, e.RowIndex].Value;
                    Engine.Products.DeleteProduct(System.Convert.ToInt32(productId));
                    this.ConsistencySuppliers_Click(null, new EventArgs());
                }
            }
        }

        private void bEmptyCategory_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
            lListOf.Text = TextResources.TitleEmptyCategory;
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

            indexForChange = 3;
            changedType = FieldType.category;
        }

        private void bEmptyManufacturer_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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

            indexForChange = 5;
            changedType = FieldType.manufacturer;
        }

        private void bWithoutImage_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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
            }

            indexForChange = 5;
            changedType = FieldType.image;
        }

        private void bWithoutShortDescription_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
            lListOf.Text = TextResources.TitleEmptyDescription;
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

            indexForChange = 4;
            changedType = FieldType.shortDescription;
        }

        private void bWithoutLongDescription_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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

            indexForChange = 4;
            changedType = FieldType.longDescription;
        }

        private void bWithoutPrice_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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

            indexForChange = 4;
            changedType = FieldType.price;
        }

        private void bWithoutWeight_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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
            indexForChange = 4;
            changedType = FieldType.weight;
        }

        private void bWithoutWholeSalePrice_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
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

            indexForChange = 4;
            changedType = FieldType.wholesalePrice;
        }

        private void bConsistencySupplier_Click(object sender, EventArgs e)
        {
            indexForChange = -1;
            lListOf.Text = "Zobrazuji produkty bez zadaného dodavatele.";
            DataGridTools.InitGrid(dgConsistency);

            dgConsistency.DataSource = Engine.Products.GetProductWithoutSupplier();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_supplier", TextResources.Supplier, false, false);
            DataGridTools.AddComboBoxColumn(dgConsistency, "supplier", TextResources.Supplier, Engine.Suppliers.GetSupplierList(), false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                textCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));

                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["supplier"];
                comboCell.Value = Engine.Manufacturers.GetManufacturerName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_supplier"].Value));
            };

            indexForChange = 5;
            changedType = FieldType.manufacturer;
        }

        private void ConsistencySuppliers_Click(object sender, EventArgs e)
        {
            foreach (SupplierConfiguration supplier in MainSettings.ActiveEshop().Suppliers)
            {
                if (supplier.UseSupplier)
                {
                    if (File.Exists(supplier.SupplierFileName) == false)
                    {
                        MessageBox.Show(TextResources.MsgNoPriceListValue + " Askina", TextResources.MsgNoPriceListTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            Engine.PriceLists.AddPriceLists(MainSettings.ActiveEshop());
                        
            indexForChange = -1;
            lListOf.Text = TextResources.TitleWithoutSupplier;
            DataGridTools.InitGrid(dgConsistency);

            dgConsistency.DataSource = Engine.Products.GetNonAvailableProductOfSuppliers(Engine.PriceLists, Engine.Suppliers.GetAskinoId(), Engine.Suppliers.GetNovikoId());

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, true, false);
            DataGridTools.AddColumn(dgConsistency, "category", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_supplier_default", TextResources.Supplier, false);
            DataGridTools.AddColumn(dgConsistency, "supplier", TextResources.Supplier, true, false);
            DataGridTools.AddButtonColumn(dgConsistency, "link", TextResources.LinkButton);
            DataGridTools.AddButtonColumn(dgConsistency, "delete", TextResources.DeleteButton);

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewTextBoxCell categoryCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["category"];
                categoryCell.Value = Engine.Categories.GetCategoryName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_category_default"].Value));

                DataGridViewTextBoxCell supplierCell = (DataGridViewTextBoxCell)dgConsistency.Rows[i].Cells["supplier"];
                supplierCell.Value = Engine.Suppliers.GetSupplierName(System.Convert.ToInt32(dgConsistency.Rows[i].Cells["id_supplier_default"].Value));
            };

            indexForChange = -1;
            changedType = FieldType.image;
        }

        #endregion
    }
}
