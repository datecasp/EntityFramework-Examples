using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataAccess;
using EntityFramework.Models.DataModels;
using System.Diagnostics.Eventing.Reader;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly EntityDBContext _context;

        public UsuariosController(EntityDBContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var libros = await _context.Libros.ToListAsync();

            Usuario[] arrayUsuarios = new Usuario[usuarios.Count];
       
            for(int i = 1; i < usuarios.Count; i++)
            {
                /*
                 * CREAR UNA CLASE LIBROSBASICOS CON SOLO LA INFO DEL LIBRO
                 * PARA MOSTRAR
                 * AHORA MISMO ESTOY COGIENDO LOS DATOS DE LIBROUSUARIO
                 * CAMBIAR ESE ORIGEN A LIBROSBASICOS QUE PUEDE SER UNA COPIA
                 * DE PARTES CONCRTEAS DE UN OBJETO LIBROUSUARIO QUE TIENE TODO
                 * 
                 * CREAR UNA CLASE LIBROSBSICOS CON INFO BASICA Y VINCULARLA TAMBIEN
                 * AL RESTO DE TABLAS COMO LIBROUSUARIO PARA QUE RECIBA LA INFO JUSTA
                 * Y AMBIAR LA REFERENCIA EN EL INCLUDE(USU => USU.LIBROS A USU.lIBROSBASICOS
                 */


                // Works but object cycle issue at serialization in swagger
                var usuConLib = _context.Usuarios.Include(usu => usu.Libros).ThenInclude(row => row.Libros).First(usu => usu.UsuarioId == i);
                if (usuConLib != null) arrayUsuarios[i] = usuConLib;
            }

            return arrayUsuarios;
            
        }

        // GET: api/Usuarios
        // GET all the Libros that are assigned to Usuario

        [HttpGet("{idUsuario}")]
        public async Task<IEnumerable<Array>> GetLibrosUsuario (int idUsuario)
        {
            var libros = from usuario in _context.Usuarios
                         where usuario.UsuarioId == idUsuario
                         select usuario.Libros.ToArray();
            
            return libros;

        }

        // GET: api/Usuarios/5
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        */

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok();//CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
