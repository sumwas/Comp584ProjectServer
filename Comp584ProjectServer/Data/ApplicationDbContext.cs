using Comp584ProjectServer.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Comp584ProjectServer.Models;

namespace Comp584ProjectServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Book> Books { get; set; }
        

    }
}
