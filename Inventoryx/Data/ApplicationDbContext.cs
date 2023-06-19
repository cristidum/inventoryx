using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inventoryx.Models;

namespace Inventoryx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Inventoryx.Models.Employee>? Employee { get; set; }
        public DbSet<Inventoryx.Models.EquipmentAllocation>? EquipmentAllocation { get; set; }
        public DbSet<Inventoryx.Models.Equipment>? Equipment { get; set; }
        public DbSet<Inventoryx.Models.Phone>? Phone { get; set; }
    }
}