using Ecommerce.Core.Interface;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;

namespace Ecommerce.Core.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}