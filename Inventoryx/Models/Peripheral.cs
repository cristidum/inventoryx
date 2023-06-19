using System.ComponentModel.DataAnnotations;

namespace Inventoryx.Models
{
    public class Peripheral
    {
        public int PeripheralId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string? AcquisitionCompany { get; set; }
        public GeneralStatus Status { get; set; }
        public string Location { get; set; }
        public string? Details { get; set; }
    }
}
