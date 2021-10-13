using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class IndustryRelation
    {
        public int Id { get; set; }
        public int IndustryId { get; set; }
        public int RelatedIndustry { get; set; }
    }
}
