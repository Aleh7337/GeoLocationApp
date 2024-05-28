
namespace TCPClient
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.textMessaggio = new System.Windows.Forms.TextBox();
            this.ConnettiButton = new System.Windows.Forms.Button();
            this.InviaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPorta = new System.Windows.Forms.ComboBox();
            this.disconnetti_button = new System.Windows.Forms.Button();
            this.confermaMessaggio = new System.Windows.Forms.ListBox();
            this.BarraStato = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ImageSelectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelImmagine = new System.Windows.Forms.Label();
            this.InviaImmagineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textMessaggio
            // 
            this.textMessaggio.AcceptsReturn = true;
            this.textMessaggio.Location = new System.Drawing.Point(22, 22);
            this.textMessaggio.Multiline = true;
            this.textMessaggio.Name = "textMessaggio";
            this.textMessaggio.Size = new System.Drawing.Size(142, 20);
            this.textMessaggio.TabIndex = 0;
            // 
            // ConnettiButton
            // 
            this.ConnettiButton.Location = new System.Drawing.Point(22, 173);
            this.ConnettiButton.Name = "ConnettiButton";
            this.ConnettiButton.Size = new System.Drawing.Size(75, 23);
            this.ConnettiButton.TabIndex = 1;
            this.ConnettiButton.Text = "Connetti";
            this.ConnettiButton.UseVisualStyleBackColor = true;
            this.ConnettiButton.Click += new System.EventHandler(this.ConnettiButton_Click);
            // 
            // InviaButton
            // 
            this.InviaButton.Location = new System.Drawing.Point(170, 15);
            this.InviaButton.Name = "InviaButton";
            this.InviaButton.Size = new System.Drawing.Size(80, 32);
            this.InviaButton.TabIndex = 2;
            this.InviaButton.Text = "Invia";
            this.InviaButton.UseVisualStyleBackColor = true;
            this.InviaButton.Click += new System.EventHandler(this.InviaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Porta:";
            // 
            // comboPorta
            // 
            this.comboPorta.FormattingEnabled = true;
            this.comboPorta.Location = new System.Drawing.Point(170, 173);
            this.comboPorta.Name = "comboPorta";
            this.comboPorta.Size = new System.Drawing.Size(121, 21);
            this.comboPorta.TabIndex = 5;
            // 
            // disconnetti_button
            // 
            this.disconnetti_button.Location = new System.Drawing.Point(22, 144);
            this.disconnetti_button.Name = "disconnetti_button";
            this.disconnetti_button.Size = new System.Drawing.Size(75, 23);
            this.disconnetti_button.TabIndex = 7;
            this.disconnetti_button.Text = "Disconnetti";
            this.disconnetti_button.UseVisualStyleBackColor = true;
            this.disconnetti_button.Click += new System.EventHandler(this.disconnetti_button_Click);
            // 
            // confermaMessaggio
            // 
            this.confermaMessaggio.FormattingEnabled = true;
            this.confermaMessaggio.Location = new System.Drawing.Point(362, 15);
            this.confermaMessaggio.Name = "confermaMessaggio";
            this.confermaMessaggio.Size = new System.Drawing.Size(143, 134);
            this.confermaMessaggio.TabIndex = 8;
            // 
            // BarraStato
            // 
            this.BarraStato.Location = new System.Drawing.Point(0, 168);
            this.BarraStato.Name = "BarraStato";
            this.BarraStato.Size = new System.Drawing.Size(517, 22);
            this.BarraStato.TabIndex = 9;
            this.BarraStato.Text = "statusStrip1";
            this.BarraStato.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ImageSelectButton
            // 
            this.ImageSelectButton.Location = new System.Drawing.Point(125, 61);
            this.ImageSelectButton.Name = "ImageSelectButton";
            this.ImageSelectButton.Size = new System.Drawing.Size(75, 23);
            this.ImageSelectButton.TabIndex = 10;
            this.ImageSelectButton.Text = "Seleziona";
            this.ImageSelectButton.UseVisualStyleBackColor = true;
            this.ImageSelectButton.Click += new System.EventHandler(this.ImageSelectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleziona File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "File Selezionato:";
            // 
            // labelImmagine
            // 
            this.labelImmagine.AutoSize = true;
            this.labelImmagine.Location = new System.Drawing.Point(109, 96);
            this.labelImmagine.Name = "labelImmagine";
            this.labelImmagine.Size = new System.Drawing.Size(0, 13);
            this.labelImmagine.TabIndex = 13;
            // 
            // InviaImmagineButton
            // 
            this.InviaImmagineButton.Location = new System.Drawing.Point(256, 72);
            this.InviaImmagineButton.Name = "InviaImmagineButton";
            this.InviaImmagineButton.Size = new System.Drawing.Size(80, 37);
            this.InviaImmagineButton.TabIndex = 14;
            this.InviaImmagineButton.Text = "Invia File";
            this.InviaImmagineButton.UseVisualStyleBackColor = true;
            this.InviaImmagineButton.Click += new System.EventHandler(this.InviaImmagineButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 222);
            this.Controls.Add(this.InviaImmagineButton);
            this.Controls.Add(this.labelImmagine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImageSelectButton);
            this.Controls.Add(this.BarraStato);
            this.Controls.Add(this.confermaMessaggio);
            this.Controls.Add(this.disconnetti_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPorta);
            this.Controls.Add(this.InviaButton);
            this.Controls.Add(this.ConnettiButton);
            this.Controls.Add(this.textMessaggio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textMessaggio;
        private System.Windows.Forms.Button ConnettiButton;
        private System.Windows.Forms.Button InviaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPorta;
        private System.Windows.Forms.Button disconnetti_button;
        public System.Windows.Forms.ListBox confermaMessaggio;
        private System.Windows.Forms.StatusStrip BarraStato;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ImageSelectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelImmagine;
        private System.Windows.Forms.Button InviaImmagineButton;
    }
}

