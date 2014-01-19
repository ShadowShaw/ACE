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
            //SupplierConfiguration askino = new SupplierConfiguration();
            //askino.SupplierName = "Askino";

            //SupplierConfiguration noviko = new SupplierConfiguration();
            //noviko.SupplierName = "Noviko";

            //Suppliers.Add(askino);
            //Suppliers.Add(noviko);

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
