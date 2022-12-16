using Cars.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class MyAppContext : DbContext
{
    private DbSet<Car> Cars { get; set; }

    private DbSet<Seller> Sellers { get; set; }

    private DbSet<CarBrand> CarBrands{ get; set; }

    private DbSet<Operation> Operations{ get; set; }

    public MyAppContext()
    {
    }

    public MyAppContext(DbContextOptions<MyAppContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=KPZ_Cars;Integrated Security=True;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarBrand>()
            .HasData(
            new CarBrand() { Id = 1, Name = "BMW" },
            new CarBrand() { Id = 2, Name = "Mercedes" },
            new CarBrand() { Id = 3, Name = "Mazda" },
            new CarBrand() { Id = 4, Name = "Renault" },
            new CarBrand() { Id = 5, Name = "Toyota" });
    }
}
