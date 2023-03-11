using ProgrammingLanguageGraphQL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly ProgrammingLanguageDbContext _context;
        public ProgrammingLanguageController(ProgrammingLanguageDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetLanguages()
        {
            return await _context.ProgrammingLanguages.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammingLanguage>> GetRecipe(int id)
        {
            var language = await _context.ProgrammingLanguages.FindAsync(id);
            if (language == null) { return NotFound(); }
            return language;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, ProgrammingLanguage programmingLanguage)
        {
            if(id != programmingLanguage.Id)
            {
                return BadRequest();
            }
            _context.Entry(programmingLanguage).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (await LanguageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        private async Task<bool> LanguageExists(Guid id)
        {
           return await _context.ProgrammingLanguages.AnyAsync(x => x.Id == id);
        }
    }
}