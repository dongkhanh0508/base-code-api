using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class CampaignSection
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public int? ShowOrder { get; set; }
    }
}
