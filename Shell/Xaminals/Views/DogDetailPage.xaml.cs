using System.Net.Sockets;
using System.Text;
using Xaminals.Data;
using Xaminals.Models;

namespace Xaminals.Views
{
    [QueryProperty(nameof(Name), "name")]
    public partial class DogDetailPage : ContentPage
    {
        Socket socketSender;
        const int DIMBUF = 1024;

        public string Name
        {
            set
            {
                LoadAnimal(value);
            }
        }

        public DogDetailPage()
        {
            InitializeComponent();
        }

        public DogDetailPage(Socket MioSocket)
        {
            this.socketSender = MioSocket;
        }
        public void pass(Socket S)
        {
            socketSender = S;
        }

        private void FunzioneInvia(object sender, EventArgs e)
        {
            byte[] bufferTesto = new byte[DIMBUF];  //la stringa del textbox è da convertire in byteArray per essere trasmessa
            int byteInviati = 0;
            bufferTesto = Encoding.ASCII.GetBytes(EntryTx.Text + '\r');

            try
            {
                if (socketSender.Connected)
                {
                    byteInviati = socketSender.Send(bufferTesto);

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




        void LoadAnimal(string name)
        {
            try
            {
                VoceMenuPersonalizzato animal = DogData.Dogs.FirstOrDefault(a => a.Name == name);
                BindingContext = animal;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load animal.");
            }
        }
    }
}

