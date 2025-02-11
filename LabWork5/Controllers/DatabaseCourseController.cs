using LabWork5.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork5.Controllers
{
    public class DatabaseCourseController : Controller
    {
        private static List<DatabaseCourseModel> courses = new List<DatabaseCourseModel>();

        static DatabaseCourseController()
        {
            Helpers.DatabaseCourseHelper.GetMockDatabaseCourseList()
                .ForEach(courses.Add);
        }

        // GET: DatabaseCourseController
        public ActionResult Index()
        {
            TempData["UseInternalMethod"] = true;
            return View(courses);
        }

        // GET: DatabaseCourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = courses.Find(item => item.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: DatabaseCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DatabaseCourseModel model)
        {
            if (ModelState.IsValid)
            {
                model.CourseId = courses.LastOrDefault(model).CourseId + 1;
                courses.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: DatabaseCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = courses.Find(item => item.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: DatabaseCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DatabaseCourseModel model)
        {
            if (ModelState.IsValid)
            {
                var course = courses.Find(item => item.CourseId == id);

                if (course != null)
                {
                    course.CourseName = model.CourseName;
                    course.Description = model.Description;
                    course.Teacher = model.Teacher;
                    course.StartDate = model.StartDate;
                    course.EndDate = model.EndDate;
                    course.TeacherPhone = model.TeacherPhone;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: DatabaseCourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatabaseCourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
