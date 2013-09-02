namespace Desktop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.productsSD = new System.Windows.Forms.SaveFileDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.openProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.openNoviko = new System.Windows.Forms.ToolStripMenuItem();
            this.openAskino = new System.Windows.Forms.ToolStripMenuItem();
            this.openZverac = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importManufactures = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowChangeLog = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusAgent = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPresta = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpHome = new System.Windows.Forms.TabPage();
            this.CategoryTree = new System.Windows.Forms.TreeView();
            this.bLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.homeBrowser = new System.Windows.Forms.WebBrowser();
            this.tpConsistency = new System.Windows.Forms.TabPage();
            this.lListOf = new System.Windows.Forms.Label();
            this.bLoadProducts = new System.Windows.Forms.Button();
            this.dgConsistency = new System.Windows.Forms.DataGridView();
            this.gbConsistency = new System.Windows.Forms.GroupBox();
            this.bSaveChanges = new System.Windows.Forms.Button();
            this.bWithoutWholeSalePrice = new System.Windows.Forms.Button();
            this.bWithoutLongDescription = new System.Windows.Forms.Button();
            this.bWithoutPrice = new System.Windows.Forms.Button();
            this.bConsistencyNoviko = new System.Windows.Forms.Button();
            this.bWithoutWeight = new System.Windows.Forms.Button();
            this.bConsistencyAskino = new System.Windows.Forms.Button();
            this.bEmptyManufacturer = new System.Windows.Forms.Button();
            this.bWithoutShortDescription = new System.Windows.Forms.Button();
            this.bEmptyCategory = new System.Windows.Forms.Button();
            this.bWithoutImage = new System.Windows.Forms.Button();
            this.tpPriceUpdate = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lProcenta = new System.Windows.Forms.Label();
            this.lSupplier = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.bReprice = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.eReprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cManufacturers = new System.Windows.Forms.ComboBox();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.bSave = new System.Windows.Forms.Button();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.cbEshopType = new System.Windows.Forms.ComboBox();
            this.bDelEshop = new System.Windows.Forms.Button();
            this.bAddEshop = new System.Windows.Forms.Button();
            this.treeConfiguration = new System.Windows.Forms.TreeView();
            this.gbPrestaSetup = new System.Windows.Forms.GroupBox();
            this.bPrestaTest = new System.Windows.Forms.Button();
            this.bSavePresta = new System.Windows.Forms.Button();
            this.ePrestaToken = new System.Windows.Forms.TextBox();
            this.ePrestaUrl = new System.Windows.Forms.TextBox();
            this.lPrestaToken = new System.Windows.Forms.Label();
            this.lPrestaUrl = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tc.SuspendLayout();
            this.tpHome.SuspendLayout();
            this.tpConsistency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsistency)).BeginInit();
            this.gbConsistency.SuspendLayout();
            this.tpPriceUpdate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.tpSetup.SuspendLayout();
            this.gbPrestaSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProducts,
            this.toolsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1015, 24);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // openProducts
            // 
            this.openProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNoviko,
            this.openAskino,
            this.openZverac});
            this.openProducts.Name = "openProducts";
            this.openProducts.Size = new System.Drawing.Size(53, 20);
            this.openProducts.Text = "Soubor";
            // 
            // openNoviko
            // 
            this.openNoviko.Name = "openNoviko";
            this.openNoviko.Size = new System.Drawing.Size(177, 22);
            this.openNoviko.Text = "Otevřít ceník Noviko";
            this.openNoviko.Click += new System.EventHandler(this.openNoviko_Click);
            // 
            // openAskino
            // 
            this.openAskino.Name = "openAskino";
            this.openAskino.Size = new System.Drawing.Size(177, 22);
            this.openAskino.Text = "Otevřít ceník Askino";
            this.openAskino.Click += new System.EventHandler(this.openAskino_Click);
            // 
            // openZverac
            // 
            this.openZverac.Name = "openZverac";
            this.openZverac.Size = new System.Drawing.Size(177, 22);
            this.openZverac.Text = "Otevřít ceník Zveráče";
            this.openZverac.Click += new System.EventHandler(this.openZverac_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importManufactures,
            this.menuShowChangeLog});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // importManufactures
            // 
            this.importManufactures.Name = "importManufactures";
            this.importManufactures.Size = new System.Drawing.Size(159, 22);
            this.importManufactures.Text = "Importuj výrobce";
            this.importManufactures.Click += new System.EventHandler(this.importManufactures_Click);
            // 
            // menuShowChangeLog
            // 
            this.menuShowChangeLog.Name = "menuShowChangeLog";
            this.menuShowChangeLog.Size = new System.Drawing.Size(159, 22);
            this.menuShowChangeLog.Text = "Zobraz changelog";
            this.menuShowChangeLog.Click += new System.EventHandler(this.menuShowChangeLog_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusAgent,
            this.statusLogin,
            this.statusPresta,
            this.statusProgress,
            this.statusMessage});
            this.status.Location = new System.Drawing.Point(0, 644);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1015, 22);
            this.status.TabIndex = 14;
            this.status.Text = "Status";
            // 
            // statusAgent
            // 
            this.statusAgent.Name = "statusAgent";
            this.statusAgent.Size = new System.Drawing.Size(59, 17);
            this.statusAgent.Text = "ACE Agent";
            this.statusAgent.Visible = false;
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(32, 17);
            this.statusLogin.Text = "Login";
            this.statusLogin.Visible = false;
            // 
            // statusPresta
            // 
            this.statusPresta.Name = "statusPresta";
            this.statusPresta.Size = new System.Drawing.Size(70, 17);
            this.statusPresta.Text = "Eshop Presta";
            this.statusPresta.Visible = false;
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
            this.tc.Size = new System.Drawing.Size(1015, 614);
            this.tc.TabIndex = 17;
            // 
            // tpHome
            // 
            this.tpHome.Controls.Add(this.CategoryTree);
            this.tpHome.Controls.Add(this.bLogin);
            this.tpHome.Controls.Add(this.button1);
            this.tpHome.Controls.Add(this.homeBrowser);
            this.tpHome.Location = new System.Drawing.Point(4, 25);
            this.tpHome.Name = "tpHome";
            this.tpHome.Padding = new System.Windows.Forms.Padding(3);
            this.tpHome.Size = new System.Drawing.Size(1007, 585);
            this.tpHome.TabIndex = 0;
            this.tpHome.Text = "Home";
            this.tpHome.UseVisualStyleBackColor = true;
            // 
            // CategoryTree
            // 
            this.CategoryTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CategoryTree.Location = new System.Drawing.Point(20, 16);
            this.CategoryTree.Name = "CategoryTree";
            this.CategoryTree.Size = new System.Drawing.Size(363, 412);
            this.CategoryTree.TabIndex = 3;
            // 
            // bLogin
            // 
            this.bLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLogin.Location = new System.Drawing.Point(20, 486);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(363, 79);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(20, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "test tree";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // homeBrowser
            // 
            this.homeBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeBrowser.Location = new System.Drawing.Point(404, 6);
            this.homeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.homeBrowser.Name = "homeBrowser";
            this.homeBrowser.Size = new System.Drawing.Size(600, 573);
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
            this.tpConsistency.Size = new System.Drawing.Size(1007, 585);
            this.tpConsistency.TabIndex = 3;
            this.tpConsistency.Text = "Kontrola konzistence databáze eshopu";
            this.tpConsistency.UseVisualStyleBackColor = true;
            // 
            // lListOf
            // 
            this.lListOf.AutoSize = true;
            this.lListOf.Location = new System.Drawing.Point(243, 11);
            this.lListOf.Name = "lListOf";
            this.lListOf.Size = new System.Drawing.Size(105, 13);
            this.lListOf.TabIndex = 24;
            this.lListOf.Text = "Zobrazuji produkty s:";
            // 
            // bLoadProducts
            // 
            this.bLoadProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoadProducts.Location = new System.Drawing.Point(19, 15);
            this.bLoadProducts.Name = "bLoadProducts";
            this.bLoadProducts.Size = new System.Drawing.Size(200, 30);
            this.bLoadProducts.TabIndex = 23;
            this.bLoadProducts.Tag = "";
            this.bLoadProducts.Text = "Načti produkty";
            this.bLoadProducts.UseVisualStyleBackColor = true;
            this.bLoadProducts.Click += new System.EventHandler(this.bLoadProducts_Click);
            // 
            // dgConsistency
            // 
            this.dgConsistency.AllowUserToAddRows = false;
            this.dgConsistency.AllowUserToDeleteRows = false;
            this.dgConsistency.AllowUserToOrderColumns = true;
            this.dgConsistency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsistency.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgConsistency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsistency.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgConsistency.Location = new System.Drawing.Point(243, 30);
            this.dgConsistency.Name = "dgConsistency";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsistency.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgConsistency.Size = new System.Drawing.Size(761, 552);
            this.dgConsistency.TabIndex = 22;
            this.dgConsistency.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsistency_CellValueChanged);
            // 
            // gbConsistency
            // 
            this.gbConsistency.Controls.Add(this.bSaveChanges);
            this.gbConsistency.Controls.Add(this.bWithoutWholeSalePrice);
            this.gbConsistency.Controls.Add(this.bWithoutLongDescription);
            this.gbConsistency.Controls.Add(this.bWithoutPrice);
            this.gbConsistency.Controls.Add(this.bConsistencyNoviko);
            this.gbConsistency.Controls.Add(this.bWithoutWeight);
            this.gbConsistency.Controls.Add(this.bConsistencyAskino);
            this.gbConsistency.Controls.Add(this.bEmptyManufacturer);
            this.gbConsistency.Controls.Add(this.bWithoutShortDescription);
            this.gbConsistency.Controls.Add(this.bEmptyCategory);
            this.gbConsistency.Controls.Add(this.bWithoutImage);
            this.gbConsistency.Enabled = false;
            this.gbConsistency.Location = new System.Drawing.Point(8, 51);
            this.gbConsistency.Name = "gbConsistency";
            this.gbConsistency.Size = new System.Drawing.Size(229, 531);
            this.gbConsistency.TabIndex = 20;
            this.gbConsistency.TabStop = false;
            this.gbConsistency.Text = "Vyhledej produkty:";
            // 
            // bSaveChanges
            // 
            this.bSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSaveChanges.Location = new System.Drawing.Point(11, 401);
            this.bSaveChanges.Name = "bSaveChanges";
            this.bSaveChanges.Size = new System.Drawing.Size(200, 30);
            this.bSaveChanges.TabIndex = 29;
            this.bSaveChanges.Text = "Zapiš změny";
            this.bSaveChanges.UseVisualStyleBackColor = true;
            this.bSaveChanges.Click += new System.EventHandler(this.bSaveChanges_Click);
            // 
            // bWithoutWholeSalePrice
            // 
            this.bWithoutWholeSalePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutWholeSalePrice.Location = new System.Drawing.Point(11, 298);
            this.bWithoutWholeSalePrice.Name = "bWithoutWholeSalePrice";
            this.bWithoutWholeSalePrice.Size = new System.Drawing.Size(200, 30);
            this.bWithoutWholeSalePrice.TabIndex = 28;
            this.bWithoutWholeSalePrice.Text = " bez velkoobchodni ceny";
            this.bWithoutWholeSalePrice.UseVisualStyleBackColor = true;
            this.bWithoutWholeSalePrice.Click += new System.EventHandler(this.bWithoutWholeSalePrice_Click);
            // 
            // bWithoutLongDescription
            // 
            this.bWithoutLongDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutLongDescription.Location = new System.Drawing.Point(11, 205);
            this.bWithoutLongDescription.Name = "bWithoutLongDescription";
            this.bWithoutLongDescription.Size = new System.Drawing.Size(200, 30);
            this.bWithoutLongDescription.TabIndex = 27;
            this.bWithoutLongDescription.Text = "bez dlouhého popisu";
            this.bWithoutLongDescription.UseVisualStyleBackColor = true;
            this.bWithoutLongDescription.Click += new System.EventHandler(this.bWithoutLongDescription_Click);
            // 
            // bWithoutPrice
            // 
            this.bWithoutPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutPrice.Location = new System.Drawing.Point(11, 251);
            this.bWithoutPrice.Name = "bWithoutPrice";
            this.bWithoutPrice.Size = new System.Drawing.Size(200, 30);
            this.bWithoutPrice.TabIndex = 26;
            this.bWithoutPrice.Text = " bez maloobchodní ceny";
            this.bWithoutPrice.UseVisualStyleBackColor = true;
            this.bWithoutPrice.Click += new System.EventHandler(this.bWithoutPrice_Click);
            // 
            // bConsistencyNoviko
            // 
            this.bConsistencyNoviko.Enabled = false;
            this.bConsistencyNoviko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConsistencyNoviko.Location = new System.Drawing.Point(11, 489);
            this.bConsistencyNoviko.Name = "bConsistencyNoviko";
            this.bConsistencyNoviko.Size = new System.Drawing.Size(200, 36);
            this.bConsistencyNoviko.TabIndex = 12;
            this.bConsistencyNoviko.Text = "Zkontroluj konzistenci dodavatele Noviko";
            this.bConsistencyNoviko.UseVisualStyleBackColor = true;
            // 
            // bWithoutWeight
            // 
            this.bWithoutWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutWeight.Location = new System.Drawing.Point(11, 111);
            this.bWithoutWeight.Name = "bWithoutWeight";
            this.bWithoutWeight.Size = new System.Drawing.Size(200, 30);
            this.bWithoutWeight.TabIndex = 25;
            this.bWithoutWeight.Text = "s nulovou váhou";
            this.bWithoutWeight.UseVisualStyleBackColor = true;
            this.bWithoutWeight.Click += new System.EventHandler(this.bWithoutWeight_Click);
            // 
            // bConsistencyAskino
            // 
            this.bConsistencyAskino.Enabled = false;
            this.bConsistencyAskino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConsistencyAskino.Location = new System.Drawing.Point(11, 437);
            this.bConsistencyAskino.Name = "bConsistencyAskino";
            this.bConsistencyAskino.Size = new System.Drawing.Size(200, 46);
            this.bConsistencyAskino.TabIndex = 13;
            this.bConsistencyAskino.Text = "Zkontroluj konzistenci dodavatele Askino";
            this.bConsistencyAskino.UseVisualStyleBackColor = true;
            // 
            // bEmptyManufacturer
            // 
            this.bEmptyManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmptyManufacturer.Location = new System.Drawing.Point(11, 64);
            this.bEmptyManufacturer.Name = "bEmptyManufacturer";
            this.bEmptyManufacturer.Size = new System.Drawing.Size(200, 30);
            this.bEmptyManufacturer.TabIndex = 15;
            this.bEmptyManufacturer.Text = "s prázdným výrobcem";
            this.bEmptyManufacturer.UseVisualStyleBackColor = true;
            this.bEmptyManufacturer.Click += new System.EventHandler(this.bEmptyManufacturer_Click);
            // 
            // bWithoutShortDescription
            // 
            this.bWithoutShortDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutShortDescription.Location = new System.Drawing.Point(11, 158);
            this.bWithoutShortDescription.Name = "bWithoutShortDescription";
            this.bWithoutShortDescription.Size = new System.Drawing.Size(200, 30);
            this.bWithoutShortDescription.TabIndex = 24;
            this.bWithoutShortDescription.Text = "bez krátkého popisu";
            this.bWithoutShortDescription.UseVisualStyleBackColor = true;
            this.bWithoutShortDescription.Click += new System.EventHandler(this.bWithoutShortDescription_Click);
            // 
            // bEmptyCategory
            // 
            this.bEmptyCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmptyCategory.Location = new System.Drawing.Point(11, 19);
            this.bEmptyCategory.Name = "bEmptyCategory";
            this.bEmptyCategory.Size = new System.Drawing.Size(200, 30);
            this.bEmptyCategory.TabIndex = 14;
            this.bEmptyCategory.Text = "s prázdnou kategorií";
            this.bEmptyCategory.UseVisualStyleBackColor = true;
            this.bEmptyCategory.Click += new System.EventHandler(this.bEmptyCategory_Click);
            // 
            // bWithoutImage
            // 
            this.bWithoutImage.Enabled = false;
            this.bWithoutImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWithoutImage.Location = new System.Drawing.Point(11, 345);
            this.bWithoutImage.Name = "bWithoutImage";
            this.bWithoutImage.Size = new System.Drawing.Size(200, 30);
            this.bWithoutImage.TabIndex = 23;
            this.bWithoutImage.Text = "bez obrázku";
            this.bWithoutImage.UseVisualStyleBackColor = true;
            this.bWithoutImage.Visible = false;
            this.bWithoutImage.Click += new System.EventHandler(this.bWithoutImage_Click);
            // 
            // tpPriceUpdate
            // 
            this.tpPriceUpdate.Controls.Add(this.groupBox2);
            this.tpPriceUpdate.Controls.Add(this.dgView);
            this.tpPriceUpdate.Controls.Add(this.bSave);
            this.tpPriceUpdate.Location = new System.Drawing.Point(4, 25);
            this.tpPriceUpdate.Name = "tpPriceUpdate";
            this.tpPriceUpdate.Size = new System.Drawing.Size(1007, 585);
            this.tpPriceUpdate.TabIndex = 2;
            this.tpPriceUpdate.Text = "Přeceňování eshopu";
            this.tpPriceUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lProcenta);
            this.groupBox2.Controls.Add(this.lSupplier);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.bReprice);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.eReprice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cManufacturers);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 162);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Přeceňování";
            // 
            // lProcenta
            // 
            this.lProcenta.AutoSize = true;
            this.lProcenta.Location = new System.Drawing.Point(6, 58);
            this.lProcenta.Name = "lProcenta";
            this.lProcenta.Size = new System.Drawing.Size(107, 13);
            this.lProcenta.TabIndex = 15;
            this.lProcenta.Text = "Procentní přecenění";
            // 
            // lSupplier
            // 
            this.lSupplier.AutoSize = true;
            this.lSupplier.Location = new System.Drawing.Point(285, 19);
            this.lSupplier.Name = "lSupplier";
            this.lSupplier.Size = new System.Drawing.Size(56, 13);
            this.lSupplier.TabIndex = 14;
            this.lSupplier.Text = "Dodavatel";
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Askino",
            "Noviko"});
            this.comboBox1.Location = new System.Drawing.Point(347, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nad mezí";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pod mezí";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mez:";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(58, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Přeceň podle mezí";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bReprice
            // 
            this.bReprice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReprice.Location = new System.Drawing.Point(288, 52);
            this.bReprice.Name = "bReprice";
            this.bReprice.Size = new System.Drawing.Size(282, 23);
            this.bReprice.TabIndex = 8;
            this.bReprice.Text = "Přeceň";
            this.bReprice.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(58, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(208, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(376, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(194, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(376, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 20);
            this.textBox2.TabIndex = 5;
            // 
            // eReprice
            // 
            this.eReprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eReprice.Location = new System.Drawing.Point(166, 55);
            this.eReprice.Name = "eReprice";
            this.eReprice.Size = new System.Drawing.Size(100, 20);
            this.eReprice.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Výrobce";
            // 
            // cManufacturers
            // 
            this.cManufacturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cManufacturers.FormattingEnabled = true;
            this.cManufacturers.Location = new System.Drawing.Point(58, 16);
            this.cManufacturers.Name = "cManufacturers";
            this.cManufacturers.Size = new System.Drawing.Size(208, 21);
            this.cManufacturers.TabIndex = 0;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgView.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgView.Location = new System.Drawing.Point(8, 171);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgView.Size = new System.Drawing.Size(991, 370);
            this.dgView.TabIndex = 17;
            // 
            // bSave
            // 
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Location = new System.Drawing.Point(8, 547);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(991, 32);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "Ulož přeceněné produkty";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.cbEshopType);
            this.tpSetup.Controls.Add(this.bDelEshop);
            this.tpSetup.Controls.Add(this.bAddEshop);
            this.tpSetup.Controls.Add(this.treeConfiguration);
            this.tpSetup.Controls.Add(this.gbPrestaSetup);
            this.tpSetup.Location = new System.Drawing.Point(4, 25);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetup.Size = new System.Drawing.Size(1007, 585);
            this.tpSetup.TabIndex = 1;
            this.tpSetup.Text = "Nastavení připojení k eshopu";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // cbEshopType
            // 
            this.cbEshopType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbEshopType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEshopType.FormattingEnabled = true;
            this.cbEshopType.Items.AddRange(new object[] {
            "Prestashop"});
            this.cbEshopType.Location = new System.Drawing.Point(8, 522);
            this.cbEshopType.Name = "cbEshopType";
            this.cbEshopType.Size = new System.Drawing.Size(121, 21);
            this.cbEshopType.TabIndex = 5;
            // 
            // bDelEshop
            // 
            this.bDelEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDelEshop.Location = new System.Drawing.Point(135, 550);
            this.bDelEshop.Name = "bDelEshop";
            this.bDelEshop.Size = new System.Drawing.Size(151, 23);
            this.bDelEshop.TabIndex = 4;
            this.bDelEshop.Text = "Smaž konfiguraci eshopu";
            this.bDelEshop.UseVisualStyleBackColor = true;
            this.bDelEshop.Click += new System.EventHandler(this.bDelEshop_Click);
            // 
            // bAddEshop
            // 
            this.bAddEshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddEshop.Location = new System.Drawing.Point(135, 521);
            this.bAddEshop.Name = "bAddEshop";
            this.bAddEshop.Size = new System.Drawing.Size(151, 23);
            this.bAddEshop.TabIndex = 3;
            this.bAddEshop.Text = "Přidej konfiguraci eshopu";
            this.bAddEshop.UseVisualStyleBackColor = true;
            this.bAddEshop.Click += new System.EventHandler(this.bAddEshop_Click);
            // 
            // treeConfiguration
            // 
            this.treeConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treeConfiguration.LabelEdit = true;
            this.treeConfiguration.Location = new System.Drawing.Point(8, 6);
            this.treeConfiguration.Name = "treeConfiguration";
            this.treeConfiguration.Size = new System.Drawing.Size(278, 510);
            this.treeConfiguration.TabIndex = 2;
            this.treeConfiguration.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeConfiguration_AfterLabelEdit);
            this.treeConfiguration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeConfiguration_MouseDown);
            // 
            // gbPrestaSetup
            // 
            this.gbPrestaSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrestaSetup.Controls.Add(this.bPrestaTest);
            this.gbPrestaSetup.Controls.Add(this.bSavePresta);
            this.gbPrestaSetup.Controls.Add(this.ePrestaToken);
            this.gbPrestaSetup.Controls.Add(this.ePrestaUrl);
            this.gbPrestaSetup.Controls.Add(this.lPrestaToken);
            this.gbPrestaSetup.Controls.Add(this.lPrestaUrl);
            this.gbPrestaSetup.Location = new System.Drawing.Point(292, 6);
            this.gbPrestaSetup.Name = "gbPrestaSetup";
            this.gbPrestaSetup.Size = new System.Drawing.Size(707, 573);
            this.gbPrestaSetup.TabIndex = 0;
            this.gbPrestaSetup.TabStop = false;
            this.gbPrestaSetup.Text = "Připojení k Presta eshopu";
            // 
            // bPrestaTest
            // 
            this.bPrestaTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPrestaTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrestaTest.Location = new System.Drawing.Point(439, 144);
            this.bPrestaTest.Name = "bPrestaTest";
            this.bPrestaTest.Size = new System.Drawing.Size(121, 23);
            this.bPrestaTest.TabIndex = 5;
            this.bPrestaTest.Text = "Test připojení";
            this.bPrestaTest.UseVisualStyleBackColor = true;
            this.bPrestaTest.Click += new System.EventHandler(this.bPrestaTest_Click);
            // 
            // bSavePresta
            // 
            this.bSavePresta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSavePresta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSavePresta.Location = new System.Drawing.Point(566, 144);
            this.bSavePresta.Name = "bSavePresta";
            this.bSavePresta.Size = new System.Drawing.Size(121, 23);
            this.bSavePresta.TabIndex = 4;
            this.bSavePresta.Text = "Ulož nastavení";
            this.bSavePresta.UseVisualStyleBackColor = true;
            this.bSavePresta.Click += new System.EventHandler(this.bSavePresta_Click);
            // 
            // ePrestaToken
            // 
            this.ePrestaToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePrestaToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaToken.Location = new System.Drawing.Point(22, 102);
            this.ePrestaToken.Name = "ePrestaToken";
            this.ePrestaToken.Size = new System.Drawing.Size(665, 20);
            this.ePrestaToken.TabIndex = 3;
            this.ePrestaToken.Text = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
            // 
            // ePrestaUrl
            // 
            this.ePrestaUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePrestaUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaUrl.Location = new System.Drawing.Point(22, 53);
            this.ePrestaUrl.Name = "ePrestaUrl";
            this.ePrestaUrl.Size = new System.Drawing.Size(665, 20);
            this.ePrestaUrl.TabIndex = 2;
            this.ePrestaUrl.Text = "http://testpresta.mzf.cz/prestashop/";
            // 
            // lPrestaToken
            // 
            this.lPrestaToken.AutoSize = true;
            this.lPrestaToken.Location = new System.Drawing.Point(19, 86);
            this.lPrestaToken.Name = "lPrestaToken";
            this.lPrestaToken.Size = new System.Drawing.Size(91, 13);
            this.lPrestaToken.TabIndex = 1;
            this.lPrestaToken.Text = "Autorizační token";
            // 
            // lPrestaUrl
            // 
            this.lPrestaUrl.AutoSize = true;
            this.lPrestaUrl.Location = new System.Drawing.Point(19, 37);
            this.lPrestaUrl.Name = "lPrestaUrl";
            this.lPrestaUrl.Size = new System.Drawing.Size(78, 13);
            this.lPrestaUrl.TabIndex = 0;
            this.lPrestaUrl.Text = "Adresa eshopu";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 666);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "ACE Desktop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.tc.ResumeLayout(false);
            this.tpHome.ResumeLayout(false);
            this.tpConsistency.ResumeLayout(false);
            this.tpConsistency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsistency)).EndInit();
            this.gbConsistency.ResumeLayout(false);
            this.tpPriceUpdate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.tpSetup.ResumeLayout(false);
            this.gbPrestaSetup.ResumeLayout(false);
            this.gbPrestaSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog productsSD;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem openProducts;
        private System.Windows.Forms.ToolStripMenuItem openNoviko;
        private System.Windows.Forms.ToolStripMenuItem openAskino;
        private System.Windows.Forms.ToolStripMenuItem openZverac;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusAgent;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
        private System.Windows.Forms.ToolStripStatusLabel statusPresta;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importManufactures;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpHome;
        private System.Windows.Forms.TabPage tpSetup;
        private System.Windows.Forms.TabPage tpPriceUpdate;
        private System.Windows.Forms.WebBrowser homeBrowser;
        private System.Windows.Forms.GroupBox gbPrestaSetup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bReprice;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox eReprice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cManufacturers;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TabPage tpConsistency;
        private System.Windows.Forms.GroupBox gbConsistency;
        private System.Windows.Forms.Button bConsistencyAskino;
        private System.Windows.Forms.Button bConsistencyNoviko;
        private System.Windows.Forms.DataGridView dgConsistency;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.Button bSavePresta;
        private System.Windows.Forms.TextBox ePrestaToken;
        private System.Windows.Forms.TextBox ePrestaUrl;
        private System.Windows.Forms.Label lPrestaToken;
        private System.Windows.Forms.Label lPrestaUrl;
        private System.Windows.Forms.Label lSupplier;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lProcenta;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.TreeView CategoryTree;
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
        private System.Windows.Forms.ComboBox cbEshopType;
        private System.Windows.Forms.Button bDelEshop;
        private System.Windows.Forms.Button bAddEshop;
        private System.Windows.Forms.TreeView treeConfiguration;
    }
}

