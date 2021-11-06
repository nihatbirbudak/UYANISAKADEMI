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
    public class ComplaintService : IComplaintService
    {
        private readonly IUnitofWork uow;
        public ComplaintService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// It delete the "Complaint" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd, will be delete</param>
        /// <returns>Its will return True or False</returns>
        public bool deleteEntity(int entityId)
        {
            try
            {
                var selected = uow.GetRepository<Complaint>().Get(z => z.Id == entityId);
                uow.GetRepository<Complaint>().Delete(selected);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// It get all "Complaint" entity in database
        /// </summary>
        /// <returns>Its return ComplaintDTO list</returns>
        public List<ComplaintDTO> getAll()
        {
            var list = uow.GetRepository<Complaint>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ComplaintDTO>>(list);
        }

        /// <summary>
        /// It bring to "Complaint" entity according to the entity ıd you give.
        /// </summary>
        /// <param name="entityId">Give a entity ıd</param>
        /// <returns>Its return ComplaintDTO</returns>
        public ComplaintDTO getEntity(int entityId)
        {
            var select = uow.GetRepository<Complaint>().Get(z => z.Id == entityId);
            return MapperFactory.CurrentMapper.Map<ComplaintDTO>(select);
        }

        /// <summary>
        /// It bring to "Complaint" entity according to the colorValue you give.
        /// </summary>
        /// <param name="entityName">Enter the complaintTitle</param>
        /// <returns>Its return ComplaintDTO list</returns>
        public List<ComplaintDTO> getEntityName(string complaintTitle)
        {
            var select = uow.GetRepository<Complaint>().Get(z => z.Title == complaintTitle);
            return MapperFactory.CurrentMapper.Map<List<ComplaintDTO>>(select);
        }

        /// <summary>
        /// Its save to new "Complaint" entity if have not database.
        /// </summary>
        /// <param name="entity">Enter new ComplaintDTO entity</param>
        /// <returns>Its return ComplaintDTO or null</returns>
        public ComplaintDTO newEntity(ComplaintDTO entity)
        {
            if (!uow.GetRepository<Complaint>().GetAll().Any(z=> z.Title == entity.Title && z.CustomerId == entity.CustomerId))
            {
                var added = MapperFactory.CurrentMapper.Map<Complaint>(entity);
                added = uow.GetRepository<Complaint>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ComplaintDTO>(added);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// It update to Complaint entity according to the entity you give.
        /// </summary>
        /// <param name="entity">Give a Complaint entity will be update.</param>
        /// <returns>Its return ComplaintDTO</returns>
        public ComplaintDTO updateEntity(ComplaintDTO entity)
        {
            var select = uow.GetRepository<Complaint>().Get(z => z.Id == entity.ID);
            select = MapperFactory.CurrentMapper.Map<Complaint>(entity);
            uow.GetRepository<Complaint>().Update(select);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ComplaintDTO>(select);
        }
    }
}
