using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace EntityFramework.Models.DataModels
{
    public class Libro : BaseEntity
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Autor { get; set; } = string.Empty;
        
        public IEnumerable<LibroUsuario> LibroUsuarios { get; set; }
    }
}
