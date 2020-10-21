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
    public class ContactService : IContactService
    {
        private readonly IUnitofWork uow;
        public ContactService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<ContactDTO> getAll()
        {
            var sList = uow.GetRepository<Contact>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ContactDTO>>(sList);
        }

        public ContactDTO getEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<ContactDTO> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public ContactDTO newEntity(ContactDTO entity)
        {
            if (uow.GetRepository<Contact>().GetAll().Any(z=> z.Address == entity.Address))
            {
                var added = MapperFactory.CurrentMapper.Map<Contact>(entity);
                added = uow.GetRepository<Contact>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ContactDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public ContactDTO updateEntity(ContactDTO entity)
        {
            var updated = uow.GetRepository<Contact>().Get(z => z.Id == entity.ID);
            updated = MapperFactory.CurrentMapper.Map<Contact>(entity);
            uow.GetRepository<Contact>().Update(updated);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ContactDTO>(updated);
        }
    }
}
