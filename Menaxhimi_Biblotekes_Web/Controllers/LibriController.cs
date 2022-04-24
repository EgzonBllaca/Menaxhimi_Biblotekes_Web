using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menaxhimi_Biblotekes_Web.Models;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    public class LibriController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public LibriController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: Libris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libri.ToListAsync());
        }

        // GET: Libris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libri = await _context.Libri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libri == null)
            {
                return NotFound();
            }

            return View(libri);
        }

        // GET: Libris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriaId,Titulli,Image,Pershkrimi,ISBN,ShtepiaBotuese,VitiBotimit,NrKopjeve,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Libri libri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libri);/*
                [Bind("")]
                _context.Add()*/
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libri);
        }

        // GET: Libris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libri = await _context.Libri.FindAsync(id);
            if (libri == null)
            {
                return NotFound();
            }
            return View(libri);
        }

        // POST: Libris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriaId,Titulli,Image,Pershkrimi,ISBN,ShtepiaBotuese,VitiBotimit,NrKopjeve,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Libri libri)
        {
            if (id != libri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibriExists(libri.Id))
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
            return View(libri);
        }

        // GET: Libris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libri = await _context.Libri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libri == null)
            {
                return NotFound();
            }

            return View(libri);
        }

        // POST: Libris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libri = await _context.Libri.FindAsync(id);
            _context.Libri.Remove(libri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibriExists(int id)
        {
            return _context.Libri.Any(e => e.Id == id);
        }
    }
}
