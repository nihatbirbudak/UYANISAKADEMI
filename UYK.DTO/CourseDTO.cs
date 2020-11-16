using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UYK.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        [Display(Name ="Kurs Adı")]
        public string CourseName { get; set; }
        [Display(Name ="Kurs Başlığı")]
        public string CourseTitle { get; set; }
        [Display(Name = "Ana Gövde İcerikler")]
        public string CourseMainContent { get; set; }
        [Display(Name = "Kursun İceriği")]
        public string CourseContent { get; set; }
        [Display(Name = "Kimin İçin Acıklama Kısmı")]
        public string CourseForWho { get; set; }
        [Display(Name = "Kursun Hedefleri")]
        public string CourseTarget { get; set; }
        [Display(Name = "Kursun Alt Başlıkları")]
        public string CourseSubjects { get; set; }
        [Display(Name = "Son Güncelleme")]
        public DateTime UpdateTime { get; set; }
        [Display(Name = "Yayında mı?")]
        public bool IsApply { get; set; }

        [Display(Name ="Kurs Sınıfı")]
        public List<ClassTypeDTO> ClassTypeDTOs { get; set; }

        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }

        [Display(Name = "Kurs Kategorisi")]
        public int CourseCategoryTypeId { get; set; }
        public CourseCategoryTypeDTO CourseCategoryTypeDTO { get; set; }
    }
}
