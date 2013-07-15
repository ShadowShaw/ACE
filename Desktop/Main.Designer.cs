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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.productsSD = new System.Windows.Forms.SaveFileDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.openProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.openNoviko = new System.Windows.Forms.ToolStripMenuItem();
            this.openAskino = new System.Windows.Forms.ToolStripMenuItem();
            this.openZverac = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importManufactures = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusAgent = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPresta = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpHome = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.homeBrowser = new System.Windows.Forms.WebBrowser();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.gbJoomlaSetup = new System.Windows.Forms.GroupBox();
            this.setupBrowser = new System.Windows.Forms.WebBrowser();
            this.gbPrestaSetup = new System.Windows.Forms.GroupBox();
            this.tpPriceUpdate = new System.Windows.Forms.TabPage();
            this.priceBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.tpConsistency = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.consistencyBrowser = new System.Windows.Forms.WebBrowser();
            this.gbConsistency = new System.Windows.Forms.GroupBox();
            this.bConsistencyAskino = new System.Windows.Forms.Button();
            this.bConsistencyNoviko = new System.Windows.Forms.Button();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lPrestaUrl = new System.Windows.Forms.Label();
            this.lPrestaToken = new System.Windows.Forms.Label();
            this.ePrestaUrl = new System.Windows.Forms.TextBox();
            this.ePrestaToken = new System.Windows.Forms.TextBox();
            this.bSavePresta = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lSupplier = new System.Windows.Forms.Label();
            this.lProcenta = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tc.SuspendLayout();
            this.tpHome.SuspendLayout();
            this.tpSetup.SuspendLayout();
            this.gbPrestaSetup.SuspendLayout();
            this.tpPriceUpdate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.tpConsistency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbConsistency.SuspendLayout();
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
            this.importManufactures});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // importManufactures
            // 
            this.importManufactures.Name = "importManufactures";
            this.importManufactures.Size = new System.Drawing.Size(157, 22);
            this.importManufactures.Text = "Importuj výrobce";
            this.importManufactures.Click += new System.EventHandler(this.importManufactures_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusAgent,
            this.statusLogin,
            this.statusPresta,
            this.statusProgress});
            this.status.Location = new System.Drawing.Point(0, 644);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1015, 22);
            this.status.TabIndex = 14;
            this.status.Text = "Status";
            // 
            // statusAgent
            // 
            this.statusAgent.Enabled = false;
            this.statusAgent.Name = "statusAgent";
            this.statusAgent.Size = new System.Drawing.Size(59, 17);
            this.statusAgent.Text = "ACE Agent";
            // 
            // statusLogin
            // 
            this.statusLogin.Enabled = false;
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(32, 17);
            this.statusLogin.Text = "Login";
            // 
            // statusPresta
            // 
            this.statusPresta.Enabled = false;
            this.statusPresta.Name = "statusPresta";
            this.statusPresta.Size = new System.Drawing.Size(70, 17);
            this.statusPresta.Text = "Eshop Presta";
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tc.Controls.Add(this.tpHome);
            this.tc.Controls.Add(this.tpSetup);
            this.tc.Controls.Add(this.tpPriceUpdate);
            this.tc.Controls.Add(this.tpConsistency);
            this.tc.Location = new System.Drawing.Point(0, 27);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(1015, 614);
            this.tc.TabIndex = 17;
            // 
            // tpHome
            // 
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
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
            this.homeBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.gbJoomlaSetup);
            this.tpSetup.Controls.Add(this.setupBrowser);
            this.tpSetup.Controls.Add(this.gbPrestaSetup);
            this.tpSetup.Location = new System.Drawing.Point(4, 25);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetup.Size = new System.Drawing.Size(1007, 585);
            this.tpSetup.TabIndex = 1;
            this.tpSetup.Text = "Nastavení";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // gbJoomlaSetup
            // 
            this.gbJoomlaSetup.Enabled = false;
            this.gbJoomlaSetup.Location = new System.Drawing.Point(8, 184);
            this.gbJoomlaSetup.Name = "gbJoomlaSetup";
            this.gbJoomlaSetup.Size = new System.Drawing.Size(587, 396);
            this.gbJoomlaSetup.TabIndex = 1;
            this.gbJoomlaSetup.TabStop = false;
            this.gbJoomlaSetup.Text = "Připojení k Joomla eshopu";
            // 
            // setupBrowser
            // 
            this.setupBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setupBrowser.Location = new System.Drawing.Point(601, 6);
            this.setupBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.setupBrowser.Name = "setupBrowser";
            this.setupBrowser.Size = new System.Drawing.Size(400, 573);
            this.setupBrowser.TabIndex = 1;
            // 
            // gbPrestaSetup
            // 
            this.gbPrestaSetup.Controls.Add(this.bSavePresta);
            this.gbPrestaSetup.Controls.Add(this.ePrestaToken);
            this.gbPrestaSetup.Controls.Add(this.ePrestaUrl);
            this.gbPrestaSetup.Controls.Add(this.lPrestaToken);
            this.gbPrestaSetup.Controls.Add(this.lPrestaUrl);
            this.gbPrestaSetup.Location = new System.Drawing.Point(8, 0);
            this.gbPrestaSetup.Name = "gbPrestaSetup";
            this.gbPrestaSetup.Size = new System.Drawing.Size(587, 178);
            this.gbPrestaSetup.TabIndex = 0;
            this.gbPrestaSetup.TabStop = false;
            this.gbPrestaSetup.Text = "Připojení k Presta eshopu";
            // 
            // tpPriceUpdate
            // 
            this.tpPriceUpdate.Controls.Add(this.priceBrowser);
            this.tpPriceUpdate.Controls.Add(this.groupBox2);
            this.tpPriceUpdate.Controls.Add(this.dgView);
            this.tpPriceUpdate.Controls.Add(this.bSave);
            this.tpPriceUpdate.Location = new System.Drawing.Point(4, 25);
            this.tpPriceUpdate.Name = "tpPriceUpdate";
            this.tpPriceUpdate.Size = new System.Drawing.Size(1007, 585);
            this.tpPriceUpdate.TabIndex = 2;
            this.tpPriceUpdate.Text = "Přeceňování";
            this.tpPriceUpdate.UseVisualStyleBackColor = true;
            // 
            // priceBrowser
            // 
            this.priceBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceBrowser.Location = new System.Drawing.Point(602, 6);
            this.priceBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.priceBrowser.Name = "priceBrowser";
            this.priceBrowser.Size = new System.Drawing.Size(400, 573);
            this.priceBrowser.TabIndex = 22;
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
            this.groupBox2.Size = new System.Drawing.Size(588, 162);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Přeceňování";
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgView.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgView.Location = new System.Drawing.Point(8, 171);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgView.Size = new System.Drawing.Size(588, 370);
            this.dgView.TabIndex = 17;
            // 
            // bSave
            // 
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Location = new System.Drawing.Point(8, 547);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(588, 32);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "Ulož přeceněné produkty";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // tpConsistency
            // 
            this.tpConsistency.Controls.Add(this.dataGridView1);
            this.tpConsistency.Controls.Add(this.consistencyBrowser);
            this.tpConsistency.Controls.Add(this.gbConsistency);
            this.tpConsistency.Location = new System.Drawing.Point(4, 25);
            this.tpConsistency.Name = "tpConsistency";
            this.tpConsistency.Size = new System.Drawing.Size(1007, 585);
            this.tpConsistency.TabIndex = 3;
            this.tpConsistency.Text = "Kontrola konzistence";
            this.tpConsistency.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView1.Location = new System.Drawing.Point(8, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView1.Size = new System.Drawing.Size(588, 403);
            this.dataGridView1.TabIndex = 22;
            // 
            // consistencyBrowser
            // 
            this.consistencyBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consistencyBrowser.Location = new System.Drawing.Point(601, 6);
            this.consistencyBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.consistencyBrowser.Name = "consistencyBrowser";
            this.consistencyBrowser.Size = new System.Drawing.Size(400, 573);
            this.consistencyBrowser.TabIndex = 21;
            // 
            // gbConsistency
            // 
            this.gbConsistency.Controls.Add(this.bConsistencyAskino);
            this.gbConsistency.Controls.Add(this.bConsistencyNoviko);
            this.gbConsistency.Location = new System.Drawing.Point(8, 0);
            this.gbConsistency.Name = "gbConsistency";
            this.gbConsistency.Size = new System.Drawing.Size(587, 170);
            this.gbConsistency.TabIndex = 20;
            this.gbConsistency.TabStop = false;
            this.gbConsistency.Text = "Kontrola konzistence";
            // 
            // bConsistencyAskino
            // 
            this.bConsistencyAskino.Location = new System.Drawing.Point(11, 50);
            this.bConsistencyAskino.Name = "bConsistencyAskino";
            this.bConsistencyAskino.Size = new System.Drawing.Size(239, 25);
            this.bConsistencyAskino.TabIndex = 13;
            this.bConsistencyAskino.Text = "Zkontroluj konzistenci dodavatele Askino";
            this.bConsistencyAskino.UseVisualStyleBackColor = true;
            // 
            // bConsistencyNoviko
            // 
            this.bConsistencyNoviko.Location = new System.Drawing.Point(11, 19);
            this.bConsistencyNoviko.Name = "bConsistencyNoviko";
            this.bConsistencyNoviko.Size = new System.Drawing.Size(239, 25);
            this.bConsistencyNoviko.TabIndex = 12;
            this.bConsistencyNoviko.Text = "Zkontroluj konzistenci dodavatele Noviko";
            this.bConsistencyNoviko.UseVisualStyleBackColor = true;
            // 
            // statusProgress
            // 
            this.statusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(200, 16);
            this.statusProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
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
            // lPrestaToken
            // 
            this.lPrestaToken.AutoSize = true;
            this.lPrestaToken.Location = new System.Drawing.Point(19, 86);
            this.lPrestaToken.Name = "lPrestaToken";
            this.lPrestaToken.Size = new System.Drawing.Size(91, 13);
            this.lPrestaToken.TabIndex = 1;
            this.lPrestaToken.Text = "Autorizační token";
            // 
            // ePrestaUrl
            // 
            this.ePrestaUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaUrl.Location = new System.Drawing.Point(22, 53);
            this.ePrestaUrl.Name = "ePrestaUrl";
            this.ePrestaUrl.Size = new System.Drawing.Size(532, 20);
            this.ePrestaUrl.TabIndex = 2;
            this.ePrestaUrl.Text = "http://testpresta.mzf.cz/prestashop/";
            // 
            // ePrestaToken
            // 
            this.ePrestaToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaToken.Location = new System.Drawing.Point(22, 102);
            this.ePrestaToken.Name = "ePrestaToken";
            this.ePrestaToken.Size = new System.Drawing.Size(532, 20);
            this.ePrestaToken.TabIndex = 3;
            this.ePrestaToken.Text = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
            // 
            // bSavePresta
            // 
            this.bSavePresta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSavePresta.Location = new System.Drawing.Point(433, 138);
            this.bSavePresta.Name = "bSavePresta";
            this.bSavePresta.Size = new System.Drawing.Size(121, 23);
            this.bSavePresta.TabIndex = 4;
            this.bSavePresta.Text = "Ulož nastavení";
            this.bSavePresta.UseVisualStyleBackColor = true;
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
            // lSupplier
            // 
            this.lSupplier.AutoSize = true;
            this.lSupplier.Location = new System.Drawing.Point(285, 19);
            this.lSupplier.Name = "lSupplier";
            this.lSupplier.Size = new System.Drawing.Size(56, 13);
            this.lSupplier.TabIndex = 14;
            this.lSupplier.Text = "Dodavatel";
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
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.tc.ResumeLayout(false);
            this.tpHome.ResumeLayout(false);
            this.tpSetup.ResumeLayout(false);
            this.gbPrestaSetup.ResumeLayout(false);
            this.gbPrestaSetup.PerformLayout();
            this.tpPriceUpdate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.tpConsistency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbConsistency.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbJoomlaSetup;
        private System.Windows.Forms.WebBrowser setupBrowser;
        private System.Windows.Forms.WebBrowser priceBrowser;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TabPage tpConsistency;
        private System.Windows.Forms.WebBrowser consistencyBrowser;
        private System.Windows.Forms.GroupBox gbConsistency;
        private System.Windows.Forms.Button bConsistencyAskino;
        private System.Windows.Forms.Button bConsistencyNoviko;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.Button bSavePresta;
        private System.Windows.Forms.TextBox ePrestaToken;
        private System.Windows.Forms.TextBox ePrestaUrl;
        private System.Windows.Forms.Label lPrestaToken;
        private System.Windows.Forms.Label lPrestaUrl;
        private System.Windows.Forms.Label lSupplier;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lProcenta;
    }
}

