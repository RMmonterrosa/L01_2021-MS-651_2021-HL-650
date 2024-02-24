using L01_2021_MS_651_2021_HL_650.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Def.Models
{
    public class pruebaContext : DbContext
    {

        public pruebaContext(DbContextOptions<pruebaContext> options) : base(options)  
        {
        }

        public DbSet<Pedidios> pedidos {  get; set; } 
        public DbSet<Summer> Summero { get; set; } 

    }
}
