using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Bussiness.UserSettings
{
    public enum EshopType
    {
        Prestashop = 0,
        MySQLDatabase = 1
    }

    public class SupplierConfiguration
    { 
        public string SupplierName { get; set; }
        public bool UseSupplier { get; set; }
        public string SupplierFileName { get; set; }
    }


    public class EshopConfiguration //: INotifyPropertyChanged
    {
        public string EshopName { get; set; }
        public EshopType Type { get; set; }
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<SupplierConfiguration> Suppliers { get; set; }
        public bool UseAskino { get; set; }
        public bool UseNoviko { get; set; }
        public string AskinoFilePath { get; set; }
        public string NovikoFilePath { get; set; }

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
            //AskinoFilePath = "cesta k ceníku Askina constu";
            //BaseUrl = String.Empty;
            //UseAskino = false;
            Suppliers = new List<SupplierConfiguration>();
        }
    }
}
