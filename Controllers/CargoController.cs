using Microsoft.AspNetCore.Mvc;
using MyFinanzeAPI.Data;
using MyFinanzeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFinanzeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CargoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            return await _context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var prueba = await _context.Cargos.FindAsync(id);

            if (prueba == null)
            {
                return NotFound();
            }

            return prueba;
        }

        // POST: api/Cargos
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargos(Cargo prueba)
        {
            _context.Cargos.Add(prueba);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCargo), new { id = prueba.Id }, prueba);
        }

        // PUT: api/Cargos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargos(int id, Cargo prueba)
        {
            if (id != prueba.Id)
            {
                return BadRequest();
            }

            _context.Entry(prueba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargosExists(id))
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

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargos(int id)
        {
            var prueba = await _context.Cargos.FindAsync(id);
            if (prueba == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(prueba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.Id == id);
        }
    }
}
