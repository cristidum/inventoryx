using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Equipments
{
    public class DeleteModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public DeleteModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FirstOrDefaultAsync(m => m.EquipmentId == id);

            if (equipment == null)
            {
                return NotFound();
            }
            else 
            {
                Equipment = equipment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment != null)
            {
                Equipment = equipment;
                _context.Equipment.Remove(Equipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
