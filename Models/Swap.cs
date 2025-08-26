using System.ComponentModel.DataAnnotations;

namespace BarterSystem_2024_back_up_.Models
{
    public class Swap
    {
        public int Id { get; set; }


        [Required]
        public int OfferedItemId { get; set; }
        public virtual BarterItem OfferedItem { get; set; }


        [Required]
        public int RequestedItemId { get; set; }
        public virtual BarterItem RequestedItem { get; set; }


        [Required]
        public string RequesterId { get; set; }
        public virtual ApplicationUser Requester { get; set; }


        [Required]
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }


        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
