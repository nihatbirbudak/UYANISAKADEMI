using System;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Complaint : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
