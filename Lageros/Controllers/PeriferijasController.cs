using Lageros.Data;
using Lageros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lageros.Controllers
{
    [Authorize]
    public class PeriferijasController : Controller
    {
        private readonly LagerosContext _context;

        public PeriferijasController(LagerosContext context)
        {
            _context = context;
        }

        // GET: Periferijas
        public async Task<IActionResult> Index()
        {
            var lagerosContext = _context.Periferija.Include(p => p.Izbor);
            return View(await lagerosContext.ToListAsync());
        }

        // GET: Periferijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferija = await _context.Periferija
                .Include(p => p.Izbor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periferija == null)
            {
                return NotFound();
            }

            return View(periferija);
        }

        // GET: Periferijas/Create
        public IActionResult Create()
        {
            ViewData["IzborId"] = new SelectList(_context.Set<Izbor>(), "Id", "NazivPeriferije");
            return View();
        }

        // POST: Periferijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IzborId,NazivPeriferije,Model,Kolicnina")] Periferija periferija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periferija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IzborId"] = new SelectList(_context.Set<Izbor>(), "Id", "Id", periferija.IzborId);
            return View(periferija);
        }

        // GET: Periferijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferija = await _context.Periferija.FindAsync(id);
            if (periferija == null)
            {
                return NotFound();
            }
            ViewData["IzborId"] = new SelectList(_context.Set<Izbor>(), "Id", "Id", periferija.IzborId);
            return View(periferija);
        }

        // POST: Periferijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kolicnina")] Periferija periferija)
        {
            if (id != periferija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periferija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriferijaExists(periferija.Id))
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
            ViewData["IzborId"] = new SelectList(_context.Set<Izbor>(), "Id", "Id", periferija.IzborId);
            return View(periferija);
        }

        // GET: Periferijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferija = await _context.Periferija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periferija == null)
            {
                return NotFound();
            }

            return View(periferija);
        }

        // POST: Periferijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periferija = await _context.Periferija.FindAsync(id);
            _context.Periferija.Remove(periferija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriferijaExists(int id)
        {
            return _context.Periferija.Any(e => e.Id == id);
        }
    }
}
