namespace BookShop
{
    /// <summary>
    /// Jest to interfejs, który definiuje metody do pobierania książek z bazy danych
    /// </summary>
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks(string sTerm = "", int genreId = 0);
        Task<IEnumerable<Genre>> Genres();
    }

}