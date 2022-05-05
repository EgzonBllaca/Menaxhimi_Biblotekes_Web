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
    public class PjesemarresiController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public PjesemarresiController(BiblotekaDbContext context)
        {
            _context = context;
        }

        // GET: Pjesemarresis
        public async Task<IActionResult> Index(string search)
        {
            ViewData["PjesemarresiFilter"] = search;
            var pjesemarresit = _context.Pjesemarresi.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                pjesemarresit = pjesemarresit.Where(s => s.Emri.ToUpper().Contains(search.ToUpper())||s.Mbiemri.ToUpper().Contains(search.ToUpper())).ToList();
            }
            return View(pjesemarresit);
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
            var roli = await _context.Roli.FirstOrDefaultAsync(m => m.Id == pjesemarresi.RoliId);
            pjesemarresi.Roli = roli;
            //RoliPjesemarresit rp = new RoliPjesemarresit { Pjesemarresi = pjesemarresi, Roli = roli };

            return View(pjesemarresi);
        }

        // GET: Pjesemarresis/Create
        public IActionResult Create()
        {
            ICollection<Roli> Rolet = _context.Roli.ToList();
            RoliPjesemarresit p = new RoliPjesemarresit();
            p.Rolet = new List<SelectListItem>();
            foreach (Roli r in Rolet)
            {
                p.Rolet.Add(new SelectListItem { Text = r.Pershkrimi, Value = r.Id.ToString() });
            }
            return View(p);
        }

        // POST: Pjesemarresis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoliPjesemarresit roliPjesemarresit)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        roliPjesemarresit.Pjesemarresi.RoliId = roliPjesemarresit.RoliId;
                        _context.Pjesemarresi.Add(roliPjesemarresit.Pjesemarresi);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        
                    }
                return RedirectToAction(nameof(Index));
            }
            return View();
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
            List<SelectListItem> rolet = new List<SelectListItem>();
            var roli =  _context.Roli.ToList();
            foreach (var item in roli)
            {
                rolet.Add(new SelectListItem { Text = item.Pershkrimi, Value = item.Id.ToString() });
            }
            RoliPjesemarresit rp = new RoliPjesemarresit { Pjesemarresi = pjesemarresi, Rolet = rolet };
            return View(rp);
        }

        // POST: Pjesemarresis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pjesemarresi pjesemarresi)
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
