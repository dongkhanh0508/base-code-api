using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
    }

    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}