using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class InvestmentDetail
    {
        public int Id { get; set; }
        public int? InvestmentId { get; set; }
        public int? CampaignPackageId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Status { get; set; }
    }
}
