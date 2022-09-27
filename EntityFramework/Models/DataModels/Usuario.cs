using Microsoft.Build.Framework;
using System.Text.Json.Serialization;

namespace EntityFramework.Models.DataModels
{
    public class Usuario : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Libro> Libros { get; set; }
    }
}
