using Clinic_Management_System_MVC.Data;
using Clinic_Management_System_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System_MVC.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors
                    .Include(d => d.Department)
                    .ToList();

            return View(doctors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _context.Departments.ToList();

            var selectlist = new SelectList(departments,"Id","Name");

            ViewBag.Departments = selectlist;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            var departments = _context.Departments.ToList();
            var selectlist = new SelectList(departments, "Id", "Name");

            ViewBag.Departments = selectlist;

            return View(doctor);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var doctor = _context.Doctors.Include(d => d.Department).FirstOrDefault(c => c.Id == id);

            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
                return NotFound();

            var departments = _context.Departments.ToList();

            var selectlist = new SelectList(departments, "Id", "Name", doctor.DepartmentId);

            ViewBag.Departments = selectlist;

            return View(doctor);
        }

        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Update(doctor);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            var departments = _context.Departments.ToList();
            var selectlist = new SelectList(departments, "Id", "Name");

            ViewBag.Departments = selectlist;


            return View(doctor);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
                return NotFound();

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

