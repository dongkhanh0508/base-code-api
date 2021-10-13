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
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
    }
}
