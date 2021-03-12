using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieDbContext _db;
        public MovieRepository(MovieDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Movie> AddMovieDetails(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return _db.Movies.ToList();
        }

        public List<Movie> GetAllMovies()
        {
            return _db.Movies.ToList();
        }

        public List<Movie> GetAvailableMovies()
        {
            List<Movie> al = new List<Movie>();
            List<Movie> all = _db.Movies.ToList();
            foreach (Movie m in all)
            {
                if (m.status == true)
                {
                    Movie item = new Movie()
                    {
                        Id = m.Id,
                        MovieName = m.MovieName,
                        Fare = m.Fare,
                        status = m.status

                    };
                    al.Add(item);
                }
            }
            return al;
        }

        public Movie GetMovieDetails(string name)
        {
            
            Movie m = _db.Movies.FirstOrDefault(x => x.MovieName== name && x.status==true);
            if(m!=null)
            {
                return m;
            }
            return null;
        }
    }
}
