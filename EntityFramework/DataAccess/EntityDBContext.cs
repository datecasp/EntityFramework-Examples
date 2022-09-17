using EntityFramework.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataAccess
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext (DbContextOptions<EntityDBContext> options) : base(options) { }

        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
    }
}
