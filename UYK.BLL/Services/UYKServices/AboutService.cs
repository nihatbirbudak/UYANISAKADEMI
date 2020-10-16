using System;
using System.Collections.Generic;
using System.Linq;
using UYK.Core.Data.UnitOfWork;
using UYK.Core.Services.Abstract;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.BLL.Services.UYKServices
{
    public class AboutService : IAboutService
    {
        private readonly IUnitofWork uow;
        public AboutService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It Delete the "About" entity according to the Id you give in database. 
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns></returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var about = uow.GetRepository<About>().Get(z => z.Id == entityId);
                uow.GetRepository<About>().Delete(about);
                uow.SaveChanges();
                return true;
             }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all "About" Entity in Database
        /// </summary>
        /// <returns></returns>
        public List<AboutDTO> getAll()
        {
            var aboutList = uow.GetRepository<About>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<AboutDTO>>(aboutList);
        }

        /// <summary>
        /// It bring the "About" Entity according to the Id you give.
        /// </summary>
        /// <param name="entityId">Entity ID</param>
        /// <returns></returns>
        public AboutDTO getEntity(int entityId)
        {
            var about = uow.GetRepository<About>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<AboutDTO>(about);
        }

        /// <summary>
        /// It bring the "about" Entity according to the Title you give.
        /// </summary>
        /// <param name="entityTitle">Entity Title</param>
        /// <returns></returns>
        public List<AboutDTO> getEntityName(string entityTitle)
        {
            var abouts = uow.GetRepository<About>().Get(z => z.Title == entityTitle);
            return MapperFactory.CurrentMapper.Map<List<AboutDTO>>(abouts);
        }

        /// <summary>
        /// It Add the new "About" entity in Database
        /// </summary>
        /// <param name="entity">"About" Entity</param>
        /// <returns></returns>
        public AboutDTO newEntity(AboutDTO entity)
        {
            if (!uow.GetRepository<About>().GetAll().Any(z=> z.Title == entity.Title))
            {
                var added = MapperFactory.CurrentMapper.Map<About>(entity);
                added = uow.GetRepository<About>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<AboutDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update the "About" entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a entity will be update</param>
        /// <returns></returns>
        public AboutDTO updateEntity(AboutDTO entity)
        {
            var selected = uow.GetRepository<About>().Get(z => z.Id == entity.Id);
            selected = MapperFactory.CurrentMapper.Map<About>(entity);
            uow.GetRepository<About>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<AboutDTO>(selected);
        }
    }
}
