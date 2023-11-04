using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoIt.Infra.Configurations;

public static class AggregateRootConfiguration
{
    public static void ConfigureAggregateRoot<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IAggregateRoot
    {
        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .IsRequired();

        builder.Property(r => r.CreatedBy)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.UpdatedBy)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.RowVersion)
            .IsConcurrencyToken()
            .IsRequired();
    }
}
