using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Attribute;
using Ecommerce.Infrastructure.Enums;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Service
{
    public class AuditService : IAuditService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Audit> _repository;
        public AuditService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Audit>();
        }
        public async Task<GeneralResponse> WriteLogAsync(AuditViewModel item, CancellationToken token = default(CancellationToken))
        {
            if (!item.IsValid())
            {
                return new GeneralResponse
                {
                    Success = false,
                    Id = item.Id,
                    Messages = item.Validations
                };
            }

             await _repository.InsertAsync(new AuditViewModel().Map(item), token);

            var result = new GeneralResponse
            {
                Success = true,
                Messages = new List<ResponseMessage>(
                    new List<ResponseMessage>
                    {
                        new ResponseMessage
                        {
                            Status = QueryStatus.Success,
                            Key = "WriteLogAsync",
                            Message = Constants.Messages.CreatedSuccess
                        }
                    })
            };

            return result;
        }
    }
}
