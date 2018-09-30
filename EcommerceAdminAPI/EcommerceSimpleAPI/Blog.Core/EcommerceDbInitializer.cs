using Ecommerce.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Core
{
    public class EcommerceDbInitializer
    {
        public EcommerceDbInitializer()
        {
        }

        public static void Initializer(EcommerceDbContext context, UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            if (!(context.PostCategorys.Count() > 0))
            {
                if (!roleManager.Roles.Any())
                {
                    var adminRole = roleManager.CreateAsync(new UserRole { Name = "Admin", Description = "Quản trị viên" }).Result;
                    var memberRole = roleManager.CreateAsync(new UserRole { Name = "Member", Description = "Người dùng" }).Result;
                }

                var userLogin = userManager.FindByEmailAsync("danghonghung31121995@gmail.com").Result;
                Guid userId;

                if (userLogin == null)
                {
                    var user = new User()
                    {
                        Id = Guid.NewGuid(),
                        UserName = "danghonghung31121995@gmail.com",
                        EmailConfirmed = true,
                        BirthDay = new DateTime(1993, 9, 20),
                        FullName = "Đặng Hùng",
                        IsActive = true,
                        Email = "danghonghung31121995@gmail.com"
                    };
                    var userCreate = userManager.CreateAsync(user, "Abc@12345").Result;
                    var userDb = userManager.FindByEmailAsync("danghonghung31121995@gmail.com").Result;
                    userId = userDb.Id;
                    var userRole = userManager.AddToRolesAsync(userDb, new string[] { "Admin", "Member" }).Result;
                }
                else
                {
                    userId = userLogin.Id;
                }

                List<PostCategory> postCategorys = new List<PostCategory>();
                for (int i = 0; i < 5; i++)
                {
                    PostCategory postCategory = new PostCategory()
                    {
                        Id = Guid.NewGuid(),
                        CategoryName = $"Category {i}",
                        CategoryDescription = $"Post Category {i} ",
                        CreateOn = DateTime.Now,
                        CreateBy = userId,
                        IsPublic = true
                    };

                    postCategorys.Add(postCategory);
                };
                context.PostCategorys.AddRange(postCategorys);

                List<Post> posts = new List<Post>();
                for (int i = 0; i < 5; i++)
                {
                    Post post = new Post()
                    {
                        Id = Guid.NewGuid(),
                        Title = $"Post {i}",
                        Content = "",
                        PostCategoryId = postCategorys.First().Id,
                        CreateOn = DateTime.Now,
                        CreateBy = userId,
                        IsPublic = true
                    };

                    posts.Add(post);
                };

                context.Posts.AddRange(posts);

                context.SaveChanges();
            }
        }
    }
}