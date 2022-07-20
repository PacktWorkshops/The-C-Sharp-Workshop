using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoListApp.Models;

namespace ToDoListApp.Data;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {

    }

    public DbSet<ToDoTask> Tasks { get; set; }
    public DbSet<ActivityLog> Activities { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var logs = GenerateActivityLog();

        Activities.AddRange(logs);

        return base.SaveChangesAsync(cancellationToken);
    }

    private IEnumerable<ActivityLog> GenerateActivityLog()
    {
        var changes = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Modified)
            .ToList();

        foreach (var entity in changes)
        {
            var changedProperties = entity
                .Properties
                .Where(p => p.IsModified && !p.CurrentValue.Equals(p.OriginalValue));

            foreach (var property in changedProperties)
            {
                yield return new ActivityLog()
                {
                    EntityId = GetPrimaryKey(entity),
                    Timestamp = DateTime.UtcNow,
                    Property = property.Metadata.Name,
                    OldValue = property.OriginalValue.ToString(),
                    NewValue = property.CurrentValue.ToString()
                };
            }
        }

        string GetPrimaryKey(EntityEntry entity)
        {
            return entity.Metadata.FindPrimaryKey()
                .Properties
                .Select(p => entity.Property(p.Name).CurrentValue)
                .Single()
                .ToString();
        }
    }
}
