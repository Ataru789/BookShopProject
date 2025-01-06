using System.Diagnostics;
using BookShop.Models;
using BookShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers


{
    /// <summary>
    /// Kontroler obslugujacy widoki strony glownej
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Books(string sterm = "", int genreId = 0)
        {
            
            IEnumerable<Book> books = await _homeRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModelDTO bookModel = new BookDisplayModelDTO
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };

            return View(bookModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
