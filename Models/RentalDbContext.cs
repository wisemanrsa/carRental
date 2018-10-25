using Microsoft.EntityFrameworkCore;

namespace carRental.Models
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options): base(options){}

        public DbSet<RentalAgency> RentalAgency { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarType> CarType { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<PickUp> Pickup { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}