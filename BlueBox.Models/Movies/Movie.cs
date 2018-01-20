using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBox.Models.Movies
{
    public class Movie
    {
        public int movie_id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public Decimal price { get; set; }
        public DateTime releaseDate { get; set; }

    }
}
