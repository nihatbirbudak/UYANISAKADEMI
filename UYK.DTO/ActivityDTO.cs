using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UYK.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        [Display(Name = "Eğitim Başlanğıç Tarihi")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "Eğitim Başlangıç Saati")]
        public string StartClock { get; set; }
        [Display(Name = "Eğitim Bitiş Tarihi")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "Eğitim Bitiş Saati")]
        public string EndClock { get; set; }
        [Display(Name = "Yayın Tarihi")]
        public DateTime? IssueDate { get; set; }
        [Display(Name = "Yayın Bitiş Tarihi")]
        public DateTime? EndIssue { get; set; }
        [Display(Name = "Konum")]
        public string Location { get; set; }
        [Display(Name = "Sertifikalı mı?")]
        public bool IsCertified { get; set; }
        [Display(Name = "Etike")]
        public string Tags { get; set; }

        public int CustomerId { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Eğitmen")]
        public virtual CustomerDTO CustomerDTO { get; set; }
        public virtual CourseDTO CourseDTO { get; set; }
        public virtual ProductDTO ProductDTO { get; set; }
    }
}
