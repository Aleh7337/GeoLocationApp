using System;
using System.IO;
using System.Windows.Forms;

namespace TCPServ
{
    public partial class Form1 : Form
    {
        public bool listenStatus = false;
        const int nporte = 10;
        ServerClass MioServer;

        public Form1() {
            InitializeComponent();
        }

        // FORM LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;  //consente l'accesso agli oggetti dell'interfaccia grafica
                                                      //da parte di un thread concorrente diverso
            MioServer = new ServerClass(this);
            for (int i = 0; i < nporte; i++) { comboPorta.Items.Add(8080 + i); }
            comboPorta.Text = "8080";
            for (int i = 10; i < 100; i += 10) { comboClient.Items.Add(i); }
            comboPorta.Text = "8080"; comboClient.Text = "10";
            //MioServer.initServer(Convert.ToInt32(comboPorta.Text), Convert.ToInt32(comboClient.Text));
        }

        // GESTORE CLICK ASCOLTA BUTTON
        private void AscoltaButton_Click(object sender, EventArgs e)
        {
            if (listenStatus){
                MioServer.stopServer();
                comboPorta.Enabled = true; comboClient.Enabled = true;
                AscoltaButton.Text = "Ascolta";
                BarraStatoServer.Items.Clear();
                BarraStatoServer.Items.Add("Server off");
                listenStatus = false;
                File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " [INFO] Server disconnesso\r\n");
            }
            else{
                MioServer.avviaServer(Convert.ToInt32(comboPorta.Text), Convert.ToInt32(comboClient.Text));
                AscoltaButton.Text = "Stop";
                BarraStatoServer.Items.Clear();
                BarraStatoServer.Items.Add("Server in ascolto sulla porta: " + comboPorta.Text);
                comboPorta.Enabled = false; comboClient.Enabled = false;
                listenStatus = true;
                File.AppendAllText(".\\log.log", DateTime.Now.ToString() + " [INFO] Server in ascolto\r\n");
            }
        }

        // GESTORE CHIUSURA FORM
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MioServer.stopServer();
        }

    }
}
