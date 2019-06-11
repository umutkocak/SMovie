using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMovie.API.Models.ViewModels
{
    public class MovieDetailsViewModel
    {
        public MovieViewModel Movie { get; set; }
        public bool IsAdult { get; set; }

    }
}
