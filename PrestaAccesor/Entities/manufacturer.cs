using System;
using System.Collections.Generic;

namespace PrestaAccesor.Entities
{
    public class manufacturer : PrestashopEntity
    {
        public string name { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public int active { get; set; }
        public List<language> description { get; set; }
        public List<language> short_description { get; set; }
        public List<language> meta_title { get; set; }
        public List<language> meta_description { get; set; }
        public List<language> meta_keywords { get; set; }
        public associations associations { get; set; }
    }
}
