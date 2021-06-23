using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoM_Labb2.Data;
using WoM_Labb2.Models;

namespace WoM_Labb2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AssignmentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignments>>> GetAssignments()
        {
            return await _context.Assignments
                .Include(a => a.User).ToListAsync();
        }

        // GET: api/Assignments/5
        [HttpGet("{id}/{taskID}")]
        public async Task<ActionResult<Assignments>> GetAssignments(int id, int taskID)
        {
            var assignments = await _context.Assignments.FindAsync(id, taskID);

            if (assignments == null)
            {
                return NotFound();
            }

            return assignments;
        }

        // PUT: api/Assignments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignments(int id, Assignments assignments)
        {
            if (id != assignments.UserID)
            {
                return BadRequest();
            }

            _context.Entry(assignments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentsExists(id))
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

        // POST: api/Assignments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Assignments>> PostAssignments(Assignments assignments)
        {
            _context.Assignments.Add(assignments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssignmentsExists(assignments.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssignments", new { id = assignments.UserID }, assignments);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}/{taskID}")]
        public async Task<ActionResult<Assignments>> DeleteAssignments(int id, int taskID)
        {
            var assignments = await _context.Assignments.FindAsync(id, taskID);
            if (assignments == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignments);
            await _context.SaveChangesAsync();

            return assignments;
        }

        private bool AssignmentsExists(int id)
        {
            return _context.Assignments.Any(e => e.UserID == id);
        }
    }
}
