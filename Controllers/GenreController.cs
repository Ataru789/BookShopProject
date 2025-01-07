using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    /// <summary>
    /// Kontroler obsługujący widoki dotyczące gatunków książek
    /// </summary>
    [Authorize(Roles = nameof(Roles.Admin))]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetGenres();
            return View(genres);
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreDTO genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            try
            {
                var genreToAdd = new Genre
                {
                    GenreName = genre.GenreName,
                    Id = genre.Id
                };
                await _genreRepository.AddGenre(genreToAdd);
                TempData["successMessage"] = "Genre has been added";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error while adding genre";
                return View(genre);
            }
        }

        public async Task<IActionResult> EditGenre(int id)
        {
            var genre = await _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                throw new InvalidOperationException("Genre not found");
            }
            var genreToUpdate = new GenreDTO
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
            return View(genreToUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGenre(GenreDTO genreToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(genreToUpdate);
            }
            try
            {
                var genre = new Genre
                {
                    Id = genreToUpdate.Id,
                    GenreName = genreToUpdate.GenreName
                };
                await _genreRepository.UpdateGenre(genre);
                TempData["successMessage"] = "Genre has been updated";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error while updating genre";
                return View(genreToUpdate);
            }
        }

        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                throw new InvalidOperationException("Genre not found");
            }
            await _genreRepository.DeleteGenre(genre);
            return RedirectToAction(nameof(Index));
        }
    }
}
