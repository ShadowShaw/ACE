using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaSharp.Models
{    
    public class ps_product
    {
        public long id_product { get; set; }
        public Nullable<long> id_supplier { get; set; }
        public Nullable<long> id_manufacturer { get; set; }
        public Nullable<long> id_category_default { get; set; }
        public long id_shop_default { get; set; }
        public long id_tax_rules_group { get; set; }
        public bool on_sale { get; set; }
        public bool online_only { get; set; }
        public string ean13 { get; set; }
        public string upc { get; set; }
        public decimal ecotax { get; set; }
        public int quantity { get; set; }
        public long minimal_quantity { get; set; }
        public decimal price { get; set; }
        public decimal wholesale_price { get; set; }
        public string unity { get; set; }
        public decimal unit_price_ratio { get; set; }
        public decimal additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal depth { get; set; }
        public decimal weight { get; set; }
        public long out_of_stock { get; set; }
        public Nullable<bool> quantity_discount { get; set; }
        public sbyte customizable { get; set; }
        public sbyte uploadable_files { get; set; }
        public sbyte text_fields { get; set; }
        public bool active { get; set; }
        public string redirect_type { get; set; }
        public long id_product_redirected { get; set; }
        public bool available_for_order { get; set; }
        public System.DateTime available_date { get; set; }
        public string condition { get; set; }
        public bool show_price { get; set; }
        public bool indexed { get; set; }
        public string visibility { get; set; }
        public bool cache_is_pack { get; set; }
        public bool cache_has_attachments { get; set; }
        public bool is_virtual { get; set; }
        public Nullable<long> cache_default_attribute { get; set; }
        public System.DateTime date_add { get; set; }
        public System.DateTime date_upd { get; set; }
        public bool advanced_stock_management { get; set; }
    }
}
