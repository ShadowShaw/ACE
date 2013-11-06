using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestaAccesor.Entities
{
    public class LanguageEntity : PrestashopEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public string iso_code { get; set; }
        public string language_code { get; set; }
        public string date_format_lite { get; set; }
        public string date_format_full { get; set; }
        public bool is_rtl { get; set; }
    }
}
