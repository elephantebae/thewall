using Microsoft.EntityFrameworkCore;
 
namespace thewall.Models
{
    public class WallContext : DbContext
    {
        public WallContext(DbContextOptions<WallContext> options) : base(options) { }

        public DbSet<Message> messages {get;set;}
        public DbSet<Comment> comments {get;set;}

        public DbSet<User> users {get;set;}
    }
}