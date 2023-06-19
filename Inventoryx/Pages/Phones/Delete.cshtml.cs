using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Phones
{
    public class DeleteModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public DeleteModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Phone Phone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.FirstOrDefaultAsync(m => m.PhoneId == id);

            if (phone == null)
            {
                return NotFound();
            }
            else 
            {
                Phone = phone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }
            var phone = await _context.Phone.FindAsync(id);

            if (phone != null)
            {
                Phone = phone;
                _context.Phone.Remove(Phone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
