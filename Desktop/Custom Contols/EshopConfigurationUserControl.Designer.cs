namespace Desktop.Custom_Contols
{
    partial class EshopConfigurationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbPrestaSetup = new System.Windows.Forms.GroupBox();
            this.cbSupliers = new System.Windows.Forms.ComboBox();
            this.bDelSupplier = new System.Windows.Forms.Button();
            this.lRepricingLimits = new System.Windows.Forms.Label();
            this.dgSuppliers = new System.Windows.Forms.DataGridView();
            this.dgRepricingLimits = new System.Windows.Forms.DataGridView();
            this.bOpenSupplierPriceList = new System.Windows.Forms.Button();
            this.bAddSupplier = new System.Windows.Forms.Button();
            this.lSupplierSetup = new System.Windows.Forms.Label();
            this.lEshopType = new System.Windows.Forms.Label();
            this.cbTypeEshop = new System.Windows.Forms.ComboBox();
            this.ePrestaToken = new System.Windows.Forms.TextBox();
            this.ePrestaUrl = new System.Windows.Forms.TextBox();
            this.lPrestaToken = new System.Windows.Forms.Label();
            this.lPrestaUrl = new System.Windows.Forms.Label();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbPrestaSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRepricingLimits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPrestaSetup
            // 
            this.gbPrestaSetup.Controls.Add(this.cbSupliers);
            this.gbPrestaSetup.Controls.Add(this.bDelSupplier);
            this.gbPrestaSetup.Controls.Add(this.lRepricingLimits);
            this.gbPrestaSetup.Controls.Add(this.dgSuppliers);
            this.gbPrestaSetup.Controls.Add(this.dgRepricingLimits);
            this.gbPrestaSetup.Controls.Add(this.bOpenSupplierPriceList);
            this.gbPrestaSetup.Controls.Add(this.bAddSupplier);
            this.gbPrestaSetup.Controls.Add(this.lSupplierSetup);
            this.gbPrestaSetup.Controls.Add(this.lEshopType);
            this.gbPrestaSetup.Controls.Add(this.cbTypeEshop);
            this.gbPrestaSetup.Controls.Add(this.ePrestaToken);
            this.gbPrestaSetup.Controls.Add(this.ePrestaUrl);
            this.gbPrestaSetup.Controls.Add(this.lPrestaToken);
            this.gbPrestaSetup.Controls.Add(this.lPrestaUrl);
            this.gbPrestaSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPrestaSetup.Location = new System.Drawing.Point(0, 0);
            this.gbPrestaSetup.Name = "gbPrestaSetup";
            this.gbPrestaSetup.Size = new System.Drawing.Size(675, 535);
            this.gbPrestaSetup.TabIndex = 1;
            this.gbPrestaSetup.TabStop = false;
            this.gbPrestaSetup.Text = "Konfigurace eshopu";
            // 
            // cbSupliers
            // 
            this.cbSupliers.FormattingEnabled = true;
            this.cbSupliers.Location = new System.Drawing.Point(22, 153);
            this.cbSupliers.Name = "cbSupliers";
            this.cbSupliers.Size = new System.Drawing.Size(200, 21);
            this.cbSupliers.TabIndex = 22;
            // 
            // bDelSupplier
            // 
            this.bDelSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDelSupplier.Location = new System.Drawing.Point(359, 153);
            this.bDelSupplier.Name = "bDelSupplier";
            this.bDelSupplier.Size = new System.Drawing.Size(125, 21);
            this.bDelSupplier.TabIndex = 21;
            this.bDelSupplier.Text = "Odstranit dodavatele";
            this.bDelSupplier.UseVisualStyleBackColor = true;
            this.bDelSupplier.Click += new System.EventHandler(this.BDelSupplierClick);
            // 
            // lRepricingLimits
            // 
            this.lRepricingLimits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lRepricingLimits.AutoSize = true;
            this.lRepricingLimits.Location = new System.Drawing.Point(22, 371);
            this.lRepricingLimits.Name = "lRepricingLimits";
            this.lRepricingLimits.Size = new System.Drawing.Size(166, 13);
            this.lRepricingLimits.TabIndex = 20;
            this.lRepricingLimits.Text = "Nastavení limitů pro přeceňování";
            // 
            // dgSuppliers
            // 
            this.dgSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuppliers.Location = new System.Drawing.Point(22, 182);
            this.dgSuppliers.Name = "dgSuppliers";
            this.dgSuppliers.ReadOnly = true;
            this.dgSuppliers.Size = new System.Drawing.Size(633, 161);
            this.dgSuppliers.TabIndex = 19;
            // 
            // dgRepricingLimits
            // 
            this.dgRepricingLimits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRepricingLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRepricingLimits.Location = new System.Drawing.Point(22, 387);
            this.dgRepricingLimits.Name = "dgRepricingLimits";
            this.dgRepricingLimits.Size = new System.Drawing.Size(633, 130);
            this.dgRepricingLimits.TabIndex = 18;
            // 
            // bOpenSupplierPriceList
            // 
            this.bOpenSupplierPriceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenSupplierPriceList.Location = new System.Drawing.Point(490, 153);
            this.bOpenSupplierPriceList.Name = "bOpenSupplierPriceList";
            this.bOpenSupplierPriceList.Size = new System.Drawing.Size(125, 21);
            this.bOpenSupplierPriceList.TabIndex = 14;
            this.bOpenSupplierPriceList.Text = "Otevřít ceník dodavatele";
            this.bOpenSupplierPriceList.UseVisualStyleBackColor = true;
            this.bOpenSupplierPriceList.Click += new System.EventHandler(this.BOpenSupplierPriceListClick);
            // 
            // bAddSupplier
            // 
            this.bAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddSupplier.Location = new System.Drawing.Point(228, 153);
            this.bAddSupplier.Name = "bAddSupplier";
            this.bAddSupplier.Size = new System.Drawing.Size(125, 21);
            this.bAddSupplier.TabIndex = 13;
            this.bAddSupplier.Text = "Přidat dodavatele";
            this.bAddSupplier.UseVisualStyleBackColor = true;
            this.bAddSupplier.Click += new System.EventHandler(this.BAddSupplierClick);
            // 
            // lSupplierSetup
            // 
            this.lSupplierSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lSupplierSetup.AutoSize = true;
            this.lSupplierSetup.Location = new System.Drawing.Point(22, 137);
            this.lSupplierSetup.Name = "lSupplierSetup";
            this.lSupplierSetup.Size = new System.Drawing.Size(113, 13);
            this.lSupplierSetup.TabIndex = 12;
            this.lSupplierSetup.Text = "Nastavení dodavatelů";
            // 
            // lEshopType
            // 
            this.lEshopType.AutoSize = true;
            this.lEshopType.Location = new System.Drawing.Point(22, 29);
            this.lEshopType.Name = "lEshopType";
            this.lEshopType.Size = new System.Drawing.Size(66, 13);
            this.lEshopType.TabIndex = 7;
            this.lEshopType.Text = "Typ eshopu:";
            // 
            // cbTypeEshop
            // 
            this.cbTypeEshop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTypeEshop.Enabled = false;
            this.cbTypeEshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTypeEshop.FormattingEnabled = true;
            this.cbTypeEshop.Items.AddRange(new object[] {
            "Prestashop"});
            this.cbTypeEshop.Location = new System.Drawing.Point(94, 26);
            this.cbTypeEshop.Name = "cbTypeEshop";
            this.cbTypeEshop.Size = new System.Drawing.Size(561, 21);
            this.cbTypeEshop.TabIndex = 6;
            // 
            // ePrestaToken
            // 
            this.ePrestaToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePrestaToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaToken.Location = new System.Drawing.Point(22, 111);
            this.ePrestaToken.Name = "ePrestaToken";
            this.ePrestaToken.Size = new System.Drawing.Size(633, 20);
            this.ePrestaToken.TabIndex = 3;
            this.ePrestaToken.Text = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
            this.ePrestaToken.TextChanged += new System.EventHandler(this.EshopChanged);
            this.ePrestaToken.Validated += new System.EventHandler(this.EPrestaTokenValidated);
            // 
            // ePrestaUrl
            // 
            this.ePrestaUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePrestaUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaUrl.Location = new System.Drawing.Point(22, 68);
            this.ePrestaUrl.Name = "ePrestaUrl";
            this.ePrestaUrl.Size = new System.Drawing.Size(633, 20);
            this.ePrestaUrl.TabIndex = 2;
            this.ePrestaUrl.Text = "http://testpresta.mzf.cz/prestashop/";
            this.ePrestaUrl.TextChanged += new System.EventHandler(this.EshopChanged);
            this.ePrestaUrl.Validating += new System.ComponentModel.CancelEventHandler(this.EPrestaUrlValidating);
            // 
            // lPrestaToken
            // 
            this.lPrestaToken.AutoSize = true;
            this.lPrestaToken.Location = new System.Drawing.Point(19, 95);
            this.lPrestaToken.Name = "lPrestaToken";
            this.lPrestaToken.Size = new System.Drawing.Size(94, 13);
            this.lPrestaToken.TabIndex = 1;
            this.lPrestaToken.Text = "Autorizační token:";
            // 
            // lPrestaUrl
            // 
            this.lPrestaUrl.AutoSize = true;
            this.lPrestaUrl.Location = new System.Drawing.Point(19, 52);
            this.lPrestaUrl.Name = "lPrestaUrl";
            this.lPrestaUrl.Size = new System.Drawing.Size(81, 13);
            this.lPrestaUrl.TabIndex = 0;
            this.lPrestaUrl.Text = "Adresa eshopu:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.RightToLeft = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EshopConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPrestaSetup);
            this.Name = "EshopConfigurationControl";
            this.Size = new System.Drawing.Size(675, 535);
            this.gbPrestaSetup.ResumeLayout(false);
            this.gbPrestaSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRepricingLimits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPrestaSetup;
        private System.Windows.Forms.Button bOpenSupplierPriceList;
        private System.Windows.Forms.Button bAddSupplier;
        private System.Windows.Forms.Label lSupplierSetup;
        private System.Windows.Forms.Label lEshopType;
        private System.Windows.Forms.ComboBox cbTypeEshop;
        private System.Windows.Forms.TextBox ePrestaToken;
        private System.Windows.Forms.TextBox ePrestaUrl;
        private System.Windows.Forms.Label lPrestaToken;
        private System.Windows.Forms.Label lPrestaUrl;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.DataGridView dgRepricingLimits;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgSuppliers;
        private System.Windows.Forms.Label lRepricingLimits;
        private System.Windows.Forms.Button bDelSupplier;
        private System.Windows.Forms.ComboBox cbSupliers;
    }
}
