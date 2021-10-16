using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
    }

    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}