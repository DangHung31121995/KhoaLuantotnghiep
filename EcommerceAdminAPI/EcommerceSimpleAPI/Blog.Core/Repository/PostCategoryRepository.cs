using Ecommerce.Core.Interface;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;

namespace Ecommerce.Core.Repository
{
    public class PostCategoryRepository : Repository<PostCategory>, IPostCagegoryRepository
    {
        public PostCategoryRepository(EcommerceDbContext context) : base(context)
        {
        }
        

    }
}