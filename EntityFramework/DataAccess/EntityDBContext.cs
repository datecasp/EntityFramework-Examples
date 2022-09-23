using EntityFramework.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataAccess
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options) { }
        public EntityDBContext() { }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<LibroUsuario>? LibroUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>(b =>
            {
                b.HasMany(e => e.LibroUsuarios)
                .WithOne(e => e.Usuario)
                .HasForeignKey(ur => ur.Id)
                .IsRequired();
            });

            builder.Entity<Libro>(b =>
            {
                b.HasMany(e => e.LibroUsuarios)
                .WithOne(e => e.Libro)
                .HasForeignKey(ur => ur.Id)
                .IsRequired();
            });

            builder.Entity<LibroUsuario>();
        }
    }
}
