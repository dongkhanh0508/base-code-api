namespace Unikrowd.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}