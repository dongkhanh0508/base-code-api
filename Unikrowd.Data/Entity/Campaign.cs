﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Unikrowd.Data.Entity
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignLocations = new HashSet<CampaignLocation>();
            CampaignPackages = new HashSet<CampaignPackage>();
            CampaignRisks = new HashSet<CampaignRisk>();
            CampaignStages = new HashSet<CampaignStage>();
            Documents = new HashSet<Document>();
            Locations = new HashSet<Location>();
            News = new HashSet<News>();
            Payments = new HashSet<Payment>();
            PeriodRevenues = new HashSet<PeriodRevenue>();
            QnAs = new HashSet<QnA>();
            SharingPeriods = new HashSet<SharingPeriod>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? MaxTarget { get; set; }
        public int? MinTarget { get; set; }
        public DateTime? KickoffDate { get; set; }
        public int? Maturity { get; set; }
        public DateTime? EndDate { get; set; }
        public double? InvestmentMultiple { get; set; }
        public int? Status { get; set; }
        public int? BusinessId { get; set; }
        public int? RiskId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Description { get; set; }
        public string RejectReason { get; set; }

        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual ICollection<CampaignPackage> CampaignPackages { get; set; }
        public virtual ICollection<CampaignRisk> CampaignRisks { get; set; }
        public virtual ICollection<CampaignStage> CampaignStages { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PeriodRevenue> PeriodRevenues { get; set; }
        public virtual ICollection<QnA> QnAs { get; set; }
        public virtual ICollection<SharingPeriod> SharingPeriods { get; set; }
    }
}
