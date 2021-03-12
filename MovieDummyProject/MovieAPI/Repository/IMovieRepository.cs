using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public interface IMovieRepository
    {
        public List<Movie> GetAllMovies();
        public List<Movie> GetAvailableMovies();
        public Movie GetMovieDetails(string name);

        public IEnumerable<Movie> AddMovieDetails(Movie movie);
    }
}
