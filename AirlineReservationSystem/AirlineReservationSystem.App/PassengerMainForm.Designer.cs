namespace AirlineReservationSystem.App
{
    partial class PassengerMainForm
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
            this.buttonPassenger = new System.Windows.Forms.Button();
            this.buttonFindTicket = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPassenger
            // 
            this.buttonPassenger.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPassenger.Location = new System.Drawing.Point(42, 48);
            this.buttonPassenger.Name = "buttonPassenger";
            this.buttonPassenger.Size = new System.Drawing.Size(247, 81);
            this.buttonPassenger.TabIndex = 2;
            this.buttonPassenger.Text = "Book Flight Ticket\r\nUnbook Flight Ticket\r\nView Flight Details";
            this.buttonPassenger.UseVisualStyleBackColor = true;
            this.buttonPassenger.Click += new System.EventHandler(this.buttonPassenger_Click);
            // 
            // buttonFindTicket
            // 
            this.buttonFindTicket.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindTicket.Location = new System.Drawing.Point(42, 153);
            this.buttonFindTicket.Name = "buttonFindTicket";
            this.buttonFindTicket.Size = new System.Drawing.Size(247, 40);
            this.buttonFindTicket.TabIndex = 3;
            this.buttonFindTicket.Text = "Find Booking";
            this.buttonFindTicket.UseVisualStyleBackColor = true;
            this.buttonFindTicket.Click += new System.EventHandler(this.buttonFindTicket_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonPassenger);
            this.groupBox3.Controls.Add(this.buttonFindTicket);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(63, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 216);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passenger";
            // 
            // PassengerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 308);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PassengerMainForm";
            this.Text = "Passenger Main Area";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPassenger;
        private System.Windows.Forms.Button buttonFindTicket;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}