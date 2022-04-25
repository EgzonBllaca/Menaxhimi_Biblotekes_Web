using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menaxhimi_Biblotekes.Models;
using Menaxhimi_Biblotekes_Web.Models;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    public class HuazimiController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public HuazimiController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: Huazimi
        public async Task<IActionResult> Index()
        {
            var biblotekaDbContext = _context.Huazimi.Include(h => h.Libri).Include(h => h.Pjesemarresi);
            return View(await biblotekaDbContext.ToListAsync());
        }

        // GET: Huazimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huazimi = await _context.Huazimi
                .Include(h => h.Libri)
                .Include(h => h.Pjesemarresi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (huazimi == null)
            {
                return NotFound();
            }

            return View(huazimi);
        }

        // GET: Huazimi/Create
        public IActionResult Create()
        {
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Id");
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Id");
            return View();
        }

        // POST: Huazimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibriId,PjesemarresiId,DataHuazimit,AfatiKthimit,DataKthimit,Verejtje,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Huazimi huazimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huazimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Id", huazimi.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Id", huazimi.PjesemarresiId);
            return View(huazimi);
        }

        // GET: Huazimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huazimi = await _context.Huazimi.FindAsync(id);
            if (huazimi == null)
            {
                return NotFound();
            }
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Id", huazimi.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Id", huazimi.PjesemarresiId);
            return View(huazimi);
        }

        // POST: Huazimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibriId,PjesemarresiId,DataHuazimit,AfatiKthimit,DataKthimit,Verejtje,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Huazimi huazimi)
        {
            if (id != huazimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huazimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuazimiExists(huazimi.Id))
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
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Id", huazimi.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Id", huazimi.PjesemarresiId);
            return View(huazimi);
        }

        // GET: Huazimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huazimi = await _context.Huazimi
                .Include(h => h.Libri)
                .Include(h => h.Pjesemarresi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (huazimi == null)
            {
                return NotFound();
            }

            return View(huazimi);
        }

        // POST: Huazimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huazimi = await _context.Huazimi.FindAsync(id);
            _context.Huazimi.Remove(huazimi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuazimiExists(int id)
        {
            return _context.Huazimi.Any(e => e.Id == id);
        }
    }
}
