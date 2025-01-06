using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.DTOs
{
    /// <summary>
    /// Przechowuje i przekazuje dane o gatunku książki
    /// </summary>
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string GenreName { get; set; }

    }
}
