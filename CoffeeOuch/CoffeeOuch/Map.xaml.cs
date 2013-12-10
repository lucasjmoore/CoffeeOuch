using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using Microsoft.Phone.Maps.Services;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;

namespace CoffeeOuch
{
    public partial class Map : PhoneApplicationPage
    {
        List<GeoCoordinate> MyCoordinates = new List<GeoCoordinate>();
        GeocodeQuery Mygeocodequery = null;
        RouteQuery MyQuery = null;

        public Map()
        {
            InitializeComponent();
            GetCoordinates();
        }

        private async void GetCoordinates()
        {
            Geolocator MyGeolocator = new Geolocator();
            MyGeolocator.DesiredAccuracyInMeters = 5;
            Geoposition MyGeoPosition = null;
            try
            {
                MyGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));  // get where I am now
                MyCoordinates.Add(new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude));

                Mygeocodequery = new GeocodeQuery();
                Mygeocodequery.SearchTerm = "501 Smyth Rd, Ottawa, ON K1H 8L6";
                Mygeocodequery.GeoCoordinate = new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude);    // Geocode_query_QueryCompleted will be called both for route searches and location searched.  Needs some geolocation (either new GeoCoordinate(0, 0) if we don't have ours, or MyCoordinate )

                Mygeocodequery.QueryCompleted += Mygeocodequery_QueryCompleted;
                Mygeocodequery.QueryAsync();

            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Location is disabled in phone settings or capabilities are not checked.");
            }
            catch (Exception ex)
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(ex.Message);
            }
        }

        private void Mygeocodequery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if (e.Error == null && e.Result.Count > 0)
            {
                MyQuery = new RouteQuery();
                MyCoordinates.Add(e.Result[0].GeoCoordinate);
                MyQuery.Waypoints = MyCoordinates;
                MyQuery.QueryCompleted += MyQuery_QueryCompleted;
                MyQuery.QueryAsync();
                Mygeocodequery.Dispose();
            }
        }

        private void MyQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error == null)
            {
                Route MyRoute = e.Result;
                MapRoute MyMapRoute = new MapRoute(MyRoute);
                MyMap.AddRoute(MyMapRoute);
                MyQuery.Dispose();
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}