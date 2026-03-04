using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YungChingInterviewProject.Entities;

namespace YungChingInterviewProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}
