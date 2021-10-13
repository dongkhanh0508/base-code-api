using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class CampaignRisk
    {
        public int CampaignId { get; set; }
        public int RiskId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Risk Risk { get; set; }
    }
}
