using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.MapperViewModels
{
    public class CampaignPackageViewModel
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? MaxQuantity { get; set; }
        public string Name { get; set; }
        public string Reward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
    }
}
