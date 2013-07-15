using LINQtoCSV;
using System;

namespace Desktop.Models
{
    public class Manufacturer
    {
        [CsvColumn(FieldIndex = 1)]
        public int Id { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string Date1 { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string Date2 { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public int Showed { get; set; }
    }
}
