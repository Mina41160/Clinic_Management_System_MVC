using Clinic_Management_System_MVC.Data;
using Clinic_Management_System_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinic_Management_System_MVC.ViewModels;


namespace Clinic_Management_System_MVC.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d!.Department)
                .Include(a => a.Patient)
                .ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _context.Departments.ToList();

            var selectlist = new SelectList(departments, "Id", "Name");

            ViewBag.Departments = selectlist;

            var doctors = _context.Doctors.ToList();
            var selectlist1 = new SelectList(doctors, "Id", "Name");
            ViewBag.Doctors = selectlist1;

            var patients = _context.Patients.ToList();
            var selectlist2 = new SelectList(patients, "Id", "Name");
            ViewBag.Patients = selectlist2;

            var model = new AppointmentCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AppointmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    AppointmentDate = model.AppointmentDate
                };


                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            var departments = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(
                departments,
                "Id",
                "Name",
                model.DepartmentId
            );

            var doctors = _context.Doctors
                .Where(d => d.DepartmentId == model.DepartmentId)
                .ToList();

            ViewBag.Doctors = new SelectList(
                doctors,
                "Id",
                "Name",
                model.DoctorId
            );

            var patients = _context.Patients.ToList();
            ViewBag.Patients = new SelectList(
                patients,
                "Id",
                "Name",
                model.PatientId
            );


            return View(model);
        }

        public IActionResult GetDoctorsByDepartment(int departmentId)
        {
            var doctors = _context.Doctors
                .Where(d => d.DepartmentId == departmentId)
                .Select(d => new
                {
                    id = d.Id,
                    name = d.Name
                }).ToList();

            return Json(doctors);
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d=> d!.Department)
                .Include(a => a.Patient)
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            var doctors = _context.Doctors.ToList();
            var selectlist = new SelectList(doctors, "Id", "Name",appointment.DoctorId);
            ViewBag.Doctors = selectlist;

            var patients = _context.Patients.ToList();
            var selectlist1 = new SelectList(patients, "Id", "Name",appointment.PatientId);
            ViewBag.Patients = selectlist1;


            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            var doctors = _context.Doctors.ToList();
            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");

            var patients = _context.Patients.ToList();
            ViewBag.Patients = new SelectList(patients, "Id", "Name");

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d=> d!.Department)
                .Include(a => a.Patient)
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
