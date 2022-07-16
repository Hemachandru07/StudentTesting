using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTesting.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace StudentTesting.Controllers
{

    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var canAcess = false;

            // check the refer
            var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                var rUri = new System.UriBuilder(referer).Uri;
                var req = filterContext.HttpContext.Request;
                if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                {
                    canAcess = true;
                }
            }

            // ... check other requirements

            if (!canAcess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }

    public class LoginController : Controller
    {
        private readonly StudentDBContext db;
        private readonly ISession Session;
        public LoginController(StudentDBContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db= _db;
            Session = httpContextAccessor.HttpContext.Session;
        }

        //--------------Student Login----------

        [NoDirectAccess]
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

        [NoDirectAccess]
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


        //------------Teacher Login----------

        [NoDirectAccess]
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

        [NoDirectAccess]
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

        //public IActionResult SearchForm()
        //{
        //    return View();
        //}

        //public IActionResult SearchResult(string SearchPhrase)
        //{
        //    return View(db.studenttbls.Where(i => i.Reg_no.Contains(SearchPhrase)).ToList());
        //}



    }
}
