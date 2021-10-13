using Unikrowd.Data.Context;

namespace Unikrowd.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private UnikrowdContext dbContext;

        public UnikrowdContext Init()
        {
            return dbContext ??= new UnikrowdContext();
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}