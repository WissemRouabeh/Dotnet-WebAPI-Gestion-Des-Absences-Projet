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
    public class EmploisController : ControllerBase
    {
        private readonly AbsencesContext _context;

        public EmploisController(AbsencesContext context)
        {
            _context = context;
        }

        // GET: api/Emplois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploi()
        {
            return await _context.Emploi.ToListAsync();
        }
        // GET: api/Emploiscls
        [HttpGet("/api/Emploiscls/{cid}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploiscls(int cid)
        {
            return await _context.Emploi.Where(e => e.ClasseId == cid).ToListAsync();
        }
        // GET: api/Emploismat
        [HttpGet("/api/Emploimat/{mat}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploismat(int mat)
        {
            return await _context.Emploi.Where(e => e.MatiereId == mat).ToListAsync();
        }
        // GET: api/Emploiscls
        [HttpGet("/api/Emploisclsens/{cid}/{ensid}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploisclsens(int cid, int ensid)
        {
            return await _context.Emploi.Where(e => e.ClasseId == cid && e.EnseignantId == ensid).ToListAsync();
        }
        // GET: api/Emploiscls
        [HttpGet("/api/Emploisclsmat/{cid}/{matid}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploisclsmat(int cid, int matid)
        {
            return await _context.Emploi.Where(e => e.ClasseId == cid && e.MatiereId == matid).ToListAsync();
        }
        // GET: api/Emploiscls
        [HttpGet("/api/Emploisens/{ensid}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploissens(int ensid)
        {
            return await _context.Emploi.Where(e => e.EnseignantId == ensid).ToListAsync();
        }
        // GET: api/Emploiscls
        [HttpGet("/api/GetEmploisclsensmat/{cid}/{ensid}/{matid}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploisclsensmat(int cid, int ensid, int matid)
        {
            return await _context.Emploi.Where(e => e.ClasseId == cid && e.EnseignantId == ensid && e.MatiereId == matid).ToListAsync();
        }

        // GET: api/Emplois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emploi>> GetEmploi(int id)
        {
            var emploi = await _context.Emploi.FindAsync(id);

            if (emploi == null)
            {
                return NotFound();
            }

            return emploi;
        }

        // PUT: api/Emplois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploi(int id, Emploi emploi)
        {
            if (id != emploi.Id)
            {
                return BadRequest();
            }

            _context.Entry(emploi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploiExists(id))
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

        // POST: api/Emplois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emploi>> PostEmploi(Emploi emploi)
        {
            _context.Emploi.Add(emploi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploi", new { id = emploi.Id }, emploi);
        }

        // DELETE: api/Emplois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploi(int id)
        {
            var emploi = await _context.Emploi.FindAsync(id);
            if (emploi == null)
            {
                return NotFound();
            }

            _context.Emploi.Remove(emploi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploiExists(int id)
        {
            return _context.Emploi.Any(e => e.Id == id);
        }
    }
}
