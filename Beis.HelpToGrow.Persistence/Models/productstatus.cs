using System;
using System.Collections.Generic;

#nullable disable

namespace Beis.HelpToGrow.Persistence.Models
{
    public partial class productstatus
    {
        public productstatus()
        {
            product1s = new HashSet<product1>();
        }

        public long id { get; set; }
        public string status_description { get; set; }

        public virtual ICollection<product1> product1s { get; set; }
    }
}
