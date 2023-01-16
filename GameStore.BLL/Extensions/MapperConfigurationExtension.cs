using AutoMapper;
using GameStore.BLL.Mapper;

namespace GameStore.BLL.Extensions
{
    public static class MapperConfigurationExtension
    {
        public static void AddCustomProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfiles(new Profile[] {
                new GameProfile(),
                new CommentProfile(),
                new GenreProfile(),
                new OrderDetailsProfile(),
                new OrderProfile(),
                new PlatformProfile(),
                new PublisherProfile(),
                new TranslationsProfile(),
                new UserProfile(),
                new OtherProfile()
            
            });
        }
    }
}
