using EVOffice_BE.Entities.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVOffice_BE.Entities.Configuration;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.Property(tl => tl.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(tl => tl.Items)
            .WithOne(ti => ti.List)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
