#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatieresController : ControllerBase
    {
        private readonly AbsencesContext _context;

        public MatieresController(AbsencesContext context)
        {
            _context = context;
        }

        // GET: api/Matieres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matiere>>> GetMatiere()
        {
            return await _context.Matiere.ToListAsync();
        }

        // GET: api/Matieres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matiere>> GetMatiere(int id)
        {
            var matiere = await _context.Matiere.FindAsync(id);

            if (matiere == null)
            {
                return NotFound();
            }

            return matiere;
        }

        // PUT: api/Matieres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatiere(int id, Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/Matieres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matiere>> PostMatiere(Matiere matiere)
        {
            
            _context.Matiere.Add(matiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatiere", new { id = matiere.Id }, matiere);
        }

        // DELETE: api/Matieres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatiere(int id)
        {
            var matiere = await _context.Matiere.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            _context.Matiere.Remove(matiere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatiereExists(int id)
        {
            return _context.Matiere.Any(e => e.Id == id);
        }
    }
}
