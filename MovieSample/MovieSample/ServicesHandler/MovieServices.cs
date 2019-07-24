using MovieSample.API;
using MovieSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MovieSample.ServicesHandler
{
    public class MovieServices
    {

        readonly MovieNowPlaying<Movie> _movieNowPlaying = new MovieNowPlaying<Movie>();

        public async Task<ObservableCollection<Movie>> GetMovies()
        {
            var movies = await  _movieNowPlaying.GetAllMovies();
            return movies;
        }

     

    }
}
