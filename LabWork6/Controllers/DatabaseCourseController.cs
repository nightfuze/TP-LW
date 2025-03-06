using System;
using System.Web.Mvc;
using System.Web.WebPages;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [HandleError(ExceptionType = typeof(FormatException), View = "FormatError")]
    public class DatabaseCourseController : Controller
    {
        // GET: DatabaseCourse
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [CustomIdFilter]
        public ActionResult Index(FormCollection collection)
        {
            var id = Request.Form["id"];
            if (id.IsEmpty())
            {
                return View();
            }

            TempData["DatabaseType"] = Request.Form["DatabaseType"];
            TempData["Description"] = collection["Description"];

            var databaseName = Request.Form["DatabaseName"];
            var isActive = collection["IsActive"].Contains("true");

            return RedirectToRoute(new
            {
                controller = "DatabaseCourse",
                action = "Details",
                id = id,
                DatabaseName = databaseName,
                IsActive = isActive
            });
        }

        // GET: DatabaseCourse/Details/5
        [CustomIdFilter]
        [CustomAuthFilter]
        [CustomExceptionFilter]
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            ViewBag.IsActive = Request.QueryString["IsActive"];
            ViewBag.DatabaseName = Request.QueryString["DatabaseName"];
            ViewBag.DatabaseType = TempData["DatabaseType"];
            ViewBag.Description = TempData["Description"];

            return View();
        }

        // GET: DatabaseCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatabaseCourse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
        }

        // GET: DatabaseCourse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatabaseCourse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DatabaseCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatabaseCourse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
