using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface ICampaignPackageRepository : IRepository<CampaignPackage>
    {
    }

    public class CampaignPackageRepository : RepositoryBase<CampaignPackage>, ICampaignPackageRepository
    {
        public CampaignPackageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}