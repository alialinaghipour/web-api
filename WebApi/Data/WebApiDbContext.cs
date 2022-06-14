using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
