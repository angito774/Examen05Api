using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Examen05Api.Models
{
    public class ContextDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.4,14334; Database=Examen05Api;User id=sa;Password=as123@.*;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;");
        }


            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Producto> Productos { get; set; }


    
    }
}
