using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class CampaignLocation
    {
        public int CampaignId { get; set; }
        public int LocationId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Location Location { get; set; }
    }
}
