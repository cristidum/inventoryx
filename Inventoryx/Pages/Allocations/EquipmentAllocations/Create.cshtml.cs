using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventoryx.Data;
using Inventoryx.Models;
using Microsoft.Data.SqlClient;

namespace Inventoryx.Pages.Allocations.EquipmentAllocations
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

            this.ViewData["equipments"] = _context.Equipment
                .Where(x => x.Status == GeneralStatus.Unallocated)
                .Select(x => new SelectListItem
            {
                Value = x.EquipmentId.ToString(),
                Text = x.Name + " | " + x.SerialNumber

            }).ToList();

            this.ViewData["employees"] = _context.Employee.Select(x => new SelectListItem { 
                Value = x.EmployeeId.ToString(),
                Text = x.FirstName + " " + x.LastName
            }).ToList();

            return Page();

        }

        [BindProperty]
        public EquipmentAllocation EquipmentAllocation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.EquipmentAllocation == null || EquipmentAllocation == null)
            {
                return Page();
            }

            this.ViewData["equipments"] = _context.Equipment
                .Where(x => x.Status == GeneralStatus.Unallocated)
                .Select(x => new SelectListItem
            {
                Value = x.EquipmentId.ToString(),
                Text = x.Name + " | " + x.SerialNumber

            })
            .ToList();

            this.ViewData["employees"] = _context.Employee.Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.FirstName + " " + x.LastName
            }).ToList();


            int eqCheck = 0;

            try
            {
                eqCheck = _context.EquipmentAllocation// tries to grab an Equipment with this serial number
                    .Where(a => a.EquipmentId == EquipmentAllocation.EquipmentId && a.IsActive == true)
                    .Select(b => b.EquipmentAllocationId)
                    .FirstOrDefault();

            }
            catch (Exception)
            {

            }

            if (eqCheck != 0)
            {
                ModelState.AddModelError("DuplicateEQ", "This equipment is already alocated");
                return Page();
            }
            else
            {
                EquipmentAllocation.EquipmentName = _context.Equipment
                    .Where(a => a.EquipmentId == EquipmentAllocation.EquipmentId)
                    .Select(b => b.Name)
                    .FirstOrDefault();

                EquipmentAllocation.EquipmentSN = _context.Equipment
                    .Where(a => a.EquipmentId == EquipmentAllocation.EquipmentId)
                    .Select(b => b.SerialNumber)
                    .FirstOrDefault();

                EquipmentAllocation.EmployeeName = _context.Employee
                    .Where(a => a.EmployeeId == EquipmentAllocation.EmployeeId)
                    .Select(b => b.FirstName)
                    .FirstOrDefault()
                    +
                    " "
                    +
                    _context.Employee
                    .Where(a => a.EmployeeId == EquipmentAllocation.EmployeeId)
                    .Select(b => b.LastName)
                    .FirstOrDefault();

                var status = GeneralStatus.Assigned;

                var equipment = _context.Equipment
                    .Where(a => a.EquipmentId == EquipmentAllocation.EquipmentId)
                    .FirstOrDefault();

                equipment.Status = status;

                _context.Equipment.Update(equipment);

                _context.EquipmentAllocation.Add(EquipmentAllocation);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

        }
    }
}
