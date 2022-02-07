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
    public class EtudiantsController : ControllerBase
    {
        private readonly AbsencesContext _context;

        public EtudiantsController(AbsencesContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetEtudiant()
        {
            return await _context.Etudiant.ToListAsync();
        }

        // GET: api/Etudiantclasseid

        [HttpGet("/api/Etudiantscls/{cid}")]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetEtudiantcls(int cid)
        {
            return await _context.Etudiant.Where(et => et.ClasseId == cid).ToListAsync();
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
            var etudiant = await _context.Etudiant.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return etudiant;
        }

        // PUT: api/Etudiants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostEtudiant(Etudiant etudiant)
        {
            _context.Etudiant.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.Id }, etudiant);
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiant.Remove(etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiant.Any(e => e.Id == id);
        }
    }
}
