using BarterSystem_2024_back_up_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarterSystem_2024_back_up_.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }


    }
}
