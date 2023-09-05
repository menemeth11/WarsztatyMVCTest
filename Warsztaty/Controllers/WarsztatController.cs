using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warsztaty.Entities;

namespace Warsztaty.Controllers
{
    public class WarsztatController : Controller
    {
        private readonly AppDbContext _context;

        public WarsztatController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Warsztat
        public async Task<IActionResult> Index()
        {
              return _context.Warsztaty != null ? 
                          View(await _context.Warsztaty.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Warsztaty'  is null.");
        }

        // GET: Warsztat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Warsztaty == null)
            {
                return NotFound();
            }

            var warsztatEntity = await _context.Warsztaty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warsztatEntity == null)
            {
                return NotFound();
            }

            return View(warsztatEntity);
        }

        // GET: Warsztat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warsztat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desciption,Address,PhoneNumber")] WarsztatEntity warsztatEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warsztatEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warsztatEntity);
        }

        // GET: Warsztat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Warsztaty == null)
            {
                return NotFound();
            }

            var warsztatEntity = await _context.Warsztaty.FindAsync(id);
            if (warsztatEntity == null)
            {
                return NotFound();
            }
            return View(warsztatEntity);
        }

        // POST: Warsztat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desciption,Address,PhoneNumber")] WarsztatEntity warsztatEntity)
        {
            if (id != warsztatEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warsztatEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarsztatEntityExists(warsztatEntity.Id))
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
            return View(warsztatEntity);
        }

        // GET: Warsztat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Warsztaty == null)
            {
                return NotFound();
            }

            var warsztatEntity = await _context.Warsztaty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warsztatEntity == null)
            {
                return NotFound();
            }

            return View(warsztatEntity);
        }

        // POST: Warsztat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Warsztaty == null)
            {
                return Problem("Entity set 'AppDbContext.Warsztaty'  is null.");
            }
            var warsztatEntity = await _context.Warsztaty.FindAsync(id);
            if (warsztatEntity != null)
            {
                _context.Warsztaty.Remove(warsztatEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarsztatEntityExists(int id)
        {
          return (_context.Warsztaty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
