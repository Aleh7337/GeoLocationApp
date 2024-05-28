
namespace TCPServ
{
    partial class FormRiceviClient
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
            this.ListRiceviClient = new System.Windows.Forms.ListBox();
            this.StatusBarClient = new System.Windows.Forms.StatusStrip();
            this.labelIDClient = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListRiceviClient
            // 
            this.ListRiceviClient.FormattingEnabled = true;
            this.ListRiceviClient.Location = new System.Drawing.Point(40, 56);
            this.ListRiceviClient.Name = "ListRiceviClient";
            this.ListRiceviClient.Size = new System.Drawing.Size(215, 238);
            this.ListRiceviClient.TabIndex = 0;
            // 
            // StatusBarClient
            // 
            this.StatusBarClient.Location = new System.Drawing.Point(0, 314);
            this.StatusBarClient.Name = "StatusBarClient";
            this.StatusBarClient.Size = new System.Drawing.Size(752, 22);
            this.StatusBarClient.TabIndex = 1;
            this.StatusBarClient.Text = "statusStrip1";
            // 
            // labelIDClient
            // 
            this.labelIDClient.AutoSize = true;
            this.labelIDClient.Location = new System.Drawing.Point(37, 22);
            this.labelIDClient.Name = "labelIDClient";
            this.labelIDClient.Size = new System.Drawing.Size(0, 13);
            this.labelIDClient.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(296, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormRiceviClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 336);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelIDClient);
            this.Controls.Add(this.StatusBarClient);
            this.Controls.Add(this.ListRiceviClient);
            this.Name = "FormRiceviClient";
            this.Text = "FormRiceviClient";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListRiceviClient;
        public System.Windows.Forms.StatusStrip StatusBarClient;
        public System.Windows.Forms.Label labelIDClient;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}