using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Investment
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public int? CampaignId { get; set; }
        public int? CampaignPackageId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPledge { get; set; }
        public double? Paid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? PaidMaturity { get; set; }
        public DateTime? LastPaymentTime { get; set; }
        public int? IsDelete { get; set; }

        public virtual CampaignPackage CampaignPackage { get; set; }
        public virtual Investor Owner { get; set; }
    }
}
