using Microsoft.EntityFrameworkCore;
namespace WebApiDemo.Models
{
    public class ApiDBContect : DbContext
    {
        public ApiDBContect()
        { }
        public ApiDBContect(DbContextOptions<ApiDBContect> options)
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
            var connectionString = configuration.GetConnectionString("ApiCoreDBContect");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblContact> tblContact { get; set; }
    }
}
