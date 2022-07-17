using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentTesting.Models;

namespace StudentTesting.Controllers
{
    public class MarksController : Controller
    {
        private readonly StudentDBContext _context;

        public MarksController(StudentDBContext context)
        {
            _context = context;
        }

        [NoDirectAccess]
        // GET: Marks
        public async Task<IActionResult> Index()
        {
            //if (HttpContext.Session.GetInt32("LoginStudentId") != null)
            //{
            //    Marks m = _context.marks.Find(HttpContext.Session.GetInt32("LoginStudentId"));
            //    List <Marks> marks = new List<Marks>();
            //    marks.Add(m);
            //    return View(marks);

            //}
            //else
            //{
            //    return View(await _context.marks.ToListAsync());
            //}
            var studentDBContext = _context.marks.Include(m => m.Studentid);
            return View(await studentDBContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            
            var studentDBContext = _context.marks.Include(m => m.Studentid);
            return View(await studentDBContext.ToListAsync());
        }


        [NoDirectAccess]
        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.marks
                .Include(m => m.Studentid)
                .FirstOrDefaultAsync(m => m.MarksId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        [NoDirectAccess]
        // GET: Marks/Create
        public IActionResult Create()
        {
            var result = new SelectList(from i in _context.studenttbls select i.StudentId).ToList();
            ViewBag.StudentId = result;
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarksId,Subject1,Subject2,Subject3,Subject4,Subject5,Subject6,StudentId")] Marks marks)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["StudentId"] = new SelectList(_context.studenttbls, "StudentId", "Department", marks.StudentId);
            //return View(marks);
        }


        // GET: Marks/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.studenttbls, "StudentId", "Department", marks.StudentId);
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarksId,Subject1,Subject2,Subject3,Subject4,Subject5,Subject6,StudentId")] Marks marks)
        {
            if (id != marks.MarksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.MarksId))
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
            ViewData["StudentId"] = new SelectList(_context.studenttbls, "StudentId", "Department", marks.StudentId);
            return View(marks);
        }

        // GET: Marks/Delete/5
        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.marks
                .Include(m => m.Studentid)
                .FirstOrDefaultAsync(m => m.MarksId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marks = await _context.marks.FindAsync(id);
            _context.marks.Remove(marks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool MarksExists(int id)
        {
            return _context.marks.Any(e => e.MarksId == id);
        }
    }
}
