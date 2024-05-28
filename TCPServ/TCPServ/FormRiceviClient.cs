using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TCPServ
{
    public partial class FormRiceviClient : Form
    {
        Socket SockClientCorrente;
        public FormRiceviClient()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public FormRiceviClient(Socket sClient)
        {
            CheckForIllegalCrossThreadCalls = false;
            SockClientCorrente = sClient;
            InitializeComponent();
            StatusBarClient.Items.Add("IP: " + ((IPEndPoint)(SockClientCorrente.RemoteEndPoint)).Address); //Fatto per riconoscere il client che si connette
            StatusBarClient.Items.Add(" Porta: " + ((IPEndPoint)(SockClientCorrente.RemoteEndPoint)).Port);
        }

        public void ShowHideForm( bool show)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action< bool>(( isShow) => {
                    if (isShow)
                        this.Show();
                    else
                        this.Hide();
                }), show);
            }
            else
            {
                if (show)
                    this.Show();
                else
                    this.Hide();
            } //if
        } //ShowHideForm

        public void FormRiceviClient_Load(object sender, EventArgs e)
        {
            //ImageBox.Image = Image.FromFile("download.jpg");
        }
    }
}
