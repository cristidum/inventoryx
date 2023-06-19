using System.ComponentModel.DataAnnotations;

namespace Inventoryx.Models
{
    public class Printer
    {
        public int PrinterId { get; set; }
        public string Name { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string? AcquisitionCompany { get; set; }
        public GeneralStatus Status { get; set; }
        public string Location { get; set; }
        public string? IP { get; set; }
        public string? PagesPrinted { get; set; }
        public string? Details { get; set; }
    }
}
