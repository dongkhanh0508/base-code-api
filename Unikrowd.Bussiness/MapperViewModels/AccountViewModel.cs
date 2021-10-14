using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.MapperViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual IEnumerable<BusinessViewModel> Businesses { get; set; }
        public virtual IEnumerable<InvestorViewModel> Investors { get; set; }
    }
}
