using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Data;
using Inventoryx.Models;

namespace Inventoryx.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public IndexModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync(string nameSearch)
        {
            if (_context.Employee != null)
            {
                ViewData["NameFilter"] = nameSearch;

                var employee = from e in _context.Employee
                               select e;

                if (!String.IsNullOrEmpty(nameSearch))
                {
                    employee = employee.Where(s =>
                        s.FirstName.Contains(nameSearch) || s.LastName.Contains(nameSearch)
                    );
                }

                Employee = await employee.ToListAsync();
            }
        }
    }
}
