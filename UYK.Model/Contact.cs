using UYK.Core.Entities;

namespace UYK.Model
{
    public class Contact : Entity<int>
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string EmailInfo { get; set; }
    }
}
