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
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork uow;
        public RoleService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// It delete the "Role" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Role>().Get(z => z.Id == entityId);
                uow.GetRepository<Role>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Role" entity in database
        /// </summary>
        /// <returns>Its return RoleDTO list</returns>
        public List<RoleDTO> getAll()
        {
            var list = uow.GetRepository<Role>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(list);
        }

        /// <summary>
        /// It bring to "Role" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return RoleDTO</returns>
        public RoleDTO getEntity(int entityId)
        {
            var selecet = uow.GetRepository<Role>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(selecet);
        }

        /// <summary>
        /// It bring to "Role" entity according to the roleName you give.
        /// </summary>
        /// <param name="entityName">Enter the roleName</param>
        /// <returns>Its return RoleDTO list</returns>
        public List<RoleDTO> getEntityName(string roleName)
        {
            var list = uow.GetRepository<Role>().Get(z => z.RoleName == roleName);
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(list);
        }

        /// <summary>
        /// It bring to "Role" entity according to the roleName you give.
        /// </summary>
        /// <param name="entityName">Enter the roleName</param>
        /// <returns>Its return RoleDTO list</returns>
        public RoleDTO getRoleName(string roleName)
        {
            var select = uow.GetRepository<Role>().Get(z => z.RoleName == roleName);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(select);
        }

        /// <summary>
        /// Its save to new "Role" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new RoleDTO entity</param>
        /// <returns>Its return RoleDTO or null</returns>
        public RoleDTO newEntity(RoleDTO entity)
        {
            if (!uow.GetRepository<Role>().GetAll().Any(z => z.RoleName == entity.RoleName))
            {
                var added = MapperFactory.CurrentMapper.Map<Role>(entity);
                added = uow.GetRepository<Role>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Role entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a color entity will be update.</param>
        /// <returns>Its return RoleDTO</returns>
        public RoleDTO updateEntity(RoleDTO entity)
        {
            var update = uow.GetRepository<Role>().Get(z => z.Id == entity.ID);
            update = MapperFactory.CurrentMapper.Map<Role>(entity);
            uow.GetRepository<Role>().Add(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(update);
        }
    }
}
