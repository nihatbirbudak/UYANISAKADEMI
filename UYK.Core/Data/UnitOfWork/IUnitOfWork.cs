using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Data.Repositories;
using UYK.Core.Entities;

namespace UYK.Core.Data.UnitOfWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}
