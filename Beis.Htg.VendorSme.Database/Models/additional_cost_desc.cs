using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class additional_cost_desc
    {
        public additional_cost_desc()
        {
            additional_costs = new HashSet<additional_cost>();
        }

        public long additional_cost_desc_id { get; set; }
        public string additional_costDesc { get; set; }

        public virtual ICollection<additional_cost> additional_costs { get; set; }
    }
}
