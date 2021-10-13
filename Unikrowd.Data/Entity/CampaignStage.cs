using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class CampaignStage
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public string FromMonth { get; set; }
        public string ToMonth { get; set; }
        public string StageName { get; set; }
        public int? Percents { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Status { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
