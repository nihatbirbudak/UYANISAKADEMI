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
    public class PaymentService : IPaymentService
    {
        private readonly IUnitofWork uow;
        public PaymentService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Payment" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Payment>().Get(z => z.Id == entityId);
                uow.GetRepository<Payment>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Payment" entity in database
        /// </summary>
        /// <returns>Its return PaymentDTO list</returns>
        public List<PaymentDTO> getAll()
        {
            var select = uow.GetRepository<Payment>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<PaymentDTO>>(select);
        }

        /// <summary>
        /// It bring to "Payment" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return PaymentDTO</returns>
        public PaymentDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Payment>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<PaymentDTO>(select);
        }

        /// <summary>
        /// It bring to "Payment" entity according to the paymentType you give.
        /// </summary>
        /// <param name="entityName">Enter the paymentType</param>
        /// <returns>Its return PaymentDTO list</returns>
        public List<PaymentDTO> getEntityName(string paymentType)
        {
            var selectList = uow.GetRepository<Payment>().Get(z => z.PaymentType == paymentType);
            return MapperFactory.CurrentMapper.Map<List<PaymentDTO>>(selectList);
        }

        /// <summary>
        /// Its save to new "Payment" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new PaymentDTO entity</param>
        /// <returns>Its return PaymentDTO or null</returns>
        public PaymentDTO newEntity(PaymentDTO entity)
        {
            if (!uow.GetRepository<Payment>().GetAll().Any(z=> z.PaymentType == entity.PaymentType))
            {
                var added = MapperFactory.CurrentMapper.Map<Payment>(entity);
                added = uow.GetRepository<Payment>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<PaymentDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Payment entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a Payment entity will be update.</param>
        /// <returns>Its return PaymentDTO</returns>
        public PaymentDTO updateEntity(PaymentDTO entity)
        {
            var selected = uow.GetRepository<Payment>().Get(z => z.Id == entity.ID);
            selected = MapperFactory.CurrentMapper.Map<Payment>(entity);
            uow.GetRepository<Payment>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<PaymentDTO>(selected);
        }
    }
}
