using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PulsacionesApi.Context;
using PulsacionesApi.Models;

namespace PulsacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PulsacionesController : ControllerBase
    {
        private readonly PulsacionesContext _context;

        public PulsacionesController(PulsacionesContext context)
        {
            _context = context;
        }

        // GET: api/Pulsaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Pulsaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(string id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Pulsaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(string id, Persona persona)
        {
            if (id != persona.Identificacion)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Pulsaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            
            persona.CalcularPulsaciones();

            _context.Personas.Add(persona);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(persona.Identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersona", new { id = persona.Identificacion }, persona);
        }

        // DELETE: api/Pulsaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona>> DeletePersona(string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(string id)
        {
            return _context.Personas.Any(e => e.Identificacion == id);
        }
    }
}
