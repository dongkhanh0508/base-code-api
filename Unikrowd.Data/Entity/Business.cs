using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Business
    {
        public Business()
        {
            BusinessIndustries = new HashSet<BusinessIndustry>();
            BusinessMembers = new HashSet<BusinessMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessLicense { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }
        public string BankAccountHolder { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Image { get; set; }

        public virtual Account User { get; set; }
        public virtual ICollection<BusinessIndustry> BusinessIndustries { get; set; }
        public virtual ICollection<BusinessMember> BusinessMembers { get; set; }
    }
}
