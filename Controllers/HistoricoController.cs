#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using base_conhecimento.Models;

namespace base_conhecimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly banco_conhecimentoContext _context;

        public HistoricoController(banco_conhecimentoContext context)
        {
            _context = context;
        }

        // GET: api/Historico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historico>>> GetHistorico()
        {
            return await _context.Historicos.ToListAsync();
        }

        // GET: api/Historico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historico>> GetHistorico(int id)
        {
            var historico = await _context.Historicos.FindAsync(id);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        // PUT: api/Historico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorico(int id, Historico historico)
        {
            if (id != historico.Id)
            {
                return BadRequest();
            }

            _context.Entry(historico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoExists(id))
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

        // POST: api/Historico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historico>> PostHistorico(Historico historico)
        {
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorico", new { id = historico.Id }, historico);
        }

        // DELETE: api/Historico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorico(int id)
        {
            var historico = await _context.Historicos.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.Historicos.Remove(historico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historicos.Any(e => e.Id == id);
        }
    }
}
