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
    public class IndexModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public IndexModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Phone != null)
            {
                Phone = await _context.Phone.ToListAsync();
            }
        }
    }
}
