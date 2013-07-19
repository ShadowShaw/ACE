using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Desktop.UserSettings
{
    sealed class MainSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public bool UsePresta
        {
            get { return (bool)this["UsePresta"]; }
            set { this["UsePresta"] = value; }
        }

        [UserScopedSettingAttribute()]
        public string PrestaShopUrl
        {
            get { return (string)this["PrestaShopUrl"]; }
            set { this["PrestaShopUrl"] = value; }
        }

        [UserScopedSettingAttribute()]
        //[DefaultSettingValueAttribute("0, 0")]
        public string PrestaApiToken
        {
            get { return (string)(this["PrestaApiToken"]); }
            set { this["PrestaApiToken"] = value; }
        }

        [UserScopedSettingAttribute()]
        //[DefaultSettingValueAttribute("225, 200")]
        public Size FormSize
        {
            get { return (Size)this["FormSize"]; }
            set { this["FormSize"] = value; }
        }
    }
}
