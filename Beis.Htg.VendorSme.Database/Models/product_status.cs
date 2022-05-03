using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class product_status
    {
        public long id { get; set; }
        public string status_description { get; set; }
    }
}
