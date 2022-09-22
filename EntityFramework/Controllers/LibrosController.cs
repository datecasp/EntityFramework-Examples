using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataAccess;
using EntityFramework.Models.DataModels;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly EntityDBContext _context;
        private readonly ILogger<UsuariosController> _logger;


        public LibrosController(ILogger<UsuariosController> logger, EntityDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Libroes
        [HttpGet]
        public async Task<ActionResult> GetLibros()
        {
            var libros = await _context.Roles
                .Include(x => x.LibroUsuarios)
                .ThenInclude(x => x.Usuario)
                .ToListAsync();

            return View(libros);
        }

        // GET: api/Libroes/5

        // GET all the Usuarios that have had a Libro
        /*
        [HttpGet("{idLibro}")]
        public async Task<IEnumerable<Array>> GetLibrosDeUsuario(int idLibro)
        {
            
            var usuarios = from libro in _context.Libros 
                         where libro.Id == idLibro
                         select libro.Usuarios.ToArray();
            return usuarios;
        }
        */
        // GET: api/Libroes/5
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }
        */

        // PUT: api/Libroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // DELETE: api/Libroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
        */
    }
}
