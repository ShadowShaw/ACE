using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaSharp.Models
{
    public class ps_manufacturer
    {
        public long id_manufacturer { get; set; }
        public string name { get; set; }
        public System.DateTime date_add { get; set; }
        public System.DateTime date_upd { get; set; }
        public bool active { get; set; }
    }
}
