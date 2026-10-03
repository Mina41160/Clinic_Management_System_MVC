using Clinic_Management_System_MVC.Models;
using Clinic_Management_System_MVC.ViewModels;
using Clinic_Management_System_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace Clinic_Management_System_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context )
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel counts = new DashboardViewModel {
                DepartmentCount = _context.Departments.Count(),
                DoctorCount = _context.Doctors.Count(),
                PatientCount = _context.Patients.Count(),
                AppointmentCount = _context.Appointments.Count()
            };
            return View(counts);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
