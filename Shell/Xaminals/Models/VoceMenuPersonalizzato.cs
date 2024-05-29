using System.Net.Sockets;

namespace Xaminals.Models
{
    public class VoceMenuPersonalizzato
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public Entry IndirizzoServer { get; set; }
        public Button OkButton { get; set; }
        public Socket SocketClientMobile { get; set; }
    }
}
