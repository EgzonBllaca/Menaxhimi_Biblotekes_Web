using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menaxhimi_Biblotekes_Web.Models;
using Menaxhimi_Biblotekes.Models;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    public class KerkesatPerHuazimController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public KerkesatPerHuazimController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: KerkesatPerHuazim
        public async Task<IActionResult> Index(string sortOrder)
        {
            var huazimi = _context.KerkesatPerHuazim.Include(k => k.Libri).Include(k => k.Pjesemarresi).ToList();
            ViewData["DataKerkeses"] = String.IsNullOrEmpty(sortOrder) ? "huazimi_desc" : "";
            switch (sortOrder)
            {
                case "huazimi_desc":
                    huazimi = huazimi.OrderByDescending(s => s.DataKerkeses).ToList();
                    break;
                default:
                    huazimi = huazimi.OrderBy(s => s.DataKerkeses).ToList();
                    break;
            }
            return View(huazimi);
        }

        // GET: KerkesatPerHuazim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kerkesatPerHuazim = await _context.KerkesatPerHuazim
                .Include(k => k.Libri)
                .Include(k => k.Pjesemarresi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kerkesatPerHuazim == null)
            {
                return NotFound();
            }

            return View(kerkesatPerHuazim);
        }

        // GET: KerkesatPerHuazim/Create
        public IActionResult Create()
        {
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Titulli");
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Perdoruesi");
            return View();
        }

        // POST: KerkesatPerHuazim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id/*[Bind("Id,LibriId,PjesemarresiId,DataKerkeses,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] KerkesatPerHuazim kerkesatPerHuazim*/)
        {


                KerkesatPerHuazim kerkesatPerHuazim = new KerkesatPerHuazim { DataKerkeses = DateTime.Now, LibriId = id, Pjesemarresi = new Pjesemarresi { Id = 1 } };
                _context.KerkesatPerHuazim.Add(kerkesatPerHuazim);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Libri");
            /*
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "ISBN", kerkesatPerHuazim.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Email", kerkesatPerHuazim.PjesemarresiId);*/
            //return View(kerkesatPerHuazim);
        }

        // GET: KerkesatPerHuazim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kerkesatPerHuazim = await _context.KerkesatPerHuazim.FindAsync(id);
            if (kerkesatPerHuazim == null)
            {
                return NotFound();
            }
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Titulli", kerkesatPerHuazim.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Perdoruesi", kerkesatPerHuazim.PjesemarresiId);
            return View(kerkesatPerHuazim);
        }

        // POST: KerkesatPerHuazim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibriId,PjesemarresiId,DataKerkeses,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] KerkesatPerHuazim kerkesatPerHuazim)
        {
            if (id != kerkesatPerHuazim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kerkesatPerHuazim.DataKerkeses = DateTime.Now;
                    _context.Update(kerkesatPerHuazim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KerkesatPerHuazimExists(kerkesatPerHuazim.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }/*
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "ISBN", kerkesatPerHuazim.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Email", kerkesatPerHuazim.PjesemarresiId);*/
            return View(kerkesatPerHuazim);
        }

        // GET: KerkesatPerHuazim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kerkesatPerHuazim = await _context.KerkesatPerHuazim
                .Include(k => k.Libri)
                .Include(k => k.Pjesemarresi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kerkesatPerHuazim == null)
            {
                return NotFound();
            }

            return View(kerkesatPerHuazim);
        }

        // POST: KerkesatPerHuazim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kerkesatPerHuazim = await _context.KerkesatPerHuazim.FindAsync(id);
            _context.KerkesatPerHuazim.Remove(kerkesatPerHuazim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KerkesatPerHuazimExists(int id)
        {
            return _context.KerkesatPerHuazim.Any(e => e.Id == id);
        }
    }
}
