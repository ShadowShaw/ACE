using Bussiness.UserSettings;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Desktop.UserSettings
{
    public enum ACETabType
    {
        Home,
        Consistency,
        Repricing,
        Setup
    }

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
        public ACETabType ACETab;
        public GenericKeyValueList()
        {
            ACETab = ACETabType.Home;
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
                return GetValue("DesktopUserName");
            }
            set
            {
                SetValue("DesktopUserName", value);
            }
         }
        public string DesktopPassword
        {
            get
            {
                return GetValue("DesktopPassword");
            }
            set
            {
                SetValue("DesktopPassword", value);
            }
        }

        public EshopConfiguration ActiveEshop()
        {
            if ((Eshops.Eshops.Count > Eshops.ActiveEshopIndex) && (Eshops.ActiveEshopIndex != -1))
            {
                return Eshops.Eshops[Eshops.ActiveEshopIndex];
            }
            
            return null;
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
                result = FormSizes.FormSizes.FirstOrDefault(x => x.Name == formName).FSize;
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
            if (FormSizes.FormSizes.FirstOrDefault(x => x.Name == formName) == null)
            {
                FormSize item = new FormSize();
                item.Name = formName;
                item.FSize = formSize;
                FormSizes.FormSizes.Add(item);
            }
            else
            {
                FormSizes.FormSizes.FirstOrDefault(x => x.Name == formName).FSize = formSize;
            }
        }

        public int GetWidth(string widthName)
        {
            int result = 100;
            if (ColumnWidth.ColumnWidths.Exists(x => x.Name == widthName))
            {
                result = ColumnWidth.ColumnWidths.FirstOrDefault(x => x.Name == widthName).Width;
            }
                        
            return result;
        }

        public void SetWidth(string widthName, int width)
        {
            if (ColumnWidth == null)
            {
                ColumnWidth = new ColumnWidthList();
            }
            if (ColumnWidth.ColumnWidths.FirstOrDefault(x => x.Name == widthName) == null)
            {
                ColumnWidth item = new ColumnWidth();
                item.Name = widthName;
                item.Width = width;
                ColumnWidth.ColumnWidths.Add(item);
            }
            else
            {
                ColumnWidth.ColumnWidths.FirstOrDefault(x => x.Name == widthName).Width = width;
            }
        }

        public string GetValue(string key)
        {
            string result = String.Empty;

            if (Values.Values.Exists(x => x.Key == key))
            {
                result = Values.Values.FirstOrDefault(v => v.Key == key).Value;
            }
            
            return result;
            
        }

        public void SetValue(string key, string value)
        {
            if (Values == null)
            {
                Values = new GenericKeyValueList();
            }
            if (Values.Values.FirstOrDefault(x => x.Key == key) == null)
            {
                GenericKeyValueItem item = new GenericKeyValueItem();
                item.Key = key;
                item.Value = value;
                Values.Values.Add(item);
            }
            else
            {
                Values.Values.FirstOrDefault(x => x.Key == key).Value = value;
            }
        }

        private void LoadColumnWidth()
        {
            ColumnWidth = ACESettingsTools.LoadSettings<ColumnWidthList>(ColumnsSettingsPath);
        }

        private void SaveColumnWidth()
        {
            ACESettingsTools.SaveSettings(ColumnsSettingsPath, ColumnWidth);
        }

        private void LoadValues()
        {
            Values = ACESettingsTools.LoadSettings<GenericKeyValueList>(DesktopSettingsPath);
        }

        private void SaveValues()
        {
            ACESettingsTools.SaveSettings(DesktopSettingsPath, Values);
        }
        
        private void LoadEshops()
        {
            Eshops = ACESettingsTools.LoadSettings<EshopList>(EshopsSettingsPath);
        }

        private void SaveEshops()
        {
            ACESettingsTools.SaveSettings(EshopsSettingsPath, Eshops);
        }

        private void LoadFormSizes()
        {
            FormSizes = ACESettingsTools.LoadSettings<FormSizesList>(SizesSettingsPath);
        }

        private void SaveFormSizes()
        {
            ACESettingsTools.SaveSettings(SizesSettingsPath, FormSizes);
        }


        public ACESettings()
        {
            if (File.Exists(EshopsSettingsPath))
            {
                LoadEshops();
            }
            else
            {
                CreateFile(EshopsSettingsPath); 
            }
            if (Eshops == null)
            {
                Eshops = new EshopList();
                Eshops.ActiveEshopIndex = -1;
            }
            
            if (File.Exists(ColumnsSettingsPath))
            {
                LoadColumnWidth();
            }
            else
            {
                CreateFile(ColumnsSettingsPath);
            }

            if (File.Exists(SizesSettingsPath))
            {
                LoadFormSizes();
            }
            else
            {
                CreateFile(SizesSettingsPath);
            }

            if (File.Exists(DesktopSettingsPath))
            {
                LoadValues();
            }
            else
            {
                CreateFile(DesktopSettingsPath);
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
