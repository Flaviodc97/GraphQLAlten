using LanguageGraphQL.Data;
using LanguageGraphQL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanguageGraphQL.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly ProgrammingLanguageContext _context;
        public ProgrammingLanguageController(ProgrammingLanguageContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetLanguages()
        {
            return await _context.ProgrammingLanguage.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammingLanguage>> GetRecipe(int id)
        {
            var language = await _context.ProgrammingLanguage.FindAsync(id);
            if (language == null) { return NotFound(); }
            return language;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, ProgrammingLanguage programmingLanguage)
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
        private async Task<bool> LanguageExists(int id)
        {
           return await _context.ProgrammingLanguage.AnyAsync(x => x.Id == id);
        }
    }
}