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
    public class NabavaTonerasController : Controller
    {
        private readonly LagerosContext _context;

        public NabavaTonerasController(LagerosContext context)
        {
            _context = context;
        }

        // GET: NabavaToneras
        public async Task<IActionResult> Index()
        {
            var lagerosContext = _context.NabavaTonera.Include(n => n.Toner);
            return View(await lagerosContext.ToListAsync());
        }

        // GET: NabavaToneras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nabavaTonera = await _context.NabavaTonera
                .Include(n => n.Toner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nabavaTonera == null)
            {
                return NotFound();
            }

            return View(nabavaTonera);
        }

        // GET: NabavaToneras/Create
        public IActionResult Create()
        {
            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Model");
            ViewData["Toner"] = new SelectList(_context.Toner, "Id", "Kolicina");
            return View();
        }

        // POST: NabavaToneras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TonerId,Kolicina,DatumZamjene")] NabavaTonera nabavaTonera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nabavaTonera);
                _context.Entry(nabavaTonera)
                    .Reference(r => r.Toner)
                    .Load();


                nabavaTonera.Toner.Kolicina += nabavaTonera.Kolicina;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Model", nabavaTonera.TonerId);
            return View(nabavaTonera);
        }

        // GET: NabavaToneras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nabavaTonera = await _context.NabavaTonera.FindAsync(id);
            if (nabavaTonera == null)
            {
                return NotFound();
            }
            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Id", nabavaTonera.TonerId);
            return View(nabavaTonera);
        }

        // POST: NabavaToneras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TonerId,DatumZamjene")] NabavaTonera nabavaTonera)
        {
            if (id != nabavaTonera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nabavaTonera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NabavaToneraExists(nabavaTonera.Id))
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
            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Id", nabavaTonera.TonerId);
            return View(nabavaTonera);
        }

        // GET: NabavaToneras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nabavaTonera = await _context.NabavaTonera
                .Include(n => n.Toner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nabavaTonera == null)
            {
                return NotFound();
            }

            return View(nabavaTonera);
        }

        // POST: NabavaToneras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nabavaTonera = await _context.NabavaTonera.FindAsync(id);

            _context.Entry(nabavaTonera)
                .Reference(t => t.Toner)
                .Load();

            if (nabavaTonera.Toner.Kolicina < 1)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = "Nedovoljna količina tonera u sustavu!" });
            }
            else
            {
                nabavaTonera.Toner.Kolicina -= nabavaTonera.Kolicina;
            }

            _context.NabavaTonera.Remove(nabavaTonera);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool NabavaToneraExists(int id)
        {
            return _context.NabavaTonera.Any(e => e.Id == id);
        }
    }
}
