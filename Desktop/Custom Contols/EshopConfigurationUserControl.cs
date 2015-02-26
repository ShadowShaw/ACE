using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bussiness;
using Desktop.Utils;
using UserSettings;

namespace Desktop.Custom_Contols
{
    public delegate void SupplierEventHandler(object sender, EshopEventArgs e);

    public partial class EshopConfigurationControl : UserControl
    {
        public event SupplierEventHandler SuppliersChanged;
        private bool disableCallBack;

        protected virtual void OnSuppliersChanged(EshopEventArgs e)
        {
            if (eshop != null)
            {
                SuppliersChanged(this, e);    
            }
        }

        public void DisableControls(bool state)
        {
            cbTypeEshop.Enabled = state;
            ePrestaUrl.Enabled = state;
            gbPrestaSetup.Enabled = state;
            if (state == false)
            {
                errorProvider.SetError(ePrestaUrl, String.Empty);
                errorProvider.SetError(ePrestaToken, String.Empty);    
            }
        }

        private EshopConfiguration eshop;
        
        public bool IsValid { get; private set; }
        
        public EshopConfigurationControl()
        {
            eshop = new EshopConfiguration();
            IsValid = true;

            InitializeComponent();
            
            InitializeSuppliersCombo();
            
            InitializeSuppliersGrid();
            InitializeLimitsGrid();

            errorProvider.ContainerControl = this;

            cbTypeEshop.SelectedIndex = 0;

            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
        }

        private void InitializeSuppliersGrid()
        {
            DataGridTools.InitGrid(dgSuppliers, true);

            DataGridTools.AddColumn(dgSuppliers, "Supplier", "Dodavatel", true, true, 125);
            DataGridTools.AddColumn(dgSuppliers, "PathToFile", "Cesta k ceníku", true, true, 300);
        }

        private void InitializeLimitsGrid()
        {
            DataGridTools.InitGrid(dgRepricingLimits);
            
            DataGridTools.AddColumn(dgRepricingLimits, "LowLimit", "Spodní mez", false);
            DataGridTools.AddColumn(dgRepricingLimits, "HiLimit", "Horní mez", false);
            DataGridTools.AddColumn(dgRepricingLimits, "Value", "Hodnota", false);
         }

        private void InitializeSuppliersCombo()
        {
            cbSupliers.DataSource = Enum.GetValues(typeof(Enums.Suppliers));
            cbSupliers.SelectedIndex = 0;
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
            
            gbPrestaSetup.Text =  TextResources.EUCPrestaSetup + eshop.EshopName;
            
            // Initialize bindings of grid.
            dgSuppliers.DataSource = eshop.Suppliers;
            dgRepricingLimits.DataSource = eshop.RepriceLimits;

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

        private void EshopChanged(object sender, EventArgs e)
        {
            if (disableCallBack)
            {
                return;
            }

            eshop.BaseUrl = ePrestaUrl.Text;
            eshop.Password = ePrestaToken.Text;
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

        private void BAddSupplierClick(object sender, EventArgs e)
        {
            Enums.Suppliers suplier;
            Enum.TryParse(cbSupliers.SelectedValue.ToString(), out suplier); 
            if (eshop.Suppliers.Any(item => item.Supplier == suplier) == false)
            {
                SupplierConfiguration newSupplier = new SupplierConfiguration();
                newSupplier.Supplier = suplier;
                eshop.Suppliers.Add(newSupplier);    
            }
        }

        private void BDelSupplierClick(object sender, EventArgs e)
        {
            SupplierConfiguration selectedSupplier = GetSelectedSupplier();
            if (selectedSupplier != null)
            {
                eshop.Suppliers.Remove(selectedSupplier);
            }
        }

        private void BOpenSupplierPriceListClick(object sender, EventArgs e)
        {
            openDialog.FileName = "";
            SupplierConfiguration selectedSupplier = GetSelectedSupplier();
            if (selectedSupplier != null)
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedSupplier.PathToFile = openDialog.FileName;
                }
            }
            eshop.Suppliers.ResetBindings();
        }

        private SupplierConfiguration GetSelectedSupplier()
        {
            SupplierConfiguration result = null;
            if (dgSuppliers.SelectedRows.Count > 0)
            {
                int ordersItemIndex = dgSuppliers.SelectedRows[0].Index;
                string suppliers = (dgSuppliers.Rows[ordersItemIndex].Cells[0].Value).ToString();

                foreach (SupplierConfiguration supplier in eshop.Suppliers)
                {
                    if (supplier.Supplier.ToString() == suppliers)
                    {
                        result = supplier;
                    }
                }
            }
            return result;
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