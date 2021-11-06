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
    public class ProductService : IProductService
    {
        private readonly IUnitofWork uow;
        public ProductService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        #region Base Services
        /// <summary>
        /// It delete the "Product" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Product>().Get(z => z.Id == entityId);
                uow.GetRepository<Product>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Product" entity in database
        /// </summary>
        /// <returns>Its return ProductDTO list</returns>
        public List<ProductDTO> getAll()
        {
            var selectList = uow.GetRepository<Product>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<ProductDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Product" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return ProductDTO</returns>
        public ProductDTO getEntity(int entityId)
        {
            var selecet = uow.GetRepository<Product>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<ProductDTO>(selecet);
        }

        /// <summary>
        /// It bring to "Product" entity according to the productName you give.
        /// </summary>
        /// <param name="entityName">Enter the productName</param>
        /// <returns>Its return ProductDTO list</returns>
        public List<ProductDTO> getEntityName(string productName)
        {
            var selectList = uow.GetRepository<Product>().Get(z => z.ProductName == productName);
            return MapperFactory.CurrentMapper.Map<List<ProductDTO>>(selectList);
        }

        /// <summary>
        /// Its save to new "Product" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new ProductDTO entity</param>
        /// <returns>Its return ProductDTO or null</returns>
        public ProductDTO newEntity(ProductDTO entity)
        {
            if (entity.ActivityDTO != null )
            {
                var activity = MapperFactory.CurrentMapper.Map<Activity>(entity.ActivityDTO);
                var added = MapperFactory.CurrentMapper.Map<Product>(entity);
                added.Activity = activity;
                added = uow.GetRepository<Product>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ProductDTO>(added);
            }
            else
            {
                var added = MapperFactory.CurrentMapper.Map<Product>(entity);
                added = uow.GetRepository<Product>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ProductDTO>(added);
            }
        }

        /// <summary>
        /// It update to Product entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a Product entity will be update.</param>
        /// <returns>Its return ProductDTO</returns>
        public ProductDTO updateEntity(ProductDTO entity)
        {
            var update = uow.GetRepository<Product>().Get(z => z.Id == entity.ID);
            update = MapperFactory.CurrentMapper.Map<Product>(entity);
            uow.GetRepository<Product>().Add(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ProductDTO>(update);

        } 
        #endregion
    }
}
