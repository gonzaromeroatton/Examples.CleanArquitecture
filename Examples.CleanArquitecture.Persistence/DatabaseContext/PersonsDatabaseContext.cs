using Examples.CleanArquitecture.Domain;
using Examples.CleanArquitecture.Domain.Common;
using Examples.CleanArquitecture.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Examples.CleanArquitecture.Persistence.DatabaseContext;

/// <summary>
/// 
/// </summary>
public sealed class PersonsDatabaseContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public PersonsDatabaseContext(DbContextOptions<PersonsDatabaseContext> options) { }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Person> Persons { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
        .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;

            if (entry.State == EntityState.Added)
                entry.Entity.DateCreated = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
