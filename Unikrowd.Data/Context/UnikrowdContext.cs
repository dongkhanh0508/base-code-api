using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Unikrowd.Data.Entity;

#nullable disable

namespace Unikrowd.Data.Context
{
    public partial class UnikrowdContext : DbContext
    {
        public UnikrowdContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public UnikrowdContext(DbContextOptions<UnikrowdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessIndustry> BusinessIndustries { get; set; }
        public virtual DbSet<BusinessMember> BusinessMembers { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignComment> CampaignComments { get; set; }
        public virtual DbSet<CampaignLocation> CampaignLocations { get; set; }
        public virtual DbSet<CampaignPackage> CampaignPackages { get; set; }
        public virtual DbSet<CampaignRisk> CampaignRisks { get; set; }
        public virtual DbSet<CampaignSection> CampaignSections { get; set; }
        public virtual DbSet<CampaignStage> CampaignStages { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<FavoriteCampaign> FavoriteCampaigns { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<IndustryRelation> IndustryRelations { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<InvestmentDetail> InvestmentDetails { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<InvestorLocation> InvestorLocations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PeriodRevenue> PeriodRevenues { get; set; }
        public virtual DbSet<PeriodRevenueComment> PeriodRevenueComments { get; set; }
        public virtual DbSet<QnA> QnAs { get; set; }
        public virtual DbSet<Risk> Risks { get; set; }
        public virtual DbSet<SharingPeriod> SharingPeriods { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:54.151.235.125,1433;Database=dev-crowdfundingplatform;User ID=dev-fseed;Password=PX:K37(Mh8T4WdktUx#yZ$+?a_D;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;");
            }
        }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Username, "IX_Account")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Bank).HasMaxLength(100);

                entity.Property(e => e.BankAccountHolder).HasMaxLength(100);

                entity.Property(e => e.BanksAccount).HasMaxLength(30);

                entity.Property(e => e.BusinessLicense).HasMaxLength(30);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Business_Users");
            });

            modelBuilder.Entity<BusinessIndustry>(entity =>
            {
                entity.HasKey(e => new { e.IndustryId, e.BusinessId })
                    .HasName("PK__Business__3214EC07D83CFD78");

                entity.ToTable("BusinessIndustry");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.BusinessIndustries)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessIndustry_Business");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.BusinessIndustries)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessIndustry_Industry");
            });

            modelBuilder.Entity<BusinessMember>(entity =>
            {
                entity.ToTable("BusinessMember");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.BusinessMembers)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessMember_Business");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KickoffDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RiskId).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<CampaignComment>(entity =>
            {
                entity.ToTable("CampaignComment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<CampaignLocation>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.LocationId })
                    .HasName("PK__Campaign__3214EC07EB45A231");

                entity.ToTable("CampaignLocation");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignLocations)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignLocation_Campaign");
            });

            modelBuilder.Entity<CampaignPackage>(entity =>
            {
                entity.ToTable("CampaignPackage");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Reward).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignPackages)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_CampaignPackage_Campaign");
            });

            modelBuilder.Entity<CampaignRisk>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.RiskId });

                entity.ToTable("CampaignRisk");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignRisks)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignRisk_Campaign");

                entity.HasOne(d => d.Risk)
                    .WithMany(p => p.CampaignRisks)
                    .HasForeignKey(d => d.RiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignRisk_Risk");
            });

            modelBuilder.Entity<CampaignSection>(entity =>
            {
                entity.ToTable("CampaignSection");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<CampaignStage>(entity =>
            {
                entity.ToTable("CampaignStage");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FromMonth).HasMaxLength(50);

                entity.Property(e => e.StageName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.ToMonth).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignStages)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_CampaignStage_Campaign");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_Document_Campaign");
            });

            modelBuilder.Entity<FavoriteCampaign>(entity =>
            {
                entity.ToTable("FavoriteCampaign");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.ToTable("Fee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industry");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<IndustryRelation>(entity =>
            {
                entity.ToTable("IndustryRelation");
            });

            modelBuilder.Entity<Investment>(entity =>
            {
                entity.ToTable("Investment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.LastPaymentTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.CampaignPackage)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.CampaignPackageId)
                    .HasConstraintName("FK_Investment_CampaignPackage");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Investment_Investor");
            });

            modelBuilder.Entity<InvestmentDetail>(entity =>
            {
                entity.ToTable("InvestmentDetail");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.ToTable("Investor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Bank).HasMaxLength(100);

                entity.Property(e => e.BanksAccount).HasMaxLength(30);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IdCard).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Investors)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Investor_Users");
            });

            modelBuilder.Entity<InvestorLocation>(entity =>
            {
                entity.HasKey(e => new { e.InvestorId, e.LocationId });

                entity.ToTable("InvestorLocation");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.InvestorLocations)
                    .HasForeignKey(d => d.InvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestorLocation_Investor");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Ward).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_Location_Campaign");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.InvestorId)
                    .HasConstraintName("FK_Location_Investor");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_News_Campaign");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.PaymentType).HasMaxLength(250);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<PeriodRevenue>(entity =>
            {
                entity.ToTable("PeriodRevenue");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MonthRevenue).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.PeriodRevenues)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_PeriodRevenue_Campaign");
            });

            modelBuilder.Entity<PeriodRevenueComment>(entity =>
            {
                entity.ToTable("PeriodRevenueComment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<QnA>(entity =>
            {
                entity.ToTable("QnA");

                entity.Property(e => e.AnsweredAt).HasColumnType("datetime");

                entity.Property(e => e.AnsweredBy).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Risk>(entity =>
            {
                entity.ToTable("Risk");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RiskType).HasMaxLength(50);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);
            });

            modelBuilder.Entity<SharingPeriod>(entity =>
            {
                entity.ToTable("SharingPeriod");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FromMonth).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.ToMonth).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.SharingPeriods)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_SharingPeriod_Campaign");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.TransactionType).HasMaxLength(250);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Transactions_Payment");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
