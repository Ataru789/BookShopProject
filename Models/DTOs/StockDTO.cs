using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.DTOs
{
    public class StockDTO
    {
        public int BookId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater then -1" )]
        public int Quantity { get; set; }
    }
}
