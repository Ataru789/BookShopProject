using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    [Table("Book")]
    /// <summary>
    /// Model przechowujący informacje o książkach
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        public string? Image {  get; set; }

        [Required]
        public string? Author { get; set; }
        
        public float Price { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public List<OrderDetail> OrderDetail  { get; set; }

        public List<CartDetail> CartDetail { get; set; }

        public Stock Stock { get; set; }

        [NotMapped]
        public string GenreName { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
    }
}
