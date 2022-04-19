using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using GameStore.BLL.Mapper;
using GameStore.DAL.UoW.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Tests.Attributes
{
    public class AutoDomainDataAttribute:AutoDataAttribute
    {
        public AutoDomainDataAttribute() :base(CreateFixture){ }

        private static IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());        
            fixture.Customize(
             new CompositeCustomization(
                 new AutoMoqCustomization { ConfigureMembers = true, },
                 new AutoMapperCustomization(x => x.AddProfile<AutoMapperConfig>())
                 )
            );
            return fixture;
        }
    }
}
