using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyElectronicShop.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? PrId { get; set; }
        [Required]
        public int? Quantity { get; set; }

        [ForeignKey("PrId")]
        public Product Product { get; set; } = null!;
    }
}
