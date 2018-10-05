using Ecommerce.Core.Model;
using Ecommerce.Service.Interface;
using Ecommerce.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repository
{
    public class AuditRepository : Repository<Audit>, IAuditRepository
    {
        public AuditRepository(EcommerceDbContext context) : base(context)
        {

        }
        
    }
}
