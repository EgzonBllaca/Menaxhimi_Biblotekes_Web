﻿using System;
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
    public class PjesemarresiController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public PjesemarresiController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: Pjesemarresis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pjesemarresi.ToListAsync());
        }

        // GET: Pjesemarresis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesemarresi = await _context.Pjesemarresi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pjesemarresi == null)
            {
                return NotFound();
            }

            return View(pjesemarresi);
        }

        // GET: Pjesemarresis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pjesemarresis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoliId,Emri,Mbiemri,Email,Perdoruesi,Fjalekalimi,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Pjesemarresi pjesemarresi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pjesemarresi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pjesemarresi);
        }

        // GET: Pjesemarresis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesemarresi = await _context.Pjesemarresi.FindAsync(id);
            if (pjesemarresi == null)
            {
                return NotFound();
            }
            return View(pjesemarresi);
        }

        // POST: Pjesemarresis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoliId,Emri,Mbiemri,Email,Perdoruesi,Fjalekalimi,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] Pjesemarresi pjesemarresi)
        {
            if (id != pjesemarresi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pjesemarresi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PjesemarresiExists(pjesemarresi.Id))
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
            return View(pjesemarresi);
        }

        // GET: Pjesemarresis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesemarresi = await _context.Pjesemarresi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pjesemarresi == null)
            {
                return NotFound();
            }

            return View(pjesemarresi);
        }

        // POST: Pjesemarresis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pjesemarresi = await _context.Pjesemarresi.FindAsync(id);
            _context.Pjesemarresi.Remove(pjesemarresi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PjesemarresiExists(int id)
        {
            return _context.Pjesemarresi.Any(e => e.Id == id);
        }
    }
}