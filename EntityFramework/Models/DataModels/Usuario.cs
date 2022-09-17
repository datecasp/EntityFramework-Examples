using EntityFramework.DataAccess;
using Microsoft.Build.Framework;

namespace EntityFramework.Models.DataModels
{
    public class Usuario : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public IEnumerable<Libro> Libros { get; set; }
    }
}
