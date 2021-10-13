using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CampaignId { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
