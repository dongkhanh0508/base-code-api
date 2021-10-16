using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IBusinessRepository : IRepository<Business>
    {
    }

    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        public BusinessRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}