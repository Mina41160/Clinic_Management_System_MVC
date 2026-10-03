namespace Clinic_Management_System_MVC.ViewModels
{
    public class AppointmentCreateViewModel
    {
        public  int DepartmentId { get; set; }
        public  int DoctorId { get; set; }
        public  int PatientId { get; set; }
        public  DateTime AppointmentDate{ get; set; }
    }
}
