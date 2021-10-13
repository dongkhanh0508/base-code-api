using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class SharingPeriod
    {
        public int Id { get; set; }
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }
        public double? SharingRevenue { get; set; }
        public int? CampaignId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Status { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
