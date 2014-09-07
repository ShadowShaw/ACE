using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bussiness;
using Bussiness.UserSettings;
using Desktop.Utils;

namespace Desktop.Custom_Contols
{
    public delegate void SupplierEventHandler(object sender, EshopEventArgs e);

    public partial class EshopConfigurationControl : UserControl
    {
        public event SupplierEventHandler SuppliersChanged;
        private bool disableCallBack;

        protected virtual void OnSuppliersChanged(EshopEventArgs e)
        {
            SuppliersChanged(this, e);
        }

        private EshopConfiguration eshop;
        private const string LabelPathToAskinoPriceList = "cesta k ceníku Askina";
        private const string LabelPathToNovikoPriceList = "cesta k ceníku Novika";

        public bool IsValid { get; private set; }

        public EshopConfigurationControl()
        {
            eshop = new EshopConfiguration();
            IsValid = true;

            InitializeComponent();
            InitializeDatabindings();

            InitializeLimitsGrid();

            errorProvider.ContainerControl = this;

            cbTypeEshop.SelectedIndex = 0;

            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
        }

        private void InitializeLimitsGrid()
        {
            DataGridTools.InitGrid(dgRepricingLimits);

            DataGridTools.AddColumn(dgRepricingLimits, "LowLimit", "Spodní mez", false);
            DataGridTools.AddColumn(dgRepricingLimits, "HiLimit", "Horní mez", false);
            DataGridTools.AddColumn(dgRepricingLimits, "Value", "Hodnota", false);
            
            dgRepricingLimits.DataSource = eshop.RepriceLimits;
         }

        public EshopConfiguration GetEshop()
        {
            return eshop;
        }

        public void SetEshop(EshopConfiguration eshopx)
        {
            disableCallBack = true;
            
            if (eshopx == null)
            {
                eshop = new EshopConfiguration();
            }
            else
            {
                eshop = eshopx;
            }

            if (eshop.Suppliers.Exists(s => s.SupplierName == "Askino") == false)
            {
                SupplierConfiguration askino = new SupplierConfiguration();
                askino.SupplierName = "Askino";
                eshop.Suppliers.Add(askino);
            }

            if (eshop.Suppliers.Exists(s => s.SupplierName == "Noviko") == false)
            {
                SupplierConfiguration noviko = new SupplierConfiguration();
                noviko.SupplierName = "Noviko";
                eshop.Suppliers.Add(noviko);
            }

            
            ePrestaUrl.Text = eshop.BaseUrl;
            ePrestaToken.Text = eshop.Password;
            chAskinoSetup.Checked = eshop.Suppliers[eshop.AskinoIndex()].UseSupplier;
            chNovikoSetup.Checked = eshop.Suppliers[eshop.NovikoIndex()].UseSupplier;
            if (String.IsNullOrEmpty(eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName))
            {
                lAskinoPath.Text = LabelPathToAskinoPriceList;
            }
            else
            {
                lAskinoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
            }

            if (String.IsNullOrEmpty(eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName))
            {
                lNovikoPath.Text = LabelPathToNovikoPriceList;
            }
            else
            {
                lNovikoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
            }
            
            gbPrestaSetup.Text =  TextResources.EUCPrestaSetup + eshop.EshopName;

            ValidateControls();

            disableCallBack = false;
        }

        private void ValidateControls()
        {
            errorProvider.SetError(ePrestaUrl, String.Empty);
            IsValid = true;

            ValidateEshopUrl();
            ValidateEshopPassword();
        }

        private void ValidateEshopPassword()
        {
            if (ePrestaToken.Text.Length > 0)
            {
                errorProvider.SetError(ePrestaToken, String.Empty);
                IsValid = true;
            }
            else
            {
                errorProvider.SetError(ePrestaToken, TextResources.EUCEmptyToken);
                IsValid = false;
            }
        }

        private void ValidateEshopUrl()
        {
            if (IsValidUrl(ePrestaUrl.Text))
            {
                errorProvider.SetError(ePrestaUrl, String.Empty);
                IsValid = true;
            }
            else
            {
                errorProvider.SetError(ePrestaUrl, TextResources.EUCValidUrl);
                IsValid = false;
            }
        }

        private void InitializeDatabindings()
        {
            //ePrestaUrl.DataBindings.Add("Text", this.eshop, "BaseUrl");
            //ePrestaToken.DataBindings.Add("Text", this.eshop, "Password");
            //chAskinoSetup.DataBindings.Add("Checked", this.eshop, "UseAskino");
            //lAskinoPath.DataBindings.Add("Text", this.eshop, "AskinoFilePath");
            //chNovikoSetup.DataBindings.Add("Checked", this.eshop, "UseNoviko");
            //lNovikoPath.DataBindings.Add("Text", this.eshop, "NovikoFilePath");

            //ePrestaUrl.DataBindings.Add("Text", this.eshop, "BaseUrl", false, DataSourceUpdateMode.OnPropertyChanged);
            //ePrestaToken.DataBindings.Add("Text", this.eshop, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            //chAskinoSetup.DataBindings.Add("Checked", this.eshop, "UseAskino", false, DataSourceUpdateMode.OnPropertyChanged);
            //lAskinoPath.DataBindings.Add("Text", this.eshop, "AskinoFilePath", false, DataSourceUpdateMode.OnPropertyChanged);
            //chNovikoSetup.DataBindings.Add("Checked", this.eshop, "UseNoviko", false, DataSourceUpdateMode.OnPropertyChanged);
            //lNovikoPath.DataBindings.Add("Text", this.eshop, "NovikoFilePath", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BOpenAskinoClick(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName = openDialog.FileName;
                eshop.Suppliers[eshop.AskinoIndex()].UseSupplier = true;
                
                lAskinoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
                chAskinoSetup.Checked = true;
                
                OnSuppliersChanged(new EshopEventArgs(eshop));
            }
        }

        private void BOpenNovikoClick(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName = openDialog.FileName;
                lNovikoPath.Text = eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName;
                eshop.Suppliers[eshop.NovikoIndex()].UseSupplier = true;
                chNovikoSetup.Checked = true;
                OnSuppliersChanged(new EshopEventArgs(eshop));
            }
        }

        private void EshopChanged(object sender, EventArgs e)
        {
            if (disableCallBack)
            {
                return;
            }

            eshop.BaseUrl = ePrestaUrl.Text;
            eshop.Password = ePrestaToken.Text;
            eshop.Suppliers[eshop.AskinoIndex()].UseSupplier = chAskinoSetup.Checked;
            eshop.Suppliers[eshop.NovikoIndex()].UseSupplier = chNovikoSetup.Checked;
            eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName = lAskinoPath.Text;
            eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName = lNovikoPath.Text;
            OnSuppliersChanged(new EshopEventArgs(eshop));
        }

        private void EPrestaUrlValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateEshopUrl();
        }

        public static bool IsValidUrl(string url)
        {
            Regex matchRegex = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return matchRegex.IsMatch(url);
            //const string pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$";
            //Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //return reg.IsMatch(url);
        }

        private void EPrestaTokenValidated(object sender, EventArgs e)
        {
            ValidateEshopPassword();
        }

        private void BAddLimitClick(object sender, EventArgs e)
        {
            //Limit test = new Limit();
            //test.LowLimit = 10;
            //test.HiLimit = 20;
            //test.Value = 50;
            //eshop.RepriceLimits.Add(test);
        }

        private void bRemoveLimit_Click(object sender, EventArgs e)
        {
            //
        } 

    }
  
    public class EshopEventArgs : EventArgs
    {
        public EshopEventArgs(EshopConfiguration eshop)
        {
            Eshop = eshop;
        }
        public EshopConfiguration Eshop { get; set; }
    }
}