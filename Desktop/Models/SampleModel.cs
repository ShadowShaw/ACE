using LINQtoCSV;
using System;

namespace Desktop.Models
{
    public class SampleModel
    {
        [CsvColumn(FieldIndex = 1)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public int i1 { get; set; }
        
        [CsvColumn(FieldIndex = 3)]
        public int i2 { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public int i3 { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public int i4 { get; set; }
        
        [CsvColumn(FieldIndex = 6)]
        public int i5 { get; set; }
    }

        //[CsvColumn(Name = "ProductName", FieldIndex = 1)]
        //[CsvColumn(FieldIndex = 2, OutputFormat = "dd MMM HH:mm:ss")]
        //[CsvColumn(FieldIndex = 3, CanBeNull = false, OutputFormat = "C")]
}




