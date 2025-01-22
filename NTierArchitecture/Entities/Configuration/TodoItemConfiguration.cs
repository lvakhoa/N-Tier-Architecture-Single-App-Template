using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NTierArchitecture.Entities.Domain;

namespace NTierArchitecture.Entities.Configuration;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(ti => ti.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ti => ti.Body)
            .HasMaxLength(1000)
            .IsRequired();
    }
}
