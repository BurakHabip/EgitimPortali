using System.ComponentModel.DataAnnotations;

namespace EgitimPortali.ViewModels
{
    public class LessonModel
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Ders Adı Giriniz!")]
        public string Name { get; set; }



        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}
