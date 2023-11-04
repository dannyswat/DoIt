using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.ToDos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoIt.Infra.DbContexts;

public class DoItDbContext : DbContext
{
    public DoItDbContext(DbContextOptions<DoItDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; } = null!;

    public DbSet<ToDoList> ToDoLists { get; set; } = null!;

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ToDoItem>()
            .HasOne<ToDoList>()
            .WithMany(r => r.Items)
            .HasForeignKey(r => r.ToDoListId);
    }
}
