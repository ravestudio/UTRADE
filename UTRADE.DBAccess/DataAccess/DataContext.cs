using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UTRADE.DBAccess.DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/home/pi/db/utrade_service.db");
        }
    }
}