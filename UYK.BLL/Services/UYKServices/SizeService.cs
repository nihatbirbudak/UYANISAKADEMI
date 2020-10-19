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
    public class SizeService : ISizeService
    {
        private readonly IUnitofWork uow;
        public SizeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Size" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Size>().Get(z => z.Id == entityId);
                uow.GetRepository<Size>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Size" entity in database
        /// </summary>
        /// <returns>Its return SizeDTO list</returns>
        public List<SizeDTO> getAll()
        {
            var selectList = uow.GetRepository<Size>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<SizeDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Size" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return SizeDTO</returns>
        public SizeDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Size>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<SizeDTO>(select);
        }

        /// <summary>
        /// Empty
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<SizeDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Its save to new "Size" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new SizeDTO entity</param>
        /// <returns>Its return SizeDTO or null</returns>
        public SizeDTO newEntity(SizeDTO entity)
        {
            if (!uow.GetRepository<Size>().GetAll().Any(z=> z.SizeValue == entity.SizeValue))
            {
                var added = MapperFactory.CurrentMapper.Map<Size>(entity);
                added = uow.GetRepository<Size>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SizeDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Size entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a color entity will be update.</param>
        /// <returns>Its return SizeDTO</returns>
        public SizeDTO updateEntity(SizeDTO entity)
        {
            var update = uow.GetRepository<Size>().Get(z => z.Id == entity.ID);
            update = MapperFactory.CurrentMapper.Map<Size>(entity);
            uow.GetRepository<Size>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SizeDTO>(update);
        }
    }
}
