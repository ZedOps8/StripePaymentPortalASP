using Microsoft.EntityFrameworkCore;
using StripeWebApp.Models; // Ensure the correct namespace for your Item model

namespace StripeWebApp.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
