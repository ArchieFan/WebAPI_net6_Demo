using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<laptop> laptops { get; set; }
    }
}
