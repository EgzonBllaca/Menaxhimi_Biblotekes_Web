﻿using Menaxhimi_Biblotekes_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    [Authorize]
    public class MesazhetController : Controller
    {
        private readonly BiblotekaDbContext _context;

        public MesazhetController(BiblotekaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Mesazhet m)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    m.PjesemarresiId = 1;
                    var model = _context.Mesazhet.Add(m);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            return View();
        }
    }
}
