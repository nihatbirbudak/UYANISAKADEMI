using System.Collections.Generic;

namespace UYK.Core.Services
{
    public interface IServiceBase<T> 
    {
        List<T> getAll();
        T getEntity(int entityId);
        List<T> getEntityName(string entityName);
        T newEntity(T entity);
        T updateEntity(T entity);
        bool deleteEntity(int entityId);
    }
}
