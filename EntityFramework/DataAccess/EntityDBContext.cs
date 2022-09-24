using EntityFramework.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace EntityFramework.DataAccess
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options) { }
        public EntityDBContext() { }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        //public DbSet<LibroUsuario>? LibroUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Libro>();

            builder.Entity<Usuario>();

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            Usuario sp1 = new Usuario()
            {
                Id = -1,
                Nombre = "Usu1",
                LibroId = -1
            };

            Usuario sp2 = new Usuario()
            {
                Id = -2,
                Nombre = "Usu2",
                LibroId = -1
            };

            Usuario sp3 = new Usuario()
            {
                Id = -3,
                Nombre = "Usu3",
                LibroId= -2
            };

            Libro tk1 = new Libro()
            {
                Id = -1,
                Titulo = "tit1",
                Autor = "aut1",
                UsuarioId = -1
            };

            Libro tk2 = new Libro()
            {
                Id = -2,
                Titulo = "tit2",
                Autor = "aut2",
                UsuarioId = -1
            };

            Libro tk3 = new Libro()
            {
                Id = -3,
                Titulo = "tit3",
                Autor = "aut3",
                UsuarioId = -2
            };

            Libro tk4 = new Libro()
            {
                Id = -4,
                Titulo = "tit4",
                Autor = "aut4",
                UsuarioId = -3
            };

            Libro tk5 = new Libro()
            {
                Id = -5,
                Titulo = "tit5",
                Autor = "aut5",
                UsuarioId = -3
            };

            Libro tk6 = new Libro()
            {
                Id = -6,
                Titulo = "tit6",
                Autor = "aut6",
                UsuarioId = -3
            };

            builder.Entity<Usuario>().HasData(sp1, sp2, sp3);
            builder.Entity<Libro>().HasData(tk1, tk2, tk3, tk4, tk5, tk6);
        }

    }
}
