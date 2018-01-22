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
            return _movieRepository.GetMovie();
        }

        public int AddMovie(Movie movie)
        {
            return _movieRepository.AddMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public void UpdateMovie(int id, Movie movie)
        {
            _movieRepository.UpdateMovie(id, movie);
        }

    }
}
