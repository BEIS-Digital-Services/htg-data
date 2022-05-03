using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class administrator
    {
        public long user_id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string sname { get; set; }
        public string email { get; set; }
        public bool level1 { get; set; }
        public bool level2 { get; set; }
        public bool level3 { get; set; }
        public bool level4 { get; set; }
    }
}
