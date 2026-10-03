using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System_MVC.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
