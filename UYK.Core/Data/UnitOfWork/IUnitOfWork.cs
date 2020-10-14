using UYK.Core.Entities;
using UYK.Core.Data.Repositories;

namespace UYK.Core.Data.UnitOfWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}
