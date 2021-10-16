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
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
