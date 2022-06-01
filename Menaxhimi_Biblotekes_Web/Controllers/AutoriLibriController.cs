using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menaxhimi_Biblotekes_Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Menaxhimi_Biblotekes_Web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AutoriLibriController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public AutoriLibriController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: AutoriLibri
        public async Task<IActionResult> Index()
        {
            var biblotekaDbContext = _context.AutoriLibri.Include(a => a.Autori).Include(a => a.Libri);
            return View(await biblotekaDbContext.ToListAsync());
        }

       
        // GET: AutoriLibri/Create
        public IActionResult Create()
        {
            ViewData["AutoriId"] = new SelectList(_context.Autori,"Id","Emri");
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Titulli");
            return View();
        }

        // POST: AutoriLibri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibriId,AutoriId")] AutoriLibri autoriLibri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoriLibri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoriId"] = new SelectList(_context.Autori, "Id", "Id");
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "Id");
            return View(autoriLibri);
        }

        // GET: AutoriLibri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoriLibri = await _context.AutoriLibri.FindAsync(id);
            if (autoriLibri == null)
            {
                return NotFound();
            }
            ViewData["Autori"] = new SelectList(_context.Autori,"Id","Emri",autoriLibri.AutoriId);
            ViewData["Libri"] = new SelectList(_context.Libri, "Id","Titulli",autoriLibri.LibriId);
            return View(autoriLibri);
        }

        // POST: AutoriLibri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibriId,AutoriId")] AutoriLibri autoriLibri)
        {
            if (id != autoriLibri.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoriLibri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoriLibriExists(autoriLibri.Id))
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
            return View(autoriLibri);
        }

        // GET: AutoriLibri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoriLibri = await _context.AutoriLibri
                .Include(a => a.Autori)
                .Include(a => a.Libri)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoriLibri == null)
            {
                return NotFound();
            }

            return View(autoriLibri);
        }

        // POST: AutoriLibri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoriLibri = await _context.AutoriLibri.FindAsync(id);
            _context.AutoriLibri.Remove(autoriLibri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoriLibriExists(int id)
        {
            return _context.AutoriLibri.Any(e => e.Id == id);
        }
    }
}
