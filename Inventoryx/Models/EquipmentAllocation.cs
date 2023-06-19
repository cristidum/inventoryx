using Inventoryx.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Inventoryx.Models
{
    public class EquipmentAllocation
    {
        public int EquipmentAllocationId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EquipmentName { get; set; }
        public string? EquipmentSN { get; set; }
        public DateTime AllocationDate { get; set; } = DateTime.Now.Date;
        public bool IsActive { get; set; } = true;
        public string? Details { get; set; }
    }
}
