using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCPServ
{
    class ServerClass {
        IPAddress IndirizzoIPClient;
        Socket MioSocketTCP, mioClientSocket;
        IPEndPoint ClientConnesso;
        const int BUFFERDIM = 4096;
        const int RSADIM = 256;
        Socket MioSocketDescriptor = null;
        Thread PuntaAcceptThread;
        Form1 PuntaForm1;
        bool stopReceive = false;
        List<ClientDescriptorClass> VettoreClient = new List<ClientDescriptorClass>();
        RSACryptoServiceProvider ChiavePrivata = new RSACryptoServiceProvider();
        MySqlConnection conn;
        int id = 0;

        // COSTRUTTORE
        public ServerClass(Form1 pf)
        {
            PuntaForm1 = pf;
        }

        // INIT SERVER
        public void initServer(int p, int MaxConn)
        {
            IndirizzoIPClient = IPAddress.Any;
            MioSocketTCP = new Socket(IndirizzoIPClient.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            ClientConnesso = new IPEndPoint(IndirizzoIPClient, p);
            MioSocketTCP.Bind(ClientConnesso);
            MioSocketTCP.Listen(MaxConn);
            PuntaAcceptThread = new Thread(() => mioAcceptThread());
        }

        // AVVIA SERVER
        public void avviaServer(int porta, int numMaxConnessioni)
        {
            if (MioSocketTCP == null) initServer(porta, numMaxConnessioni);
            stopReceive = false;
            PuntaAcceptThread.Start();
        }

        // STOP SERVER
        public void stopServer()
        {
            try
            {
                stopReceive = true;
                foreach (var client in VettoreClient)
                {
                    if (client.ClientSocketDescriptor != null && client.ClientSocketDescriptor.Connected)
                    {
                        InviaMessaggioDiChiusura(client.ClientSocketDescriptor);
                    }
                }

                if (MioSocketDescriptor != null) MioSocketDescriptor.Close();
                if (PuntaAcceptThread != null)
                {
                    MioSocketTCP.Dispose();
                    MioSocketTCP = null;
                    PuntaAcceptThread.Join();
                    PuntaAcceptThread = null;
                }

                foreach(var client in VettoreClient)
                {
                    client.ClientRicezioneThread.Join();
                    client.ClientRicezioneThread = null;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
            }
        }

        // THREAD ACCEPT
        public void mioAcceptThread()
        {
            string identificatoreClient = "";
            while (!stopReceive)
            {
                try
                {
                    mioClientSocket = MioSocketTCP.Accept();

                    connectDB();

                    identificatoreClient = riceviId(mioClientSocket);
                    id = creaClient(identificatoreClient, mioClientSocket);
                    if (VettoreClient[id].nuovoArrivo)
                    {
                        VettoreClient[id].puntaForm = new FormRiceviClient(mioClientSocket);
                        VettoreClient[id].ChiavePubblica = new RSAParameters();
                        VettoreClient[id].ClientFormThreadDescriptor = new Thread(() => ShowForm(id));
                        VettoreClient[id].ClientRicezioneThread = new Thread(() => ricevi(id));
                        VettoreClient[id].ClientFormThreadDescriptor.Start();
                        VettoreClient[id].ClientRicezioneThread.Start();
                    }
                    else
                    {
                        try
                        {
                            VettoreClient[id].ClientRicezioneThread = new Thread(() => ricevi(id));
                            VettoreClient[id].ClientRicezioneThread.Start();
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                }
            }
        }


        // RICEVI ID
        string riceviId(Socket SocketNuovoClient)
        {
            string messaggio = ""; bool nomeChiaveRicevuto = false;
            byte[] bufferRicezione = new byte[BUFFERDIM];
            int numByteRicevuti, numByteInviati;
            while (SocketNuovoClient.Connected && (!nomeChiaveRicevuto))
            {
                try
                {
                    numByteRicevuti = SocketNuovoClient.Receive(bufferRicezione);
                    messaggio += Encoding.ASCII.GetString(bufferRicezione, 0, numByteRicevuti);
                    if (messaggio.Contains("<id>"))
                    {
                        messaggio = messaggio.Substring(0, messaggio.IndexOf("<id>"));
                        numByteInviati = SocketNuovoClient.Send(Encoding.ASCII.GetBytes(messaggio + "<id>\0"));
                        nomeChiaveRicevuto = true;
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                }
            }
            return messaggio;
        }

        // CREA CLIENT
        int creaClient(String clID, Socket clientAccettato) {
            int IDtrovato = -1, i = 0;
            ClientDescriptorClass nuovoClient;
            while (i < VettoreClient.Count) { 
                if (VettoreClient.Count != 0 && VettoreClient[i].nomeClient == clID)
                {
                    IDtrovato = i;
                    VettoreClient[IDtrovato].ClientSocketDescriptor = clientAccettato;
                    VettoreClient[IDtrovato].StatoC = StatoClient.Attivo;
                    VettoreClient[IDtrovato].nuovoArrivo = false;
                    File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " [INFO] Client " + clID + " riconnesso al server\r\n");
                    //i++;
                    break;
                } 
                else i++;
            }
            if (IDtrovato < 0) {
                nuovoClient = new ClientDescriptorClass(clientAccettato, StatoClient.Attivo, null);
                nuovoClient.nomeClient = clID;
                nuovoClient.ClientID = VettoreClient.Count;
                VettoreClient.Add(nuovoClient);
                IDtrovato = nuovoClient.ClientID;
                File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " [INFO] Client " + clID + " connesso al server\r\n");
            }
            return IDtrovato;
        }

        // SHOW FORM RICEVI CLIENT
        public void ShowForm(int id){
            VettoreClient[id].puntaForm.labelIDClient.Text = VettoreClient[id].nomeClient;
            VettoreClient[id].puntaForm.ShowDialog();
        }

        // RICEVI
        void ricevi(int clientID)
        {
            string messaggio, latitudine = "", longitudine = "";
            int numByteRicevuti;

            while (VettoreClient[clientID].StatoC == StatoClient.Attivo)
            {
                try
                {
                    byte[] bufferRicezioneTest = new byte[BUFFERDIM];
                    numByteRicevuti = VettoreClient[clientID].ClientSocketDescriptor.Receive(bufferRicezioneTest);
                    messaggio = "";
                    messaggio += Encoding.Default.GetString(bufferRicezioneTest);
                    messaggio = messaggio.Substring(0, numByteRicevuti);

                    if (messaggio.Contains("<latitude>"))
                    {
                        latitudine = messaggio.Substring(0, messaggio.IndexOf("<latitude>"));
                        VettoreClient[clientID].puntaForm.ListRiceviClient.Items.Add($"Latitudine: {latitudine}");
                        messaggio = "";
                    }
                    else if (messaggio.Contains("<longitude>"))
                    {
                        longitudine = messaggio.Substring(0, messaggio.IndexOf("<longitude>"));
                        VettoreClient[clientID].puntaForm.ListRiceviClient.Items.Add($"Longitudine: {longitudine}");
                        messaggio = "";
                    }

                    if (latitudine != "" && longitudine != "")
                    {
                        uploadDB(VettoreClient[clientID].nomeClient, latitudine.Replace(",", "."), longitudine.Replace(",", "."));
                        latitudine = ""; longitudine = "";
                    }

                }
                catch (Exception ex)
                {
                    VettoreClient[clientID].StatoC = StatoClient.Sospeso;
                    File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                    break;
                }
            }
        }

        void connectDB()
        {
            string ServerIP = "127.0.0.1";
            string portMySql = "3306";
            string connectionString = "SERVER=" + ServerIP + ";" + "PORT =" + portMySql + ";"
            + "DATABASE =dbtaxi;UID =root;PASSWORD =";
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }
        void uploadDB(string targa, string latitudine, string longitudine)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"INSERT INTO data(ts) VALUES('{timestamp}')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"INSERT INTO posizione(latitudine, longitudine) VALUES('{latitudine}', '{longitudine}')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"INSERT INTO cronologia_posizioni(targa, latitudine, longitudine, ts) VALUES('{targa}', '{latitudine}', '{longitudine}', '{timestamp}')";
            cmd.ExecuteNonQuery();
        }

        private void InviaMessaggioDiChiusura(Socket clientSocket)
        {
            try
            {
                byte[] messaggioDiChiusura = Encoding.Default.GetBytes("</close/>");
                clientSocket.Send(messaggioDiChiusura);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'invio del messaggio di chiusura al client: " + ex.Message);
            }
        }

        byte[] riceviChiave(Socket SocketNuovoClient, string tag)
        {
            string messaggio = "";
            byte[] buffer = new byte[BUFFERDIM];
            bool chiaveRicevuta = false;
            int numByteRicevuti;
            string tagPF = "</" + tag.Substring(1);
            
            while (SocketNuovoClient.Connected && (!chiaveRicevuta))
            {
                try
                {
                    numByteRicevuti = SocketNuovoClient.Receive(buffer);
                    messaggio += Encoding.ASCII.GetString(buffer, 0, numByteRicevuti);
                    if (messaggio.Contains(tagPF)) {
                        int indicePartenza = messaggio.IndexOf(tag) + tag.Length;
                        int indiceFine = messaggio.IndexOf(tagPF);
                        messaggio = messaggio.Substring(indicePartenza, indiceFine - indicePartenza);

                        buffer = Encoding.Default.GetBytes(messaggio);
                        
                        chiaveRicevuta = true;
                    }
                } 
                catch (Exception ex)
                {
                    File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                }
            }
            return buffer;
        }
    }
}