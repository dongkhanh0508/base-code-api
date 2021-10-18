using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Investment
    {
        public Investment()
        {
            Payments = new HashSet<Payment>();
        }

        public int OwnerId { get; set; }
        public int CampaignPackageId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPledge { get; set; }
        public double? Paid { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? PaidMaturity { get; set; }
        public DateTime? LastPaymentTime { get; set; }
        public int? IsDelete { get; set; }
        public int Id { get; set; }

        public virtual CampaignPackage CampaignPackage { get; set; }
        public virtual Investor Owner { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
