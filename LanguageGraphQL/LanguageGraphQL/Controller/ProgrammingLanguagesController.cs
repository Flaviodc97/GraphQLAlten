using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanguageGraphQL.Data;
using LanguageGraphQL.Model;

namespace LanguageGraphQL.Controller
{
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly ProgrammingLanguageContext _context;

        public ProgrammingLanguagesController(ProgrammingLanguageContext context)
        {
            _context = context;
        }

        // GET: ProgrammingLanguages
        public async Task<IActionResult> Index()
        {
            var programmingLanguageContext = _context.ProgrammingLanguage.Include(p => p.TypeLanguage);
            return View(await programmingLanguageContext.ToListAsync());
        }

        // GET: ProgrammingLanguages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgrammingLanguage == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguage
                .Include(p => p.TypeLanguage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Create
        public IActionResult Create()
        {
            ViewData["TypeLanguageId"] = new SelectList(_context.TypeLanguage, "Id", "Id");
            return View();
        }

        // POST: ProgrammingLanguages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Description,TypeLanguageId")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmingLanguage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeLanguageId"] = new SelectList(_context.TypeLanguage, "Id", "Id", programmingLanguage.TypeLanguageId);
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgrammingLanguage == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguage.FindAsync(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }
            ViewData["TypeLanguageId"] = new SelectList(_context.TypeLanguage, "Id", "Id", programmingLanguage.TypeLanguageId);
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Description,TypeLanguageId")] ProgrammingLanguage programmingLanguage)
        {
            if (id != programmingLanguage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmingLanguage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammingLanguageExists(programmingLanguage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeLanguageId"] = new SelectList(_context.TypeLanguage, "Id", "Id", programmingLanguage.TypeLanguageId);
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgrammingLanguage == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguage
                .Include(p => p.TypeLanguage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgrammingLanguage == null)
            {
                return Problem("Entity set 'ProgrammingLanguageContext.ProgrammingLanguage'  is null.");
            }
            var programmingLanguage = await _context.ProgrammingLanguage.FindAsync(id);
            if (programmingLanguage != null)
            {
                _context.ProgrammingLanguage.Remove(programmingLanguage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammingLanguageExists(int id)
        {
          return (_context.ProgrammingLanguage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
