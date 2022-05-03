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
    public class AutoriController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public AutoriController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: Autori
        public async Task<IActionResult> Index(string search)
        {
            ViewData["AutoriFilter"] = search;
            var autoret = _context.Autori.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                autoret = autoret.Where(s => s.Emri.ToUpper().Contains(search.ToUpper()) || s.Mbiemri.ToUpper().Contains(search.ToUpper())).ToList();
            }
            return View(autoret);
        }

        // GET: Autori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // GET: Autori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Mbiemri,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Autori autori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autori);
        }

        // GET: Autori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori.FindAsync(id);
            if (autori == null)
            {
                return NotFound();
            }
            return View(autori);
        }

        // POST: Autori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Mbiemri,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Autori autori)
        {
            if (id != autori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoriExists(autori.Id))
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
            return View(autori);
        }

        // GET: Autori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // POST: Autori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autori = await _context.Autori.FindAsync(id);
            _context.Autori.Remove(autori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoriExists(int id)
        {
            return _context.Autori.Any(e => e.Id == id);
        }
    }
}
