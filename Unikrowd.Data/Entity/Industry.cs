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
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<BusinessIndustry> BusinessIndustries { get; set; }
    }
}
