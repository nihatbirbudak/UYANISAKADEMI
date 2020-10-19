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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork uow;
        public CustomerService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        #region Base Function
            /// <summary>
            /// It delete the "Customer" entity according to the entity ıd you give.
            /// </summary>
            /// <param name="entityId">Give a entity ıd, will be delete</param>
            /// <returns>Its will return True or False</returns>
            public bool deleteEntity(int entityId)
            {
                try
                {
                    var select = uow.GetRepository<Customer>().Get(z => z.Id == entityId);
                    uow.GetRepository<Customer>().Delete(select);
                    uow.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            /// <summary>
            /// It get all "Customer" entity in database
            /// </summary>
            /// <returns>Its return CustomerDTO list</returns>
            public List<CustomerDTO> getAll()
            {
                var selectList = uow.GetRepository<Customer>().GetAll().ToList();
                return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(selectList);
            }

            /// <summary>
            /// It bring to "Customer" entity according to the entity ıd you give.
            /// </summary>
            /// <param name="entityId">Give a entity ıd</param>
            /// <returns>Its return CustomerDTO</returns>
            public CustomerDTO getEntity(int entityId)
            {
                var select = uow.GetRepository<Customer>().Get(z => z.Id == entityId);
                return MapperFactory.CurrentMapper.Map<CustomerDTO>(select);
            }

            /// <summary>
            /// It bring to "Customer" entity according to the firstName you give.
            /// </summary>
            /// <param name="entityName">Enter the firstName</param>
            /// <returns>Its return CustomerDTO list</returns>
            public List<CustomerDTO> getEntityName(string firstName)
            {
                var selectList = uow.GetRepository<Customer>().Get(z => z.FirstName == firstName);
                return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(selectList);
            }

            /// <summary>
            /// Its save to new "Customer" entity if have not database.
            /// </summary>
            /// <param name="entity">Enter new CustomerDTO entity</param>
            /// <returns>Its return CustomerDTO or null</returns>
            public CustomerDTO newEntity(CustomerDTO entity)
            {
                if (!uow.GetRepository<Customer>().GetAll().Any(z => z.Email == entity.Email))
                {
                    var select = MapperFactory.CurrentMapper.Map<Customer>(entity);
                    select = uow.GetRepository<Customer>().Add(select);
                    uow.SaveChanges();
                    return MapperFactory.CurrentMapper.Map<CustomerDTO>(select);
                }
                else
                {
                    return null;
                }
            }

            /// <summary>
            /// It update to Customer entity according to the entity you give.
            /// </summary>
            /// <param name="entity">Give a Customer entity will be update.</param>
            /// <returns>Its return CustomerDTO</returns>
            public CustomerDTO updateEntity(CustomerDTO entity)
            {
                var select = uow.GetRepository<Customer>().Get(z => z.Id == entity.ID);
                select = MapperFactory.CurrentMapper.Map<Customer>(entity);
                uow.GetRepository<Customer>().Update(select);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CustomerDTO>(select);
            }
        #endregion


        /// <summary>
        /// It bring to "Customer" entity according to the lastName you give.
        /// </summary>
        /// <param name="entityName">Enter the lastName</param>
        /// <returns>Its return CustomerDTO list</returns>
        public List<CustomerDTO> getEntityLastName(string lastName)
        {
            var selectList = uow.GetRepository<Customer>().Get(z => z.LastName == lastName);
            return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Customer" entity according to the firstName and lastName you give.
        /// </summary>
        /// <param name="entityName">Enter the firstName and lastName</param>
        /// <returns>Its return CustomerDTO list</returns>
        public List<CustomerDTO> getEntityName(string firstName, string lastName)
        {
            var selectList = uow.GetRepository<Customer>().Get(z => z.FirstName == firstName && z.LastName == lastName);
            return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(selectList);
        }

        /// <summary>
        /// It bring to "Customer" entity according to the country you give.
        /// </summary>
        /// <param name="entityName">Enter the country</param>
        /// <returns>Its return CustomerDTO list</returns>
        public List<CustomerDTO> getEntityCountry(string country)
        {
            var selectList = uow.GetRepository<Customer>().Get(z => z.Country == country);
            return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(selectList);
        }

        /// <summary>
        /// get user in db
        /// </summary>
        /// <param name="mailorUserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public CustomerDTO FindwithUsernameandMail(string mailorUserName, string Password)
        {
            var getCustomer = uow.GetRepository<Customer>().Get(z => z.Email == mailorUserName || z.UserName == mailorUserName && z.Password == Password);
            return MapperFactory.CurrentMapper.Map<CustomerDTO>(getCustomer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public List<CustomerDTO> getAllUserinRole(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public void changeRememberMe(CustomerDTO customerDTO)
        {
            
        }
    }
}
