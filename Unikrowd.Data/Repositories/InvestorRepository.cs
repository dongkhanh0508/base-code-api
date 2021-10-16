using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IInvestorRepository : IRepository<Investor>
    {
    }

    public class InvestorRepository : RepositoryBase<Investor>, IInvestorRepository
    {
        public InvestorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}