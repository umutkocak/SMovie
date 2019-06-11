using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMovie.API.Models.ViewModels;
using TMDbLib.Client;

namespace SMovie.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly TMDbClient client = new TMDbClient("5a9a9f456c217677c2c38eb444762974");

        [HttpGet]
        public async Task<MovieViewModel> GetMovie(int movieId)
        {
            client.DefaultLanguage = "tr-TR";
            var searchMovieById = await client.GetMovieAsync(movieId);

            var movie = new MovieViewModel
            {
                TMDbId = searchMovieById.Id,
                IMDbId = searchMovieById.ImdbId,
                Title = searchMovieById.Title,
                OriginalTitle = searchMovieById.OriginalTitle,
                ReleaseYear = searchMovieById.ReleaseDate,
                ImagePath = "https://image.tmdb.org/t/p/original/" + searchMovieById.PosterPath,
                BackdropPath = "https://image.tmdb.org/t/p/original/" + searchMovieById.BackdropPath,
            };
            foreach (var genre in searchMovieById.Genres)
            {
                movie.Genres.Add(new GenreViewModel { Id = genre.Id, Name = genre.Name });
            }
            return movie;
        }

        [HttpGet]
        public async Task<List<MovieViewModel>> GetMovies([FromQuery] int[] movieIds)
        {
            var movieList = new List<MovieViewModel>();
            foreach (var movieId in movieIds)
            {
                var movie = await GetMovie(movieId);
                movieList.Add(movie);
            }
            return movieList;
        }

        //public async Task<MovieDetailsViewModel> GetDetailsMovie(int movieId)
        //{
        //    //To Do
           
        //}
    }
}
