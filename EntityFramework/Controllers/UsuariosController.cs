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
using System.Net.Sockets;

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
            List<Usuario> result = new List<Usuario>();

            foreach (var usuario in usuarios)
            {
                foreach (var libro in libros)
                {
                    if (libro.Id == usuario.LibroId)
                    {
                        var libroUsuario = new Usuario()
                        {
                            Id = usuario.Id,
                            Nombre = usuario.Nombre,
                            Libros = new Libro[] { libro }
                        };
                        result.Add(libroUsuario);
                    }
                }
            }
            return result;

        }

        // GET: api/Usuarios
        // GET all the Libros that are assigned to Usuario

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            var libros = await _context.Libros.ToListAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            foreach (var libro in libros)
            {
                if (libro.UsuarioId == id)
                {
                    var libroUsuario = new Usuario()
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        Libros = new Libro[] { libro }
                    };
                    usuario = libroUsuario;
                }
            }

            return usuario;
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
            if (id != usuario.Id)
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
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
