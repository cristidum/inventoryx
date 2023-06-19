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

namespace Inventoryx.Pages.Allocations.EquipmentAllocations
{
    public class EditModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public EditModel(Inventoryx.Data.ApplicationDbContext context)
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
            EquipmentAllocation = equipmentallocation;

            var eqId = _context.EquipmentAllocation
                 .Where(a => a.EquipmentAllocationId == id)
                 .Select(b => b.EquipmentId)
                 .FirstOrDefault();

            this.ViewData["equipments"] = _context.Equipment
                .Where(x => x.Status == GeneralStatus.Unallocated || x.EquipmentId == eqId)
                .Select(x => new SelectListItem
                {
                    Value = x.EquipmentId.ToString(),
                    Text = x.Name + " | " + x.SerialNumber

                }).ToList();

            this.ViewData["employees"] = _context.Employee
                .Where(x => x.IsActive == true)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = x.FirstName + " " + x.LastName
                }).ToList();

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

            var eqId = _context.EquipmentAllocation
             .Where(a => a.EquipmentAllocationId == id)
             .Select(b => b.EquipmentId)
             .FirstOrDefault();

            var oldEquipment = _context.Equipment
                .Where(a => a.EquipmentId == eqId)
                .FirstOrDefault();

            this.ViewData["equipments"] = _context.Equipment
                .Where(x => x.Status == GeneralStatus.Unallocated || x.EquipmentId == eqId)
                .Select(x => new SelectListItem
                {
                    Value = x.EquipmentId.ToString(),
                    Text = x.Name + " | " + x.SerialNumber

                }).ToList();

            this.ViewData["employees"] = _context.Employee.Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.FirstName + " " + x.LastName
            }).ToList();

            _context.Attach(EquipmentAllocation).State = EntityState.Modified;



            try
            {
                
                //modify the old eq as unnasigned

                var oldEqStatus = GeneralStatus.Unallocated;

                oldEquipment.Status = oldEqStatus;

                _context.Equipment.Update(oldEquipment);

                //modify the new eq as assinged

                var status = GeneralStatus.Assigned;

                if (EquipmentAllocation.IsActive == false)
                {
                    status = GeneralStatus.Unallocated;
                }

                var equipment = _context.Equipment
                    .Where(a => a.EquipmentId == EquipmentAllocation.EquipmentId)
                    .FirstOrDefault();

                equipment.Status = status;

                _context.Equipment.Update(equipment);

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

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentAllocationExists(EquipmentAllocation.EquipmentAllocationId))
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

        private bool EquipmentAllocationExists(int id)
        {
            return (_context.EquipmentAllocation?.Any(e => e.EquipmentAllocationId == id)).GetValueOrDefault();
        }
    }
}
