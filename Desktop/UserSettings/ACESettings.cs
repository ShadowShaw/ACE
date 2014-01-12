using Bussiness.UserSettings;
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
    public class EshopList
    {
        public List<EshopConfiguration> Eshops { get; set; }
        public EshopList()
        {
            Eshops = new List<EshopConfiguration>();
        }
        public int ActiveEshopIndex { get; set; }
    }
        
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
        public const string EshopsSettingsPath = "Settings\\Eshops.xml";
        public const string ColumnsSettingsPath = "Settings\\Columns.xml";
        public const string SizesSettingsPath = "Settings\\Sizes.xml";
        public const string DesktopSettingsPath = "Settings\\ACEDesktop.xml";

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

        public EshopConfiguration ActiveEshop()
        {
            if ((Eshops.Eshops.Count > Eshops.ActiveEshopIndex) && (Eshops.ActiveEshopIndex != -1))
            {
                return Eshops.Eshops[Eshops.ActiveEshopIndex];
            }
            else
            {
                return null;
            }
        }

        public void UpdateSelectedEshop(EshopConfiguration eshop, int selectedIndex)
        {
            Eshops.Eshops[selectedIndex] = eshop;
        }

        public Size GetSize(string formName)
        {
            Size result;
            if (FormSizes.FormSizes.Exists(x => x.Name == formName))
            {
                result = FormSizes.FormSizes.Where(x => x.Name == formName).FirstOrDefault().FSize;
            }
            else
            {
                result = new Size(400, 400);
            }
            
            return result;
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
            int result = 100;
            if (ColumnWidth.ColumnWidths.Exists(x => x.Name == widthName))
            {
                result = ColumnWidth.ColumnWidths.Where(x => x.Name == widthName).FirstOrDefault().Width;
            }
                        
            return result;
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
            string result = String.Empty;

            if (Values.Values.Exists(x => x.Key == key))
            {
                result = Values.Values.Where(v => v.Key == key).FirstOrDefault().Value;
            }
            
            return result;
            
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

        private void LoadColumnWidth()
        {
            this.ColumnWidth = ACESettingsTools.LoadSettings<ColumnWidthList>(ColumnsSettingsPath);
        }

        private void SaveColumnWidth()
        {
            ACESettingsTools.SaveSettings<ColumnWidthList>(ColumnsSettingsPath, ColumnWidth);
        }

        private void LoadValues()
        {
            this.Values = ACESettingsTools.LoadSettings<GenericKeyValueList>(DesktopSettingsPath);
        }

        private void SaveValues()
        {
            ACESettingsTools.SaveSettings<GenericKeyValueList>(DesktopSettingsPath, Values);
        }
        
        private void LoadEshops()
        {
            this.Eshops = ACESettingsTools.LoadSettings<EshopList>(EshopsSettingsPath);
        }

        private void SaveEshops()
        {
            ACESettingsTools.SaveSettings<EshopList>(EshopsSettingsPath, Eshops);
        }

        private void LoadFormSizes()
        {
            this.FormSizes = ACESettingsTools.LoadSettings<FormSizesList>(SizesSettingsPath);
        }

        private void SaveFormSizes()
        {
            ACESettingsTools.SaveSettings<FormSizesList>(SizesSettingsPath, FormSizes);
        }


        public ACESettings()
        {
            if (File.Exists(ACESettings.EshopsSettingsPath))
            {
                LoadEshops();
                if (this.Eshops == null)
                {
                    Eshops = new EshopList();
                    Eshops.ActiveEshopIndex = -1;
                }
            }
            else
            {
                CreateFile(ACESettings.EshopsSettingsPath); 
                Eshops.ActiveEshopIndex = -1;
            }

            if (File.Exists(ACESettings.ColumnsSettingsPath))
            {
                LoadColumnWidth();
            }
            else
            {
                CreateFile(ACESettings.ColumnsSettingsPath);
            }

            if (File.Exists(ACESettings.SizesSettingsPath))
            {
                LoadFormSizes();
            }
            else
            {
                CreateFile(ACESettings.SizesSettingsPath);
            }

            if (File.Exists(ACESettings.DesktopSettingsPath))
            {
                LoadValues();
            }
            else
            {
                CreateFile(ACESettings.DesktopSettingsPath);
            }

            if (Eshops == null)
            {
                Eshops = new EshopList();
            }

            if (FormSizes == null)
            {
                FormSizes = new FormSizesList();
            }

            if (ColumnWidth == null)
            {
                ColumnWidth = new ColumnWidthList();
            }

            if (Values == null)
            {
                Values = new GenericKeyValueList();
            }
        }

        private static void CreateFile(string file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            var myFile = File.Create(file);
            myFile.Close();
        }

        public void SaveSettings()
        {
            SaveEshops();
            SaveColumnWidth();
            SaveFormSizes();
            SaveValues();
        }
    }
}
