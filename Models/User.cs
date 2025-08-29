using Microsoft.AspNetCore.Identity;

namespace BarterSystem_2024_back_up_.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        // Navigation: one user → many items
        public virtual ICollection<BarterItem> Items { get; set; }

        //public virtual ICollection<BarterItem> Items { get; set; } Problomatic
        // public virtual ICollection<Swap> SentSwaps { get; set; } Problomatic
        // public virtual ICollection<Swap> ReceivedSwaps { get; set; } Problomatic

    }
}
