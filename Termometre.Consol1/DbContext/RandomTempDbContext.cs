using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termometre.Consol1.Concrete;

namespace Termometre.Consol1
{
    public class RandomTempDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = "Server=localhost,1433;Database=DbTempreture;User=SA;Password=Ykp14538-;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=Ykp14538-;");
        }
       
        public DbSet<RandomTemp> RandomTemps { get; set; }
    }
}
