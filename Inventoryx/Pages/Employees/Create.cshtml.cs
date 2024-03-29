﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Employees
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
        public Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
                if (!ModelState.IsValid || _context.Employee == null || Employee == null)
                {
                    return Page();
                }

                _context.Employee.Add(Employee);

                await _context.SaveChangesAsync();
           

               

                return RedirectToPage("./Index");
            

        }
    }
}
