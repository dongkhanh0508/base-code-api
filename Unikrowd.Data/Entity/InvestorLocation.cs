using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class InvestorLocation
    {
        public int InvestorId { get; set; }
        public int LocationId { get; set; }

        public virtual Investor Investor { get; set; }
    }
}
