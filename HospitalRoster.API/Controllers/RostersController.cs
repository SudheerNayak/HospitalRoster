using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalRoster.API.Models;

namespace HospitalRoster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RostersController : ControllerBase
    {
        private readonly RosterContext _context;

        public RostersController(RosterContext context)
        {
            _context = context;
        }

        // GET: api/Rosters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roster>>> GetRosters()
        {
            return await _context.Rosters
                .Include(r => r.Staff)
                .Include(r => r.Shift)
                .Include(r => r.Department)
                .Select(r=> new Roster
                {
                    RosterId = r.RosterId,
                    StaffName = $"{r.Staff.FirstName} {r.Staff.LastName}",
                    ShiftName = r.Shift.Name,
                    Date = r.Date,
                    DepartmentName = r.Department.Name,
                    IsApproved = r.IsApproved
                    
                })
                .OrderByDescending(r=>r.RosterId)
                .ToListAsync();
        }

        // GET: api/Rosters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roster>> GetRoster(int id)
        {
            var roster = await _context.Rosters.FindAsync(id);

            if (roster == null)
            {
                return NotFound();
            }

            return roster;
        }

        // PUT: api/Rosters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoster(int id, Roster roster)
        {
            if (id != roster.RosterId)
            {
                return BadRequest();
            }

            _context.Entry(roster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RosterExists(id))
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

        // POST: api/Rosters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roster>> PostRoster(Roster roster)
        {
            _context.Rosters.Add(roster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoster", new { id = roster.RosterId }, roster);
        }

        // DELETE: api/Rosters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoster(int id)
        {
            var roster = await _context.Rosters.FindAsync(id);
            if (roster == null)
            {
                return NotFound();
            }

            _context.Rosters.Remove(roster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RosterExists(int id)
        {
            return _context.Rosters.Any(e => e.RosterId == id);
        }
    }
}
