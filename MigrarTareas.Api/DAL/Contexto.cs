using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrarTareas.Api.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
}
