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
            
            ePrestaUrl.Text = eshop.BaseUrl;
            ePrestaToken.Text = eshop.Password;
            chAskinoSetup.Checked = eshop.UseAskino;
            chNovikoSetup.Checked = eshop.UseNoviko;
            if (String.IsNullOrEmpty(eshop.AskinoFilePath))
            {
                lAskinoPath.Text = labelPathToAskinoPriceList;
            }
            else
            {
                lAskinoPath.Text = eshop.AskinoFilePath;
            }

            if (String.IsNullOrEmpty(eshop.NovikoFilePath))
            {
                lNovikoPath.Text = labelPathToNovikoPriceList;
            }
            else
            {
                lNovikoPath.Text = eshop.NovikoFilePath;
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
                eshop.AskinoFilePath = openDialog.FileName;
                lAskinoPath.Text = eshop.AskinoFilePath;
                eshop.UseAskino = true;
                chAskinoSetup.Checked = true;
                OnSuppliersChanged(new EshopEventArgs(this.eshop));
            }
        }

        private void bOpenNoviko_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                eshop.NovikoFilePath = openDialog.FileName;
                lNovikoPath.Text = eshop.NovikoFilePath;
                eshop.UseNoviko = true;
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
            eshop.UseAskino = chAskinoSetup.Checked;
            eshop.UseNoviko = chNovikoSetup.Checked;
            eshop.AskinoFilePath = lAskinoPath.Text;
            eshop.NovikoFilePath = lNovikoPath.Text;
            OnSuppliersChanged(new EshopEventArgs(this.eshop));
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