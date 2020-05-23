using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cw10.Models;

namespace Cw10.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly CodeFirstContext _context;

        public DoctorsController(CodeFirstContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            return await _context.Doctor.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.IdDoctor)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctorExists(doctor.IdDoctor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoctor", new { id = doctor.IdDoctor }, doctor);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.IdDoctor == id);
        }
    }
}
