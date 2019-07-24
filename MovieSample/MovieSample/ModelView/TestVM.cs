using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
