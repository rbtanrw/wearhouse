using Microsoft.EntityFrameworkCore;
using WearHouse.Models;

namespace WearHouse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DataUser> DataUsers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
