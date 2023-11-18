using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnaeLogiciel.Data;
using AnaeLogiciel.Models;

namespace AnaeLogiciel.Controllers
{
    public class MoisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mois
        public async Task<IActionResult> Index()
        {
              return _context.Mois != null ? 
                          View(await _context.Mois.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mois'  is null.");
        }

        // GET: Mois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mois == null)
            {
                return NotFound();
            }

            var mois = await _context.Mois
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mois == null)
            {
                return NotFound();
            }

            return View(mois);
        }

        // GET: Mois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Mois mois)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mois);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mois);
        }

        // GET: Mois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mois == null)
            {
                return NotFound();
            }

            var mois = await _context.Mois.FindAsync(id);
            if (mois == null)
            {
                return NotFound();
            }
            return View(mois);
        }

        // POST: Mois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Mois mois)
        {
            if (id != mois.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mois);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoisExists(mois.Id))
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
            return View(mois);
        }

        // GET: Mois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mois == null)
            {
                return NotFound();
            }

            var mois = await _context.Mois
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mois == null)
            {
                return NotFound();
            }

            return View(mois);
        }

        // POST: Mois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mois == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mois'  is null.");
            }
            var mois = await _context.Mois.FindAsync(id);
            if (mois != null)
            {
                _context.Mois.Remove(mois);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoisExists(int id)
        {
          return (_context.Mois?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
