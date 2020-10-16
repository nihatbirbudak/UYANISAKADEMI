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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork uow;
        public CategoryService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// It Delete to "Category" Entity according to the entity ıd you give in database
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>ıt will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Category>().Get(z => z.Id == entityId);
                uow.GetRepository<Category>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method get all "Category" entities. 
        /// </summary>
        /// <returns>it will return CategoryDTO list</returns>
        public List<CategoryDTO> getAll()
        {
            var list = uow.GetRepository<Category>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CategoryDTO>>(list);
        }

        /// <summary>
        /// It bring to "category" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd will be search</param>
        /// <returns>ıt will return CategoryDTO </returns>
        public CategoryDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Category>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(select);
        }

        /// <summary>
        /// It bring to "category" entity according to the entity name you give.
        /// </summary>
        /// <param name="entityName">Give a entity name will be search</param>
        /// <returns>Its will return CategoryDTO list</returns>
        public List<CategoryDTO> getEntityName(string categoryName)
        {
            var list = uow.GetRepository<Category>().Get(z => z.CategoryName == categoryName);
            return MapperFactory.CurrentMapper.Map<List<CategoryDTO>>(list);
        }

        /// <summary>
        /// It save to new "category" entity in database
        /// </summary>
        /// <param name="entity">Give a new "Category" Entity</param>
        /// <returns>Its return a CategoryDTO or null</returns>
        public CategoryDTO newEntity(CategoryDTO entity)
        {
            if (!uow.GetRepository<Category>().GetAll().Any(z => z.CategoryName == entity.CategoryName))
            {
                var added = MapperFactory.CurrentMapper.Map<Category>(entity);
                added = uow.GetRepository<Category>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CategoryDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to category entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a Category entity will be update.</param>
        /// <returns>Its return CategoryDTO</returns>
        public CategoryDTO updateEntity(CategoryDTO entity)
        {
            var selected = uow.GetRepository<Category>().Get(z => z.Id == entity.ID);
            selected = MapperFactory.CurrentMapper.Map<Category>(entity);
            uow.GetRepository<Category>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(selected);
        }
    }
}
