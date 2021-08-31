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
    public class TonersController : Controller
    {
        private readonly LagerosContext _context;

        public TonersController(LagerosContext context)
        {
            _context = context;
        }

        // GET: Toners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toner.ToListAsync());
        }

        // GET: Toners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toner = await _context.Toner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toner == null)
            {
                return NotFound();
            }

            return View(toner);
        }

        // GET: Toners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Toners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Kolicina,Boja")] Toner toner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toner);
        }

        // GET: Toners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toner = await _context.Toner.FindAsync(id);
            if (toner == null)
            {
                return NotFound();
            }
            return View(toner);
        }

        // POST: Toners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Kolicina,Boja")] Toner toner)
        {
            if (id != toner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TonerExists(toner.Id))
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
            return View(toner);
        }

        // GET: Toners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toner = await _context.Toner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toner == null)
            {
                return NotFound();
            }

            return View(toner);
        }

        // POST: Toners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toner = await _context.Toner.FindAsync(id);
            _context.Toner.Remove(toner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TonerExists(int id)
        {
            return _context.Toner.Any(e => e.Id == id);
        }
    }
}
