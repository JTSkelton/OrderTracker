using Microsoft.EntityFrameworkCore;
using OrderTracker.Models;

namespace OrderTracker.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vendor> Vendors { get; set; }        
    }
}
