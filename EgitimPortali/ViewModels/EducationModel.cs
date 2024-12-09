using System.ComponentModel.DataAnnotations;

namespace EgitimPortali.ViewModels
{
    public class EducationModel
    {
        public int Id { get; set; }


        [Display(Name = "Eğitim Adı")]
        [Required(ErrorMessage = "Eğitim Adı Giriniz!")]
        public string Name { get; set; }


        [Display(Name = "Eğitim Açıklaması")]
        [Required(ErrorMessage = "Eğitim Açıklaması Giriniz!")]
        public string Description { get; set; }

        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        [Display(Name = "Ders")]
        [Required(ErrorMessage = "Ders Giriniz!")]
        public int LessonId { get; set; }

   

    }
}
