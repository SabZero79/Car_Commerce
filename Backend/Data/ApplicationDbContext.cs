using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Make = "Ford Fiesta", Year = 2021, Transmission = "Manual", ImageUrl = "https://img.classistatic.de/api/v1/mo-prod/images/42/42356da7-a4e3-4b3c-ba91-e029f7334251?rule=mo-1600.jpg" },
                new Car { Id = 2, Make = "Toyota Corolla", Year = 2019, Transmission = "Manual", ImageUrl = "https://img.classistatic.de/api/v1/mo-prod/images/46/46681d0d-16d3-44a9-b14b-8de4607ae5de?rule=mo-1600.jpg" },
                new Car { Id = 3, Make = "BMW 3 Series", Year = 2020, Transmission = "Automatic", ImageUrl = "https://img.classistatic.de/api/v1/mo-prod/images/2a/2a0663b7-98f3-48f8-9d9d-5200aefbf0b4?rule=mo-1600.jpg" }
            );
        }
    }
}
