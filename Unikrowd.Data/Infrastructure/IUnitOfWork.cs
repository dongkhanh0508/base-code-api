using System.Threading.Tasks;

namespace Unikrowd.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}