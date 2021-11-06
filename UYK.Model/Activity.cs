using System;
using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Activity : Entity<int>
    {
        public DateTime? StartTime { get; set; }
        public string StartClock { get; set; }
        public DateTime? EndTime { get; set; }
        public string EndClock { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? EndIssue { get; set; }
        public string Location { get; set; }
        public bool IsCertified { get; set; }
        public string Tags { get; set; }

        public int CustomerId { get; set; }
        public int CourseId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Course Course { get; set; }
        public virtual Product Product { get; set; }

    }
}
