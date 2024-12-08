using Microsoft.EntityFrameworkCore;
using Shared.Data.DomainModel;

namespace Shared.Data;

public class LsDbContext : DbContext
{
    public DbSet<Mod> Mods { get; set; }
    public DbSet<Setting> Settings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./LsManager.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}