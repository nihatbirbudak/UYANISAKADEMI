using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UYK.DTO
{
    public class AboutDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Başlık",Prompt ="Örn: Hakkımızda , Biz Kimiz?")]
        public string ContentTitle { get; set; }
        [Display(Name = "İcerik",Prompt ="Bu Alana Hakkımızda Kısmı İle İlgili İcerikleri Giriniz")]
        public string Content { get; set; }
        [Display(Name = "Başlık 2" , Prompt ="Örn: Neden Biz? , Eğitmenlerimiz")]
        public string Content2Title { get; set; }
        [Display(Name = "İcerik 2" , Prompt = "Bu Alana Hakkımızda Kısmı İle İlgili İcerikleri Giriniz")]
        public string Content2 { get; set; }
        [Display(Name = "Logo veya Fotograf")]
        public string Image { get; set; }

        public DateTime UpdateDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
    }
}
