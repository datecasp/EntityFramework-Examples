using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models.DataModels
{
    public class LibroUsuario : IdentityUserRole<string>
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
    }
}
