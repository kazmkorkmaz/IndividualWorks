using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class TvSeries
    {
        public int Id { get; set; }
        public string  name { get; set; }
        public string poster_path { get; set; }
        public DateTime first_air_date { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
    }
}
