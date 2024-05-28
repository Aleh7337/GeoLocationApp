using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Net.Configuration;

namespace TCPServ{
    class ServerClass {
        IPAddress IndirizzoIPClient;
        Socket MioSocketTCP, mioClientSocket;  
        IPEndPoint ClientConnesso;
        const int BUFFERDIM = 1024;
        Socket MioSocketDescriptor = null;
        Thread PuntaAcceptThread;  
        Form1 PuntaForm1;
        bool stopReceive = false;
        List<ClientDescriptorClass> VettoreClient = new List<ClientDescriptorClass>();
        int id = 0;

        int creaClient(String clID, Socket clientAccettato) {
            int IDtrovato = -1, i = 0;
            ClientDescriptorClass nuovoClient;
            while (IDtrovato < 0 && i<VettoreClient.Count) { 
                if (VettoreClient[i].nomeClient == clID){
                    IDtrovato = i;
                    VettoreClient[IDtrovato].ClientSocketDescriptor = clientAccettato;
                    VettoreClient[IDtrovato].StatoC = StatoClient.Attivo;
                    VettoreClient[IDtrovato].nuovoArrivo = false;
                }
                i++;
            }
            if (IDtrovato < 0) {  
                nuovoClient = new ClientDescriptorClass(clientAccettato, StatoClient.Attivo, null);
                nuovoClient.nomeClient = clID;
                nuovoClient.ClientID = VettoreClient.Count;
                VettoreClient.Add(nuovoClient);
                IDtrovato = nuovoClient.ClientID;
            }
            return IDtrovato;
        }
        public void ShowForm(int id){
            VettoreClient[id].puntaForm.ShowDialog();
        }
        public void mioAcceptThread() {  //funzione da eseguire in parallelo
        String identificatoreClient = "";
            while (!stopReceive) {
                try {
                    mioClientSocket = MioSocketTCP.Accept();
                    identificatoreClient = riceviId(mioClientSocket);
                    if (identificatoreClient != "ErroreRicezioneID"){
                        id = creaClient(identificatoreClient, mioClientSocket);
                        if (VettoreClient[id].nuovoArrivo) {
                            VettoreClient[id].puntaForm = new FormRiceviClient(mioClientSocket);
                            VettoreClient[id].ClientFormThreadDescriptor = new Thread(() => ShowForm(id));
                            VettoreClient[id].ClientRicezioneThread = new Thread(() => ricevi(id));
                            VettoreClient[id].ClientFormThreadDescriptor.Start();
                            VettoreClient[id].ClientRicezioneThread.Start();
                        }
                        else{
                            try {
                                VettoreClient[id].ClientRicezioneThread = new Thread(() => ricevi(id));
                                VettoreClient[id].ClientRicezioneThread.Start();
                            }
                            catch (Exception e) {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }
        String riceviId(Socket SocketNuovoClient){
            String messaggio = ""; bool nomeClientRicevuto = false;
            byte[] bufferRicezione = new byte[BUFFERDIM];
            int numByteRicevuti;
            while ((SocketNuovoClient.Connected) && (!nomeClientRicevuto)) {
                try {
                    numByteRicevuti = SocketNuovoClient.Receive(bufferRicezione);
                    messaggio += Encoding.ASCII.GetString(bufferRicezione, 0, numByteRicevuti);
                    if (messaggio.Contains("/id"))  {
                        messaggio = messaggio.Substring(0, messaggio.IndexOf("/id"));
                        SocketNuovoClient.Send(Encoding.ASCII.GetBytes(messaggio+"/id\0"));
                        nomeClientRicevuto = true;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return "ErroreRicezioneID";
                }
            }
        return messaggio;
        }
        void ricevi(int clientID)
        {
            String messaggio = "";
            String MessaggioBuono = "";
            byte[] bufferRicezione = new byte[BUFFERDIM];
            int numByteRicevuti, numByteInviati;
            string percorso = @"C:\Users\andra\OneDrive\Desktop\TCPServ\TCPServ\" + VettoreClient[clientID].nomeClient + "Coordinate.txt";
            while (VettoreClient[clientID].StatoC == StatoClient.Attivo)
            {
                try
                {
                    numByteRicevuti = VettoreClient[clientID].ClientSocketDescriptor.Receive(bufferRicezione);
                    messaggio += Encoding.ASCII.GetString(bufferRicezione, 0, numByteRicevuti);
                    if (messaggio.StartsWith("latitudine:"))
                    {
                        MessaggioBuono = messaggio.Substring("latitudine:".Length);
                        VettoreClient[clientID].puntaForm.ListReceiveLoc.Items.Add(MessaggioBuono);
                        numByteInviati = VettoreClient[clientID].ClientSocketDescriptor.Send(Encoding.ASCII.GetBytes(MessaggioBuono));
                        using (StreamWriter sw = File.AppendText(percorso))
                        {
                            sw.WriteLine(MessaggioBuono);
                        }
                    }
                    else if (messaggio.StartsWith("longitudine:"))
                    {
                        MessaggioBuono = messaggio.Substring("longitudine:".Length);
                        VettoreClient[clientID].puntaForm.ListReceiveLoc.Items.Add(MessaggioBuono);
                        numByteInviati = VettoreClient[clientID].ClientSocketDescriptor.Send(Encoding.ASCII.GetBytes(MessaggioBuono));
                        using (StreamWriter sw = File.AppendText(percorso))
                        {
                            sw.WriteLine(MessaggioBuono);
                        }
                    }
                        if (messaggio.Contains('\r'))
                    {
                        VettoreClient[clientID].puntaForm.ListRiceviClient.Items.Add(messaggio);
                        numByteInviati = VettoreClient[clientID].ClientSocketDescriptor.Send(Encoding.ASCII.GetBytes(messaggio));
                        messaggio = "";
                    } 
                }
                catch (Exception ex)
                {

                    VettoreClient[clientID].StatoC = StatoClient.Sospeso;
                    break;
                }
            }
        }

        public ServerClass(Form1 pf){
            PuntaForm1=pf;
        }
                
        public void initServer(int p,int MaxConn) {  
            IndirizzoIPClient = IPAddress.Any;  
            MioSocketTCP = new Socket(IndirizzoIPClient.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            ClientConnesso = new IPEndPoint(IndirizzoIPClient, p);
            MioSocketTCP.Bind(ClientConnesso);
            MioSocketTCP.Listen(MaxConn);
            PuntaAcceptThread = new Thread(() => mioAcceptThread());
        }
        
        public void avviaServer(int porta, int numMaxConnessioni) {
            if (MioSocketTCP==null) initServer(porta, numMaxConnessioni);
            stopReceive = false;
            PuntaAcceptThread.Start(); 
        }

        public void stopServer(){
            try {
                stopReceive = true;
                if (MioSocketDescriptor != null) MioSocketDescriptor.Close();
                if (PuntaAcceptThread != null)
                {
                    MioSocketTCP.Close();
                    MioSocketTCP.Dispose();
                    PuntaAcceptThread.Abort();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
