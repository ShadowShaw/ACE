using LINQtoCSV;
using Suppliers.Interfaces;
using System;

namespace Suppliers.Models
{
    public class AskinoModel
    {
        [CsvColumn(FieldIndex = 1)]
        public string LocationCode { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string SupplierCode { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string VariantCode { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public string VariantDescription { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string Supply { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public string Unit { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string UnitPrice { get; set; }

        [CsvColumn(FieldIndex = 10)]
        public float Dph { get; set; }

        [CsvColumn(FieldIndex = 11)]
        public string PriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 12)]
        public string Ean { get; set; }
    }
}
