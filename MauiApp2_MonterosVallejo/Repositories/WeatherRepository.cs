using MauiApp2_MonterosVallejo.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static MauiApp2_MonterosVallejo.WeatherModels.WeatherModels;

namespace MauiApp2_MonterosVallejo.Repositories
{
    class WeatherRepository
    {
        public async Task<WeatherData> GetWeatherCurrentLocationAsync()
        {
            GeolocationRepository geolocationRepository = new GeolocationRepository();
            var location = await geolocationRepository.GetCurrentLocation();
            return await GetWeatherDataAsync(location.Latitude, location.Longitude);
        }
        public async Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude)
        {
            HttpClient httpClient = new HttpClient();
            string Latitude_F = latitude.ToString().Replace(",", ".");
            string Longitude_F = longitude.ToString().Replace(",", ".");

            string url = $"https://api.open-meteo.com/v1/forecast?latitude=" + Latitude_F + "&longitude=" + Longitude_F + "&current_weather=true&timezone=America%2FLima";

            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            WeatherData data = JsonConvert.DeserializeObject<WeatherData>(result);
            return data;
        }

    }
}
