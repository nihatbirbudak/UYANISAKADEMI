using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UYK.BLL.Services.Abstract;
using UYK.Core.Data.UnitOfWork;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.BLL.Services.UYKServices
{
    public class CourseService : ICourseService
    {
        private readonly IUnitofWork uow;
        public CourseService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        #region Base Class
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Course>().Get(z => z.Id == entityId);
                uow.GetRepository<Course>().Delete(deleted);
                uow.SaveChanges();
                return true;

    }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CourseDTO> getAll()
        {
            var sList = uow.GetRepository<Course>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CourseDTO>>(sList);
        }

        public CourseDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Course>().Get(z => z.Id == entityId,i => i.CourseClassTpyes,null);
            var select1 = uow.GetRepository<Course>().Get(z => z.Id == entityId);
            var mapped = MapperFactory.CurrentMapper.Map<CourseDTO>(select1);
            mapped.ClassTypeDTOs = new List<ClassTypeDTO>();
            
            foreach (var i in select.FirstOrDefault().CourseClassTpyes)
            {
                var a = uow.GetRepository<ClassType>().Get(z => z.Id == i.Id);
                var mapa = MapperFactory.CurrentMapper.Map<ClassTypeDTO>(a);
                mapped.ClassTypeDTOs.Add(mapa);
            }
            return mapped;
        }

        public List<CourseDTO> getEntityName(string courseName)
        {
            var select = uow.GetRepository<Course>().Get(z => z.CourseName == courseName);
            return MapperFactory.CurrentMapper.Map<List<CourseDTO>>(select);
        }

        public CourseDTO newEntity(CourseDTO entity)
        {
            if (!uow.GetRepository<Course>().GetAll().Any(z => z.CourseName == entity.CourseName))
            {
                var added = MapperFactory.CurrentMapper.Map<Course>(entity);
                var cct = new List<CourseClassTpye>();
                foreach (var classType in entity.ClassTypeDTOs)
                {
                    cct.Add(new CourseClassTpye { ClassTypeId = MapperFactory.CurrentMapper.Map<ClassType>(classType).Id, CourseId = MapperFactory.CurrentMapper.Map<Course>(entity).Id });
                }
                added.CourseClassTpyes = cct;
                added = uow.GetRepository<Course>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CourseDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public CourseDTO updateEntity(CourseDTO entity)
        {
            var updated = uow.GetRepository<Course>().Get(z => z.Id.Equals(entity.Id));
            updated = MapperFactory.CurrentMapper.Map<Course>(entity);
            uow.GetRepository<Course>().Update(updated);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CourseDTO>(updated);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<int,IEnumerable<int>> getCategoryCount()
        {
            var list = uow.GetRepository<Course>().GetAll().ToList();
            if (list.Count() != 0)
            {
                var list2 = list.GroupBy(z => z.CourseCategoryTypeId);
                var list3 = list2.ToDictionary(y => y.Key, y => y.Select(z => z.CourseCategoryTypeId));
                return list3;
            }
            return null;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public Dictionary<int,IEnumerable<int>> getClassCount()
        //{
        //    var list = uow.GetRepository<Course>().Get(null, z => z.CourseClassTpyes, null, null, null);
        //    if (!list.Count().Equals(0))
        //    {
        //        var list2 = list.GroupBy(z => z.CourseClassTpyes );
        //        var list3 = list2.ToDictionary(z => z.Key., z => z.Select(y => y.CourseClassTpyes));
        //        return list;
        //    }
        //    return null;
        //}
        
    }
}
