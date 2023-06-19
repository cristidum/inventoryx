using System.ComponentModel.DataAnnotations;

namespace Inventoryx.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Details { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
