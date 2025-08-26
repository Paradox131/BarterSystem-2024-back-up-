using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarterSystem_2024_back_up_.Models
{
    public class BarterItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; } // Clothes, Toys, Skills, Food

        public string ImagePath { get; set; }

        public bool IsApproved { get; set; } = false;

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public bool IsTraded { get; set; } = false;

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Description)}={Description}, {nameof(Category)}={Category}, {nameof(ImagePath)}={ImagePath}, {nameof(IsApproved)}={IsApproved.ToString()}, {nameof(OwnerId)}={OwnerId}, {nameof(Owner)}={Owner}, {nameof(IsTraded)}={IsTraded.ToString()}}}";
        }
    }
}
