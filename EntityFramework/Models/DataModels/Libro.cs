using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace EntityFramework.Models.DataModels
{
    public class Libro : IdentityRole
    {
        public ICollection<LibroUsuario> LibroUsuarios { get; set; }

       
    }
}
