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

        readonly MovieNowPlaying _movieNowPlaying = new MovieNowPlaying();

        public async Task<ObservableCollection<Movie>> GetNowPlaying()
        {
            var movies = await  _movieNowPlaying.GetAllMovies();
            return movies;
        }
    }
}
