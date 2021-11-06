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
    public class ActivityService : IActivityService
    {
        private readonly IUnitofWork uow;
        public ActivityService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It Delete "Activity" entity according to the Id you give in database
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>"True" or "False"</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var entity = uow.GetRepository<Activity>().Get(z => z.Id == entityId);
                uow.GetRepository<Activity>().Delete(entity);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all "Activity" Entitiy in Database
        /// </summary>
        /// <returns>"ActivityDTO List"</returns>
        public List<ActivityDTO> getAll()
        {
            var list = uow.GetRepository<Activity>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ActivityDTO>>(list);
        }

        /// <summary>
        /// It bring the "Activity" entity according to the Id you give.
        /// </summary>
        /// <param name="entityId">Entity ID</param>
        /// <returns>It's return to ActivityDTO</returns>
        public ActivityDTO getEntity(int entityId)
        {
            var entity = uow.GetRepository<Activity>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<ActivityDTO>(entity);
        }

        /// <summary>
        /// It bring the "Aktivity" Entity according to the Title you give.
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns>It's return List<ActivityDTO> </returns>
        public List<ActivityDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// It add the new "Activity" entity in Database
        /// </summary>
        /// <param name="entity">"Activity" Entity</param>
        /// <returns>New ActivityDTO</returns>
        public ActivityDTO newEntity(ActivityDTO entity)
        {
            var added = MapperFactory.CurrentMapper.Map<Activity>(entity);
            added = uow.GetRepository<Activity>().Add(added);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ActivityDTO>(added); 
        }

        public ActivityDTO updateEntity(ActivityDTO entity)
        {
            var selected = uow.GetRepository<Activity>().Get(z => z.Id == entity.Id);
            selected = MapperFactory.CurrentMapper.Map<Activity>(entity);
            uow.GetRepository<Activity>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ActivityDTO>(selected);
        }
    }
}
