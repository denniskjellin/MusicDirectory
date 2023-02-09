using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDirectory.Data;
using MusicDirectory.Models;

namespace MusicDirectory.Controllers
{
    public class RentController : Controller
    {
        private readonly MusicContext _context;

        public RentController(MusicContext context)
        {
            _context = context;
        }

        // GET: Rent
        [Route("/rent")]
        public async Task<IActionResult> Index()
        {
            var musicContext = _context.Renting.Include(r => r.Album);
            return View(await musicContext.ToListAsync());
        }

        // GET: Rent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Album)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // GET: Rent/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title");
            return View();
        }

        // POST: Rent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,Name,AlbumId,DateOfRent")] Renting renting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title", renting.AlbumId);
            return View(renting);
        }

        // GET: Rent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting.FindAsync(id);
            if (renting == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title", renting.AlbumId);
            return View(renting);
        }

        // POST: Rent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,Name,AlbumId,DateOfRent")] Renting renting)
        {
            if (id != renting.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentingExists(renting.RentalId))
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
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title", renting.AlbumId);
            return View(renting);
        }

        // GET: Rent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Album)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // POST: Rent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Renting == null)
            {
                return Problem("Entity set 'MusicContext.Renting'  is null.");
            }
            var renting = await _context.Renting.FindAsync(id);
            if (renting != null)
            {
                _context.Renting.Remove(renting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentingExists(int id)
        {
          return (_context.Renting?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}
