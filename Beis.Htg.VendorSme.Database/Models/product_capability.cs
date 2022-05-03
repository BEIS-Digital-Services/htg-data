using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class product_capability
    {
        public long Id { get; set; }
        public long product_id { get; set; }
        public long capability_id { get; set; }
        public string draft_capability { get; set; }
    }
}
