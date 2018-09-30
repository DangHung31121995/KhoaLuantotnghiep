using AutoMapper;

namespace Ecommerce.Service.Mapping
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainMappingToDtoProfile());
            });
        }
    }
}