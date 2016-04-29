namespace AirlineReservationSystem.App
{
    partial class AdminMainForm
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
            this.buttonAdminRole = new System.Windows.Forms.Button();
            this.buttonPassenger = new System.Windows.Forms.Button();
            this.buttonFindTicket = new System.Windows.Forms.Button();
            this.buttonCrewRole = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdminRole
            // 
            this.buttonAdminRole.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdminRole.Location = new System.Drawing.Point(49, 41);
            this.buttonAdminRole.Name = "buttonAdminRole";
            this.buttonAdminRole.Size = new System.Drawing.Size(247, 83);
            this.buttonAdminRole.TabIndex = 0;
            this.buttonAdminRole.Text = "Manage Flights\r\nManage Flight Carriers\r\nManage Flight Crews";
            this.buttonAdminRole.UseVisualStyleBackColor = true;
            this.buttonAdminRole.Click += new System.EventHandler(this.buttonAdminRole_Click);
            // 
            // buttonPassenger
            // 
            this.buttonPassenger.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPassenger.Location = new System.Drawing.Point(49, 30);
            this.buttonPassenger.Name = "buttonPassenger";
            this.buttonPassenger.Size = new System.Drawing.Size(247, 81);
            this.buttonPassenger.TabIndex = 1;
            this.buttonPassenger.Text = "Book Flight Ticket\r\nUnbook Flight Ticket\r\nView Flight Details";
            this.buttonPassenger.UseVisualStyleBackColor = true;
            this.buttonPassenger.Click += new System.EventHandler(this.buttonPassenger_Click);
            // 
            // buttonFindTicket
            // 
            this.buttonFindTicket.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindTicket.Location = new System.Drawing.Point(49, 117);
            this.buttonFindTicket.Name = "buttonFindTicket";
            this.buttonFindTicket.Size = new System.Drawing.Size(247, 48);
            this.buttonFindTicket.TabIndex = 4;
            this.buttonFindTicket.Text = "Find Booking";
            this.buttonFindTicket.UseVisualStyleBackColor = true;
            this.buttonFindTicket.Click += new System.EventHandler(this.buttonFindTicket_Click);
            // 
            // buttonCrewRole
            // 
            this.buttonCrewRole.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrewRole.Location = new System.Drawing.Point(49, 47);
            this.buttonCrewRole.Name = "buttonCrewRole";
            this.buttonCrewRole.Size = new System.Drawing.Size(247, 58);
            this.buttonCrewRole.TabIndex = 6;
            this.buttonCrewRole.Text = "View Roster";
            this.buttonCrewRole.UseVisualStyleBackColor = true;
            this.buttonCrewRole.Click += new System.EventHandler(this.buttonCrewRole_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAdminRole);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(79, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 159);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administrator";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCrewRole);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(79, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 139);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crew";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonPassenger);
            this.groupBox3.Controls.Add(this.buttonFindTicket);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(79, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 184);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passenger";
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 564);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminMainForm";
            this.Text = "Admin Main Area";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdminRole;
        private System.Windows.Forms.Button buttonPassenger;
        private System.Windows.Forms.Button buttonFindTicket;
        private System.Windows.Forms.Button buttonCrewRole;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}