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
    public class AbsencesController : ControllerBase
    {
        private readonly AbsencesContext _context;

        public AbsencesController(AbsencesContext context)
        {
            _context = context;
        }

        // GET: api/Absences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsence()
        {
            return await _context.Absence.ToListAsync();
        }
        // GET: api/Absences
        [HttpGet("/api/Absencesbyseance/{seanceid}")]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsencebyseance(int seanceid)
        {
            return await _context.Absence.Where(ab => ab.EmploiId == seanceid).ToListAsync();
        }
        // GET: api/Absencesmat
        [HttpGet("/api/Absencesbymat/{mat}")]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsencebymat(int mat)
        {
            return await _context.Absence.Where(ab => ab.MatiereId == mat).ToListAsync();
        }
        // GET: api/Absences
        [HttpGet("/api/Absencesbyseancedate/{seanceid}/{date}")]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsencebyseancedate(int seanceid,string date)
        {
            return await _context.Absence.Where(ab => ab.EmploiId == seanceid && ab.Date == date).ToListAsync();
        }

        // GET: api/Absences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Absence>> GetAbsence(int id)
        {
            var absence = await _context.Absence.FindAsync(id);

            if (absence == null)
            {
                return NotFound();
            }

            return absence;
        }



        // PUT: api/Absences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbsence(int id, Absence absence)
        {
            if (id != absence.Id)
            {
                return BadRequest();
            }

            _context.Entry(absence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceExists(id))
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

        // POST: api/Absences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Absence>> PostAbsence(Absence absence)
        {
            _context.Absence.Add(absence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbsence", new { id = absence.Id }, absence);
        }

        // DELETE: api/Absences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }

            _context.Absence.Remove(absence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absence.Any(e => e.Id == id);
        }
    }
}
