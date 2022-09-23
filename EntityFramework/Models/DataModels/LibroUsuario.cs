using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models.DataModels
{
    public class LibroUsuario : BaseEntity
    {
        [Required]
        public Libro Libro { get; set; }
        [Required]
        public Usuario Usuario { get; set; }
    }
}
