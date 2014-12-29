﻿namespace Desktop.Forms
 {
     partial class Main
     {
         /// <summary>
         /// Required designer variable.
         /// </summary>
         private System.ComponentModel.IContainer components = null;

         /// <summary>
         /// Clean up any resources being used.
         /// </summary>
         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
         protected override void Dispose(bool disposing)
         {
             if (disposing && (components != null))
             {
                 components.Dispose();
             }
             base.Dispose(disposing);
         }

         #region Windows Form Designer generated code

         /// <summary>
         /// Required method for Designer support - do not modify
         /// the contents of this method with the code editor.
         /// </summary>
         private void InitializeComponent()
         {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.productsSD = new System.Windows.Forms.SaveFileDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.openProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.ukončitACEDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowChangeLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowHome = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusAgent = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusActiveEshop = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpHome = new System.Windows.Forms.TabPage();
            this.gbModuleInfo = new System.Windows.Forms.GroupBox();
            this.dgHomeModules = new System.Windows.Forms.DataGridView();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OrderedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lHomeCredit = new System.Windows.Forms.Label();
            this.lHomeUserName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lHomeEmail = new System.Windows.Forms.Label();
            this.lHomeName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lHomePaymentSymbol = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lHomeCompany = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.homeBrowser = new System.Windows.Forms.WebBrowser();
            this.tpConsistency = new System.Windows.Forms.TabPage();
            this.lListOf = new System.Windows.Forms.Label();
            this.bLoadProducts = new System.Windows.Forms.Button();
            this.dgConsistency = new System.Windows.Forms.DataGridView();
            this.gbConsistency = new System.Windows.Forms.GroupBox();
            this.bWithoutSupplier = new System.Windows.Forms.Button();
            this.bSaveChanges = new System.Windows.Forms.Button();
            this.bWithoutWholeSalePrice = new System.Windows.Forms.Button();
            this.bWithoutLongDescription = new System.Windows.Forms.Button();
            this.bWithoutPrice = new System.Windows.Forms.Button();
            this.bConsistencySuppliers = new System.Windows.Forms.Button();
            this.bWithoutWeight = new System.Windows.Forms.Button();
            this.bEmptyManufacturer = new System.Windows.Forms.Button();
            this.bWithoutShortDescription = new System.Windows.Forms.Button();
            this.bEmptyCategory = new System.Windows.Forms.Button();
            this.bWithoutImage = new System.Windows.Forms.Button();
            this.tpPriceUpdate = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lPricingSupplierIndication = new System.Windows.Forms.Label();
            this.lPricingCategoryIndication = new System.Windows.Forms.Label();
            this.bPricingInit = new System.Windows.Forms.Button();
            this.lPricingManufacturerIndication = new System.Windows.Forms.Label();
            this.gbSelectProduct = new System.Windows.Forms.GroupBox();
            this.chPricingSupplier = new System.Windows.Forms.CheckBox();
            this.bPricingShow = new System.Windows.Forms.Button();
            this.rbPricingLimit = new System.Windows.Forms.RadioButton();
            this.bPricingSave = new System.Windows.Forms.Button();
            this.rbPricingProcent = new System.Windows.Forms.RadioButton();
            this.treePricing = new System.Windows.Forms.TreeView();
            this.lPricingSupplier = new System.Windows.Forms.Label();
            this.cPricingSuppliers = new System.Windows.Forms.ComboBox();
            this.bReprice = new System.Windows.Forms.Button();
            this.lPricingManufacturer = new System.Windows.Forms.Label();
            this.cPricingManufacturers = new System.Windows.Forms.ComboBox();
            this.ePricingPercent = new System.Windows.Forms.TextBox();
            this.dgPricing = new System.Windows.Forms.DataGridView();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.eshopSettings = new Desktop.Custom_Contols.EshopConfigurationControl();
            this.lActiveEshop = new System.Windows.Forms.Label();
            this.cbActiveEshop = new System.Windows.Forms.ComboBox();
            this.bDelEshop = new System.Windows.Forms.Button();
            this.bAddEshop = new System.Windows.Forms.Button();
            this.treeConfiguration = new System.Windows.Forms.TreeView();
            this.bPrestaTest = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tc.SuspendLayout();
            this.tpHome.SuspendLayout();
            this.gbModuleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeModules)).BeginInit();
            this.gbUserInfo.SuspendLayout();
            this.tpConsistency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsistency)).BeginInit();
            this.gbConsistency.SuspendLayout();
            this.tpPriceUpdate.SuspendLayout();
            this.gbSelectProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPricing)).BeginInit();
            this.tpSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProducts,
            this.toolsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1031, 24);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // openProducts
            // 
            this.openProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ukončitACEDesktopToolStripMenuItem});
            this.openProducts.Name = "openProducts";
            this.openProducts.Size = new System.Drawing.Size(53, 20);
            this.openProducts.Text = "Soubor";
            // 
            // ukončitACEDesktopToolStripMenuItem
            // 
            this.ukončitACEDesktopToolStripMenuItem.Name = "ukončitACEDesktopToolStripMenuItem";
            this.ukončitACEDesktopToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ukončitACEDesktopToolStripMenuItem.Text = "Ukončit ACE Desktop";
            this.ukončitACEDesktopToolStripMenuItem.Click += new System.EventHandler(this.UkončitACEDesktopToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowChangeLog,
            this.menuShowHome});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.toolsToolStripMenuItem.Text = "Zobraz";
            // 
            // menuShowChangeLog
            // 
            this.menuShowChangeLog.Name = "menuShowChangeLog";
            this.menuShowChangeLog.Size = new System.Drawing.Size(175, 22);
            this.menuShowChangeLog.Text = "Zobraz seznam změn";
            this.menuShowChangeLog.Click += new System.EventHandler(this.MenuShowChangeLogClick);
            // 
            // menuShowHome
            // 
            this.menuShowHome.Name = "menuShowHome";
            this.menuShowHome.Size = new System.Drawing.Size(175, 22);
            this.menuShowHome.Text = "Zobraz home stránku";
            this.menuShowHome.Click += new System.EventHandler(this.MenuShowHomeClick);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusAgent,
            this.statusLogin,
            this.statusActiveEshop,
            this.statusProgress,
            this.statusMessage});
            this.status.Location = new System.Drawing.Point(0, 647);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1031, 22);
            this.status.TabIndex = 14;
            this.status.Text = "Status";
            // 
            // statusAgent
            // 
            this.statusAgent.Name = "statusAgent";
            this.statusAgent.Size = new System.Drawing.Size(115, 17);
            this.statusAgent.Text = "Přihlášení k ACE Agent";
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(32, 17);
            this.statusLogin.Text = "Login";
            this.statusLogin.Visible = false;
            // 
            // statusActiveEshop
            // 
            this.statusActiveEshop.Name = "statusActiveEshop";
            this.statusActiveEshop.Size = new System.Drawing.Size(75, 17);
            this.statusActiveEshop.Text = "Aktivní eshop:";
            // 
            // statusProgress
            // 
            this.statusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgress.MarqueeAnimationSpeed = 20;
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(200, 16);
            this.statusProgress.Step = 0;
            this.statusProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusProgress.Visible = false;
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tc.Controls.Add(this.tpHome);
            this.tc.Controls.Add(this.tpConsistency);
            this.tc.Controls.Add(this.tpPriceUpdate);
            this.tc.Controls.Add(this.tpSetup);
            this.tc.Location = new System.Drawing.Point(0, 27);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(1031, 617);
            this.tc.TabIndex = 17;
            this.tc.SelectedIndexChanged += new System.EventHandler(this.TcSelectedIndexChanged);
            // 
            // tpHome
            // 
            this.tpHome.Controls.Add(this.gbModuleInfo);
            this.tpHome.Controls.Add(this.gbUserInfo);
            this.tpHome.Controls.Add(this.bLogin);
            this.tpHome.Controls.Add(this.homeBrowser);
            this.tpHome.Location = new System.Drawing.Point(4, 25);
            this.tpHome.Name = "tpHome";
            this.tpHome.Padding = new System.Windows.Forms.Padding(3);
            this.tpHome.Size = new System.Drawing.Size(1023, 588);
            this.tpHome.TabIndex = 0;
            this.tpHome.Text = "Home";
            this.tpHome.UseVisualStyleBackColor = true;
            // 
            // gbModuleInfo
            // 
            this.gbModuleInfo.Controls.Add(this.dgHomeModules);
            this.gbModuleInfo.Location = new System.Drawing.Point(10, 203);
            this.gbModuleInfo.Name = "gbModuleInfo";
            this.gbModuleInfo.Size = new System.Drawing.Size(383, 322);
            this.gbModuleInfo.TabIndex = 4;
            this.gbModuleInfo.TabStop = false;
            this.gbModuleInfo.Text = "Info o modulech";
            // 
            // dgHomeModules
            // 
            this.dgHomeModules.AllowUserToAddRows = false;
            this.dgHomeModules.AllowUserToDeleteRows = false;
            this.dgHomeModules.AllowUserToResizeColumns = false;
            this.dgHomeModules.AllowUserToResizeRows = false;
            this.dgHomeModules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgHomeModules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgHomeModules.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgHomeModules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgHomeModules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgHomeModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHomeModules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Module,
            this.ModuleActive,
            this.OrderedTo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgHomeModules.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgHomeModules.Location = new System.Drawing.Point(6, 19);
            this.dgHomeModules.Name = "dgHomeModules";
            this.dgHomeModules.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgHomeModules.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgHomeModules.RowHeadersVisible = false;
            this.dgHomeModules.Size = new System.Drawing.Size(371, 297);
            this.dgHomeModules.TabIndex = 0;
            // 
            // Module
            // 
            this.Module.HeaderText = "Jméno modulu";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            this.Module.Width = 200;
            // 
            // ModuleActive
            // 
            this.ModuleActive.HeaderText = "Objednán";
            this.ModuleActive.Name = "ModuleActive";
            this.ModuleActive.ReadOnly = true;
            this.ModuleActive.Width = 65;
            // 
            // OrderedTo
            // 
            this.OrderedTo.HeaderText = "Objednán do";
            this.OrderedTo.Name = "OrderedTo";
            this.OrderedTo.ReadOnly = true;
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.label16);
            this.gbUserInfo.Controls.Add(this.lHomeCredit);
            this.gbUserInfo.Controls.Add(this.lHomeUserName);
            this.gbUserInfo.Controls.Add(this.label13);
            this.gbUserInfo.Controls.Add(this.lHomeEmail);
            this.gbUserInfo.Controls.Add(this.lHomeName);
            this.gbUserInfo.Controls.Add(this.label10);
            this.gbUserInfo.Controls.Add(this.lHomePaymentSymbol);
            this.gbUserInfo.Controls.Add(this.label8);
            this.gbUserInfo.Controls.Add(this.label7);
            this.gbUserInfo.Controls.Add(this.lHomeCompany);
            this.gbUserInfo.Controls.Add(this.label5);
            this.gbUserInfo.Location = new System.Drawing.Point(10, 9);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(383, 188);
            this.gbUserInfo.TabIndex = 3;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "Info o uživateli";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Kredit:";
            // 
            // lHomeCredit
            // 
            this.lHomeCredit.Location = new System.Drawing.Point(151, 154);
            this.lHomeCredit.Name = "lHomeCredit";
            this.lHomeCredit.Size = new System.Drawing.Size(35, 13);
            this.lHomeCredit.TabIndex = 10;
            // 
            // lHomeUserName
            // 
            this.lHomeUserName.Location = new System.Drawing.Point(151, 31);
            this.lHomeUserName.Name = "lHomeUserName";
            this.lHomeUserName.Size = new System.Drawing.Size(35, 13);
            this.lHomeUserName.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Email:";
            // 
            // lHomeEmail
            // 
            this.lHomeEmail.Location = new System.Drawing.Point(151, 104);
            this.lHomeEmail.Name = "lHomeEmail";
            this.lHomeEmail.Size = new System.Drawing.Size(35, 13);
            this.lHomeEmail.TabIndex = 7;
            // 
            // lHomeName
            // 
            this.lHomeName.Location = new System.Drawing.Point(151, 55);
            this.lHomeName.Name = "lHomeName";
            this.lHomeName.Size = new System.Drawing.Size(35, 13);
            this.lHomeName.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Jméno:";
            // 
            // lHomePaymentSymbol
            // 
            this.lHomePaymentSymbol.Location = new System.Drawing.Point(151, 128);
            this.lHomePaymentSymbol.Name = "lHomePaymentSymbol";
            this.lHomePaymentSymbol.Size = new System.Drawing.Size(35, 13);
            this.lHomePaymentSymbol.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Platební symbol:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Společnost:";
            // 
            // lHomeCompany
            // 
            this.lHomeCompany.Location = new System.Drawing.Point(151, 77);
            this.lHomeCompany.Name = "lHomeCompany";
            this.lHomeCompany.Size = new System.Drawing.Size(35, 13);
            this.lHomeCompany.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Uživatelské jméno:";
            // 
            // bLogin
            // 
            this.bLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLogin.Location = new System.Drawing.Point(10, 540);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(383, 34);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Přihlášení";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.BLoginClick);
            // 
            // homeBrowser
            // 
            this.homeBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeBrowser.Location = new System.Drawing.Point(404, 6);
            this.homeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.homeBrowser.Name = "homeBrowser";
            this.homeBrowser.Size = new System.Drawing.Size(601, 576);
            this.homeBrowser.TabIndex = 0;
            // 
            // tpConsistency
            // 
            this.tpConsistency.Controls.Add(this.lListOf);
            this.tpConsistency.Controls.Add(this.bLoadProducts);
            this.tpConsistency.Controls.Add(this.dgConsistency);
            this.tpConsistency.Controls.Add(this.gbConsistency);
            this.tpConsistency.Location = new System.Drawing.Point(4, 25);
            this.tpConsistency.Name = "tpConsistency";
            this.tpConsistency.Size = new System.Drawing.Size(1023, 588);
            this.tpConsistency.TabIndex = 3;
            this.tpConsistency.Text = "Kontrola databáze eshopu";
            this.tpConsistency.UseVisualStyleBackColor = true;
            // 
            // lListOf
            // 
            this.lListOf.AutoSize = true;
            this.lListOf.Location = new System.Drawing.Point(187, 11);
            this.lListOf.Name = "lListOf";
            this.lListOf.Size = new System.Drawing.Size(105, 13);
            this.lListOf.TabIndex = 24;
            this.lListOf.Text = "Zobrazuji produkty s:";
            // 
            // bLoadProducts
            // 
            this.bLoadProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoadProducts.Location = new System.Drawing.Point(8, 11);
            this.bLoadProducts.Name = "bLoadProducts";
            this.bLoadProducts.Size = new System.Drawing.Size(173, 30);
            this.bLoadProducts.TabIndex = 23;
            this.bLoadProducts.Tag = "";
            this.bLoadProducts.Text = "Načti produkty";
            this.bLoadProducts.UseVisualStyleBackColor = true;
            this.bLoadProducts.Click += new System.EventHandler(this.BLoadProductsClick);
            // 
            // dgConsistency
            // 
            this.dgConsistency.AllowUserToAddRows = false;
            this.dgConsistency.AllowUserToDeleteRows = false;
            this.dgConsistency.AllowUserToOrderColumns = true;
            this.dgConsistency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsistency.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgConsistency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsistency.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgConsistency.Location = new System.Drawing.Point(187, 30);
            this.dgConsistency.Name = "dgConsistency";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsistency.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgConsistency.Size = new System.Drawing.Size(828, 552);
            this.dgConsistency.TabIndex = 22;
            this.dgConsistency.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgConsistencyCellClick);
            this.dgConsistency.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgConsistencyCellValueChanged);
            // 
            // gbConsistency
            // 
            this.gbConsistency.Controls.Add(this.bWithoutSupplier);
            this.gbConsistency.Controls.Add(this.bSaveChanges);
            this.gbConsistency.Controls.Add(this.bWithoutWholeSalePrice);
            this.gbConsistency.Controls.Add(this.bWithoutLongDescription);
            this.gbConsistency.Controls.Add(this.bWithoutPrice);
            this.gbConsistency.Controls.Add(this.bConsistencySuppliers);
            this.gbConsistency.Controls.Add(this.bWithoutWeight);
            this.gbConsistency.Controls.Add(this.bEmptyManufacturer);
            this.gbConsistency.Controls.Add(this.bWithoutShortDescription);
            this.gbConsistency.Controls.Add(this.bEmptyCategory);
            this.gbConsistency.Controls.Add(this.bWithoutImage);
            this.gbConsistency.Enabled = false;
            this.gbConsistency.Location = new System.Drawing.Point(8, 51);
            this.gbConsistency.Name = "gbConsistency";
            this.gbConsistency.Size = new System.Drawing.Size(173, 531);
            this.gbConsistency.TabIndex = 20;
            this.gbConsistency.TabStop = false;
            this.gbConsistency.Text = "Vyhledej produkty:";
            // 
            // bWithoutSupplier
            // 
            this.bWithoutSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutSupplier.Location = new System.Drawing.Point(11, 266);
            this.bWithoutSupplier.Name = "bWithoutSupplier";
            this.bWithoutSupplier.Size = new System.Drawing.Size(150, 25);
            this.bWithoutSupplier.TabIndex = 30;
            this.bWithoutSupplier.Text = " bez dodavatele";
            this.bWithoutSupplier.UseVisualStyleBackColor = true;
            this.bWithoutSupplier.Click += new System.EventHandler(this.BConsistencySupplierClick);
            // 
            // bSaveChanges
            // 
            this.bSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSaveChanges.Location = new System.Drawing.Point(11, 492);
            this.bSaveChanges.Name = "bSaveChanges";
            this.bSaveChanges.Size = new System.Drawing.Size(150, 30);
            this.bSaveChanges.TabIndex = 29;
            this.bSaveChanges.Text = "Zapiš změny";
            this.bSaveChanges.UseVisualStyleBackColor = true;
            this.bSaveChanges.Click += new System.EventHandler(this.BSaveChangesClick);
            // 
            // bWithoutWholeSalePrice
            // 
            this.bWithoutWholeSalePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutWholeSalePrice.Location = new System.Drawing.Point(11, 203);
            this.bWithoutWholeSalePrice.Name = "bWithoutWholeSalePrice";
            this.bWithoutWholeSalePrice.Size = new System.Drawing.Size(150, 25);
            this.bWithoutWholeSalePrice.TabIndex = 28;
            this.bWithoutWholeSalePrice.Text = " bez velkoobchodni ceny";
            this.bWithoutWholeSalePrice.UseVisualStyleBackColor = true;
            this.bWithoutWholeSalePrice.Click += new System.EventHandler(this.BWithoutWholeSalePriceClick);
            // 
            // bWithoutLongDescription
            // 
            this.bWithoutLongDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutLongDescription.Location = new System.Drawing.Point(11, 141);
            this.bWithoutLongDescription.Name = "bWithoutLongDescription";
            this.bWithoutLongDescription.Size = new System.Drawing.Size(150, 25);
            this.bWithoutLongDescription.TabIndex = 27;
            this.bWithoutLongDescription.Text = "bez dlouhého popisu";
            this.bWithoutLongDescription.UseVisualStyleBackColor = true;
            this.bWithoutLongDescription.Click += new System.EventHandler(this.BWithoutLongDescriptionClick);
            // 
            // bWithoutPrice
            // 
            this.bWithoutPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutPrice.Location = new System.Drawing.Point(11, 172);
            this.bWithoutPrice.Name = "bWithoutPrice";
            this.bWithoutPrice.Size = new System.Drawing.Size(150, 25);
            this.bWithoutPrice.TabIndex = 26;
            this.bWithoutPrice.Text = " bez maloobchodní ceny";
            this.bWithoutPrice.UseVisualStyleBackColor = true;
            this.bWithoutPrice.Click += new System.EventHandler(this.BWithoutPriceClick);
            // 
            // bConsistencySuppliers
            // 
            this.bConsistencySuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConsistencySuppliers.Location = new System.Drawing.Point(11, 313);
            this.bConsistencySuppliers.Name = "bConsistencySuppliers";
            this.bConsistencySuppliers.Size = new System.Drawing.Size(150, 25);
            this.bConsistencySuppliers.TabIndex = 12;
            this.bConsistencySuppliers.Text = "jenž se nedodávají";
            this.bConsistencySuppliers.UseVisualStyleBackColor = true;
            this.bConsistencySuppliers.Click += new System.EventHandler(this.ConsistencySuppliersClick);
            // 
            // bWithoutWeight
            // 
            this.bWithoutWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutWeight.Location = new System.Drawing.Point(11, 79);
            this.bWithoutWeight.Name = "bWithoutWeight";
            this.bWithoutWeight.Size = new System.Drawing.Size(150, 25);
            this.bWithoutWeight.TabIndex = 25;
            this.bWithoutWeight.Text = "s nulovou váhou";
            this.bWithoutWeight.UseVisualStyleBackColor = true;
            this.bWithoutWeight.Click += new System.EventHandler(this.BWithoutWeightClick);
            // 
            // bEmptyManufacturer
            // 
            this.bEmptyManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmptyManufacturer.Location = new System.Drawing.Point(11, 49);
            this.bEmptyManufacturer.Name = "bEmptyManufacturer";
            this.bEmptyManufacturer.Size = new System.Drawing.Size(150, 25);
            this.bEmptyManufacturer.TabIndex = 15;
            this.bEmptyManufacturer.Text = "s prázdným výrobcem";
            this.bEmptyManufacturer.UseVisualStyleBackColor = true;
            this.bEmptyManufacturer.Click += new System.EventHandler(this.BEmptyManufacturerClick);
            // 
            // bWithoutShortDescription
            // 
            this.bWithoutShortDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutShortDescription.Location = new System.Drawing.Point(11, 110);
            this.bWithoutShortDescription.Name = "bWithoutShortDescription";
            this.bWithoutShortDescription.Size = new System.Drawing.Size(150, 25);
            this.bWithoutShortDescription.TabIndex = 24;
            this.bWithoutShortDescription.Text = "bez krátkého popisu";
            this.bWithoutShortDescription.UseVisualStyleBackColor = true;
            this.bWithoutShortDescription.Click += new System.EventHandler(this.BWithoutShortDescriptionClick);
            // 
            // bEmptyCategory
            // 
            this.bEmptyCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmptyCategory.Location = new System.Drawing.Point(11, 19);
            this.bEmptyCategory.Name = "bEmptyCategory";
            this.bEmptyCategory.Size = new System.Drawing.Size(150, 25);
            this.bEmptyCategory.TabIndex = 14;
            this.bEmptyCategory.Text = "s prázdnou kategorií";
            this.bEmptyCategory.UseVisualStyleBackColor = true;
            this.bEmptyCategory.Click += new System.EventHandler(this.BEmptyCategoryClick);
            // 
            // bWithoutImage
            // 
            this.bWithoutImage.Enabled = false;
            this.bWithoutImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutImage.Location = new System.Drawing.Point(11, 234);
            this.bWithoutImage.Name = "bWithoutImage";
            this.bWithoutImage.Size = new System.Drawing.Size(150, 25);
            this.bWithoutImage.TabIndex = 23;
            this.bWithoutImage.Text = "bez obrázku";
            this.bWithoutImage.UseVisualStyleBackColor = true;
            this.bWithoutImage.Click += new System.EventHandler(this.BWithoutImageClick);
            // 
            // tpPriceUpdate
            // 
            this.tpPriceUpdate.Controls.Add(this.label2);
            this.tpPriceUpdate.Controls.Add(this.lPricingSupplierIndication);
            this.tpPriceUpdate.Controls.Add(this.lPricingCategoryIndication);
            this.tpPriceUpdate.Controls.Add(this.bPricingInit);
            this.tpPriceUpdate.Controls.Add(this.lPricingManufacturerIndication);
            this.tpPriceUpdate.Controls.Add(this.gbSelectProduct);
            this.tpPriceUpdate.Controls.Add(this.dgPricing);
            this.tpPriceUpdate.Location = new System.Drawing.Point(4, 25);
            this.tpPriceUpdate.Name = "tpPriceUpdate";
            this.tpPriceUpdate.Size = new System.Drawing.Size(1023, 588);
            this.tpPriceUpdate.TabIndex = 2;
            this.tpPriceUpdate.Text = "Přeceňování eshopu";
            this.tpPriceUpdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Vybrané produkty:";
            // 
            // lPricingSupplierIndication
            // 
            this.lPricingSupplierIndication.AutoSize = true;
            this.lPricingSupplierIndication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPricingSupplierIndication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lPricingSupplierIndication.Location = new System.Drawing.Point(629, 12);
            this.lPricingSupplierIndication.Name = "lPricingSupplierIndication";
            this.lPricingSupplierIndication.Size = new System.Drawing.Size(103, 15);
            this.lPricingSupplierIndication.TabIndex = 24;
            this.lPricingSupplierIndication.Text = "Jakýkoliv dodavatel";
            // 
            // lPricingCategoryIndication
            // 
            this.lPricingCategoryIndication.AutoSize = true;
            this.lPricingCategoryIndication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPricingCategoryIndication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lPricingCategoryIndication.Location = new System.Drawing.Point(778, 12);
            this.lPricingCategoryIndication.Name = "lPricingCategoryIndication";
            this.lPricingCategoryIndication.Size = new System.Drawing.Size(101, 15);
            this.lPricingCategoryIndication.TabIndex = 23;
            this.lPricingCategoryIndication.Text = "Jakákoliv kategorie";
            // 
            // bPricingInit
            // 
            this.bPricingInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPricingInit.Location = new System.Drawing.Point(9, 7);
            this.bPricingInit.Name = "bPricingInit";
            this.bPricingInit.Size = new System.Drawing.Size(288, 23);
            this.bPricingInit.TabIndex = 22;
            this.bPricingInit.Text = "Inicializace přeceňování";
            this.bPricingInit.UseVisualStyleBackColor = true;
            this.bPricingInit.Click += new System.EventHandler(this.BPricingInitClick);
            // 
            // lPricingManufacturerIndication
            // 
            this.lPricingManufacturerIndication.AutoSize = true;
            this.lPricingManufacturerIndication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPricingManufacturerIndication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lPricingManufacturerIndication.Location = new System.Drawing.Point(472, 12);
            this.lPricingManufacturerIndication.Name = "lPricingManufacturerIndication";
            this.lPricingManufacturerIndication.Size = new System.Drawing.Size(94, 15);
            this.lPricingManufacturerIndication.TabIndex = 21;
            this.lPricingManufacturerIndication.Text = "Jakýkoliv výrobce";
            // 
            // gbSelectProduct
            // 
            this.gbSelectProduct.Controls.Add(this.chPricingSupplier);
            this.gbSelectProduct.Controls.Add(this.bPricingShow);
            this.gbSelectProduct.Controls.Add(this.rbPricingLimit);
            this.gbSelectProduct.Controls.Add(this.bPricingSave);
            this.gbSelectProduct.Controls.Add(this.rbPricingProcent);
            this.gbSelectProduct.Controls.Add(this.treePricing);
            this.gbSelectProduct.Controls.Add(this.lPricingSupplier);
            this.gbSelectProduct.Controls.Add(this.cPricingSuppliers);
            this.gbSelectProduct.Controls.Add(this.bReprice);
            this.gbSelectProduct.Controls.Add(this.lPricingManufacturer);
            this.gbSelectProduct.Controls.Add(this.cPricingManufacturers);
            this.gbSelectProduct.Controls.Add(this.ePricingPercent);
            this.gbSelectProduct.Enabled = false;
            this.gbSelectProduct.Location = new System.Drawing.Point(8, 36);
            this.gbSelectProduct.Name = "gbSelectProduct";
            this.gbSelectProduct.Size = new System.Drawing.Size(289, 542);
            this.gbSelectProduct.TabIndex = 20;
            this.gbSelectProduct.TabStop = false;
            this.gbSelectProduct.Text = "Přeceňování";
            // 
            // chPricingSupplier
            // 
            this.chPricingSupplier.Checked = true;
            this.chPricingSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chPricingSupplier.Location = new System.Drawing.Point(10, 449);
            this.chPricingSupplier.Name = "chPricingSupplier";
            this.chPricingSupplier.Size = new System.Drawing.Size(250, 20);
            this.chPricingSupplier.TabIndex = 0;
            this.chPricingSupplier.Text = "Přeceň podle ceníků známých dodavatelů";
            this.chPricingSupplier.UseVisualStyleBackColor = true;
            // 
            // bPricingShow
            // 
            this.bPricingShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPricingShow.Location = new System.Drawing.Point(9, 366);
            this.bPricingShow.Name = "bPricingShow";
            this.bPricingShow.Size = new System.Drawing.Size(270, 23);
            this.bPricingShow.TabIndex = 29;
            this.bPricingShow.Text = "Zobraz vybrané";
            this.bPricingShow.UseVisualStyleBackColor = true;
            this.bPricingShow.Click += new System.EventHandler(this.BPricingShowClick);
            // 
            // rbPricingLimit
            // 
            this.rbPricingLimit.AutoSize = true;
            this.rbPricingLimit.Location = new System.Drawing.Point(9, 423);
            this.rbPricingLimit.Name = "rbPricingLimit";
            this.rbPricingLimit.Size = new System.Drawing.Size(77, 17);
            this.rbPricingLimit.TabIndex = 27;
            this.rbPricingLimit.Text = "podle mezí";
            this.rbPricingLimit.UseVisualStyleBackColor = true;
            // 
            // bPricingSave
            // 
            this.bPricingSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bPricingSave.Enabled = false;
            this.bPricingSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPricingSave.Location = new System.Drawing.Point(10, 507);
            this.bPricingSave.Name = "bPricingSave";
            this.bPricingSave.Size = new System.Drawing.Size(269, 24);
            this.bPricingSave.TabIndex = 18;
            this.bPricingSave.Text = "Ulož přeceněné produkty";
            this.bPricingSave.UseVisualStyleBackColor = true;
            this.bPricingSave.Click += new System.EventHandler(this.BPricingSaveClick);
            // 
            // rbPricingProcent
            // 
            this.rbPricingProcent.AutoSize = true;
            this.rbPricingProcent.Checked = true;
            this.rbPricingProcent.Location = new System.Drawing.Point(9, 397);
            this.rbPricingProcent.Name = "rbPricingProcent";
            this.rbPricingProcent.Size = new System.Drawing.Size(124, 17);
            this.rbPricingProcent.TabIndex = 26;
            this.rbPricingProcent.TabStop = true;
            this.rbPricingProcent.Text = "procentní přecenění";
            this.rbPricingProcent.UseVisualStyleBackColor = true;
            // 
            // treePricing
            // 
            this.treePricing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treePricing.Location = new System.Drawing.Point(9, 73);
            this.treePricing.Name = "treePricing";
            this.treePricing.Size = new System.Drawing.Size(270, 287);
            this.treePricing.TabIndex = 15;
            // 
            // lPricingSupplier
            // 
            this.lPricingSupplier.AutoSize = true;
            this.lPricingSupplier.Location = new System.Drawing.Point(6, 49);
            this.lPricingSupplier.Name = "lPricingSupplier";
            this.lPricingSupplier.Size = new System.Drawing.Size(59, 13);
            this.lPricingSupplier.TabIndex = 14;
            this.lPricingSupplier.Text = "Dodavatel:";
            // 
            // cPricingSuppliers
            // 
            this.cPricingSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPricingSuppliers.FormattingEnabled = true;
            this.cPricingSuppliers.Location = new System.Drawing.Point(71, 46);
            this.cPricingSuppliers.Name = "cPricingSuppliers";
            this.cPricingSuppliers.Size = new System.Drawing.Size(208, 21);
            this.cPricingSuppliers.TabIndex = 13;
            // 
            // bReprice
            // 
            this.bReprice.Enabled = false;
            this.bReprice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReprice.Location = new System.Drawing.Point(9, 475);
            this.bReprice.Name = "bReprice";
            this.bReprice.Size = new System.Drawing.Size(270, 23);
            this.bReprice.TabIndex = 20;
            this.bReprice.Text = "Přeceň";
            this.bReprice.UseVisualStyleBackColor = true;
            this.bReprice.Click += new System.EventHandler(this.BRepriceClick);
            // 
            // lPricingManufacturer
            // 
            this.lPricingManufacturer.AutoSize = true;
            this.lPricingManufacturer.Location = new System.Drawing.Point(6, 22);
            this.lPricingManufacturer.Name = "lPricingManufacturer";
            this.lPricingManufacturer.Size = new System.Drawing.Size(49, 13);
            this.lPricingManufacturer.TabIndex = 1;
            this.lPricingManufacturer.Text = "Výrobce:";
            // 
            // cPricingManufacturers
            // 
            this.cPricingManufacturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPricingManufacturers.FormattingEnabled = true;
            this.cPricingManufacturers.Location = new System.Drawing.Point(71, 19);
            this.cPricingManufacturers.Name = "cPricingManufacturers";
            this.cPricingManufacturers.Size = new System.Drawing.Size(208, 21);
            this.cPricingManufacturers.TabIndex = 0;
            // 
            // ePricingPercent
            // 
            this.ePricingPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePricingPercent.Location = new System.Drawing.Point(139, 397);
            this.ePricingPercent.Name = "ePricingPercent";
            this.ePricingPercent.Size = new System.Drawing.Size(140, 20);
            this.ePricingPercent.TabIndex = 16;
            this.ePricingPercent.Text = "1,0";
            // 
            // dgPricing
            // 
            this.dgPricing.AllowUserToAddRows = false;
            this.dgPricing.AllowUserToDeleteRows = false;
            this.dgPricing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPricing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgPricing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPricing.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgPricing.Location = new System.Drawing.Point(303, 36);
            this.dgPricing.Name = "dgPricing";
            this.dgPricing.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPricing.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgPricing.Size = new System.Drawing.Size(712, 542);
            this.dgPricing.TabIndex = 17;
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.eshopSettings);
            this.tpSetup.Controls.Add(this.lActiveEshop);
            this.tpSetup.Controls.Add(this.cbActiveEshop);
            this.tpSetup.Controls.Add(this.bDelEshop);
            this.tpSetup.Controls.Add(this.bAddEshop);
            this.tpSetup.Controls.Add(this.treeConfiguration);
            this.tpSetup.Controls.Add(this.bPrestaTest);
            this.tpSetup.Location = new System.Drawing.Point(4, 25);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetup.Size = new System.Drawing.Size(1023, 588);
            this.tpSetup.TabIndex = 1;
            this.tpSetup.Text = "Konfigurace";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // eshopSettings
            // 
            this.eshopSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eshopSettings.Location = new System.Drawing.Point(296, 6);
            this.eshopSettings.Name = "eshopSettings";
            this.eshopSettings.Size = new System.Drawing.Size(721, 576);
            this.eshopSettings.TabIndex = 7;
            // 
            // lActiveEshop
            // 
            this.lActiveEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lActiveEshop.AutoSize = true;
            this.lActiveEshop.Location = new System.Drawing.Point(8, 564);
            this.lActiveEshop.Name = "lActiveEshop";
            this.lActiveEshop.Size = new System.Drawing.Size(73, 13);
            this.lActiveEshop.TabIndex = 6;
            this.lActiveEshop.Text = "Aktivní eshop";
            // 
            // cbActiveEshop
            // 
            this.cbActiveEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbActiveEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActiveEshop.FormattingEnabled = true;
            this.cbActiveEshop.Location = new System.Drawing.Point(87, 561);
            this.cbActiveEshop.Name = "cbActiveEshop";
            this.cbActiveEshop.Size = new System.Drawing.Size(199, 21);
            this.cbActiveEshop.TabIndex = 5;
            this.cbActiveEshop.SelectedIndexChanged += new System.EventHandler(this.CbActiveEshopSelectedIndexChanged);
            // 
            // bDelEshop
            // 
            this.bDelEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDelEshop.Location = new System.Drawing.Point(11, 527);
            this.bDelEshop.Name = "bDelEshop";
            this.bDelEshop.Size = new System.Drawing.Size(275, 23);
            this.bDelEshop.TabIndex = 4;
            this.bDelEshop.Text = "Smaž konfiguraci eshopu";
            this.bDelEshop.UseVisualStyleBackColor = true;
            this.bDelEshop.Click += new System.EventHandler(this.BDelEshopClick);
            // 
            // bAddEshop
            // 
            this.bAddEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddEshop.Location = new System.Drawing.Point(11, 498);
            this.bAddEshop.Name = "bAddEshop";
            this.bAddEshop.Size = new System.Drawing.Size(275, 23);
            this.bAddEshop.TabIndex = 3;
            this.bAddEshop.Text = "Přidej konfiguraci eshopu";
            this.bAddEshop.UseVisualStyleBackColor = true;
            this.bAddEshop.Click += new System.EventHandler(this.BAddEshopClick);
            // 
            // treeConfiguration
            // 
            this.treeConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treeConfiguration.LabelEdit = true;
            this.treeConfiguration.Location = new System.Drawing.Point(11, 6);
            this.treeConfiguration.Name = "treeConfiguration";
            this.treeConfiguration.Size = new System.Drawing.Size(275, 457);
            this.treeConfiguration.TabIndex = 0;
            this.treeConfiguration.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeConfigurationAfterLabelEdit);
            this.treeConfiguration.DoubleClick += new System.EventHandler(this.TreeConfigurationDoubleClick);
            this.treeConfiguration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeConfigurationMouseDown);
            // 
            // bPrestaTest
            // 
            this.bPrestaTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bPrestaTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrestaTest.Location = new System.Drawing.Point(11, 469);
            this.bPrestaTest.Name = "bPrestaTest";
            this.bPrestaTest.Size = new System.Drawing.Size(275, 23);
            this.bPrestaTest.TabIndex = 5;
            this.bPrestaTest.Text = "Test připojení";
            this.bPrestaTest.UseVisualStyleBackColor = true;
            this.bPrestaTest.Click += new System.EventHandler(this.BPrestaTestClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 669);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "ACE Desktop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.tc.ResumeLayout(false);
            this.tpHome.ResumeLayout(false);
            this.gbModuleInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeModules)).EndInit();
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.tpConsistency.ResumeLayout(false);
            this.tpConsistency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsistency)).EndInit();
            this.gbConsistency.ResumeLayout(false);
            this.tpPriceUpdate.ResumeLayout(false);
            this.tpPriceUpdate.PerformLayout();
            this.gbSelectProduct.ResumeLayout(false);
            this.gbSelectProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPricing)).EndInit();
            this.tpSetup.ResumeLayout(false);
            this.tpSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.OpenFileDialog openDialog;
         private System.Windows.Forms.SaveFileDialog productsSD;
         private System.Windows.Forms.MenuStrip menu;
         private System.Windows.Forms.ToolStripMenuItem openProducts;
         private System.Windows.Forms.StatusStrip status;
         private System.Windows.Forms.ToolStripStatusLabel statusAgent;
         private System.Windows.Forms.ToolStripStatusLabel statusLogin;
         private System.Windows.Forms.ToolStripStatusLabel statusActiveEshop;
         private System.Windows.Forms.SaveFileDialog saveDialog;
         private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
         private System.Windows.Forms.TabControl tc;
         private System.Windows.Forms.TabPage tpHome;
         private System.Windows.Forms.TabPage tpSetup;
         private System.Windows.Forms.TabPage tpPriceUpdate;
         private System.Windows.Forms.WebBrowser homeBrowser;
         private System.Windows.Forms.GroupBox gbSelectProduct;
         private System.Windows.Forms.Label lPricingManufacturer;
         private System.Windows.Forms.ComboBox cPricingManufacturers;
         private System.Windows.Forms.DataGridView dgPricing;
         private System.Windows.Forms.Button bPricingSave;
         private System.Windows.Forms.TabPage tpConsistency;
         private System.Windows.Forms.GroupBox gbConsistency;
         private System.Windows.Forms.Button bConsistencySuppliers;
         private System.Windows.Forms.DataGridView dgConsistency;
         private System.Windows.Forms.ToolStripProgressBar statusProgress;
         private System.Windows.Forms.Label lPricingSupplier;
         private System.Windows.Forms.ComboBox cPricingSuppliers;
         private System.Windows.Forms.Button bLogin;
         private System.Windows.Forms.Button bEmptyManufacturer;
         private System.Windows.Forms.Button bEmptyCategory;
         private System.Windows.Forms.Button bWithoutWeight;
         private System.Windows.Forms.Button bWithoutShortDescription;
         private System.Windows.Forms.Button bWithoutImage;
         private System.Windows.Forms.ToolStripStatusLabel statusMessage;
         private System.Windows.Forms.Button bWithoutLongDescription;
         private System.Windows.Forms.Button bWithoutPrice;
         private System.Windows.Forms.Button bLoadProducts;
         private System.Windows.Forms.Button bWithoutWholeSalePrice;
         private System.Windows.Forms.Label lListOf;
         private System.Windows.Forms.Button bSaveChanges;
         private System.Windows.Forms.Button bPrestaTest;
         private System.Windows.Forms.ToolStripMenuItem menuShowChangeLog;
         private System.Windows.Forms.ComboBox cbActiveEshop;
         private System.Windows.Forms.Button bDelEshop;
         private System.Windows.Forms.Button bAddEshop;
         private System.Windows.Forms.TreeView treeConfiguration;
         private System.Windows.Forms.ToolStripMenuItem menuShowHome;
         private System.Windows.Forms.GroupBox gbModuleInfo;
         private System.Windows.Forms.GroupBox gbUserInfo;
         private System.Windows.Forms.Label lHomeUserName;
         private System.Windows.Forms.Label label13;
         private System.Windows.Forms.Label lHomeEmail;
         private System.Windows.Forms.Label lHomeName;
         private System.Windows.Forms.Label label10;
         private System.Windows.Forms.Label lHomePaymentSymbol;
         private System.Windows.Forms.Label label8;
         private System.Windows.Forms.Label label7;
         private System.Windows.Forms.Label lHomeCompany;
         private System.Windows.Forms.Label label5;
         private System.Windows.Forms.Label label16;
         private System.Windows.Forms.Label lHomeCredit;
         private System.Windows.Forms.DataGridView dgHomeModules;
         private System.Windows.Forms.DataGridViewTextBoxColumn Module;
         private System.Windows.Forms.DataGridViewCheckBoxColumn ModuleActive;
         private System.Windows.Forms.DataGridViewTextBoxColumn OrderedTo;
         private System.Windows.Forms.ToolStripMenuItem ukončitACEDesktopToolStripMenuItem;
         private System.Windows.Forms.Button bReprice;
         private System.Windows.Forms.TextBox ePricingPercent;
         private System.Windows.Forms.RadioButton rbPricingLimit;
         private System.Windows.Forms.RadioButton rbPricingProcent;
         private System.Windows.Forms.TreeView treePricing;
         private System.Windows.Forms.Label lPricingManufacturerIndication;
         private System.Windows.Forms.Button bPricingShow;
         private System.Windows.Forms.Button bPricingInit;
         private System.Windows.Forms.Label lPricingSupplierIndication;
         private System.Windows.Forms.Label lPricingCategoryIndication;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.CheckBox chPricingSupplier;
         private System.Windows.Forms.Label lActiveEshop;
         private System.Windows.Forms.Button bWithoutSupplier;
         private Custom_Contols.EshopConfigurationControl eshopSettings;
     }
 }

