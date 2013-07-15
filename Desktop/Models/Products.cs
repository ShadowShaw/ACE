using LINQtoCSV;
using System;

namespace Desktop.Models
{
    public class Product
    {
        [CsvColumn(FieldIndex = 1)]
        public int IdProduct { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public int IdSupplier { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public int IdManufacturer { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public int IdTaxRulesGroup { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public int IdCategoryDefault { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public int IdColorDefault { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public int OnSale { get; set; }

        [CsvColumn(FieldIndex = 8)]
        public int OnlineOnly { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string Ean13 { get; set; }

        [CsvColumn(FieldIndex = 10)]
        public string Upc { get; set; }

        [CsvColumn(FieldIndex = 11)]
        public decimal EcoTax { get; set; }

        [CsvColumn(FieldIndex = 12)]
        public int Quantity { get; set; }

        [CsvColumn(FieldIndex = 13)]
        public int MinimumQuantity { get; set; }

        [CsvColumn(FieldIndex = 14)]
        public decimal Price { get; set; }

        [CsvColumn(FieldIndex = 15)]
        public decimal WholeSalePrice { get; set; }

        [CsvColumn(FieldIndex = 16)]
        public string Unity { get; set; }

        [CsvColumn(FieldIndex = 17)]
        public decimal UnitPriceRatio { get; set; }

        [CsvColumn(FieldIndex = 18)]
        public decimal AdditonalShipingCost { get; set; }

        [CsvColumn(FieldIndex = 19)]
        public string Reference { get; set; }

        [CsvColumn(FieldIndex = 20)]
        public string SupplierReference { get; set; }

        [CsvColumn(FieldIndex = 21)]
        public string Location { get; set; }

        [CsvColumn(FieldIndex = 22)]
        public float Width { get; set; }

        [CsvColumn(FieldIndex = 23)]
        public float Height { get; set; }

        [CsvColumn(FieldIndex = 24)]
        public float Depth { get; set; }
        
        [CsvColumn(FieldIndex = 25)]
        public float Weight { get; set; }

        [CsvColumn(FieldIndex = 26)]
        public int OutOfStock { get; set; }

        [CsvColumn(FieldIndex = 27)]
        public int QuantityDiscount { get; set; }

        [CsvColumn(FieldIndex = 28)]
        public int Customizable { get; set; }

        [CsvColumn(FieldIndex = 29)]
        public int UploadableFiles { get; set; }
        
        [CsvColumn(FieldIndex = 30)]
        public int TextField { get; set; }
        
        [CsvColumn(FieldIndex = 31)]
        public int Active { get; set; }

        [CsvColumn(FieldIndex = 32)]
        public int AvailableForOrder { get; set; }
        
        [CsvColumn(FieldIndex = 33)]
        public string Condition { get; set; }
        
        [CsvColumn(FieldIndex = 34)]
        public int ShowPrice { get; set; }

        [CsvColumn(FieldIndex = 35)]
        public int Indexed { get; set; }

        [CsvColumn(FieldIndex = 36)]
        public int CacheIsPack { get; set; }
        
        [CsvColumn(FieldIndex = 37)]
        public int CacheHasAttachements { get; set; }
        
        [CsvColumn(FieldIndex = 38)]
        public int CacheDefaultAttribute { get; set; }
        
        [CsvColumn(FieldIndex = 39)]
        public string DateAdd{ get; set; }

        [CsvColumn(FieldIndex = 40)]
        public string DateUpdate { get; set; }
    }
}
