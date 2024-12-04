using LsManagerDesktop.Data.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace LsManagerDesktop.Data;

public class LsDbContext : DbContext
{
    public DbSet<Mod> Mods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./LsManager.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}