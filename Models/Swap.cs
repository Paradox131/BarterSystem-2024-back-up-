using System.ComponentModel.DataAnnotations;

namespace BarterSystem_2024_back_up_.Models
{
    public class Swap
    {
        public int Id { get; set; }
        public int OfferedItemId { get; set; }
        public BarterItem OfferedItem { get; set; }

        public int RequestedItemId { get; set; }
        public BarterItem RequestedItem { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
