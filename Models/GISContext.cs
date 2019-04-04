using Microsoft.EntityFrameworkCore;

namespace GIS_API.Models
{
    public class GISContext : DbContext
    {
        public GISContext(DbContextOptions<GISContext> options)
            : base(options)
        {
        }

        public DbSet<GISItem> GISItems { get; set; }
    }
}