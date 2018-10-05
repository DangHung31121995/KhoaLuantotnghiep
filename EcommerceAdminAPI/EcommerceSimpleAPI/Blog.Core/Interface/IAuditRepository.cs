using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;

namespace Ecommerce.Service.Interface
{
    public interface IAuditRepository:IRepository<Audit>
    {
        //Task<ModelListResult<Audit>> GetAsync(AuditQuery query, CancellationToken token);
        //new Task<string> AddAsync(Audit item, CancellationToken cancellationToken);
        //Task<string> DeletePermanentAsync(string id, CancellationToken token);
    }
}
