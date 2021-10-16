using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IIndustryRepository : IRepository<Industry>
    {
    }

    public class IndustryRepository : RepositoryBase<Industry>, IIndustryRepository
    {
        public IndustryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}