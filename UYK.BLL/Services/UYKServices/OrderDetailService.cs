using System;
using System.Collections.Generic;
using System.Linq;
using UYK.BLL.Services.Abstract;
using UYK.Core.Data.UnitOfWork;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.BLL.Services.UYKServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitofWork uow;
        public OrderDetailService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "OrderDetail" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var select = uow.GetRepository<OrderDetail>().Get(z => z.Id == entityId);
                uow.GetRepository<OrderDetail>().Delete(select);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "OrderDetail" entity in database
        /// </summary>
        /// <returns>Its return OrderDetailDTO list</returns>
        public List<OrderDetailDTO> getAll()
        {
            var select = uow.GetRepository<OrderDetail>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<OrderDetailDTO>>(select);
        }

        /// <summary>
        /// It bring to "OrderDetail" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return OrderDetailDTO</returns>
        public OrderDetailDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<OrderDetail>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(select);
        }

        /// <summary>
        /// Empty
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<OrderDetailDTO> getEntityName(string orderNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Its save to new "OrderDetail" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new OrderDetailDTO entity</param>
        /// <returns>Its return OrderDetailDTO or null</returns>
        public OrderDetailDTO newEntity(OrderDetailDTO entity)
        {
            if (!uow.GetRepository<OrderDetail>().GetAll().Any(z=> z.OrderNumber == entity.OrderNumber))
            {
                var select = MapperFactory.CurrentMapper.Map<OrderDetail>(entity);
                select = uow.GetRepository<OrderDetail>().Add(select);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(select);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to OrderDetail entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a OrderDetail entity will be update.</param>
        /// <returns>Its return OrderDetailDTO</returns>
        public OrderDetailDTO updateEntity(OrderDetailDTO entity)
        {
            var selecet = uow.GetRepository<OrderDetail>().Get(z => z.Id == entity.ID);
            selecet = MapperFactory.CurrentMapper.Map<OrderDetail>(entity);
            uow.GetRepository<OrderDetail>().Update(selecet);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(selecet);
        }
    }
}
