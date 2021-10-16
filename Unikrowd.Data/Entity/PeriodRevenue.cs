using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class PeriodRevenue
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public string MonthRevenue { get; set; }
        public double? Amount { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string RejectReason { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
