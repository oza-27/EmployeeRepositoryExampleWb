using Microsoft.EntityFrameworkCore;

namespace EmployeeRepositoryExample.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set;}
        public DbSet<Position> positions { get; set;}
        public DbSet<Details> company_details { get; set;}
    }
}
