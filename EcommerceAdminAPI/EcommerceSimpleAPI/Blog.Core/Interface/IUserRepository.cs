using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Interface
{
    public interface IUserRepository : IRepository<User> 
    {
    }
}
