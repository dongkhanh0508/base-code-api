using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class QnA
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int? CampaignId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Answer { get; set; }
        public string AnsweredBy { get; set; }
        public DateTime? AnsweredAt { get; set; }
        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentId { get; set; }
    }
}
