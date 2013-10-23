using LINQtoCSV;
using System;

namespace Desktop.Models
{
    public class Noviko
    {
        [CsvColumn(FieldIndex = 1)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public decimal PriceWithoutDph { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public decimal PriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public decimal SalePriceWithoutDph { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public decimal SalePriceWithDph { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string Manufacturer { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public string Field_1 { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string Field_2 { get; set; }
        
        [CsvColumn(FieldIndex = 10)]
        public float Dph { get; set; }

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

        [CsvColumn(FieldIndex = 16)]
        public string EmptyField { get; set; }
    }
}
