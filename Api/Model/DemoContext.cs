using Microsoft.EntityFrameworkCore;

namespace Api.Model
{
    public class DemoContext : DbContext
    {
     
        public DemoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Std> Stds { get; set; }    
           

    }
}
