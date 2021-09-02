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
    public class IzdavanjesController : Controller
    {
        private readonly LagerosContext _context;

        public IzdavanjesController(LagerosContext context)
        {
            _context = context;
        }

        // GET: Izdavanjes
        public async Task<IActionResult> Index()
        {
            var LagerosContext = _context.Izdavanje.Include(i => i.Korisnik).Include(i => i.Laptop).Include(i => i.Monitor).Include(i => i.Periferija).Include(i => i.AdminKorisnik);
            return View(await LagerosContext.ToListAsync());
        }

        // GET: Izdavanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izdavanje = await _context.Izdavanje
                .Include(i => i.Korisnik)
                .Include(i => i.Laptop)
                .Include(i => i.Monitor)
                .Include(i => i.Periferija)
                .Include(i => i.AdminKorisnikId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (izdavanje == null)
            {
                return NotFound();
            }

            return View(izdavanje);
        }

        // GET: Izdavanjes/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "ImePrezime");
            ViewData["LaptopId"] = new SelectList(_context.Laptop, "Id", "INV");
            ViewData["MonitorId"] = new SelectList(_context.Monitor, "Id", "INV");
            ViewData["PeriferijaId"] = new SelectList(_context.Periferija, "Id", "Model");
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme");
            return View();
        }

        // POST: Izdavanjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KorisnikId,LaptopId,MonitorId,PeriferijaId,DatumZamjene,AdminKorisnikId")] Izdavanje izdavanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izdavanje);
                _context.Entry(izdavanje)
                    .Reference(r => r.Laptop)
                    .Load();
                if (izdavanje.Laptop != null)
                {
                    if (izdavanje.Laptop.Izdano)
                        return View("Error", new ErrorViewModel { ErrorMessage = "Izdano :(" });
                    else
                        izdavanje.Laptop.Izdano = true;
                }

                _context.Add(izdavanje);
                _context.Entry(izdavanje)
                    .Reference(r => r.Monitor)
                    .Load();
                if (izdavanje.Monitor != null)
                {
                    if (izdavanje.Monitor.Izdano)
                        return View("Error", new ErrorViewModel { ErrorMessage = "Izdano :(" });
                    else
                        izdavanje.Monitor.Izdano = true;
                }

                _context.Add(izdavanje);
                _context.Entry(izdavanje)
                    .Reference(r => r.Periferija)
                    .Load();
                if (izdavanje.Periferija != null)
                {
                    if (izdavanje.Periferija.Kolicnina < 1)
                        return View("Error", new ErrorViewModel { ErrorMessage = "Ponestalo :(" });
                    else
                        izdavanje.Periferija.Kolicnina--;
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "ImePrezime", izdavanje.KorisnikId);
            ViewData["LaptopId"] = new SelectList(_context.Laptop, "Id", "INV", izdavanje.LaptopId);
            ViewData["MonitorId"] = new SelectList(_context.Monitor, "Id", "INV", izdavanje.MonitorId);
            ViewData["PeriferijaId"] = new SelectList(_context.Periferija, "Id", "Naziv", izdavanje.PeriferijaId);
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme", izdavanje.AdminKorisnik);

            return View(izdavanje);
        }

        // GET: Izdavanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izdavanje = await _context.Izdavanje.FindAsync(id);
            if (izdavanje == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "ImePrezime", izdavanje.KorisnikId);
            ViewData["LaptopId"] = new SelectList(_context.Laptop, "Id", "INV", izdavanje.LaptopId);
            ViewData["MonitorId"] = new SelectList(_context.Monitor, "Id", "INV", izdavanje.MonitorId);
            ViewData["PeriferijaId"] = new SelectList(_context.Periferija, "Id", "NazivPeriferije", izdavanje.PeriferijaId);
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme", izdavanje.AdminKorisnik);
            return View(izdavanje);
        }

        // POST: Izdavanjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KorisnikId,LaptopId,MonitorId,PeriferijaId,DatumZamjene,AdminKorisnikId")] Izdavanje izdavanje)
        {
            if (id != izdavanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izdavanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzdavanjeExists(izdavanje.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Id", izdavanje.KorisnikId);
            ViewData["LaptopId"] = new SelectList(_context.Laptop, "Id", "Id", izdavanje.LaptopId);
            ViewData["MonitorId"] = new SelectList(_context.Monitor, "Id", "Id", izdavanje.MonitorId);
            ViewData["PeriferijaId"] = new SelectList(_context.Periferija, "Id", "Id", izdavanje.PeriferijaId);
            ViewData["AdminKorisnikId"] = new SelectList(_context.AdminKorisnik, "Id", "PrezimeIme", izdavanje.AdminKorisnik);
            return View(izdavanje);
        }

        // GET: Izdavanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izdavanje = await _context.Izdavanje
                .Include(i => i.Korisnik)
                .Include(i => i.Laptop)
                .Include(i => i.Monitor)
                .Include(i => i.Periferija)
                .Include(i => i.AdminKorisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (izdavanje == null)
            {
                return NotFound();
            }

            return View(izdavanje);
        }

        // POST: Izdavanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izdavanje = await _context.Izdavanje.FindAsync(id);
            if (izdavanje.PeriferijaId != null)
            {
                _context.Entry(izdavanje)
                .Reference(t => t.Periferija)
                .Load();
                izdavanje.Periferija.Kolicnina++;
            }
            if (izdavanje.LaptopId != null)
            {
                _context.Entry(izdavanje)
                .Reference(t => t.Laptop)
                .Load();
                izdavanje.Laptop.Izdano = false;
            }
            if (izdavanje.MonitorId != null)
            {
                _context.Entry(izdavanje)
                .Reference(t => t.Monitor)
                .Load();
                izdavanje.Monitor.Izdano = false;
            }
            _context.Izdavanje.Remove(izdavanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzdavanjeExists(int id)
        {
            return _context.Izdavanje.Any(e => e.Id == id);
        }
    }
}
