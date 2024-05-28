using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
namespace TCPServ {
    enum StatoClient {
        Attivo,
        Sospeso,
        Chiuso
    }
   class ClientDescriptorClass {
        public Socket ClientSocketDescriptor=null;
        public Thread ClientFormThreadDescriptor=null;
        public Thread ClientRicezioneThread = null;
        public StatoClient StatoC;
        public IPAddress ClientIndirizzoIP;
        public int ClientPorta;
        public FormRiceviClient puntaForm;
        public int ClientID = -1;
        public String nomeClient = "";
        public bool nuovoArrivo = true;
        public String percorsoFile = "";
        
        public ClientDescriptorClass(Socket MioSocket,StatoClient MioStato,FormRiceviClient MiopuntaForm)
        {
            this.StatoC = MioStato; this.ClientSocketDescriptor = MioSocket;
            this.puntaForm = MiopuntaForm;
            this.ClientIndirizzoIP = ((IPEndPoint)(MioSocket.RemoteEndPoint)).Address;
            ClientPorta = ((IPEndPoint)MioSocket.RemoteEndPoint).Port;
        }
   }
}