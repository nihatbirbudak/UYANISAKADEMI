using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UYK.DTO
{
    public class ContactDTO
    {
        public int ID { get; set; }
        [Display(Name ="Adres",Prompt ="Şiket Adresini Girin")]
        public string Address { get; set; }
        [Display(Name = "Ülke", Prompt = "Şirketin Bulunduğu Ülkeyi Girin")]
        public string Country { get; set; }
        [Display(Name = "Şehir", Prompt = "Şiketin Bulunduğu Şehri Girin")]
        public string City { get; set; }
        [Display(Name = "Telefon", Prompt = "Şiketin Telefonunu Girin")]
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        [Display(Name = "E-Mail", Prompt = "Şiketin Mail Aderesini Girin")]
        public string EmailInfo { get; set; }
    }
}
