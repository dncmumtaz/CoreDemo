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

    }
}
