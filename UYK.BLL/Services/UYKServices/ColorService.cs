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
    public class ColorService : IColorService
    {
        private readonly IUnitofWork uow;
        public ColorService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// It delete the "Color" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Color>().Get(z => z.Id == entityId);
                uow.GetRepository<Color>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Color" entity in database
        /// </summary>
        /// <returns>Its return ColorDTO list</returns>
        public List<ColorDTO> getAll()
        {
            var list = uow.GetRepository<Color>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ColorDTO>>(list);
        }

        /// <summary>
        /// It bring to "Color" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return ColorDTO</returns>
        public ColorDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Color>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<ColorDTO>(select);
        }

        /// <summary>
        /// It bring to "color" entity according to the colorValue you give.
        /// </summary>
        /// <param name="entityName">Enter the colorValue</param>
        /// <returns>Its return ColorDTO list</returns>
        public List<ColorDTO> getEntityName(string colorValue)
        {
            var list = uow.GetRepository<Color>().Get(z => z.ColorValue);
            return MapperFactory.CurrentMapper.Map<List<ColorDTO>>(list);
        }

        /// <summary>
        /// Its save to new "Color" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new ColorDTO entity</param>
        /// <returns>Its return ColorDTO or null</returns>
        public ColorDTO newEntity(ColorDTO entity)
        {
            if (!uow.GetRepository<Color>().GetAll().Any(z => z.ColorValue == entity.ColorValue))
            {
                var added = MapperFactory.CurrentMapper.Map<Color>(entity);
                added = uow.GetRepository<Color>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ColorDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to color entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a color entity will be update.</param>
        /// <returns>Its return ColorDTO</returns>
        public ColorDTO updateEntity(ColorDTO entity)
        {
            var selected = uow.GetRepository<Color>().Get(z => z.Id == entity.ID);
            selected = MapperFactory.CurrentMapper.Map<Color>(entity);
            uow.GetRepository<Color>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ColorDTO>(selected);
        }
    }
}
