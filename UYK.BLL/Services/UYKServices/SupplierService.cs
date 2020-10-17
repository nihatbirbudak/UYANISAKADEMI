using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UYK.BLL.Services.Abstract;
using UYK.Core.Data.UnitOfWork;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.BLL.Services.UYKServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitofWork uow;
        public SupplierService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Supplier" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Supplier>().Get(z => z.Id == entityId);
                uow.GetRepository<Supplier>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Supplier" entity in database
        /// </summary>
        /// <returns>Its return SupplierDTO list</returns>
        public List<SupplierDTO> getAll()
        {
            var sList = uow.GetRepository<Supplier>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<SupplierDTO>>(sList);
        }

        /// <summary>
        /// It bring to "Supplier" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return SupplierDTO</returns>
        public SupplierDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Supplier>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<SupplierDTO>(select);
        }

        /// <summary>
        /// Empty
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<SupplierDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Its save to new "Supplier" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new SupplierDTO entity</param>
        /// <returns>Its return SupplierDTO or null</returns>
        public SupplierDTO newEntity(SupplierDTO entity)
        {
            if (!uow.GetRepository<Supplier>().GetAll().Any(z=> z.CompanyName == entity.CompanyName))
            {
                var added = MapperFactory.CurrentMapper.Map<Supplier>(entity);
                added = uow.GetRepository<Supplier>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SupplierDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Supplier entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a color entity will be update.</param>
        /// <returns>Its return SupplierDTO</returns>
        public SupplierDTO updateEntity(SupplierDTO entity)
        {
            var update = uow.GetRepository<Supplier>().Get(z => z.Id == entity.ID);
            update = MapperFactory.CurrentMapper.Map<Supplier>(entity);
            uow.GetRepository<Supplier>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SupplierDTO>(update);
        }
    }
}
