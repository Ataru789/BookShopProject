    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    [Table("Genre")]
    /// <summary>   
    /// Model przechowujący informacje o gatunkach książek
    /// </summary>
    public class Genre
    {
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string GenreName { get; set; }
            public List<Book> Books { get; set; }
    }
}
