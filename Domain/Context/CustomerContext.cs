using Domain.Entities.CustomerApp;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions): base(dbContextOptions)
    {

    }

    public DbSet<Customer> Customers { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Customer).Assembly);
    }
}
