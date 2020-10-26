using System;
using System.Collections.Generic;
using System.Linq;
using UYK.BLL.Services.Abstract;
using UYK.Core.Data.Repositories;
using UYK.Core.Data.UnitOfWork;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.BLL.Services.UYKServices
{
    public class CourseCategoryTypeService :  ICourseCategoryTypeService
    {
        private readonly IUnitofWork uow;
        public CourseCategoryTypeService(IUnitofWork uow) => this.uow = uow;
        private IRepository<CourseCategoryType> getRepo(IUnitofWork uow) => uow.GetRepository<CourseCategoryType>();
        private void SaveChanges(IUnitofWork uow) => uow.SaveChanges();
        private CourseCategoryTypeDTO mapDTO(CourseCategoryType main) => MapperFactory.CurrentMapper.Map<CourseCategoryTypeDTO>(main);
        private List<CourseCategoryTypeDTO> mapDTO(List<CourseCategoryType> main) => MapperFactory.CurrentMapper.Map<List<CourseCategoryTypeDTO>>(main);
        private CourseCategoryType map(CourseCategoryTypeDTO dto) => MapperFactory.CurrentMapper.Map<CourseCategoryType>(dto);
        private List<CourseCategoryType> map(List<CourseCategoryTypeDTO> dto) => MapperFactory.CurrentMapper.Map<List<CourseCategoryType>>(dto);

        public List<CourseCategoryTypeDTO> getAll()
        {
            return mapDTO(getRepo(uow).GetAll().ToList());
        }
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = getRepo(uow).Get(z => z.Id == entityId);
                getRepo(uow).Delete(deleted);
                SaveChanges(uow);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public CourseCategoryTypeDTO getEntity(int entityId)
        {
            return mapDTO(getRepo(uow).Get(z => z.Id == entityId));
        }

        public List<CourseCategoryTypeDTO> getEntityName(string entityName)
        {
            throw new System.NotImplementedException();
        }



        public CourseCategoryTypeDTO updateEntity(CourseCategoryTypeDTO entity)
        {
            var update = getRepo(uow).Get(z => z.Id == entity.Id);
            update = map(entity);
            getRepo(uow).Update(update);
            SaveChanges(uow);
            return mapDTO(update);
        }
        public CourseCategoryTypeDTO newEntity(CourseCategoryTypeDTO entity)
        {
            if (!getRepo(uow).GetAll().Any(z => z.CategoryName == entity.CategoryName))
            {
                var added = map(entity);
                added = getRepo(uow).Add(added);
                SaveChanges(uow);
                return mapDTO(added);
            }
            else
            {
                return entity;
            }
        }


    }
}
