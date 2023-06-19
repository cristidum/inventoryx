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
    public class IndexModel : PageModel
    {
        private readonly Inventoryx.Data.ApplicationDbContext _context;

        public IndexModel(Inventoryx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string nameSearch, string snSearch)
        {
            if (_context.Equipment != null)
            {

                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["SNSortParm"] = sortOrder == "sn_asc" ? "sn_desc" : "sn_asc";
                ViewData["TypeSortParm"] = sortOrder == "type_asc" ? "type_desc" : "type_asc";
                ViewData["ADNameSortParm"] = sortOrder == "adname_asc" ? "adname_desc" : "adname_asc";
                ViewData["StatusSortParm"] = sortOrder == "status_asc" ? "status_desc" : "status_asc";
                ViewData["LocationSortParm"] = sortOrder == "loc_asc" ? "loc_desc" : "loc_asc";
                ViewData["NameFilter"] = nameSearch;
                ViewData["SNFilter"] = snSearch;

                var equipment = from e in _context.Equipment
                                select e;

                if (!String.IsNullOrEmpty(nameSearch))
                {
                    equipment = equipment.Where(s => 
                        s.Name.Contains(nameSearch)
                    );
                }

                if (!String.IsNullOrEmpty(snSearch))
                {
                    equipment = equipment.Where(s =>
                        s.SerialNumber.Contains(snSearch)
                    );
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        equipment = equipment.OrderByDescending(e => e.Name);
                        break;
                    case "sn_asc":
                        equipment = equipment.OrderBy(e => e.SerialNumber);
                        break;
                    case "sn_desc":
                        equipment = equipment.OrderByDescending(e => e.SerialNumber);
                        break;
                    case "type_asc":
                        equipment = equipment.OrderBy(e => e.Type);
                        break;
                    case "type_desc":
                        equipment = equipment.OrderByDescending(e => e.Type);
                        break;
                    case "adname_asc":
                        equipment = equipment.OrderBy(e => e.ADName);
                        break;
                    case "adname_desc":
                        equipment = equipment.OrderByDescending(e => e.ADName);
                        break;
                    case "status_asc":
                        equipment = equipment.OrderBy(e => e.Status);
                        break;
                    case "status_desc":
                        equipment = equipment.OrderByDescending(e => e.Status);
                        break;
                    case "loc_asc":
                        equipment = equipment.OrderBy(e => e.Location);
                        break;
                    case "loc_desc":
                        equipment = equipment.OrderByDescending(e => e.Location);
                        break;
                    default:
                        equipment = equipment.OrderBy(e => e.Name);
                        break;
                }

                Equipment = await equipment.AsNoTracking().ToListAsync();
            }
        }
    }
}
