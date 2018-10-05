using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ecommerce.Infrastructure.Enums;
//using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Infrastructure.Attribute
{
    //public class HandelException: ExceptionFilterAttribute
    //{
    //    public override void OnException(ExceptionContext context)
    //    {
    //        var serviceProvider = context.HttpContext.RequestServices;
    //        var auditService = serviceProvider.GetService<IAuditService>();
    //        auditService.WriteLogAsync(new AuditViewModel
    //        {
    //            Content = $"{context.Exception.Message} {context.Exception.StackTrace}",
    //            CreatedDate = DateTime.Now,
    //            LastModifiedDate = DateTime.Now,
    //            Level = AuditLevel.Exception.ToString()
    //        }, CancellationToken.None);

    //        context.Result = new JsonResult(new
    //        {
    //            Status = false,
    //            Message = Constants.Messages.ExceptionNotification
    //        });

    //        context.ExceptionHandled = true;
    //    }
    //}
}
