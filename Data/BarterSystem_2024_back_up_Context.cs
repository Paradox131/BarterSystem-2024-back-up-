using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BarterSystem_2024_back_up_.Models;

namespace BarterSystem_2024_back_up_.Data
{
    public class BarterSystem_2024_back_up_Context : IdentityDbContext<ApplicationUser>
    {
        public BarterSystem_2024_back_up_Context (DbContextOptions<BarterSystem_2024_back_up_Context> options)
            : base(options)
        {
        }

        public DbSet<BarterItem> BarterItems { get; set; }
        public DbSet<Swap> Swaps { get; set; }

        public DbSet<BarterSystem_2024_back_up_.Models.Donation> Donation { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Additional relationships if needed
        }
    }
}
