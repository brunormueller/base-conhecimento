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
    public class DocumentoTagController : ControllerBase
    {
        private readonly banco_conhecimentoContext _context;

        public DocumentoTagController(banco_conhecimentoContext context)
        {
            _context = context;
        }

        // GET: api/DocumentoTag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoTag>>> GetDocumentoTag()
        {
            return await _context.DocumentoTags.ToListAsync();
        }

        // GET: api/DocumentoTag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoTag>> GetDocumentoTag(int id)
        {
            var documentoTag = await _context.DocumentoTags.FindAsync(id);

            if (documentoTag == null)
            {
                return NotFound();
            }

            return documentoTag;
        }

        // PUT: api/DocumentoTag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentoTag(int id, DocumentoTag documentoTag)
        {
            if (id != documentoTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentoTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoTagExists(id))
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

        // POST: api/DocumentoTag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentoTag>> PostDocumentoTag(DocumentoTag documentoTag)
        {
            _context.DocumentoTags.Add(documentoTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentoTag", new { id = documentoTag.Id }, documentoTag);
        }

        // DELETE: api/DocumentoTag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentoTag(int id)
        {
            var documentoTag = await _context.DocumentoTags.FindAsync(id);
            if (documentoTag == null)
            {
                return NotFound();
            }

            _context.DocumentoTags.Remove(documentoTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentoTagExists(int id)
        {
            return _context.DocumentoTags.Any(e => e.Id == id);
        }
    }
}
