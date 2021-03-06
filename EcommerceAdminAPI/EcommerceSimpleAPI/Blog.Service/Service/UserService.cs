﻿using AutoMapper;
using Ecommerce.Core.Extensions;
using Ecommerce.Core.Interface;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Service.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        //private IUserRepository _userRepository;
        private IRepository<User> _userRepository;
        private UserManager<User> _userMaganer;

        public UserService(UserManager<User> userMaganer, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            //_userRepository = userRepository;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userMaganer = userMaganer;
        }


        public Guid Add(UserViewModel user)
        {
            var entity = Mapper.Map<UserViewModel, User>(user);
            if (IsDuplicateUser(entity))
            {
                throw new Exception("");
            }
            entity.Id = Guid.NewGuid();
            _userMaganer.CreateAsync(entity);
            return entity.Id;
        }

        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetList(int page, int pageSize, string keyWord = "", string sort = "", bool desc = false)
        {
            var query = _userRepository.GetPagedList().Items;
            var users = Mapper.Map<List<User>, List<UserViewModel>>(query.ToList());
            return users;
        }

        public bool Update(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public UserWidthRoleViewModel GetById(Guid Id)
        {
            var user = _userMaganer.FindByIdAsync(Id.ToString()).Result;
            if (user == null)
            {
                throw new EcommerceException("UserNotFound");
            }
            var roles = _userMaganer.GetRolesAsync(user).Result;
            return new UserWidthRoleViewModel()
            {
                BirthDay = user.BirthDay,
                FullName = user.FullName,
                Roles = roles.ToList(),
                Email = user.Email,
                Id = user.Id
            };

        }

        private bool IsDuplicateUser(User user)
        {
            if (user.Id != null)
            {
                return _userRepository.FindBy(x => x.IsActive && x.UserName == user.UserName && x.Id != user.Id).Any();
            }
            else
            {
                return _userRepository.FindBy(x => x.IsActive && x.UserName == user.UserName).Any();
            }
        }
    }
}