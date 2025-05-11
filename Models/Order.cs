using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    [Table("Order")]
    /// <summary>
    /// Model przechowujący informacje o zamówieniach
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        public DateTime DateDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int OrderStatusId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength (50)]
        public string? Email { get; set; }

        [Required]
        public string? MobileNumber { get; set; }

        [Required]
        [MaxLength(250)]

        public string? Address { get; set; }
        [Required]
        public string? PaymentMethod { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool isPaid { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
