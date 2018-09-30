using Ecommerce.Core.Interface;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;

namespace Ecommerce.Core.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EcommerceDbContext context) : base(context)
        {

        }
    }
}