using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaDiogo.Models;

namespace ProvaDiogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoasController(PessoaContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoaItem()
        {
            return await _context.PessoaItem.ToListAsync();
        }

        // GET: api/Pessoas/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(long id)
        {
            var pessoa = await _context.PessoaItem.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(long id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.PessoaItem.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPessoaItem), new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(long id)
        {
            var pessoa = await _context.PessoaItem.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.PessoaItem.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(long id)
        {
            return _context.PessoaItem.Any(e => e.Id == id);
        }
    }
}
