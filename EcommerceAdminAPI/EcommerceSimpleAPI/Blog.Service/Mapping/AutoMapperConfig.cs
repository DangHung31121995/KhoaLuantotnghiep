using AutoMapper;
using Ecommerce.Core.Model;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Mapping
{
    public static class AutoMapperConfig
    {
       public static MapperConfiguration Config = new MapperConfiguration(cfg =>
       {
                //cfg.AddProfile(new DomainMappingToDtoProfile());
           cfg.CreateMap<PostCategory, PostCategoryViewModel>()
                     .ForMember(x => x.ParentPostCategory, opt => opt.MapFrom(dt => dt.ParentId));
           cfg.CreateMap<Post, PostViewModel>();
           cfg.CreateMap<Comment, CommentViewModel>();
           cfg.CreateMap<User, UserViewModel>();

           cfg.CreateMap<PostCategory, SimpleSelectItem>()
               .ForMember(x => x.Id, opt => opt.MapFrom(dt => dt.Id))
               .ForMember(x => x.Name, opt => opt.MapFrom(dt => dt.CategoryName));
                //
                cfg.CreateMap<PostCategoryViewModel, PostCategory>()
               .ForMember(x => x.ParentId, opt => opt.MapFrom(dt => dt.ParentPostCategory));
           cfg.CreateMap<PostViewModel, Post>();
           cfg.CreateMap<CommentViewModel, Comment>();
           cfg.CreateMap<UserViewModel, User>();

       });

    }
}