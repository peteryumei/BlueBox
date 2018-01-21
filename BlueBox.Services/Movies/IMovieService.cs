using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBox.Models.Movies;
using BlueBox.Repositories;

namespace BlueBox.Services.Movies
{
    public interface IMovieService
    {
        Movie GetMovie(int movieId);
        IEnumerable<Movie> GetMovie();
        int AddMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(int id, Movie movie);

    }
}
