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
    public class ZamjenaTonersController : Controller
    {
        private readonly LagerosContext _context;

        public ZamjenaTonersController(LagerosContext context)
        {
            _context = context;
        }

        // GET: ZamjenaToners
        public async Task<IActionResult> Index()
        {
            var LagerosContext = _context.ZamjenaToner.Include(r => r.Printer).Include(r => r.Toner).Include(r => r.AdminKorisnik);
            return View(await LagerosContext.ToListAsync());
        }

        // GET: ZamjenaToners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaToner = await _context.ZamjenaToner
                .Include(r => r.Printer)
                .Include(r => r.Toner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamjenaToner == null)
            {
                return NotFound();
            }

            return View(zamjenaToner);
        }

        // GET: ZamjenaToners/Create
        public IActionResult Create()
        {

            ViewData["PrinterId"] = new SelectList(_context.Printeri, "Id", "Naziv");
            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Model");
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme");
            return View();

        }

        // POST: ZamjenaToners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrinterId,TonerId,DatumZamjene, AdminKorisnikId")] ZamjenaToner zamjenaToner)
        {
            if (ModelState.IsValid)
            {

                _context.Add(zamjenaToner);
                _context.Entry(zamjenaToner)
                    .Reference(r => r.Toner)
                    .Load();

                if (zamjenaToner.Toner.Kolicina < 1)
                {
                    return View("Error", new ErrorViewModel { ErrorMessage = "Ponestalo tonera :(" });
                }
                else
                {
                    zamjenaToner.Toner.Kolicina--;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrinterId"] = new SelectList(_context.Printeri, "Id", "Naziv", zamjenaToner.Printer);
            ViewData["TonerId"] = new SelectList(_context.Toner, "Id", "Naziv", zamjenaToner.Toner);
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme", zamjenaToner.AdminKorisnik);
            return View(zamjenaToner);
        }

        // GET: ZamjenaToners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaToner = await _context.ZamjenaToner.FindAsync(id);
            if (zamjenaToner == null)
            {
                return NotFound();
            }
            return View(zamjenaToner);
        }

        // POST: ZamjenaToners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatumZamjene")] ZamjenaToner zamjenaToner)
        {
            if (id != zamjenaToner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamjenaToner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamjenaTonerExists(zamjenaToner.Id))
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
            return View(zamjenaToner);
        }

        // GET: ZamjenaToners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamjenaToner = await _context.ZamjenaToner
                .Include(r => r.Toner)
                .Include(r => r.Printer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamjenaToner == null)
            {
                return NotFound();
            }
            return View(zamjenaToner);
        }

        // POST: ZamjenaToners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var zamjenaToner = await _context.ZamjenaToner.FindAsync(id);
            _context.Entry(zamjenaToner)
                .Reference(t => t.Toner)
                .Load();

            zamjenaToner.Toner.Kolicina++;

            _context.ZamjenaToner.Remove(zamjenaToner);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ZamjenaTonerExists(int id)
        {
            return _context.ZamjenaToner.Any(e => e.Id == id);
        }
    }
}
