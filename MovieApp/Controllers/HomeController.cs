using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        class MoviePage
        {
            public int page;
            public List<Movie> results;
        }
        class TvSeriesPage
        {
            public int page;
            public List<TvSeries> results;
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("popular-movies")]
        public async Task<IActionResult> GetMovies()
        {
            MoviePage movies;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=b7773490150c43fc398c0de8fe94dfef"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<MoviePage> (apiResponse);                  

                }
            }
            return View(movies.results);
        }
        [Route("popular-tv-series")]
        public async Task<IActionResult> GetTvSeries()
        {
            TvSeriesPage tvSeries;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/tv/popular?api_key=b7773490150c43fc398c0de8fe94dfef"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tvSeries = JsonConvert.DeserializeObject<TvSeriesPage>(apiResponse);

                }
            }
            return View(tvSeries.results);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
