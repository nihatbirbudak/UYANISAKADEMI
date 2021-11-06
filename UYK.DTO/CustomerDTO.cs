using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get { return getFullName(); }
            set { }
        }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public int CardExpMo { get; set; }
        public int CardExpYr { get; set; }
        public string CreditCardTypeID { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool RememberMe { get; set; }


        public int RoleId { get; set; }

        public virtual AboutDTO AboutDTO { get; set; }
        public virtual List<ActivityDTO> ActivityDTOs { get; set; }
        public virtual List<ComplaintDTO> ComplaintsDTO { get; set; }
        public virtual List<SupplierDTO> SupplierDTO { get; set; }
        public virtual List<OrderDTO> OrdersDTO { get; set; }
        public virtual RoleDTO RoleDTO { get; set; }

        public string getFullName()
        {
            return FullName = FirstName + " " + LastName;
        }
    }
}
