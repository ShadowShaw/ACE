using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PrestaAccesor.Entities
{
    public class category : prestashopentity
    {
        public Nullable<int> id { get; set; }
        public long id_shop { get; set; }  //entity.shop
        public List<Entities.language > description { get; set; }
        public List<Entities.language> short_description { get; set; }
        public List<Entities.language> meta_title { get; set; }
        public List<Entities.language> meta_description { get; set; }
        public List<Entities.language> meta_keywords { get; set; }
        
        public string name { get; set; }  // also LanguageRecord???
        
        public Nullable<long> id_parent { get; set; }
        public long id_shop_default { get; set; }
        public byte level_depth { get; set; }
        public bool is_root_category { get; set; }
    }
}