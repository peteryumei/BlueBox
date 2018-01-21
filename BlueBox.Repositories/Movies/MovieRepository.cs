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

                return movie;
            }
            else
            {
                return null;
            }

        }
    }
}
