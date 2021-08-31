using Lageros.Data;
using Lageros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lageros.Controllers
{
    [Authorize]
    public class SektorsController : Controller
    {
        private readonly LagerosContext _context;

        public SektorsController(LagerosContext context)
        {
            _context = context;
        }

        // GET: Sektors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sektor.ToListAsync());
        }

        // GET: Sektors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sektor == null)
            {
                return NotFound();
            }

            return View(sektor);
        }

        // GET: Sektors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sektors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivSektora")] Sektor sektor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sektor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sektor);
        }

        // GET: Sektors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor.FindAsync(id);
            if (sektor == null)
            {
                return NotFound();
            }
            return View(sektor);
        }

        // POST: Sektors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivSektora")] Sektor sektor)
        {
            if (id != sektor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sektor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SektorExists(sektor.Id))
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
            return View(sektor);
        }

        // GET: Sektors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sektor == null)
            {
                return NotFound();
            }

            return View(sektor);
        }

        // POST: Sektors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sektor = await _context.Sektor.FindAsync(id);
            _context.Sektor.Remove(sektor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SektorExists(int id)
        {
            return _context.Sektor.Any(e => e.Id == id);
        }
    }
}
