using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBox.Models.Movies;

namespace BlueBox.Repositories.Movies
{
    public interface IMovieRepository
    {
        Movie GetMovie(int id);

        IEnumerable<Movie> GetMovie();

        int AddMovie(Movie movie);

        void UpdateMovie(int id, Movie movie);

        void DeleteMovie(int id);

    }
}
