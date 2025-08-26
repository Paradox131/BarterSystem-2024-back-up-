using Microsoft.AspNetCore.Identity;

namespace BarterSystem_2024_back_up_.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BarterItem> Items { get; set; }
        public virtual ICollection<Swap> SentSwaps { get; set; }
        public virtual ICollection<Swap> ReceivedSwaps { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(Name)}={Name}, {nameof(Items)}={Items}, {nameof(SentSwaps)}={SentSwaps}, {nameof(ReceivedSwaps)}={ReceivedSwaps}, {nameof(Id)}={Id}, {nameof(UserName)}={UserName}, {nameof(NormalizedUserName)}={NormalizedUserName}, {nameof(Email)}={Email}, {nameof(NormalizedEmail)}={NormalizedEmail}, {nameof(EmailConfirmed)}={EmailConfirmed.ToString()}, {nameof(PasswordHash)}={PasswordHash}, {nameof(SecurityStamp)}={SecurityStamp}, {nameof(ConcurrencyStamp)}={ConcurrencyStamp}, {nameof(PhoneNumber)}={PhoneNumber}, {nameof(PhoneNumberConfirmed)}={PhoneNumberConfirmed.ToString()}, {nameof(TwoFactorEnabled)}={TwoFactorEnabled.ToString()}, {nameof(LockoutEnd)}={LockoutEnd.ToString()}, {nameof(LockoutEnabled)}={LockoutEnabled.ToString()}, {nameof(AccessFailedCount)}={AccessFailedCount.ToString()}}}";
        }
    }
}
