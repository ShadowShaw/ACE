using System;
using System.Collections.Generic;
using LINQtoCSV;
using Suppliers.Interfaces;

namespace Suppliers.Models
{
    public class AskinoModel : ISupplierModel
    {
        public Dictionary<int, string> GetMapping()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            result.Add(0, "Reference");
            result.Add(1, "SupplierCode");
            result.Add(2, "Name");
            result.Add(3, "VariantDescription");
            result.Add(4, "Unit");
            result.Add(5, "UnitPrice");
            result.Add(6, "Dph");
            result.Add(7, "PriceWithDph");
            result.Add(8, "Ean");
            
            return result;
        }

        public int GetFileTableIndex()
        {
            return 1;
        }

        public int GetReferenceColumnIndex()
        {
            return 0;
        }

        public string GetReference()
        {
            return Reference;
        }

        public decimal GetPrice()
        {
            return Convert.ToDecimal(PriceWithDph);
        }
        public decimal GetWholeSalePrice()
        {
            return Convert.ToDecimal(UnitPrice);
        }

        [CsvColumn(FieldIndex = 1)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string SupplierCode { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string VariantDescription { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string Unit { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public string UnitPrice { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string Dph { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public string PriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string Ean { get; set; }
    }
}