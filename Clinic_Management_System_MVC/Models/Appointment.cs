using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Management_System_MVC.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public Doctor? Doctor { get; set; }

        [Range(1, int.MaxValue)]
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public Patient? Patient { get; set; }

        [Range(1, int.MaxValue)]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
    }
}
