using System;
using System.Collections.Generic;
using LINQtoCSV;
using Suppliers.Interfaces;

namespace Suppliers.Models
{
    public class AskinoTrixieModel : ISupplierModel
    {
        public Dictionary<int, string> GetMapping()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            result.Add(0, "Trixie");
            result.Add(1, "TrixieReference");
            result.Add(2, "Variant");
            result.Add(3, "Reference");
            result.Add(4, "StrangeName");
            result.Add(5, "Name");
            result.Add(6, "VariantDescription");
            result.Add(7, "Unit");
            result.Add(8, "UnitPrice");
            result.Add(9, "Dph");
            result.Add(10, "PriceWithDph");
            
            return result;
        }

        public int GetFileTableIndex()
        {
            return 0;
        }

        public int GetReferenceColumnIndex()
        {
            return 3;
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
        public string Trixie { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string TrixieReference { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string Variant { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string StrangeName { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string VariantDescription { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public string Unit { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string UnitPrice { get; set; }

        [CsvColumn(FieldIndex = 10)]
        public string Dph { get; set; }

        [CsvColumn(FieldIndex = 11)]
        public string PriceWithDph { get; set; }
    }
}