using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Allocations.EquipmentAllocations
{
    public class IndexModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public IndexModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EquipmentAllocation> EquipmentAllocation { get;set; } = default!;

        public async Task OnGetAsync(string employeeName, string eqName, DateTime allocDate, string serialNumber)
        {
            if (_context.EquipmentAllocation != null)
            {
                ViewData["EmployeeName"] = employeeName;
                ViewData["EquipmentName"] = eqName;
                ViewData["AllocationDate"] = allocDate;
                ViewData["SerialNumber"] = serialNumber;

                var eqAllocation = from e in _context.EquipmentAllocation
                                   select e;

                if (!String.IsNullOrEmpty(employeeName))
                {
                    eqAllocation = eqAllocation.Where(e =>
                        e.EmployeeName.Contains(employeeName)
                    );
                }

                if (!String.IsNullOrEmpty(eqName))
                {
                    eqAllocation = eqAllocation.Where(e =>
                        e.EquipmentName.Contains(eqName)
                    );
                }

                if (!String.IsNullOrEmpty(serialNumber))
                {
                    eqAllocation = eqAllocation.Where(e =>
                        e.EquipmentSN.Contains(serialNumber)
                    );
                }

                EquipmentAllocation = await eqAllocation.ToListAsync();
            }
        }
    }
}
