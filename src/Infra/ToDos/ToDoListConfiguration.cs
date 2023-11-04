using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.ToDos;
using DoIt.Infra.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoIt.Infra.ToDos;

public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
{
    public void Configure(EntityTypeBuilder<ToDoList> builder)
    {
        builder.Property(r => r.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.Description)
            .HasMaxLength(500);

        builder.ConfigureAggregateRoot();
    }
}
