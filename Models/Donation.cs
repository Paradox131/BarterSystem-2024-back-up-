using System.ComponentModel.DataAnnotations;

namespace BarterSystem_2024_back_up_.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
