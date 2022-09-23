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
    public class LibroUsuariosController : Controller
    {
        private readonly EntityDBContext _context;

        public LibroUsuariosController(EntityDBContext context)
        {
            _context = context;
        }

        // GET: api/LibroUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroUsuario>>> GetLibroUsuarios()
        {
            return await _context.LibroUsuarios.ToListAsync();
        }

        // GET: api/LibroUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroUsuario>> GetLibroUsuario(int id)
        {
            var libroUsuario = await _context.LibroUsuarios.FindAsync(id);

            if (libroUsuario == null)
            {
                return NotFound();
            }

            return libroUsuario;
        }

        // PUT: api/LibroUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroUsuario(int id, LibroUsuario libroUsuario)
        {
            if (id != libroUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroUsuarioExists(id))
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

        // POST: api/LibroUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroUsuario>> PostLibroUsuario(LibroUsuario libroUsuario)
        {
            _context.LibroUsuarios.Add(libroUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibroUsuarioExists(libroUsuario.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibroUsuario", new { id = libroUsuario.Id }, libroUsuario);
        }

        // DELETE: api/LibroUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroUsuario(int id)
        {
            var libroUsuario = await _context.LibroUsuarios.FindAsync(id);
            if (libroUsuario == null)
            {
                return NotFound();
            }

            _context.LibroUsuarios.Remove(libroUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroUsuarioExists(int id)
        {
            return _context.LibroUsuarios.Any(e => e.Id == id);
        }
    }
}
