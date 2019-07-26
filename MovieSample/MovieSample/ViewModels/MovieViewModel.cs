using MovieSample.Model;
using MovieSample.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieSample.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public MovieViewModel()
        {
            InitializeGetMoviesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        MovieServices _movieServices = new MovieServices();

        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                OnPropertyChanged();

            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private async Task InitializeGetMoviesAsync()
        {
            try
            {
                IsBusy = true;
                _movieServices = new MovieServices();
                Movies = await _movieServices.GetNowPlaying();
            }
            finally
            {
                IsBusy = false;
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
