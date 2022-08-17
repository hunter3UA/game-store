using GameStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Context.Configuration
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasData(
                new Publisher { Id = 1, CompanyName = "DeepSilver", Description = "Desc of Publisher 1 ", HomePage = "Home" },
                new Publisher { Id = 2, CompanyName = "GSC", Description = "Desc of Publisher 2 ", HomePage = "Home2" },
                new Publisher { Id = 3, CompanyName = "Activision", Description = "Desc of Activision", HomePage = "Activision page" },
                new Publisher { Id = 4, CompanyName = "Firaxis", Description = "Desc of Firaxis", HomePage = "Firaxis page" },
                new Publisher { Id = 5, CompanyName = "Bohemia Interactive", Description = "Desc of bohemia", HomePage = "Bohemia page" });

        }
    }
}
