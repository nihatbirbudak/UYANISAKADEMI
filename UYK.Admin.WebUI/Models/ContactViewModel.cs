using Microsoft.AspNetCore.Http;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class ContactViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
        public ContactDTO ContactDTO { get; set; }
    }
}
