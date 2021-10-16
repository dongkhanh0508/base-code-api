using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;

namespace Unikrowd.Data.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }

    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}