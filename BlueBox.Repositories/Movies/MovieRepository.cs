using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBox.Models.Movies;
using BlueBox.Common;
using System.Data;
using System.Data.Sql;

namespace BlueBox.Repositories.Movies
{
    public class MovieRepository: IMovieRepository
    {

        public Movie GetMovie(int id)
        {
             DataTable data = DBX.ExecQuery($"select * from Movie where Id = {id}");
            if (data.Rows.Count > 0)
            {
                Movie movie = new Movie();
                movie.movie_id = int.Parse(data.Rows[0]["Id"].ToString());
                movie.title = data.Rows[0]["Title"].ToString();
                movie.price = decimal.Parse(data.Rows[0]["Price"].ToString());
                movie.genre = data.Rows[0]["Genre"].ToString();
                movie.releaseDate = DateTime.Parse(data.Rows[0]["ReleaseDate"].ToString());

                return movie;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Movie> GetMovie()
        {
            DataTable data = DBX.ExecQuery($"select * from Movie");
            if (data.Rows.Count > 0)
            {
                List<Movie> movies = new List<Movie>();
                for (int i= 0; i < data.Rows.Count -1; i++)
                {
                    Movie movie = new Movie();
                    movie.movie_id = int.Parse(data.Rows[i]["Id"].ToString());
                    movie.title = data.Rows[i]["Title"].ToString();
                    movie.price = decimal.Parse(data.Rows[i]["Price"].ToString());
                    movie.genre = data.Rows[i]["Genre"].ToString();
                    movie.releaseDate = DateTime.Parse(data.Rows[i]["ReleaseDate"].ToString());
                    movies.Add(movie);
                }

                return movies;
            }
            else
            {
                return null;
            }
        }

        public int AddMovie(Movie movie)
        {
            var Id = (int)DBX.ExecScalarQuery($"select max(Id) from Movie") + 1;
            string sqlAdd = $"insert into Movie values ({Id}, '{movie.title}', '{movie.genre}', '{movie.price}', '{movie.releaseDate}') ";
            DBX.ExecNonQuery(sqlAdd);
            return Id ;
        }


        public void UpdateMovie(int id, Movie movie)
        {
            //TODO only update the values that are passed in
        }

        public void DeleteMovie(int id)
        {
            string sqlDelete = $"delete from Movie where Id = {id} ";
            DBX.ExecNonQuery(sqlDelete);
        }
    }
}
