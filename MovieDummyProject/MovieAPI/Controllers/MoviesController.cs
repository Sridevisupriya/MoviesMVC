using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetMovieDetails/{name}")]
        public IActionResult GetMovieDetailsByName(string name)
        {
            Movie m = _movieRepository.GetMovieDetails(name);
            if(m==null)
            {
                return Ok(null);
            }

            return Ok(m);

        }

        [HttpGet]
        [Route("GetAllMoviesDetails")]
        public IActionResult GetAllMovies()
        {
            List<Movie> mlist = _movieRepository.GetAllMovies();
            return Ok(mlist);
          
        }

        [HttpGet]
        [Route("GetAvailableMoviesDetails")]
        public IActionResult GetAvailableMovies()
        {
            return Ok(_movieRepository.GetAvailableMovies());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            IEnumerable<Movie> mlist = _movieRepository.AddMovieDetails(movie);
            return Ok(mlist);
        }

    }
}
