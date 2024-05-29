using System.Net;
using System.Net.Sockets;
using System.Text;
using Xaminals.Data;
using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class MainViewModel {
        public string Data { get; set; }
    }
    public partial class CatDetailPage : ContentPage
    {
        public string Name
        {
            set
            {
                LoadAnimal(value);
            }
        }

        public CatDetailPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel { Data = "Hello from MainPage!" };
        }
        String clientId = "Guidatore 1";
        const int DIMBUF = 1024;
        Socket socketClientMobile;

        private void FunzioneConnetti(object sender, EventArgs e)
        {
            byte[] miobuf = new byte[DIMBUF];
            IPAddress IndirizzoIPserver = IPAddress.Parse(EntryIP.Text);
            IPEndPoint ServerIP = new IPEndPoint(IndirizzoIPserver, 8080);
            DisplayAlert("", "Connetti gestore evento", "OK");
            socketClientMobile = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketClientMobile.Connect(ServerIP);
                socketClientMobile.Send(Encoding.ASCII.GetBytes(clientId + "<id>"));
                DisplayAlert("", "Connesso", "OK");
            }
            catch(Exception ex)
            {
                DisplayAlert("", ex.Message, "OK");
            }
        }

        private void FunzioneInvia(object sender, EventArgs e)
        {
            byte[] bufferTesto = new byte[DIMBUF];  //la stringa del textbox è da convertire in byteArray per essere trasmessa
            int byteInviati = 0;
            bufferTesto = Encoding.ASCII.GetBytes(EntryTx.Text + '\r');
            try
            {
                if (socketClientMobile.Connected)
                {
                    byteInviati = socketClientMobile.Send(bufferTesto);
                    //DisplayAlert("","Messaggio:"+ EntryTx.Text+" "+"inviato", "OK");
                    EntryTx.Text = "";
                }
                else
                {
                    DisplayAlert("", "Socket disconnesso", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "OK");
            }
        }
        private void GetPosizioneClick(object sender, EventArgs e)
        {
            OnStartListening();
        }
        async void OnStartListening()
        {
            bool statoR;
            string msg = "Couldn't start listening";
            //await DisplayAlert("", "Detect posizione", "OK");
            GeolocationAccuracy precisioneP = new GeolocationAccuracy();
            try
            {
                Geolocation.LocationChanged += Geolocation_LocationChanged;
                var richiestaP = new GeolocationListeningRequest(precisioneP);
                statoR = await Geolocation.StartListeningForegroundAsync(richiestaP);
                if (statoR) msg = "Started listening for foreground location updates";
                await DisplayAlert("", msg, "OK");
            }
            catch (Exception e)
            {
                await DisplayAlert("", "Errore:" + e.Message, "OK");
            }
        }
        void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            byte[] bufferTesto = new byte[DIMBUF];  //la stringa del textbox è da convertire in byteArray per essere trasmessa
            int byteInviati = 0;
            //DisplayAlert("", "Nuova posizione: Latitudine:" + e.Location.Latitude +" Longitudine:" + e.Location.Longitude, "OK");
            bufferTesto = Encoding.ASCII.GetBytes("Nuova posizione: Latitudine:" + e.Location.Latitude +
                         " Longitudine:" + e.Location.Longitude + '\r');
            byteInviati = socketClientMobile.Send(bufferTesto);
        }

        private void stopListenPosizioneClick(object sender, EventArgs e)
        {
            OnStopListening();
        }
        void OnStopListening()
        {
            String statoP = "Listening";
            try
            {
                Geolocation.LocationChanged -= Geolocation_LocationChanged;
                Geolocation.StopListeningForeground();
                statoP = "Stopped listening location update";
                DisplayAlert("", statoP, "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "OK");
            }
        }


/*Location boston = new Location(42.358056, -71.063611);
 Location sanFrancisco = new Location(37.783333, -122.416667);
 double miles = Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Miles);*/



void LoadAnimal(string name)
            {
                try
                {
                    VoceMenuPersonalizzato animal = CatData.Cats.FirstOrDefault(a => a.Name == name);
                    BindingContext = animal;
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to load animal.");
                }
            }
    }
 }

