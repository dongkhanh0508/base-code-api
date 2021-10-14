using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.MapperViewModels
{
    public class InvestorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bank { get; set; }
        public string BanksAccount { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
