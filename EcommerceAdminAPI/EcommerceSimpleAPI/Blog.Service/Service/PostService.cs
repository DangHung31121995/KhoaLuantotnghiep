﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Core.Extensions;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Service.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Post> _postRepository;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = _unitOfWork.GetRepository<Post>();
        }

        public Guid Add(PostViewModel post, Guid currentUserId)
        {
            var entity = new PostViewModel().Map(post);

            entity.Id = Guid.NewGuid();
            entity.CreateBy = currentUserId;
            entity.CreateOn = DateTime.UtcNow;

            _postRepository.Insert(entity);

            return entity.Id;
        }

        public bool Delete(Guid id, Guid currentUserId)
        {
            var entity = _postRepository.FindBy(x => x.Id == id && !x.DeleteBy.HasValue).FirstOrDefault();

            if (entity == null)
            {
                return false;
            }
            entity.DeleteBy = currentUserId;
            entity.DeleteOn = DateTime.UtcNow;
            _postRepository.Update(entity);

            return true;
        }

        public PagingViewModel<PostViewModel> Get(string keyword, string sortColumn, Guid? postCategoryId, bool desc = false, int pageIndex = 0, int pageSize = 15)
        {
            var query = _postRepository.FindBy(x => !x.DeleteBy.HasValue);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Title.Contains(keyword));
            }

            if (postCategoryId.HasValue)
            {
                query = query.Where(x => x.PostCategoryId == postCategoryId.Value);
            }
            var totalCount = query.Count();
            query = desc ? query.OrderByDescending(x => x.Title) : query.OrderBy(x => x.Title);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var listPost = query.ProjectTo<PostViewModel>().AsNoTracking().ToList();
            var pages = new PagingViewModel<PostViewModel>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = listPost,
                TotalCount = totalCount
            };

            return pages;
        }

        public PostViewModel GetById(Guid id)
        {
            var post = _postRepository.FindBy(x => x.Id == id).FirstOrDefault();

            if (post == null)
            {
                throw new EcommerceException("POST_NOT_FOUND");
            }

            return new PostViewModel().Map(post);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public bool Update(PostViewModel post, Guid currentUserId)
        {
            var entity = _postRepository.FindBy(x => x.Id == post.Id).FirstOrDefault();

            if (entity == null)
            {
                // throw new EcommerceException("POST_NOT_FOUND");
                return false;
            }

            var entityUpdate = new PostViewModel().Map(post);

            _postRepository.Update(entityUpdate);

            return true;
        }
    }
}