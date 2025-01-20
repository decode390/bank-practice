
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class BankContext(DbContextOptions<BankContext> options): DbContext(options)
{
    public required DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User").Property(e => e.CreatedDate);

        base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        EntityTrackerHelper.UpdateTimeStamps(tracker: ChangeTracker);
        return base.SaveChanges();
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        EntityTrackerHelper.UpdateTimeStamps(tracker: ChangeTracker);
        return await base.SaveChangesAsync(cancellationToken);
    }
}