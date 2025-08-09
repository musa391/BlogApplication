
 using System.ComponentModel.DataAnnotations;
namespace BlogApplication.Models

{ 
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Baslik { get; set; }

        [StringLength(200)]
        public string AltBaslik { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş bırakılamaz.")]
        public string Icerik { get; set; }

        public string Yazar { get; set; }
        [DataType(DataType.Date)]
        public DateTime YayımlanmaTarihi { get; set; }

    }
}
