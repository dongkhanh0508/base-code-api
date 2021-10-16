using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
    }

    public class CampaignRepository : RepositoryBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}