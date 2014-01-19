using Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.ViewModels
{
    public class CategoryViewModel : IViewModel
    {
        public Nullable<long> id { get; set; }
        //public long id_shop { get; set; }  //entity.shop
        //public string description { get; set; }
        //public List<Entities.language> short_description { get; set; }
        public string link_rewrite { get; set; }
        //public List<Entities.language> meta_title { get; set; }
        //public List<Entities.language> meta_description { get; set; }
        //public List<Entities.language> meta_keywords { get; set; }

        public string name { get; set; }  

        public Nullable<long> id_parent { get; set; }
        public long id_shop_default { get; set; }
        public byte level_depth { get; set; }
        public bool is_root_category { get; set; }
    }
}