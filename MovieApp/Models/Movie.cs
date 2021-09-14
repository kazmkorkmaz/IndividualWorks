using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public double popularity { get; set; }
        public DateTime release_date { get; set; }
        public string Overview { get; set; }
        public string poster_path { get; set; }

    }
}
