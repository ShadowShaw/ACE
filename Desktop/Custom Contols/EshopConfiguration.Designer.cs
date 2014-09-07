﻿namespace Desktop.Custom_Contols
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
            this.bRemoveLimit = new System.Windows.Forms.Button();
            this.bAddLimit = new System.Windows.Forms.Button();
            this.dgRepricingLimits = new System.Windows.Forms.DataGridView();
            this.lNovikoPath = new System.Windows.Forms.Label();
            this.lAskinoPath = new System.Windows.Forms.Label();
            this.bOpenNoviko = new System.Windows.Forms.Button();
            this.bOpenAskino = new System.Windows.Forms.Button();
            this.lSupplierSetup = new System.Windows.Forms.Label();
            this.chAskinoSetup = new System.Windows.Forms.CheckBox();
            this.chNovikoSetup = new System.Windows.Forms.CheckBox();
            this.lEshopType = new System.Windows.Forms.Label();
            this.cbTypeEshop = new System.Windows.Forms.ComboBox();
            this.ePrestaToken = new System.Windows.Forms.TextBox();
            this.ePrestaUrl = new System.Windows.Forms.TextBox();
            this.lPrestaToken = new System.Windows.Forms.Label();
            this.lPrestaUrl = new System.Windows.Forms.Label();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.eshopConfigurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eshopConfigurationControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbPrestaSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRepricingLimits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eshopConfigurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eshopConfigurationControlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPrestaSetup
            // 
            this.gbPrestaSetup.Controls.Add(this.bRemoveLimit);
            this.gbPrestaSetup.Controls.Add(this.bAddLimit);
            this.gbPrestaSetup.Controls.Add(this.dgRepricingLimits);
            this.gbPrestaSetup.Controls.Add(this.lNovikoPath);
            this.gbPrestaSetup.Controls.Add(this.lAskinoPath);
            this.gbPrestaSetup.Controls.Add(this.bOpenNoviko);
            this.gbPrestaSetup.Controls.Add(this.bOpenAskino);
            this.gbPrestaSetup.Controls.Add(this.lSupplierSetup);
            this.gbPrestaSetup.Controls.Add(this.chAskinoSetup);
            this.gbPrestaSetup.Controls.Add(this.chNovikoSetup);
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
            // bRemoveLimit
            // 
            this.bRemoveLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bRemoveLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRemoveLimit.Location = new System.Drawing.Point(128, 349);
            this.bRemoveLimit.Name = "bRemoveLimit";
            this.bRemoveLimit.Size = new System.Drawing.Size(100, 23);
            this.bRemoveLimit.TabIndex = 20;
            this.bRemoveLimit.Text = "Odstranit limit";
            this.bRemoveLimit.UseVisualStyleBackColor = true;
            this.bRemoveLimit.Click += new System.EventHandler(this.bRemoveLimit_Click);
            // 
            // bAddLimit
            // 
            this.bAddLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddLimit.Location = new System.Drawing.Point(22, 349);
            this.bAddLimit.Name = "bAddLimit";
            this.bAddLimit.Size = new System.Drawing.Size(100, 23);
            this.bAddLimit.TabIndex = 19;
            this.bAddLimit.Text = "Přidat limit";
            this.bAddLimit.UseVisualStyleBackColor = true;
            this.bAddLimit.Click += new System.EventHandler(this.BAddLimitClick);
            // 
            // dgRepricingLimits
            // 
            this.dgRepricingLimits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRepricingLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRepricingLimits.Location = new System.Drawing.Point(22, 166);
            this.dgRepricingLimits.Name = "dgRepricingLimits";
            this.dgRepricingLimits.Size = new System.Drawing.Size(633, 173);
            this.dgRepricingLimits.TabIndex = 18;
            // 
            // lNovikoPath
            // 
            this.lNovikoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNovikoPath.AutoSize = true;
            this.lNovikoPath.Location = new System.Drawing.Point(35, 504);
            this.lNovikoPath.Name = "lNovikoPath";
            this.lNovikoPath.Size = new System.Drawing.Size(116, 13);
            this.lNovikoPath.TabIndex = 17;
            this.lNovikoPath.Text = "cesta k ceníku Novika";
            // 
            // lAskinoPath
            // 
            this.lAskinoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lAskinoPath.AutoSize = true;
            this.lAskinoPath.Location = new System.Drawing.Point(35, 443);
            this.lAskinoPath.Name = "lAskinoPath";
            this.lAskinoPath.Size = new System.Drawing.Size(114, 13);
            this.lAskinoPath.TabIndex = 16;
            this.lAskinoPath.Text = "cesta k ceníku Askina";
            // 
            // bOpenNoviko
            // 
            this.bOpenNoviko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOpenNoviko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenNoviko.Location = new System.Drawing.Point(96, 478);
            this.bOpenNoviko.Name = "bOpenNoviko";
            this.bOpenNoviko.Size = new System.Drawing.Size(182, 23);
            this.bOpenNoviko.TabIndex = 14;
            this.bOpenNoviko.Text = "Otevřít ceník Novika";
            this.bOpenNoviko.UseVisualStyleBackColor = true;
            this.bOpenNoviko.Click += new System.EventHandler(this.BOpenNovikoClick);
            // 
            // bOpenAskino
            // 
            this.bOpenAskino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOpenAskino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenAskino.Location = new System.Drawing.Point(96, 416);
            this.bOpenAskino.Name = "bOpenAskino";
            this.bOpenAskino.Size = new System.Drawing.Size(182, 23);
            this.bOpenAskino.TabIndex = 13;
            this.bOpenAskino.Text = "Otevřít ceník Askina";
            this.bOpenAskino.UseVisualStyleBackColor = true;
            this.bOpenAskino.Click += new System.EventHandler(this.BOpenAskinoClick);
            // 
            // lSupplierSetup
            // 
            this.lSupplierSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSupplierSetup.AutoSize = true;
            this.lSupplierSetup.Location = new System.Drawing.Point(22, 390);
            this.lSupplierSetup.Name = "lSupplierSetup";
            this.lSupplierSetup.Size = new System.Drawing.Size(113, 13);
            this.lSupplierSetup.TabIndex = 12;
            this.lSupplierSetup.Text = "Nastavení dodavatelů";
            // 
            // chAskinoSetup
            // 
            this.chAskinoSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chAskinoSetup.AutoSize = true;
            this.chAskinoSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chAskinoSetup.Location = new System.Drawing.Point(35, 419);
            this.chAskinoSetup.Name = "chAskinoSetup";
            this.chAskinoSetup.Size = new System.Drawing.Size(55, 17);
            this.chAskinoSetup.TabIndex = 9;
            this.chAskinoSetup.Text = "Askino";
            this.chAskinoSetup.UseVisualStyleBackColor = true;
            this.chAskinoSetup.CheckedChanged += new System.EventHandler(this.EshopChanged);
            // 
            // chNovikoSetup
            // 
            this.chNovikoSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chNovikoSetup.AutoSize = true;
            this.chNovikoSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chNovikoSetup.Location = new System.Drawing.Point(35, 481);
            this.chNovikoSetup.Name = "chNovikoSetup";
            this.chNovikoSetup.Size = new System.Drawing.Size(57, 17);
            this.chNovikoSetup.TabIndex = 8;
            this.chNovikoSetup.Text = "Noviko";
            this.chNovikoSetup.UseVisualStyleBackColor = true;
            this.chNovikoSetup.CheckedChanged += new System.EventHandler(this.EshopChanged);
            // 
            // lEshopType
            // 
            this.lEshopType.AutoSize = true;
            this.lEshopType.Location = new System.Drawing.Point(22, 35);
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
            this.cbTypeEshop.Location = new System.Drawing.Point(94, 32);
            this.cbTypeEshop.Name = "cbTypeEshop";
            this.cbTypeEshop.Size = new System.Drawing.Size(561, 21);
            this.cbTypeEshop.TabIndex = 6;
            // 
            // ePrestaToken
            // 
            this.ePrestaToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePrestaToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePrestaToken.Location = new System.Drawing.Point(22, 131);
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
            this.ePrestaUrl.Location = new System.Drawing.Point(22, 82);
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
            this.lPrestaToken.Location = new System.Drawing.Point(19, 115);
            this.lPrestaToken.Name = "lPrestaToken";
            this.lPrestaToken.Size = new System.Drawing.Size(94, 13);
            this.lPrestaToken.TabIndex = 1;
            this.lPrestaToken.Text = "Autorizační token:";
            // 
            // lPrestaUrl
            // 
            this.lPrestaUrl.AutoSize = true;
            this.lPrestaUrl.Location = new System.Drawing.Point(19, 66);
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
            // eshopConfigurationBindingSource
            // 
            this.eshopConfigurationBindingSource.DataSource = typeof(Bussiness.UserSettings.EshopConfiguration);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // eshopConfigurationControlBindingSource
            // 
            this.eshopConfigurationControlBindingSource.DataSource = typeof(Desktop.Custom_Contols.EshopConfigurationControl);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgRepricingLimits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eshopConfigurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eshopConfigurationControlBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPrestaSetup;
        private System.Windows.Forms.Label lNovikoPath;
        private System.Windows.Forms.Label lAskinoPath;
        private System.Windows.Forms.Button bOpenNoviko;
        private System.Windows.Forms.Button bOpenAskino;
        private System.Windows.Forms.Label lSupplierSetup;
        private System.Windows.Forms.CheckBox chAskinoSetup;
        private System.Windows.Forms.CheckBox chNovikoSetup;
        private System.Windows.Forms.Label lEshopType;
        private System.Windows.Forms.ComboBox cbTypeEshop;
        private System.Windows.Forms.TextBox ePrestaToken;
        private System.Windows.Forms.TextBox ePrestaUrl;
        private System.Windows.Forms.Label lPrestaToken;
        private System.Windows.Forms.Label lPrestaUrl;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.DataGridView dgRepricingLimits;
        private System.Windows.Forms.BindingSource eshopConfigurationControlBindingSource;
        private System.Windows.Forms.BindingSource eshopConfigurationBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button bRemoveLimit;
        private System.Windows.Forms.Button bAddLimit;
    }
}
