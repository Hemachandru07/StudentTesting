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
    public class StudentController : Controller
    {
        private readonly StudentDBContext _context;

        public StudentController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: Student
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetInt32("LoginStudentId") != null)
            {
                Studenttbl s = _context.studenttbls.Find(HttpContext.Session.GetInt32("LoginStudentId"));
                List<Studenttbl> studenttbls = new List<Studenttbl>();
                studenttbls.Add(s);
                return View(studenttbls);
            }
            else
            {
                return View(await _context.studenttbls.ToListAsync());
            }
           
        }

        

        // GET: Student/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenttbl = await _context.studenttbls
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studenttbl == null)
            {
                return NotFound();
            }

            return View(studenttbl);
        }

        // GET: Student/Create
        [NoDirectAccess]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Reg_no,DOB,Mobile_No,StudentEmail,Department,Password,CPassword")] Studenttbl studenttbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenttbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenttbl);
        }

        // GET: Student/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenttbl = await _context.studenttbls.FindAsync(id);
            if (studenttbl == null)
            {
                return NotFound();
            }
            return View(studenttbl);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Reg_no,DOB,Mobile_No,StudentEmail,Department,Password")] Studenttbl studenttbl)
        {
            if (id != studenttbl.StudentId)
            {
                return NotFound();
            }

            if (id == studenttbl.StudentId)
            {
                try
                {
                    _context.Update(studenttbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudenttblExists(studenttbl.StudentId))
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
            return View(studenttbl);
        }

        // GET: Student/Delete/5
        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenttbl = await _context.studenttbls
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studenttbl == null)
            {
                return NotFound();
            }

            return View(studenttbl);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studenttbl = await _context.studenttbls.FindAsync(id);
            _context.studenttbls.Remove(studenttbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NoDirectAccess]
        public IActionResult StudentMain()
        {
             return View();
        }

        private bool StudenttblExists(int id)
        {
            return _context.studenttbls.Any(e => e.StudentId == id);
        }
    }
}
