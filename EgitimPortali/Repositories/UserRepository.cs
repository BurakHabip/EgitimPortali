using EgitimPortali.Models;

namespace EgitimPortali.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

    }
}
