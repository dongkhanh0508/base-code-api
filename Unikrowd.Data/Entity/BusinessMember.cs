using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class BusinessMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? BusinessId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Business Business { get; set; }
    }
}
