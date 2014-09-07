using System.Collections.Generic;

namespace Bussiness.UserSettings
{
    public enum EshopType
    {
        Prestashop = 0,
        MySqlDatabase = 1
    }

    public class SupplierConfiguration
    { 
        public string SupplierName { get; set; }
        public bool UseSupplier { get; set; }
        public string SupplierFileName { get; set; }
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
        public EshopType Type { get; set; }
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Limit> RepriceLimits { get; set; }
        public List<SupplierConfiguration> Suppliers { get; set; }
        
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
            Suppliers = new List<SupplierConfiguration>();
        }

        public int AskinoIndex()
        {
            return 0;
        }

        public int NovikoIndex()
        {
            return 1;
        }
    }
}
