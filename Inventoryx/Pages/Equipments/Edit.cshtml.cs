using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Equipments
{
    public class EditModel : PageModel
    {

        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public EditModel(Inventoryx.Data.ApplicationDbContext context)
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
            Equipment = equipment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Equipment).State = EntityState.Modified;

            int snCheck = 0;
            int nameCheck = 0;

            var oldEqSN = _context.Equipment
                .Where(a => a.EquipmentId == id)
                .Select(b => b.SerialNumber)
                .FirstOrDefault();

            var oldEqName = _context.Equipment
                .Where(a => a.EquipmentId == id)
                .Select(b => b.ADName)
                .FirstOrDefault();

            try
            {
                snCheck = _context.Equipment // tries to grab an Equipment with this serial number
                    .Where(a => a.SerialNumber == Equipment.SerialNumber && a.SerialNumber != oldEqSN)
                    .Select(b => b.EquipmentId)
                    .FirstOrDefault();

                nameCheck = _context.Equipment // tries to grab an Equipment with this compunter name
                    .Where(a => a.ADName == Equipment.ADName && a.ADName != oldEqName)
                    .Select(b => b.EquipmentId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {

            }

            if (snCheck != 0 )
            {
                ModelState.AddModelError("DuplicateSN", "This serial number already exists");
                return Page();
            }
            else if (nameCheck != 0)
            {
                ModelState.AddModelError("DuplicateADName", "This Computer Name already exists");
                return Page();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(Equipment.EquipmentId))
                {
                    return NotFound();
                }
                else
                {

                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EquipmentExists(int id)
        {
            return (_context.Equipment?.Any(e => e.EquipmentId == id)).GetValueOrDefault();
        }
    }
}
