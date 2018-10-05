using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Infrastructure.Attribute;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Interface
{
    public interface IAuditService
    {
        Task<GeneralResponse> WriteLogAsync(AuditViewModel item, CancellationToken token = default(CancellationToken));
    }
}
