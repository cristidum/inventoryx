using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventoryx.Data;
using Inventoryx.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventoryx.Pages.Equipments
{
    public class CreateModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public CreateModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Equipment Equipment { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Equipment == null || Equipment == null)
            {
                return Page();
            }

            int snCheck = 0;
            int nameCheck = 0;

            try
            {
                snCheck = _context.Equipment // tries to grab an Equipment with this serial number
                    .Where(a => a.SerialNumber == Equipment.SerialNumber)
                    .Select(b => b.EquipmentId)
                    .FirstOrDefault();

                nameCheck = _context.Equipment // tries to grab an Equipment with this compunter name
                    .Where(a => a.ADName == Equipment.ADName)
                    .Select(b => b.EquipmentId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {

            }

            if (snCheck != 0)
            {
                ModelState.AddModelError("DuplicateSN", "This serial number already exists");
                return Page();
            }
            else if(nameCheck != 0)
            {
                ModelState.AddModelError("DuplicateADName", "This Computer Name already exists");
                return Page();
            }
            else
            {
                _context.Equipment.Add(Equipment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


        }
    }
}
