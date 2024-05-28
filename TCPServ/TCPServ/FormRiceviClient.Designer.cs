
namespace TCPServ
{
    partial class FormRiceviClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.ListRiceviClient = new System.Windows.Forms.ListBox();
            this.StatusBarClient = new System.Windows.Forms.StatusStrip();
            this.labelIDClient = new System.Windows.Forms.Label();
            this.ListReceiveLoc = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListRiceviClient
            // 
            this.ListRiceviClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ListRiceviClient.FormattingEnabled = true;
            this.ListRiceviClient.ItemHeight = 16;
            this.ListRiceviClient.Location = new System.Drawing.Point(53, 143);
            this.ListRiceviClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListRiceviClient.Name = "ListRiceviClient";
            this.ListRiceviClient.Size = new System.Drawing.Size(323, 292);
            this.ListRiceviClient.TabIndex = 0;
            // 
            // StatusBarClient
            // 
            this.StatusBarClient.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBarClient.Location = new System.Drawing.Point(0, 662);
            this.StatusBarClient.Name = "StatusBarClient";
            this.StatusBarClient.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusBarClient.Size = new System.Drawing.Size(1256, 22);
            this.StatusBarClient.TabIndex = 1;
            this.StatusBarClient.Text = "statusStrip1";
            // 
            // labelIDClient
            // 
            this.labelIDClient.AutoSize = true;
            this.labelIDClient.Location = new System.Drawing.Point(49, 27);
            this.labelIDClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIDClient.Name = "labelIDClient";
            this.labelIDClient.Size = new System.Drawing.Size(0, 16);
            this.labelIDClient.TabIndex = 2;
            // 
            // ListReceiveLoc
            // 
            this.ListReceiveLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ListReceiveLoc.FormattingEnabled = true;
            this.ListReceiveLoc.ItemHeight = 16;
            this.ListReceiveLoc.Location = new System.Drawing.Point(481, 143);
            this.ListReceiveLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListReceiveLoc.Name = "ListReceiveLoc";
            this.ListReceiveLoc.Size = new System.Drawing.Size(659, 452);
            this.ListReceiveLoc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(685, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "COORDINATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "MESSAGGI";
            // 
            // FormRiceviClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1256, 684);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListReceiveLoc);
            this.Controls.Add(this.labelIDClient);
            this.Controls.Add(this.StatusBarClient);
            this.Controls.Add(this.ListRiceviClient);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormRiceviClient";
            this.Text = "FormRiceviClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListRiceviClient;
        public System.Windows.Forms.StatusStrip StatusBarClient;
        public System.Windows.Forms.Label labelIDClient;
        private System.Windows.Forms.ListBox ListRiceviLocation;
        public System.Windows.Forms.ListBox ListReceiveLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}