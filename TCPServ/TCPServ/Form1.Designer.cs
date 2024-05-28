namespace TCPServ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarraStatoServer = new System.Windows.Forms.StatusStrip();
            this.AscoltaButton = new System.Windows.Forms.Button();
            this.comboPorta = new System.Windows.Forms.ComboBox();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BarraStatoServer
            // 
            this.BarraStatoServer.Location = new System.Drawing.Point(0, 279);
            this.BarraStatoServer.Name = "BarraStatoServer";
            this.BarraStatoServer.Size = new System.Drawing.Size(513, 22);
            this.BarraStatoServer.TabIndex = 0;
            this.BarraStatoServer.Text = "statusStrip1";
            // 
            // AscoltaButton
            // 
            this.AscoltaButton.Location = new System.Drawing.Point(66, 120);
            this.AscoltaButton.Name = "AscoltaButton";
            this.AscoltaButton.Size = new System.Drawing.Size(93, 53);
            this.AscoltaButton.TabIndex = 1;
            this.AscoltaButton.Text = "Ascolta";
            this.AscoltaButton.UseVisualStyleBackColor = true;
            this.AscoltaButton.Click += new System.EventHandler(this.AscoltaButton_Click);
            // 
            // comboPorta
            // 
            this.comboPorta.FormattingEnabled = true;
            this.comboPorta.Location = new System.Drawing.Point(66, 12);
            this.comboPorta.Name = "comboPorta";
            this.comboPorta.Size = new System.Drawing.Size(121, 21);
            this.comboPorta.TabIndex = 2;
            // 
            // comboClient
            // 
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(66, 63);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(121, 21);
            this.comboClient.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Porta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "n° Client:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.comboPorta);
            this.Controls.Add(this.AscoltaButton);
            this.Controls.Add(this.BarraStatoServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip BarraStatoServer;
        public System.Windows.Forms.Button AscoltaButton;
        public System.Windows.Forms.ComboBox comboPorta;
        public System.Windows.Forms.ComboBox comboClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}