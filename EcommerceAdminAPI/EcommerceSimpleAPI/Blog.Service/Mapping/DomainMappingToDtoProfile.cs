using AutoMapper;
using Ecommerce.Core.Model;
using Ecommerce.Service.ViewModels;
namespace Ecommerce.Service.Mapping
{
    public class DomainMappingToDtoProfile : Profile
    {
       public override string ProfileName => "DomainMappingToDtoProfile";
        public DomainMappingToDtoProfile()
        {

            //nó sẽ map thành phần theo mình chỉ định với name khác nhau dùng property mapfrom
            CreateMap<PostCategory, PostCategoryViewModel>()
                .ForMember(x => x.ParentPostCategory, opt => opt.MapFrom(dt => dt.ParentId));
            CreateMap<Post, PostViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<User, UserViewModel>();

            CreateMap<PostCategory, SimpleSelectItem>()
                .ForMember(x => x.Id, opt => opt.MapFrom(dt => dt.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(dt => dt.CategoryName));
            //
            CreateMap<PostCategoryViewModel, PostCategory>()
                 .ForMember(x => x.ParentId, opt => opt.MapFrom(dt => dt.ParentPostCategory));
            CreateMap<PostViewModel, Post>();
            CreateMap<CommentViewModel, Comment>();
            CreateMap<UserViewModel, User>();
        }

    }
}
