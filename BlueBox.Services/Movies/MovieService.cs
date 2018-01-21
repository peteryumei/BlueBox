using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBox.Models.Movies;
using BlueBox.Repositories.Movies;

namespace BlueBox.Services.Movies
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }
       

        public Movie GetMovie(int movieId)
        {
            return _movieRepository.GetMovie(movieId);
        }

        public IEnumerable<Movie> GetMovie()
        {
            return null;
        }

        public int AddMovie(Movie movie)
        {
            return 0;
        }

        public void DeleteMovie(int id)
        {

        }

        public void UpdateMovie(int id, Movie movie)
        {

        }

    }
}
