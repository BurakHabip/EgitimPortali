using AutoMapper;
using EgitimPortali.Models;
using EgitimPortali.ViewModels;

namespace EgitimPortali.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
