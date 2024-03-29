﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menaxhimi_Biblotekes_Web.Models;
using Menaxhimi_Biblotekes.Models;
using Microsoft.AspNetCore.Authorization;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    public class KerkesatPerHuazimController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public KerkesatPerHuazimController(BiblotekaDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        // POST: KerkesatPerHuazim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize (Roles ="Reader")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id/*[Bind("Id,LibriId,PjesemarresiId,DataKerkeses,IsDeleted,IsActive,CreatedByUserID,CreatedOn,LastUpdatedByUserID,LastUpdatedOn")] KerkesatPerHuazim kerkesatPerHuazim*/)
        {
            KerkesatPerHuazim kerkesatPerHuazim = new KerkesatPerHuazim { DataKerkeses = DateTime.Now, LibriId = id, PjesemarresiId = 1};
            var check = _context.KerkesatPerHuazim.Where(x => x.LibriId == kerkesatPerHuazim.LibriId && x.PjesemarresiId == kerkesatPerHuazim.PjesemarresiId).FirstOrDefault();
            if (check == null)
            {
                var check2 = _context.Huazimi.Where(x => x.LibriId == kerkesatPerHuazim.LibriId && x.PjesemarresiId == kerkesatPerHuazim.PjesemarresiId).FirstOrDefault();
                if(check2 is null)
                {
                    _context.KerkesatPerHuazim.Add(kerkesatPerHuazim);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "Libri");
            /*
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "ISBN", kerkesatPerHuazim.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Email", kerkesatPerHuazim.PjesemarresiId);*/
            //return View(kerkesatPerHuazim);
        }

        // GET: KerkesatPerHuazim/Edit/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kerkesatPerHuazim = await _context.KerkesatPerHuazim.FindAsync(id);
            var libri = await _context.Libri.FindAsync(kerkesatPerHuazim.LibriId);
            var pjesemarresi = await _context.Pjesemarresi.FindAsync(kerkesatPerHuazim.PjesemarresiId);
            kerkesatPerHuazim.Libri = libri;
            kerkesatPerHuazim.Pjesemarresi = pjesemarresi;
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

        [Authorize(Roles = "Admin")]
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
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Huazimi huazimi = new Huazimi
                        {
                            LibriId = kerkesatPerHuazim.LibriId,
                            PjesemarresiId = kerkesatPerHuazim.PjesemarresiId,
                            AfatiKthimit = kerkesatPerHuazim.DataKerkeses,
                            DataHuazimit = DateTime.Now
                        };
                        _context.KerkesatPerHuazim.Remove(kerkesatPerHuazim);
                        await _context.SaveChangesAsync();
                        _context.Huazimi.Add(huazimi);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
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
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }/*
            ViewData["LibriId"] = new SelectList(_context.Libri, "Id", "ISBN", kerkesatPerHuazim.LibriId);
            ViewData["PjesemarresiId"] = new SelectList(_context.Pjesemarresi, "Id", "Email", kerkesatPerHuazim.PjesemarresiId);*/
            return View(kerkesatPerHuazim);
        }


        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
