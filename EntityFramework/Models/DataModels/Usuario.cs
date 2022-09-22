using EntityFramework.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFramework.Models.DataModels
{
    public class Usuario : IdentityUser
    {
        public ICollection<LibroUsuario> LibroUsuarios { get; set; }
    }
}
