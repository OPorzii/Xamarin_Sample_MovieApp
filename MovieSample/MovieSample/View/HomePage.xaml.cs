using MovieSample.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieSample.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<Movie> movies;

        public HomePage()
        {
           InitializeComponent();
           GetData();
        }


        async void GetData()
        {
            var client = new HttpClient();


            var json = await client.GetStringAsync("https://api.themoviedb.org/3/movie/now_playing?api_key=e4302c7f32af0979d56fa7e756ab28b1&language=en-US&page=1");

            JObject jb = JObject.Parse(json);
            movies = jb["results"].ToObject<ObservableCollection<Movie>>();

             moviesList.ItemsSource = movies;

          //  Debug.WriteLine("MainPage: "+ movies[0].title);

        }

        private async void MoviesList_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MovieDetailView
                {
                    BindingContext = e.SelectedItem as Movie
                });
            }

        }
    }
}
