using System;
using Unikrowd.Data.Context;

namespace Unikrowd.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        UnikrowdContext Init();
    }
}