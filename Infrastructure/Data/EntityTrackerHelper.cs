using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data;

public static class EntityTrackerHelper
{
    public static void UpdateTimeStamps(ChangeTracker tracker){
        var entries = tracker.Entries<BaseEntity>()
        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.ModificationDate =  DateTime.UtcNow;
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTime.UtcNow;
        }
    }
}