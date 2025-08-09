using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string KullaniciAdi { get; set; }    

        [Required,MaxLength(50)]
        public string Soyad { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }   

        public string Rol {  get; set; }




    }
}













