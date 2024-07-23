using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentModelFirstApp.Models;

namespace StudentModelFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentModelFirstApproachesController : ControllerBase
    {
        private readonly StudentModelFirstApproachContext _context;

        public StudentModelFirstApproachesController(StudentModelFirstApproachContext context)
        {
            _context = context;
        }

        // GET: api/StudentModelFirstApproaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModelFirstApproach>>> GetStudentModelFirstApproaches()
        {
            return await _context.StudentModelFirstApproaches.ToListAsync();
        }

        // GET: api/StudentModelFirstApproaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModelFirstApproach>> GetStudentModelFirstApproach(int id)
        {
            var studentModelFirstApproach = await _context.StudentModelFirstApproaches.FindAsync(id);

            if (studentModelFirstApproach == null)
            {
                return NotFound();
            }

            return studentModelFirstApproach;
        }

        // PUT: api/StudentModelFirstApproaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModelFirstApproach(int id, StudentModelFirstApproach studentModelFirstApproach)
        {
            if (id != studentModelFirstApproach.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModelFirstApproach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelFirstApproachExists(id))
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

        // POST: api/StudentModelFirstApproaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentModelFirstApproach>> PostStudentModelFirstApproach(StudentModelFirstApproach studentModelFirstApproach)
        {
            _context.StudentModelFirstApproaches.Add(studentModelFirstApproach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModelFirstApproach", new { id = studentModelFirstApproach.Id }, studentModelFirstApproach);
        }

        // DELETE: api/StudentModelFirstApproaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModelFirstApproach(int id)
        {
            var studentModelFirstApproach = await _context.StudentModelFirstApproaches.FindAsync(id);
            if (studentModelFirstApproach == null)
            {
                return NotFound();
            }

            _context.StudentModelFirstApproaches.Remove(studentModelFirstApproach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelFirstApproachExists(int id)
        {
            return _context.StudentModelFirstApproaches.Any(e => e.Id == id);
        }
    }
}
