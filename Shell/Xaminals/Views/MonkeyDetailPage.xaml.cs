using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Xaminals.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
        private Socket _socketClient;
        private List<string> _coordinates;
        string ipserver;
        //WebView MyWebView;
        public MonkeyDetailPage()
        {
            InitializeComponent();
            _coordinates = new List<string>();
            //BindingContext = new MonkeyDetailViewModel();
        }
        public MonkeyDetailPage(string data)
        {
            InitializeComponent();
            _coordinates = new List<string>();
            ipserver = data;
            InitializeMapWithCurrentLocation();
        }
        private void ConnettiEQuery()
        {
            IPEndPoint ServerIP = new IPEndPoint(Convert.ToInt64(ipserver), 8080);
            try
            {
                _socketClient.Connect(ServerIP);
            }
            catch (Exception ex)
            {
                File.AppendAllText(".\\log.log", ex.ToString());
            }
        }

        private void UpdateMap(double latitude, double longitude)
        {
            // Creare un oggetto di coordinata JSON
            var coordinateObject = new
            {
                lat = latitude,
                lng = longitude
            };

            // Creare una lista di oggetti coordinate JSON
            var coordinatesList = new List<object> { coordinateObject };

            // Serializzare la lista di coordinate in JSON
            string coordinatesJson = JsonSerializer.Serialize(coordinatesList);

            string htmlSource = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Google Maps</title>
                    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyBPZbMWC4mThtDRiE5HR16jsyE97toAP5M""></script>
                    <script>
                        function initMap() {{
                            var map = new google.maps.Map(document.getElementById('map'), {{
                                zoom: 10,
                                center: {{lat: {latitude}, lng: {longitude}}},
                                mapTypeId: 'terrain'
                            }});

                            var flightPlanCoordinates = {coordinatesJson};
                            var flightPath = new google.maps.Polyline({{
                                path: flightPlanCoordinates,
                                geodesic: true,
                                strokeColor: '#FF0000',
                                strokeOpacity: 1.0,
                                strokeWeight: 2
                            }});

                            flightPath.setMap(map);
                        }}
                    </script>
                </head>
                <body onload=""initMap()"">
                    <div id=""map"" style=""height:1000px;width:1000px;""></div>
                </body>
                </html>";

            MyWebView.Source = new HtmlWebViewSource { Html = htmlSource };
        }

        private async void InitializeMapWithCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location != null)
                {
                    UpdateMap(location.Latitude,location.Longitude);
                }
                else
                {
                    // Handle location not available
                    UpdateMap(9.0035, 38.7830);//posizione default
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Errore",fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Errore", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", ex.Message, "OK");
            }
        }
    }

}