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
    public class AdminKorisniksController : Controller
    {
        private readonly LagerosContext _context;

        public AdminKorisniksController(LagerosContext context)
        {
            _context = context;
        }

        // GET: AdminKorisniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminKorisnik.ToListAsync());
        }

        // GET: AdminKorisniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminKorisnik = await _context.AdminKorisnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminKorisnik == null)
            {
                return NotFound();
            }

            return View(adminKorisnik);
        }

        // GET: AdminKorisniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminKorisniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Email")] AdminKorisnik adminKorisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminKorisnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminKorisnik);
        }

        // GET: AdminKorisniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminKorisnik = await _context.AdminKorisnik.FindAsync(id);
            if (adminKorisnik == null)
            {
                return NotFound();
            }
            return View(adminKorisnik);
        }

        // POST: AdminKorisniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Email")] AdminKorisnik adminKorisnik)
        {
            if (id != adminKorisnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminKorisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminKorisnikExists(adminKorisnik.Id))
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
            return View(adminKorisnik);
        }

        // GET: AdminKorisniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminKorisnik = await _context.AdminKorisnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminKorisnik == null)
            {
                return NotFound();
            }

            return View(adminKorisnik);
        }

        // POST: AdminKorisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminKorisnik = await _context.AdminKorisnik.FindAsync(id);
            _context.AdminKorisnik.Remove(adminKorisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminKorisnikExists(int id)
        {
            return _context.AdminKorisnik.Any(e => e.Id == id);
        }
    }
}
