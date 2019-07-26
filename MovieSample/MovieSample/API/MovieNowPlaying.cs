using MovieSample.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieSample.API
{
    public class MovieNowPlaying
    {

        private const string API_URL = "https://api.themoviedb.org/3/movie/now_playing";

        private const string API_KEY = "e4302c7f32af0979d56fa7e756ab28b1";

        readonly HttpClient _client = new HttpClient();

        public async Task<ObservableCollection<Movie>> GetAllMovies()
        {
            var json = await _client.GetStringAsync(API_URL + "?api_key=" + API_KEY + "&language=en-US&page=1");

            JObject jb = JObject.Parse(json);

            var movies_list = jb["results"].ToObject<ObservableCollection<Movie>>();

            return movies_list;

        }

    }
}
