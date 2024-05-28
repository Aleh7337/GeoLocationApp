using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace TCPServ
{
    enum StatoClient
    {
        Attivo,
        Sospeso,
        Chiuso
    }
   class ClientDescriptorClass
    {
        private const int RSADIM = 256;
        public Socket ClientSocketDescriptor = null;
        public Thread ClientFormThreadDescriptor = null;
        public Thread ClientRicezioneThread = null;
        public StatoClient StatoC;
        public IPAddress ClientIndirizzoIP;
        public int ClientPorta;
        public FormRiceviClient puntaForm;
        public int ClientID = -1;
        public String nomeClient = "";
        public bool nuovoArrivo = true;
        public RSAParameters ChiavePubblica;

        public ClientDescriptorClass(Socket MioSocket,StatoClient MioStato,FormRiceviClient MiopuntaForm)
        {
            this.StatoC = MioStato; this.ClientSocketDescriptor = MioSocket;
            this.puntaForm = MiopuntaForm;
            this.ClientIndirizzoIP = ((IPEndPoint)MioSocket.RemoteEndPoint).Address;
            ClientPorta = ((IPEndPoint)MioSocket.RemoteEndPoint).Port;
        }
    }
}