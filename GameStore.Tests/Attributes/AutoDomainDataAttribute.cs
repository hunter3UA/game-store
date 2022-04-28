using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using GameStore.BLL.Mapper;

namespace GameStore.Tests.Attributes
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute() : base(CreateFixture)
        {
        }

        private static IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customize(
             new CompositeCustomization(
                 new AutoMoqCustomization { ConfigureMembers = true, },
                 new AutoMapperCustomization(x => x.AddProfile<AutoMapperConfig>())));

            return fixture;
        }
    }
}
