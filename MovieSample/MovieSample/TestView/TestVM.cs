using MovieSample.API;
using MovieSample.Model;
using MovieSample.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieSample.ModelView
{
    public class TestModel
    {
    public string name { get; set; }
    public string lname { get; set; }
    }
    public class TestVM : INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;

        MovieServices _movieServices;

        public TestVM()
        {

            

            InitializeGetMoviesAsync();


            TestCommand = new Command(TestCommandExecute);


            Models = new ObservableCollection<TestModel>()
            {
                new TestModel()
                {
                    name = "Name1",
                    lname = "Lname1"
                },
                new TestModel()
                {
                    name = "Name2",
                    lname = "Lname2"
                },
                new TestModel()
                {
                    name = "Name3",
                    lname = "Lname3"
                }
            };

        }


        private async Task InitializeGetMoviesAsync()
        {
            try
            {
                _movieServices = new MovieServices();
                _movies = await _movieServices.GetNowPlaying();
                
            } catch
            {
            }
        }


        public ICommand TestCommand { get; private set; }

        private void TestCommandExecute()
        {

            Debug.WriteLine(_movies[0].title);


        }


        private ObservableCollection<TestModel> _models;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TestModel> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
                OnPropertyChanged();

            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        

    }
}
