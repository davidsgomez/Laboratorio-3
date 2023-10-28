using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    public class lab3Context : DbContext
    {
        public DbSet<equipos> equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E6P6QHE\\SQLEXPRESS;Database=lab3;Trusted_Connection=True;");
        }
    }
}
