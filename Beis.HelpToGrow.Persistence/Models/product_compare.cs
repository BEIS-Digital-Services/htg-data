using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class product_compare
    {
        public product_compare()
        {
            product_compare_entries = new HashSet<product_compare_entry>();
        }

        public long id { get; set; }
        public string item_name { get; set; }
        public long type_id { get; set; }
        public int? sortorder { get; set; }

        public virtual ICollection<product_compare_entry> product_compare_entries { get; set; }
    }
}
