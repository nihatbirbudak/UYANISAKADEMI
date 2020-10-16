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
    public class OrderedService : IOrderedService
    {
        private readonly IUnitofWork uow;
        public OrderedService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Ordered" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var select = uow.GetRepository<Ordered>().Get(z => z.Id == entityId);
                uow.GetRepository<Ordered>().Delete(select);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Ordered" entity in database
        /// </summary>
        /// <returns>Its return OrderedDTO list</returns>
        public List<OrderedDTO> getAll()
        {
            var selectList = uow.GetRepository<Ordered>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<OrderedDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Ordered" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return OrderedDTO</returns>
        public OrderedDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Ordered>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<OrderedDTO>(select);
        }

        /// <summary>
        /// Empty
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<OrderedDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Its save to new "Ordered" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new OrderedDTO entity</param>
        /// <returns>Its return OrderedDTO or null</returns>
        public OrderedDTO newEntity(OrderedDTO entity)
        {
            if (!uow.GetRepository<Ordered>().GetAll().Any(z=> z.OrderNumber == entity.OrderNumber))
            {
                var added = MapperFactory.CurrentMapper.Map<Ordered>(entity);
                added = uow.GetRepository<Ordered>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<OrderedDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Ordered entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a Ordered entity will be update.</param>
        /// <returns>Its return OrderedDTO</returns>
        public OrderedDTO updateEntity(OrderedDTO entity)
        {
            var selected = uow.GetRepository<Ordered>().Get(z => z.Id == entity.ID);
            selected = MapperFactory.CurrentMapper.Map<Ordered>(entity);
            uow.GetRepository<Ordered>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderedDTO>(selected);
        }
    }
}
