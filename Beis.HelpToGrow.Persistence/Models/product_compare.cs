using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_compare
    {
        public product_compare()
        {
        }

        public long id { get; set; }
        public string item_name { get; set; }
        public long type_id { get; set; }
        public int? sortorder { get; set; }

    }
}
