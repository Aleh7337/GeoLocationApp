using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace TCPClient
{
     public partial class Form1 : Form    {
        IPAddress IndirizzoIPServer;  IPEndPoint ServerIP;  Socket MiosocketTCP;
        OpenFileDialog ofd;
        String messaggioRCV; 
        const int DIMBUF = 4096, nporte = 10;
        Thread PuntaRicezioneThread;
        bool connesso = false;
        const string idClient = "idclient";
        RSACryptoServiceProvider mioRSA;
        RSAParameters chiavePub, chiavePri;
        String TagM = "<chiavePubblicaModulus>";
        String TagMf = "</chiavePubblicaModulus>";
        String TagQ = "<chiavePubblicaInverseQ>";
        String TagQf = "</chiavePubblicaInverseQ>";

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            IndirizzoIPServer = IPAddress.Parse("127.0.0.1");
            ServerIP = new IPEndPoint(IndirizzoIPServer, 8080);
            textMessaggio.Text = "Messaggio di prova";
            messaggioRCV ="";       InviaButton.Enabled = false;
            for (int i = 0; i < nporte; i++) { comboPorta.Items.Add(8080 + i); }
            comboPorta.Text = "8080";
            disconnetti_button.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;  //permette l'accesso da un thread differente da quello che l'ha generata
        }

        // GESTORE CLICK CONNETTI BUTTON
        private void ConnettiButton_Click(object sender, EventArgs e) {
            byte[] miobuf = new byte[DIMBUF];
            byte[] miobufKey = new byte[DIMBUF];
            miobuf = Encoding.ASCII.GetBytes(idClient + "<id>");
            MiosocketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                PuntaRicezioneThread = new Thread(new ThreadStart(RiceviSocket));
                MiosocketTCP.Connect(ServerIP); InviaButton.Enabled = true;
                MiosocketTCP.Send(miobuf);

                mioRSA = new RSACryptoServiceProvider();
                chiavePub = mioRSA.ExportParameters(false);
                chiavePri = mioRSA.ExportParameters(true);

                miobufKey = Encoding.ASCII.GetBytes(TagM);
                miobufKey = miobufKey.Concat(chiavePri.Modulus).ToArray();              //concatenzazione di due vettori
                miobufKey = miobufKey.Concat(Encoding.ASCII.GetBytes(TagMf)).ToArray();
                MiosocketTCP.Send(miobufKey);
                Array.Clear(miobufKey, 0, miobufKey.Length);
                miobufKey = Encoding.ASCII.GetBytes(TagQ);
                miobufKey = miobufKey.Concat(chiavePri.InverseQ).ToArray();
                miobufKey = miobufKey.Concat(Encoding.ASCII.GetBytes(TagQf)).ToArray();
                MiosocketTCP.Send(miobufKey);

                comboPorta.Enabled = false; ConnettiButton.Enabled = false;
                disconnetti_button.Enabled = true;
                InviaImmagineButton.Enabled = true;
                ImageSelectButton.Enabled = true;
                connesso = true;
                PuntaRicezioneThread.Start();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);   InviaButton.Enabled = false;
                comboPorta.Enabled = true; ConnettiButton.Enabled = true;
                disconnetti_button.Enabled = false;
                InviaImmagineButton.Enabled = false;
                ImageSelectButton.Enabled = false;
                connesso = false;
            }
        }
        
        // GESTORE CLICK DISCONNETTI BUTTON
        private void disconnetti_button_Click(object sender, EventArgs e)
        {
            ChiudiClient();
        }

        // GESTORE CHIUSURA FORM
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            ChiudiClient();
        }

        // GESTORE CLICK INVIA BUTTON
        private void InviaButton_Click(object sender, EventArgs e){
            byte[] miobuf = new byte[DIMBUF];
            int byteInviati = 0;
            miobuf = Encoding.Default.GetBytes(textMessaggio.Text + "<eom>");

            try {               
                if (MiosocketTCP.Connected) {
                    byteInviati = MiosocketTCP.Send(miobuf);
                } else {
                    MessageBox.Show("Socket Disconnesso"); ConnettiButton.Enabled = true; InviaButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n"); ConnettiButton.Enabled = true;  InviaButton.Enabled = false;
            }
        }

        private void ChiudiClient()
        {
            if (MiosocketTCP != null)
            {
                //MessageBox.Show(Convert.ToString(MiosocketTCP.Connected));
                try
                {
                    connesso = false;
                    //MiosocketTCP.Close();
                    MiosocketTCP.Dispose();
                    ConnettiButton.Enabled = true;
                    disconnetti_button.Enabled = false;
                    InviaImmagineButton.Enabled = false;
                    ImageSelectButton.Enabled = false;
                    InviaButton.Enabled = false;
                    PuntaRicezioneThread.Join();
                    PuntaRicezioneThread = null;
                }
                catch (Exception ex)
                {
                    File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                }

            }
        }

        // SELECT IMMAGINE CON OPEN FILE DIALOG
        private void ImageSelectButton_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                labelImmagine.Text = ofd.SafeFileName;
            }
        }

        // INVIA FILE
        private bool InviaFile(FileStream fs, Socket MioSocket)
        {
            bool result = false;
            byte[] buffer = new byte[DIMBUF];
            int offset = 0;
            int byteLetti = 0;
            byte[] terminatore = Encoding.Default.GetBytes("<eof>");

            try
            {
                while ((byteLetti = fs.Read(buffer, offset, DIMBUF)) > 0)
                {
                    if(byteLetti < DIMBUF)
                    {
                        MioSocket.Send(buffer);
                        MioSocket.Send(terminatore);
                    }
                    else
                    {
                        MioSocket.Send(buffer);
                    }   
                }
            }
            catch(Exception ex)
            {
                File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
            }
            

            return result;
        }

        // GESTORE CLICK INVIA FILE
        private void InviaImmagineButton_Click(object sender, EventArgs e)
        {
            string path = ofd.FileName;
            string terminatore = ofd.SafeFileName + "<fileName>";
            byte[] terminatoreBytes = Encoding.Default.GetBytes(terminatore);
            MiosocketTCP.Send(terminatoreBytes);
            FileStream file = File.OpenRead(path);
            InviaFile(file, MiosocketTCP);
        }

        private void RiceviSocket()
        {
            byte[] miobuffR = new byte[DIMBUF];
            int numByteRicevuti;
            string messaggio = "";

            while (connesso)
            {
                try
                {
                    numByteRicevuti = MiosocketTCP.Receive(miobuffR);
                    messaggio += Encoding.ASCII.GetString(miobuffR, 0, numByteRicevuti);

                    if (messaggio.Contains("</close/>"))
                    {
                        ChiudiClient();
                        break;
                    }
                    else if (messaggio.Contains("\r"))
                    {
                        confermaMessaggio.Items.Add(messaggio);
                        messaggio = "";
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(".\\LOG.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n");
                }
            }
        }

     }
}
