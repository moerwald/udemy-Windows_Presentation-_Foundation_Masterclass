using AccuWeatherApp.Model;
using AccuWeatherApp.Model.City;
using AccuWeatherApp.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuWeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public WeatherViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City() { LocalizedName = "St. Veit" };
                CurrentCondition = new CurrentCondition
                {
                    Temperature = new Temperature
                    {
                        Metric = new Metric { Value = "15" },
                    },
                    WeatherText = "Oasch"
                };
                Cities = new ObservableCollection<City>()
                {
                    new City()
                    {
                        LocalizedName = "Name",
                        AdministrativeArea = new Administrativearea { LocalizedName = "AdministrativeArea"},
                        Country = new Country { LocalizedName = "Country"}
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
        }

        public async void MakeQueryAsync()
        {
            Cities.Clear();

            var cities = await Helpers.AccuWeatherHelper.GetCities(Query);
            cities.ForEach(c => Cities.Add(c));
            Query = string.Empty;
        }

        public ObservableCollection<City> Cities { get; } = new ObservableCollection<City>();

        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        private CurrentCondition _currentConditions;

        public CurrentCondition CurrentCondition
        {
            get { return _currentConditions; }
            set
            {
                _currentConditions = value;

                OnPropertyChanged(nameof(CurrentCondition));
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));

                GetCurrentCondition(SelectedCity);
            }
        }

        private async void GetCurrentCondition(City selectedCity)
        {
            if (selectedCity is null)
                return;


            if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                CurrentCondition = await Helpers.AccuWeatherHelper.GetCurrentConditionAsync(selectedCity.Key);
            }

        }

        public SearchCommand SearchCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
