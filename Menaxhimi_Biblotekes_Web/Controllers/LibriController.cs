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
        public async Task<IActionResult> Index(string sortOrder, string search)
        {
            ViewData["TitulliSort"] = String.IsNullOrEmpty(sortOrder) ? "titulli_desc" : "";
            ViewData["VitiSort"] = sortOrder == "Viti" ? "viti_desc" : "Viti";
            ViewData["LibriFilter"] = search;
            var librat = _context.Libri.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                librat = librat.Where(s => s.Titulli.ToUpper().Contains(search.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "titulli_desc":
                    librat = librat.OrderByDescending(s => s.Titulli).ToList();
                    break;
                case "Viti":
                    librat = librat.OrderBy(s => s.VitiBotimit).ToList();
                    break;
                case "viti_desc":
                    librat = librat.OrderByDescending(s => s.VitiBotimit).ToList();
                    break;
                default:
                    librat = librat.OrderBy(s => s.Titulli).ToList();
                    break;
            }
            return View(librat);
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
            foreach (Autori autori in Autoret)
            {
                a.Autoret.Add(new SelectListItem { Text = autori.Emri + " " + autori.Mbiemri, Value = autori.Id.ToString() });
            }
            ICollection<Kategoria> Kategorite = _context.Kategoria.ToList();
            a.Kategorite = new List<SelectListItem>();
            foreach (var k in Kategorite)
            {
                a.Kategorite.Add(new SelectListItem { Text = k.Name, Value = k.KategoriaID.ToString() });
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
            ICollection<Autori> Autoret = _context.Autori.ToList();
            Autoresia a = new Autoresia();
            ICollection<Kategoria> Kategorite = _context.Kategoria.ToList();
            a.Kategorite = new List<SelectListItem>();
            foreach (var k in Kategorite)
            {
                a.Kategorite.Add(new SelectListItem { Text = k.Name, Value = k.KategoriaID.ToString() });
            }
            var libri = await _context.Libri.FindAsync(id);
            if (libri == null)
            {
                return NotFound();
            }
            a.Libri = libri;
            return View(a);
        }

        // POST: Libris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Autoresia autoresia)
        {
            if (id != autoresia.Libri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Libri.Update(autoresia.Libri);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(autoresia);
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
