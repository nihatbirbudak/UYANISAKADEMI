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
    public class ShipperService : IShipperService
    {
        private readonly IUnitofWork uow;
        public ShipperService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Shipper" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Shipper>().Get(z => z.Id == entityId);
                uow.GetRepository<Shipper>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Shipper" entity in database
        /// </summary>
        /// <returns>Its return ShipperDTO list</returns>
        public List<ShipperDTO> getAll()
        {
            var selectList = uow.GetRepository<Shipper>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<ShipperDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Shipper" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return ShipperDTO</returns>
        public ShipperDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Shipper>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<ShipperDTO>(select);
        }

        /// <summary>
        /// It bring to "Shipper" entity according to the companyName you give.
        /// </summary>
        /// <param name="entityName">Enter the companyName</param>
        /// <returns>Its return ShipperDTO list</returns>
        public List<ShipperDTO> getEntityName(string companyName)
        {
            var selectList = uow.GetRepository<Shipper>().Get(z => z.CompanyName == companyName);
            return MapperFactory.CurrentMapper.Map<List<ShipperDTO>>(selectList);
        }

        /// <summary>
        /// Its save to new "Shipper" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new ShipperDTO entity</param>
        /// <returns>Its return ShipperDTO or null</returns>
        public ShipperDTO newEntity(ShipperDTO entity)
        {
            if (!uow.GetRepository<Shipper>().GetAll().Any(z => z.CompanyName == entity.CompanyName))
            {
                var added = MapperFactory.CurrentMapper.Map<Shipper>(entity);
                added = uow.GetRepository<Shipper>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ShipperDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Shipper entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a color entity will be update.</param>
        /// <returns>Its return ShipperDTO</returns>
        public ShipperDTO updateEntity(ShipperDTO entity)
        {
            var update = uow.GetRepository<Shipper>().Get(z => z.Id == entity.ID);
            update = MapperFactory.CurrentMapper.Map<Shipper>(entity);
            uow.GetRepository<Shipper>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ShipperDTO>(update);
        }
    }
}
