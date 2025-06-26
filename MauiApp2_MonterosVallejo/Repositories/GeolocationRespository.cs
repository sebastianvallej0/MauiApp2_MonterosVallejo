﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2_MonterosVallejo.Repositories
{
    class GeolocationRepository
    {
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                return location;
            }

            catch (Exception ex)
            {
                return new Location
                {
                    Longitude = 7.44,
                    Latitude = 16.49
                };
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }
}
