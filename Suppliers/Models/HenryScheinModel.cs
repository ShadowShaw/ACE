using System;
using System.Collections.Generic;
using LINQtoCSV;
using Suppliers.Interfaces;

namespace Suppliers.Models
{
    public class HenryScheinModel : ISupplierModel
    {
        public Dictionary<int, string> GetMapping()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            result.Add(0, "Reference");
            result.Add(1, "Name");
            result.Add(2, "PriceWithoutDph");
            result.Add(3, "PriceWithDph");
            result.Add(4, "SalePriceWithoutDph");
            result.Add(5, "SalePriceWithDph");
            result.Add(6, "Manufacturer");
            result.Add(7, "Field1");
            result.Add(8, "Field2");
            result.Add(9, "Dph");
            result.Add(10, "Category");
            result.Add(11, "CategoryField1");
            result.Add(12, "CategoryField2");
            result.Add(13, "CategoryField3");
            result.Add(14, "CategoryField4");
            result.Add(15, "EmptyField");

            return result;
        }

        public int GetFileTableIndex()
        {
            return 0;
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
            return Convert.ToDecimal(SalePriceWithDph);
        }

        [CsvColumn(FieldIndex = 1)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string PriceWithoutDph { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string PriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string SalePriceWithoutDph { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public string SalePriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string Manufacturer { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public string Field1 { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string Field2 { get; set; }
        
        [CsvColumn(FieldIndex = 10)]
        public string Dph { get; set; }

        [CsvColumn(FieldIndex = 11)]
        public string Category { get; set; }

        [CsvColumn(FieldIndex = 12)]
        public string CategoryField1 { get; set; }

        [CsvColumn(FieldIndex = 13)]
        public string CategoryField2 { get; set; }

        [CsvColumn(FieldIndex = 14)]
        public string CategoryField3 { get; set; }

        [CsvColumn(FieldIndex = 15)]
        public string CategoryField4 { get; set; }
    }
}
