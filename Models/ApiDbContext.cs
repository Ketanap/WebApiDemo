using Microsoft.EntityFrameworkCore;
namespace WebApiDemo.Models
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext()
        { }
        public ApiDBContext(DbContextOptions<ApiDBContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("ApiCoreDBContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblContact> tblContact { get; set; }
    }
}
