using AutoMapper;
using EgitimPortali.Models;
using EgitimPortali.ViewModels;

namespace EgitimPortali.Repositories
{
    public class EducationRepository : GenericRepository<Education>
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
