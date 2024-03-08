using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrarTareas.Api.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Prioridades> Prioridades { get; set; }
}
