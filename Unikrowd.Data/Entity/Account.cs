using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Account
    {
        public Account()
        {
            Businesses = new HashSet<Business>();
            Investors = new HashSet<Investor>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Investor> Investors { get; set; }
    }
}
