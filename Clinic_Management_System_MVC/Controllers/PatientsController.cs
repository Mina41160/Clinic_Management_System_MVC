using Clinic_Management_System_MVC.Data;
using Clinic_Management_System_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System_MVC.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var patients = _context.Patients.ToList();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(patient);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Update(patient);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(patient);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound();

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
