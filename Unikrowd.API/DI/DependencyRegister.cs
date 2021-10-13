using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikrowd.Bussiness.Services;
using Unikrowd.Data.Context;
using Unikrowd.Data.Infrastructure;
using Unikrowd.Data.Repositories;

namespace Unikrowd.API.DI
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();

            builder.RegisterType<UnikrowdContext>().AsSelf().InstancePerLifetimeScope();

            /*builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerRequest();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();*/


            // Repositories
            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Services
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();
            //base.Load(builder);
        }
    }
}
