using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Services;
using UYK.DTO;

namespace UYK.BLL.Services.Abstract
{
    public interface ICustomerService : IServiceBase<CustomerDTO>
    {
        CustomerDTO FindwithUsernameandMail(string mailorUserName, string Password);
        List<CustomerDTO> getAllUserinRole(int CustomerId);
        void changeRememberMe(CustomerDTO customerDTO);
    }
}
