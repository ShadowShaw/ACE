using System.Collections.Generic;
using System.Drawing;

namespace UserSettings
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
        public Enums.ACETabType ACETab;
        public GenericKeyValueList()
        {
            ACETab = Enums.ACETabType.Home;
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
}
