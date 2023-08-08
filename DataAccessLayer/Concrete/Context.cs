using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            // connect to postgres with connection string from app settings
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
