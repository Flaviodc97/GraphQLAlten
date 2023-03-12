using ProgrammingLanguageGraphQL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Models;
using ProgrammingLanguageGraphQL.Interfaces;

namespace ProgrammingLanguageGraphQL.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;
        private readonly ProgrammingLanguageDbContext _context;
        public ProgrammingLanguageController(IRepository<ProgrammingLanguage> programmingLanguageRepository, ProgrammingLanguageDbContext context)
        {
           _programmingLanguageRepository= programmingLanguageRepository;
            _context= context;
        }
        [HttpGet]
        public  ActionResult<IEnumerable<ProgrammingLanguage>> GetLanguages()
        {
            var allP = _programmingLanguageRepository.GetAll();
            return Ok(allP);
        }
        [HttpGet("{id}")]
        public ActionResult<ProgrammingLanguage> GetRecipe(Guid id)
        {
            var language = _programmingLanguageRepository.GetById(id);
            if (language == null) { return NotFound(); }
            return language;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, ProgrammingLanguage programmingLanguage)
        {
            if (id != programmingLanguage.Id)
            {
                return BadRequest();
            }
            _context.Entry(programmingLanguage).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
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
        [HttpGet("Exist")]
        public async Task<bool> LanguageExists(Guid id)
        {
            return await _context.ProgrammingLanguages.AnyAsync(x => x.Id == id);
        }
    }
}