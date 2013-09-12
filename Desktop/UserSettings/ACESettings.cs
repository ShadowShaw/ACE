using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Desktop.UserSettings
{
    public enum EshopType
    { 
        Prestashop = 0,
        MySQLDatabase = 1
    }

    public class EshopList
    {
        public List<EshopConfiguration> Eshops { get; set; }
        public EshopList()
        {
            Eshops = new List<EshopConfiguration>();
        }
    }
        
    public class EshopConfiguration
    {
        public string EshopName { get; set; }
        public EshopType Type { get; set; } 
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    //public class HtmlAdresses
    //{
    //    public string Name { get; set; }
    //    public string Adress { get; set; }
    //}

    public class FormSize
    {
        public string Name { get; set; }
        public Size FSize { get; set; }
    }

    public class ColumnWidth
    {
        public string Name { get; set; }
        public int Width { get; set; }
    }


    public class FormSizesList
    {
        public List<FormSize> FormSizes { get; set; }
        public FormSizesList()
        {
            FormSizes = new List<FormSize>();
        }
    }

    public class GenericKeyValueItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class GenericKeyValueList
    { 
        public List<GenericKeyValueItem> Values { get; set; }
        public GenericKeyValueList()
        {
            Values = new List<GenericKeyValueItem>();
        }
    }

    public class ColumnWidthList
    {
        public List<ColumnWidth> ColumnWidths { get; set; }
        public ColumnWidthList()
        {
            ColumnWidths = new List<ColumnWidth>();
        }
    }

    public class ACESettings
    {
        public const string HomePath = "http://ace-2.apphb.com/HtmlDocs/Home.html";
        public const string ChangeLogPath = "http://ace-2.apphb.com/HtmlDocs/ChangeLog.html";

        public EshopList Eshops { get; set; }
        public FormSizesList FormSizes { get; set; }
        public ColumnWidthList ColumnWidth { get; set; }
        public GenericKeyValueList Values { get; set; }
        public string DesktopUserName { 
            get
            {
                return this.GetValue("DesktopUserName");
            }
            set
            {
                this.SetValue("DesktopUserName", value);
            }
         }
        public string DesktopPassword
        {
            get
            {
                return this.GetValue("DesktopPassword");
            }
            set
            {
                this.SetValue("DesktopPassword", value);
            }
        }

        public Size GetSize(string formName)
        {
            return FormSizes.FormSizes.Where(x => x.Name == formName).FirstOrDefault().FSize;
        }

        public void SetSize(string formName, Size formSize)
        {
            if (FormSizes == null)
            {
                FormSizes = new FormSizesList();
            }
            if (FormSizes.FormSizes.Where(x => x.Name == formName).FirstOrDefault() == null)
            {
                FormSize item = new FormSize();
                item.Name = formName;
                item.FSize = formSize;
                FormSizes.FormSizes.Add(item);
            }
            else
            {
                FormSizes.FormSizes.Where(x => x.Name == formName).FirstOrDefault().FSize = formSize;
            }
        }

        public int GetWidth(string widthName)
        {
            var result = ColumnWidth.ColumnWidths.Where(x => x.Name == widthName).FirstOrDefault();
            if (result == null)
            {
                return 100;
            }
            else
            {
                return result.Width;
            }
        }

        public void SetWidth(string widthName, int width)
        {
            if (ColumnWidth == null)
            {
                ColumnWidth = new ColumnWidthList();
            }
            if (ColumnWidth.ColumnWidths.Where(x => x.Name == widthName).FirstOrDefault() == null)
            {
                ColumnWidth item = new ColumnWidth();
                item.Name = widthName;
                item.Width = width;
                ColumnWidth.ColumnWidths.Add(item);
            }
            else
            {
                ColumnWidth.ColumnWidths.Where(x => x.Name == widthName).FirstOrDefault().Width = width;
            }
        }

        public string GetValue(string key)
        {
            if (Values == null)
            {
                return "";
            }
            var result = Values.Values.Where(v => v.Key == key).FirstOrDefault();
            if (result == null)
            {
                return "";
            }
            else
            {
                return result.Value;
            }
        }

        public void SetValue(string key, string value)
        {
            if (Values == null)
            {
                Values = new GenericKeyValueList();
            }
            if (Values.Values.Where(x => x.Key == key).FirstOrDefault() == null)
            {
                GenericKeyValueItem item = new GenericKeyValueItem();
                item.Key = key;
                item.Value = value;
                Values.Values.Add(item);
            }
            else
            {
                Values.Values.Where(x => x.Key == key).FirstOrDefault().Value = value;
            }
        }

        public void LoadColumnWidth()
        {
            this.ColumnWidth = ACESettingsTools.LoadSettings<ColumnWidthList>("Columns.xml");
        }

        public void SaveColumnWidth()
        {
            ACESettingsTools.SaveSettings<ColumnWidthList>("Columns.xml", ColumnWidth);
        }

        public void LoadValues()
        {
            this.Values = ACESettingsTools.LoadSettings<GenericKeyValueList>("ACEDesktop.xml");
        }

        public void SaveValues()
        {
            ACESettingsTools.SaveSettings<GenericKeyValueList>("ACEDesktop.xml", Values);
        }
        
        public void LoadEshops()
        {
            this.Eshops = ACESettingsTools.LoadSettings<EshopList>("Eshops.xml");
        }

        public void SaveEshops()
        {
            ACESettingsTools.SaveSettings<EshopList>("Eshops.xml", Eshops);
        }

        public void LoadFormSizes()
        {
            this.FormSizes = ACESettingsTools.LoadSettings<FormSizesList>("Sizes.xml");
        }

        public void SaveFormSizes()
        {
            ACESettingsTools.SaveSettings<FormSizesList>("Sizes.xml", FormSizes);
        }


        public ACESettings()
        {
            //DesktopSettings = new ACEDesktopSettigs();
            Eshops = new EshopList();
            FormSizes = new FormSizesList();
            ColumnWidth = new ColumnWidthList();
            Values = new GenericKeyValueList();
        }
    }
}
