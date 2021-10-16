using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Risk
    {
        public Risk()
        {
            CampaignRisks = new HashSet<CampaignRisk>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RiskType { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Description { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<CampaignRisk> CampaignRisks { get; set; }
    }
}
