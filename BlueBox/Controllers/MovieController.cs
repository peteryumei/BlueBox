using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBox.Controllers
{
    public class MovieController : ApiController
    {

        #region GETs
        // GET: api/Movie
        /// <summary>
        /// Returns list of movies
        /// </summary>
        /// <param name="filter">Optional filter to filter movie based movie name</param>
        /// <param name="categoty">Movie</param>
        /// <param name="limit">Max records return</param>
        /// <returns>List of movies</returns>
        [HttpGet]
        [ActionName("default")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Movie/5
        public string Get(int id)
        {
            return "value";
        }

        #endregion

        // POST: api/Movie
        [HttpPost]
        [ActionName("QueueEmail")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
