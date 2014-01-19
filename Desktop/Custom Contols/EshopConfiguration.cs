using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using Desktop.Utils;
using Bussiness.UserSettings;

namespace Desktop.Custom_Contols
{
    public delegate void SupplierEventHandler(object sender, EshopEventArgs e);

    public partial class EshopConfigurationControl : UserControl
    {
        public event SupplierEventHandler SuppliersChanged;
        private bool disableCallBack = false;

        protected virtual void OnSuppliersChanged(EshopEventArgs e)
        {
            SuppliersChanged(this, e);
        }

        private Bussiness.UserSettings.EshopConfiguration eshop;
        private const string labelPathToAskinoPriceList = "cesta k ceníku Askina";
        private const string labelPathToNovikoPriceList = "cesta k ceníku Novika";
                
        public EshopConfigurationControl()
        {
            eshop = new EshopConfiguration();

            InitializeComponent();
            InitializeDatabindings();

            cbTypeEshop.SelectedIndex = 0;

            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
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
                lAskinoPath.Text = labelPathToAskinoPriceList;
            }
            else
            {
                lAskinoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
            }

            if (String.IsNullOrEmpty(eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName))
            {
                lNovikoPath.Text = labelPathToNovikoPriceList;
            }
            else
            {
                lNovikoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
            }
            
            gbPrestaSetup.Text = "Konfigurace eshopu " + eshop.EshopName;
            
            disableCallBack = false;
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

        private void bOpenAskino_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName = openDialog.FileName;
                eshop.Suppliers[eshop.AskinoIndex()].UseSupplier = true;
                
                lAskinoPath.Text = eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName;
                chAskinoSetup.Checked = true;
                
                OnSuppliersChanged(new EshopEventArgs(this.eshop));
            }
        }

        private void bOpenNoviko_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName = openDialog.FileName;
                lNovikoPath.Text = eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName;
                eshop.Suppliers[eshop.NovikoIndex()].UseSupplier = true;
                chNovikoSetup.Checked = true;
                OnSuppliersChanged(new EshopEventArgs(this.eshop));
            }
        }

        private void gbPrestaSetup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eshop_Changed(object sender, EventArgs e)
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
            OnSuppliersChanged(new EshopEventArgs(this.eshop));
        }

        private void ePrestaUrl_Validating(object sender, CancelEventArgs e)
        {
            //GetBaseUrlFromEditBox
        }
    }

    public class EshopEventArgs : System.EventArgs
    {
        public EshopEventArgs(EshopConfiguration eshop)
        {
            Eshop = eshop;
        }
        public EshopConfiguration Eshop { get; set; }
    }
}