namespace BookShop.Models.DTOs
{
    /// <summary>
    /// Przechowuje i przekazuje dalej dane do wyświetlenia książek
    /// </summary>
    public class BookDisplayModelDTO
    {
        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string STerm { get; set; } = "";

        public int GenreId { get; set; } = 0;

    }
}
