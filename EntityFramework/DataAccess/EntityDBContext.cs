using EntityFramework.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EntityFramework.DataAccess
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext (DbContextOptions<EntityDBContext> options) : base(options) { }

        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<LibroUsuario>? LibroUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LibroUsuario>().HasKey(i => new { i.LibroId, i.UsuarioId });

            //builder.Entity<Usuario>().HasKey(i => new {i.UsuarioId, i.LibroId });
            //builder.Entity<Libro>().HasKey(i => new { i.LibroId, i.UsuarioId });


        }
    }
}
