using Clinic_Management_System_MVC.Controllers;
using Clinic_Management_System_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System_MVC.ViewModels
{
    public class DashboardViewModel
    {
        public  int DepartmentCount { get; set; }
        public  int DoctorCount { get; set; }
        public  int PatientCount { get; set; }
        public  int AppointmentCount { get; set; }
    }
}
