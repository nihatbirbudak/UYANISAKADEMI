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
    public class ClassTypeService : IClassTypeService
    {
        private readonly IUnitofWork uow;
        public ClassTypeService(IUnitofWork uow) => this.uow = uow;
        private IRepository<ClassType> getRepo() => uow.GetRepository<ClassType>();
        private ClassTypeDTO mapDTO(ClassType main) => MapperFactory.CurrentMapper.Map<ClassTypeDTO>(main);
        private List<ClassTypeDTO> mapDTO(List<ClassType> main) => MapperFactory.CurrentMapper.Map<List<ClassTypeDTO>>(main);
        private ClassType map(ClassTypeDTO dto) => MapperFactory.CurrentMapper.Map<ClassType>(dto);
        private List<ClassType> map(List<ClassTypeDTO> dto) => MapperFactory.CurrentMapper.Map<List<ClassType>>(dto);


        public bool deleteEntity(int entityId)
        {
            try
            {
                var select = uow.GetRepository<ClassType>().Get(z => z.Id == entityId);
                uow.GetRepository<ClassType>().Delete(select);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ClassTypeDTO> getAll()
        {
            var sList = uow.GetRepository<ClassType>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ClassTypeDTO>>(sList);
        }

        public ClassTypeDTO getEntity(int entityId)
        {
            return mapDTO(getRepo().Get(z => z.Id == entityId));
        }

        public List<ClassTypeDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public ClassTypeDTO newEntity(ClassTypeDTO entity)
        {
            if (!getRepo().GetAll().Any(z => z.ClassName == entity.ClassName))
            {
                var added = getRepo().Add(map(entity));
                uow.SaveChanges();
                return mapDTO(added);
            }
            else
            {
                return null;
            }
        }

        public ClassTypeDTO updateEntity(ClassTypeDTO entity)
        {
            var update = getRepo().Get(z => z.Id == entity.Id);
            update = map(entity);
            getRepo().Update(update);
            uow.SaveChanges();
            return mapDTO(update);
        }

        public Dictionary<int, int> getClassCount()
        {
            var list = uow.GetRepository<ClassType>().Get(null, z => z.CourseClassTpyes, null, null, null);
            if (!list.Count().Equals(0))
            {
                var listD = list.ToDictionary(z => z.Id, y => y.CourseClassTpyes.Count());
                return listD;
            }
            return null;
        }
        public bool deleteClass(int id)
        {
            try
            {
                var list = uow.GetRepository<CourseClassTpye>().GetAll();
                foreach (var item in list)
                {
                    if (item.CourseId.Equals(id))
                    {
                        uow.GetRepository<CourseClassTpye>().Delete(item);
                        uow.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteCourseClassTypeId(int id)
        {
            try
            {
                var list = uow.GetRepository<CourseClassTpye>().GetAll();
                foreach (var item in list)
                {
                    if (item.Id.Equals(id))
                    {
                        uow.GetRepository<CourseClassTpye>().Delete(item);
                        uow.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool whileChangeClasstype(CourseDTO courseDTO)
        {
            try
            {
                var course = uow.GetRepository<Course>().Get(z => z.Id == courseDTO.Id, z => z.CourseClassTpyes).FirstOrDefault();
                foreach (var classTpye in course.CourseClassTpyes)
                {
                    deleteCourseClassTypeId(classTpye.Id);
                }
                foreach (var classType in courseDTO.ClassTypeDTOs)
                {
                    uow.GetRepository<CourseClassTpye>().Add(new CourseClassTpye { ClassTypeId = MapperFactory.CurrentMapper.Map<ClassType>(classType).Id, CourseId = MapperFactory.CurrentMapper.Map<Course>(courseDTO).Id });
                    uow.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

}
