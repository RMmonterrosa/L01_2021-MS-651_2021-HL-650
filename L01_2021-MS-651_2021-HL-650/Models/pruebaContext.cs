using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01_2021_MS_651_2021_HL_650.Models
{
    public class pruebaContext : DbContext
    {

        public pruebaContext(DbContextOptions<pruebaContext> options) : base(options)  
        {
        }

        public DbSet<Pedidos> pedidos {  get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<platos> platos { get; set; }
        public DbSet<motoristas> motoristas { get; set;}

        


    }
}
