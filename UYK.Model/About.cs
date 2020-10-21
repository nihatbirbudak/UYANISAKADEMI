using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class About : Entity<int>
    {
        public string ContentTitle { get; set; }
        public string Content { get; set; }
        public string Content2Title { get; set; }
        public string Content2 { get; set; }
        public string Image { get; set; }


        public DateTime UpdateDate { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
