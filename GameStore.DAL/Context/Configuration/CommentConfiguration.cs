using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Context.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment { Id = 1, Name = "Oleksandr", Body = "This is my favourite game", GameId = 1, },
                new Comment { Id = 2, Name = "Oleg", Body = "And my too", GameId = 1, ParentCommentId = 1 });

        }
    }
}
