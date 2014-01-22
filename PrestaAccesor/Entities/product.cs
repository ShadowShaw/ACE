using System.Collections.Generic;

namespace PrestaAccesor.Entities
{
    public class Product : PrestashopEntity
    {
        public long id_product { get; set; }
        //public long id_shop { get; set; }
        public long id_lang { get; set; }
        public List<language> description { get; set; }
        public List<language> description_short { get; set; }
        public List<language> link_rewrite { get; set; }
        public List<language> meta_description { get; set; }
        public List<language> meta_keywords { get; set; }
        public List<language> meta_title { get; set; }
        public List<language> name { get; set; }
        //public string available_now { get; set; }
        //public string available_later { get; set; }

////        public long id_product { get; set; }
        public long? id_supplier { get; set; }
        public long? id_manufacturer { get; set; }
        public long? id_category_default { get; set; }
          //public long id_shop_default { get; set; }
        //public long id_tax_rules_group { get; set; }
        //public bool on_sale { get; set; }
        //public bool online_only { get; set; }
        //public string ean13 { get; set; }
        //public string upc { get; set; }
        //public decimal ecotax { get; set; }
        //public int quantity { get; set; }
        //public long minimal_quantity { get; set; }
        public decimal? price { get; set; }
        public decimal? wholesale_price { get; set; }
        //public string unity { get; set; }
        //public Nullable<decimal> unit_price_ratio { get; set; }
        //public Nullable<decimal> additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        //public string location { get; set; }
        //public Nullable<decimal> width { get; set; }
        //public Nullable<decimal> height { get; set; }
        //public Nullable<decimal> depth { get; set; }
        public decimal? weight { get; set; }
        //public long out_of_stock { get; set; }
        //public Nullable<bool> quantity_discount { get; set; }
        //public sbyte customizable { get; set; }
        //public sbyte uploadable_files { get; set; }
        //public sbyte text_fields { get; set; }
        //public bool active { get; set; }
        //public string redirect_type { get; set; }
        //public long id_product_redirected { get; set; }
        //public bool available_for_order { get; set; }
        //public string available_date { get; set; }
        ////public DateTime AvailableDate
        ////{
        ////    get
        ////    {
        ////        DateTime d;
        ////        if (DateTime.TryParseExact(available_date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
        ////        {
        ////            return d;
        ////        }

        ////        return default(DateTime);
        ////    }
        ////    set
        ////    {
        ////        available_date = AvailableDate.ToString();
        ////    }
        ////}
        //public string condition { get; set; }
        //public bool show_price { get; set; }
        //public bool indexed { get; set; }
        //public string visibility { get; set; }
        //public bool cache_is_pack { get; set; }
        //public bool cache_has_attachments { get; set; }
        //public bool is_virtual { get; set; }
        //public Nullable<long> cache_default_attribute { get; set; }
        //public System.DateTime date_add { get; set; }
        //public System.DateTime date_upd { get; set; }
        //////public string date_add { get; set; }
        //////public string date_upd { get; set; }
        //public bool advanced_stock_management { get; set; }
        
        //public long id_image { get; set; }
    }
}