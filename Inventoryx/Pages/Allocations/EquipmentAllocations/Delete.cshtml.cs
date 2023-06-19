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
    public class DeleteModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public DeleteModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EquipmentAllocation EquipmentAllocation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipmentAllocation == null)
            {
                return NotFound();
            }

            var equipmentallocation = await _context.EquipmentAllocation.FirstOrDefaultAsync(m => m.EquipmentAllocationId == id);

            if (equipmentallocation == null)
            {
                return NotFound();
            }
            else 
            {
                EquipmentAllocation = equipmentallocation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EquipmentAllocation == null)
            {
                return NotFound();
            }
            var equipmentallocation = await _context.EquipmentAllocation.FindAsync(id);

            if (equipmentallocation != null)
            {
                EquipmentAllocation = equipmentallocation;
                _context.EquipmentAllocation.Remove(EquipmentAllocation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
