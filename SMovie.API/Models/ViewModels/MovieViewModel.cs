using System;
using System.Collections.Generic;
using TMDbLib.Objects.General;


namespace SMovie.API.Models.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            Genres = new List<GenreViewModel>();
        }

        public int TMDbId { get; set; }
        public string IMDbId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public string ImagePath { get; set; }
        public string BackdropPath { get; set; }
        public List<GenreViewModel> Genres { get; set; }
    }

    public class GenreViewModel : Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}