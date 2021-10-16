using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IFeeRepository : IRepository<Fee>
    {
    }

    public class FeeRepository : RepositoryBase<Fee>, IFeeRepository
    {
        public FeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}