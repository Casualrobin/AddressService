using Microsoft.EntityFrameworkCore;

namespace AddressService.DBContexts
{
    public class AddressContext : DbContext
    {
       public AddressContext(DbContextOptions<AddressContext> options) : base(options)
       {
       }

        public DbSet<Address> Addresses { get; set; }

        Address a = new Address
        {
            ID = 1,
            FirstName = "John",
            LastName = "Smith",
            StreetAddress = "Test St 1",
            City = "London",
            Country = "England",
            AggregateCity = "london"
        };
        Address b = new Address
        {
            ID = 2,
            FirstName = "Jane",
            LastName = "Doe",
            StreetAddress = "Test St 2",
            City = "London",
            Country = "England",
            AggregateCity = "london"
        };
        Address c = new Address
        {
            ID = 3,
            FirstName = "Tim",
            LastName = "Jones",
            StreetAddress = "Test St 3",
            City = "New York",
            Country = "USA",
            AggregateCity = "newyork"
        };

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>().HasData(a,b,c);
    }
    }
}
