using System.ComponentModel.DataAnnotations;

namespace EgitimPortali.Models
{
    public class Education : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }


        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }




    }
}
