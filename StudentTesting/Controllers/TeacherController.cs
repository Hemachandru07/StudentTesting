﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentTesting.Models;

namespace StudentTesting.Controllers
{
    public class TeacherController : Controller
    {
        private readonly StudentDBContext _context;

        public TeacherController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public async Task<IActionResult> Index()
        {
            return View(await _context.teachertbls.ToListAsync());
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachertbl = await _context.teachertbls
                .FirstOrDefaultAsync(m => m.FacultyId == id);
            if (teachertbl == null)
            {
                return NotFound();
            }

            return View(teachertbl);
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultyId,FacultyName,Department,PassWord,CPassWord")] Teachertbl teachertbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachertbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachertbl);
        }

        // GET: Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachertbl = await _context.teachertbls.FindAsync(id);
            if (teachertbl == null)
            {
                return NotFound();
            }
            return View(teachertbl);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultyId,FacultyName,Department,PassWord,CPassWord")] Teachertbl teachertbl)
        {
            if (id != teachertbl.FacultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachertbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachertblExists(teachertbl.FacultyId))
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
            return View(teachertbl);
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachertbl = await _context.teachertbls
                .FirstOrDefaultAsync(m => m.FacultyId == id);
            if (teachertbl == null)
            {
                return NotFound();
            }

            return View(teachertbl);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachertbl = await _context.teachertbls.FindAsync(id);
            _context.teachertbls.Remove(teachertbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TeacherMain()
        {
            return View();
        }
        private bool TeachertblExists(int id)
        {
            return _context.teachertbls.Any(e => e.FacultyId == id);
        }
    }
}