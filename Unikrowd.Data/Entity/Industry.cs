using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Industry
    {
        public Industry()
        {
            BusinessIndustries = new HashSet<BusinessIndustry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<BusinessIndustry> BusinessIndustries { get; set; }
    }
}
