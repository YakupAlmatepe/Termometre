
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ApplicationContext : DbContext

    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = "Server=localhost,1433;Database=DbTempreture;User=SA;Password=Ykp14538-;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=Ykp14538-;");
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<RandomTemperature> RandomTempretures { get; set; }
    }
    // docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Ykp14538-" -p 1433:1433 --name sql2019 -v sql_data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2019-latest
}
