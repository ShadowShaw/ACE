using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Desktop.UserSettings
{
    public enum EshopType
    { 
        Prestashop = 0,
        MySQLDatabase = 1
    }

    public class EshopConfiguration
    {
        public EshopType Type { get; set; } 
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ACEDesktopSettigs
    {
        public Size FormSize { get; set; }
    }

    public class ACESettings
    {
        public ACEDesktopSettigs DesktopSettings { get; set; }
        public List<EshopConfiguration> Eshops { get; set; }

        public ACESettings()
        {
            DesktopSettings = new ACEDesktopSettigs();
            Eshops = new List<EshopConfiguration>();
        }
    }
}
