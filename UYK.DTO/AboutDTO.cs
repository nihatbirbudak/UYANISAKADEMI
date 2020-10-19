using System;

namespace UYK.DTO
{
    public class AboutDTO
    {
        public int Id { get; set; }
        public string ContentTitle { get; set; }
        public string Content { get; set; }
        public string Content2Title { get; set; }
        public string Content2 { get; set; }
        public string image { get; set; }

        public DateTime UpdateDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
    }
}
