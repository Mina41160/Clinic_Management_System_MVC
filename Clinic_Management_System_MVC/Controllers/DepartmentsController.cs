using Microsoft.AspNetCore.Mvc;
using Clinic_Management_System_MVC.Data;
using Clinic_Management_System_MVC.Controllers;
using Clinic_Management_System_MVC.Models;

namespace Clinic_Management_System_MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            ViewBag.Title = "Clinic Management System";

            ViewData["Company Owner "] = "Mina Shenouda ";


            return View(_context.Departments.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }


        public IActionResult Details(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);
        }


        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed (int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
