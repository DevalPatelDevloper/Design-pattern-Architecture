using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Data_Access_layar.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dept> Depts { get; set; }

    }
}
