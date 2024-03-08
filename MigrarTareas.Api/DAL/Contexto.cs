using Microsoft.EntityFrameworkCore;

namespace MigrarTareas.Api.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }
}
