using Microsoft.EntityFrameworkCore;
using remitee_challenge.Data.Entities;

namespace remiteechallenge;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Cuenta> Cuentas {get; set;}

    public DbSet<Balance> Balances {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Remitee;Trusted_Connection=True;");
    }
}
