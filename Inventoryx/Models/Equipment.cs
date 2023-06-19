using Inventoryx.Data;
using Inventoryx.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventoryx.Models
{

    [Index(nameof(SerialNumber), IsUnique =true)]
    [Index(nameof(ADName), IsUnique = true)]

    public class Equipment
    {
        public int EquipmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string? ADName { get; set; }
        public string? Configuration { get; set; }
        public string? WindowsLicence { get; set; }
        public string? OfficeLicence { get; set; }
        public string? AcquisitionCompany { get; set; }
        public GeneralStatus Status { get; set; } = GeneralStatus.Unallocated;
        public string Location { get; set; }
        public string? Details { get; set; }

        public string FullName
        {
            get { return Name + " " + SerialNumber; }
        }

    }

}
