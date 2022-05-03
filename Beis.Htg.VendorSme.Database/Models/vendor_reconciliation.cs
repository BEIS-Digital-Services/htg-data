#nullable disable

using System;

namespace Beis.Htg.VendorSme.Database.Models
{
    public partial class vendor_reconciliation
    {
        public long reconciliation_id { get; set; }
        public long vendor_id { get; set; }
        public DateTime? reconciliation_date { get; set; }

        public virtual vendor_reconciliation_sale reconciliation { get; set; }
    }
}
