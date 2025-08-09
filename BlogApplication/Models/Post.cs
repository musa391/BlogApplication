using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [StringLength(200)]
        [Display(Name = "Alt Başlık")]
        public string AltBaslik { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş bırakılamaz.")]
        [Display(Name = "İçerik")]
        public string Icerik { get; set; }

        [Display(Name = "Yazar")]
        public string Yazar { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Yayımlanma Tarihi")]
        public DateTime YayımlanmaTarihi { get; set; }

        [Display(Name = "Resim URL")]
        [StringLength(250)]
        public string? ResimUrl { get; set; }

        [Display(Name = "Yayınla")]
        public bool IsPublished { get; set; }
    }
}
