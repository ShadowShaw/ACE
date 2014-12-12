using System.Collections.Generic;
using System.ComponentModel;

namespace UserSettings
{
    public class SupplierConfiguration
    {
        public Enums.Suppliers Supplier { get; set; }
        public string PathToFile { get; set; }
    }

    public class Limit
    {
        public decimal LowLimit { get; set; }
        public decimal HiLimit { get; set; }
        public decimal Value { get; set; }
    }

    public class EshopConfiguration //: INotifyPropertyChanged
    {
        public string EshopName { get; set; }
        public Enums.EshopType Type { get; set; }
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public BindingList<Limit> RepriceLimits { get; set; }
        public BindingList<SupplierConfiguration> Suppliers { get; set; }
        
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged(String info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}

        public EshopConfiguration()
        {
            Suppliers = new BindingList<SupplierConfiguration>();
            RepriceLimits = new BindingList<Limit>();
        }
    }
}
