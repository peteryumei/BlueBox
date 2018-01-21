using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlueBox.Models.Movies;
using BlueBox.Services.Movies;

namespace BlueBox.Controllers
{
    public class MovieController : ApiController
    {
        private IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }
        public MovieController(IMovieService service)
        {
            _movieService = service;
        }
        
        #region GETs
        // GET: api/Movie
        /// <summary>
        /// Returns list of movies
        /// </summary>
        /// <param name="filter">Optional filter to filter movie based movie name</param>
        /// <param name="categoty">Optional parameter to filter movie by Catagory</param>
        /// <param name="limit">Optional parameter to limit Max records return</param>
        /// <returns>List of movies</returns>
        [HttpGet]
        [ActionName("default")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetMovie();
        }

        // GET: api/Movie/5
        /// <summary>
        /// Get Movie by Id
        /// </summary>
        /// <param name="Id">Movie Id</param>
        /// <returns>return movie that matches the Id</returns>
        [HttpGet]
        [ActionName("default")]
        public Movie Get(int id)
        {
            return _movieService.GetMovie(id);
        }

        #endregion

        #region POSTs
        // POST: api/Movie
        /// <summary>
        /// Add a new Movie 
        /// </summary>
        /// <param name="Movie">Movie Object</param>
        /// <returns>return movie Id</returns>
        public int Post([FromBody]Movie movie)
        {
            int movieId = _movieService.AddMovie(movie);
            return movieId;
        }
        #endregion

        #region PUTs
        // PUT: api/Movie/5
        /// <summary>
        /// Update an existing new Movie 
        /// </summary>
        /// <param name="Id">Movie Id</param>
        /// <param name="Movie">Movie Object</param>
        /// <returns>return movie Id</returns>
        public void Put(int id, [FromBody]Movie movie)
        {
            _movieService.UpdateMovie(id, movie);
        }
        #endregion

        #region DELETEs
        // DELETE: api/Movie/5
        /// <summary>
        /// Delete Movie by Id
        /// </summary>
        /// <param name="Id">Movie Id</param>
        /// <returns>Delete the movie by movie Id</returns>
        public void Delete(int id)
        {
            _movieService.DeleteMovie(id);
        }
        #endregion
    }
}
