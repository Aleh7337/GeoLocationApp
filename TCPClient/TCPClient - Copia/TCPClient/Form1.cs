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

namespace TCPClient
{
     public partial class Form1 : Form    {
        IPAddress IndirizzoIPServer;  IPEndPoint ServerIP;  Socket MiosocketTCP;
        OpenFileDialog ofd;
        String messaggioRCV; 
        const int DIMBUF = 4096, nporte = 10;
        Thread PuntaRicezioneThread;
        bool connesso = false;
        const String idClient = "idclient2";

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
            PuntaRicezioneThread = new Thread(new ThreadStart(this.RiceviSocket)); //dichiara il puntatore al thread
                                                                                   //e associa la funzione di ricezione
            CheckForIllegalCrossThreadCalls = false;  //permette l'accesso da un thread differente da quello che l'ha generata
        }

        private void ConnettiButton_Click(object sender, EventArgs e) {
            byte[] miobuf = new byte[DIMBUF];
            miobuf = Encoding.ASCII.GetBytes(idClient + "/id");
            MiosocketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                MiosocketTCP.Connect(ServerIP); InviaButton.Enabled = true;
                MiosocketTCP.Send(miobuf);
                comboPorta.Enabled = false; ConnettiButton.Enabled = false;
                disconnetti_button.Enabled = true;
                InviaImmagineButton.Enabled = true;
                ImageSelectButton.Enabled = true;
                connesso = true;
                if (PuntaRicezioneThread.ThreadState == ThreadState.Suspended) PuntaRicezioneThread.Resume(); //sospendo il thread, appena il client si riconnette
                                                                                                              //al server il tread riparte (resume)
                else PuntaRicezioneThread.Start();      //altrimenti se non era mai stato avviato viene effettuata la start

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
        
        private void disconnetti_button_Click(object sender, EventArgs e)
        {
            connesso = false;
            ChiudiClient();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connesso = false;
            ChiudiClient();
            try
            {
                if (MiosocketTCP != null) {
                    PuntaRicezioneThread.Resume();
                    PuntaRicezioneThread.Abort();
                    MiosocketTCP.Dispose();
                } 
            }
            catch (Exception ex)
            {
                BarraStato.Items.Add(ex.Message);
            }
        }

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
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ConnettiButton.Enabled = true;  InviaButton.Enabled = false;
            }
        }
        private void ChiudiClient()
        {
            if (MiosocketTCP != null)
            {
                //MessageBox.Show(Convert.ToString(MiosocketTCP.Connected));
                try
                {
                    MiosocketTCP.Close();
                    ConnettiButton.Enabled = true;
                    disconnetti_button.Enabled = false;
                    PuntaRicezioneThread.Suspend();

                }
                catch (Exception errore)
                {
                    MessageBox.Show(errore.Message);
                }

            }
        }

        private void ImageSelectButton_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                labelImmagine.Text = ofd.SafeFileName;
            }
        }

        private void InviaImmagineButton_Click(object sender, EventArgs e)
        {
            byte[] miobuf = new byte[DIMBUF];
            int byteInviati = 0;
            string path = ofd.FileName;
            byte[] fileBytes = File.ReadAllBytes(path);
            string terminator = "/" + ofd.SafeFileName + "<eof>";
            byte[] terminatorBytes = Encoding.Default.GetBytes(terminator);
            //miobuf = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(imageString));
            byte[] result = new byte[fileBytes.Length + terminatorBytes.Length];
            Buffer.BlockCopy(fileBytes, 0, result, 0, fileBytes.Length);
            Buffer.BlockCopy(terminatorBytes, 0, result, fileBytes.Length, terminatorBytes.Length);

            try
            {
                if (MiosocketTCP.Connected)
                {
                    byteInviati = MiosocketTCP.Send(result);
                }
                else
                {
                    MessageBox.Show("Socket Disconnesso"); ConnettiButton.Enabled = true; InviaButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ConnettiButton.Enabled = true; InviaButton.Enabled = false;
            }
        }

        private void RiceviSocket()
        {
            byte[] miobuffR = new byte[DIMBUF];
            int numByteRicevuti;
            String rmessaggio = "";
            while (connesso)
            {
                try
                {
                   // if (!connesso) MiosocketTCP.EndReceive();
                    numByteRicevuti = MiosocketTCP.Receive(miobuffR);
                    rmessaggio += Encoding.ASCII.GetString(miobuffR, 0, numByteRicevuti);
                    if (rmessaggio.Contains("\r"))
                    {
                        confermaMessaggio.Items.Add(rmessaggio);
                        rmessaggio = "";
                    }
                }
                catch (Exception errore)
                {
                    MessageBox.Show(errore.Message);
                }
            }
        }

    }
}
