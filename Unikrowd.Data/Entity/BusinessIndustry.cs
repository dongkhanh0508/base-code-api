using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class BusinessIndustry
    {
        public int IndustryId { get; set; }
        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
