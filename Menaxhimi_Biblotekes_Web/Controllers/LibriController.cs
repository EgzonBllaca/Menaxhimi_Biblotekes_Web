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
            ICollection<Autori> Autoret = _context.Autori.ToList();
            Autoresia a = new Autoresia();
            a.Autoret = new List<SelectListItem>();
            foreach(Autori autori in Autoret)
            {
                a.Autoret.Add(new SelectListItem { Text = autori.Emri + " " + autori.Mbiemri, Value = autori.Id.ToString() });
            }
            ICollection<Kategoria> Kategorite = _context.Kategoria.ToList();
            a.Kategorite = new List<SelectListItem>();
            foreach (var k in Kategorite)
            {
                a.Kategorite.Add(new SelectListItem { Text = k.Name , Value = k.KategoriaID.ToString() });
            }
            return View(a);
        }

        // POST: Libris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autoresia autoresia)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction()) 
                {
                    try
                    {
                        _context.Libri.Add(autoresia.Libri);
                        await _context.SaveChangesAsync();

                        ICollection<AutoriLibri> autoriLibri = new List<AutoriLibri>();
                        foreach (var item in autoresia.AutoriIds)
                        {
                            autoriLibri.Add(new AutoriLibri { LibriId = autoresia.Libri.Id, AutoriId = item });
                        }
                        _context.AutoriLibri.AddRange(autoriLibri);
                        await _context.SaveChangesAsync();

                        KategoriaLibri k = new KategoriaLibri { LibriId = autoresia.Libri.Id, KategoriaId = autoresia.KategoriaId };
                        _context.KategoriaLibri.Add(k);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
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
