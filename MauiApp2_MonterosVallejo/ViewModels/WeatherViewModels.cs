using MauiApp2_MonterosVallejo.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MauiApp2_MonterosVallejo.WeatherModels.WeatherModels;

namespace MauiApp2_MonterosVallejo.ViewModels
{
    class WeatherViewModel : INotifyPropertyChanged
    {

        private WeatherData _weatherData;

        public WeatherData WeatherDatainfo
        {
            get => _weatherData;
            set
            {
                if (_weatherData != value)
                {
                    _weatherData = value;
                    OnPropertyChanged();
                }
            }
        }

        public WeatherViewModel()
        {
            _weatherData = new WeatherData();
            GetCurrentWeather();
        }

        public async Task GetCurrentWeather()
        {
            WeatherRepository weatherRepository = new WeatherRepository();
            WeatherDatainfo = await weatherRepository.GetWeatherCurrentLocationAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
