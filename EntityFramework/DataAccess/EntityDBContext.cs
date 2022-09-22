using EntityFramework.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataAccess
{
    public class EntityDBContext : IdentityDbContext<Usuario, Libro, string,
        IdentityUserClaim<string>, LibroUsuario, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EntityDBContext (DbContextOptions<EntityDBContext> options) : base(options) { }

       protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating (builder);

            builder.Entity<Usuario>(b =>
            {
                b.HasMany(e => e.LibroUsuarios)
                .WithOne(e => e.Usuario)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });

            builder.Entity<Libro>(b =>
            {
                b.HasMany(e => e.LibroUsuarios)
                .WithOne(e => e.Libro)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            builder.Entity<Usuario>();
            builder.Entity<Libro>();
            builder.Entity<LibroUsuario>();

        }
    }


}
