using Ecommerce.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface IPostService
    {
        PagingViewModel<PostViewModel> Get(string keyword, string sortColumn, Guid? postCategoryId, bool desc = false, int pageIndex = 0, int pageSize = 15);

        Guid Add(PostViewModel post, Guid currentUserId);

        bool Update(PostViewModel post, Guid currentUserId);

        bool Delete(Guid id, Guid currentUserId);

        PostViewModel GetById(Guid id);

        void Save();

        Task SaveChangesAsync();
    }
}