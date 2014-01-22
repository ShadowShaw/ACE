using System.Collections.Generic;


namespace PrestaAccesor.Entities
{
    public class category : PrestashopEntity
    {
        public long id_shop { get; set; }  //entity.shop
        public List<language > description { get; set; }
        public List<language> short_description { get; set; }
        public List<language> link_rewrite { get; set; }
        public List<language> meta_title { get; set; }
        public List<language> meta_description { get; set; }
        public List<language> meta_keywords { get; set; }
        
        public string name { get; set; }  // also LanguageRecord???
        
        public long? id_parent { get; set; }
        public long id_shop_default { get; set; }
        public byte level_depth { get; set; }
        public bool is_root_category { get; set; }
    }
}