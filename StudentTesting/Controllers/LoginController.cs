﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTesting.Models;
using System.Linq;
using System;

namespace StudentTesting.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentDBContext db;
        private readonly ISession Session;
        public LoginController(StudentDBContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db= _db;
            Session = httpContextAccessor.HttpContext.Session;
        }

        /*--------------Student Login----------*/

        public IActionResult SLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SLogin(Studenttbl s)
        {
            var result = (from i in db.studenttbls where i.StudentId == s.StudentId && i.Password == s.Password select i).SingleOrDefault();
            if(result != null)
            {
                HttpContext.Session.SetString("StudentName", result.StudentName);
                return RedirectToAction("StudentMain","Student");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        
        public IActionResult SRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SRegister(Studenttbl obj)
        {
            ViewBag.StudentId = obj.StudentId;
            if (obj.StudentId != null)
            {
                db.studenttbls.Add(obj);
                db.SaveChanges();
                HttpContext.Session.SetInt32("StudentId", obj.StudentId);
                return View();
            }
            else 
            { 
                return View(); 
            }

        }


        /*------------Teacher Login----------*/

        public IActionResult TLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TLogin(Teachertbl t)
        {
            var result = (from i in db.teachertbls where i.FacultyId == t.FacultyId && i.Password == t.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("FacultyName", result.FacultyName);
                return RedirectToAction("TeacherMain","Teacher");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout1()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult TRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TRegister(Teachertbl t)
        {
            ViewBag.FacultyId = t.FacultyId;
            if (t.FacultyId != null)
            {
                db.teachertbls.Add(t);
                db.SaveChanges();
                HttpContext.Session.SetInt32("FacultyId", t.FacultyId);
                return View();
            }
            else 
            { 
                return View(); 
            }
        }



    }
}