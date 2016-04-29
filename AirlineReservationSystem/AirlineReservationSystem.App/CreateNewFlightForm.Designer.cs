namespace AirlineReservationSystem.App
{
    partial class CreateNewFlightForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.textBoxOrigin = new System.Windows.Forms.TextBox();
            this.comboBoxCarrier = new System.Windows.Forms.ComboBox();
            this.textBoxFlightNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBusinessPrice = new System.Windows.Forms.TextBox();
            this.textBoxEconomyPlusPrice = new System.Windows.Forms.TextBox();
            this.textBoxEconomyPrice = new System.Windows.Forms.TextBox();
            this.textBoxBusinessSeat = new System.Windows.Forms.TextBox();
            this.textBoxEconomyPlusSeat = new System.Windows.Forms.TextBox();
            this.textBoxEconomySeat = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCrews = new System.Windows.Forms.DataGridView();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrews)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerArrival);
            this.groupBox1.Controls.Add(this.dateTimePickerDeparture);
            this.groupBox1.Controls.Add(this.textBoxDestination);
            this.groupBox1.Controls.Add(this.textBoxOrigin);
            this.groupBox1.Controls.Add(this.comboBoxCarrier);
            this.groupBox1.Controls.Add(this.textBoxFlightNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 508);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight Details";
            // 
            // dateTimePickerArrival
            // 
            this.dateTimePickerArrival.Location = new System.Drawing.Point(135, 323);
            this.dateTimePickerArrival.MaxDate = new System.DateTime(5000, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerArrival.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerArrival.Name = "dateTimePickerArrival";
            this.dateTimePickerArrival.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerArrival.TabIndex = 13;
            // 
            // dateTimePickerDeparture
            // 
            this.dateTimePickerDeparture.Location = new System.Drawing.Point(135, 199);
            this.dateTimePickerDeparture.MaxDate = new System.DateTime(5000, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerDeparture.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            this.dateTimePickerDeparture.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDeparture.TabIndex = 11;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(135, 263);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(200, 20);
            this.textBoxDestination.TabIndex = 12;
            // 
            // textBoxOrigin
            // 
            this.textBoxOrigin.Location = new System.Drawing.Point(135, 149);
            this.textBoxOrigin.Name = "textBoxOrigin";
            this.textBoxOrigin.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrigin.TabIndex = 10;
            // 
            // comboBoxCarrier
            // 
            this.comboBoxCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarrier.FormattingEnabled = true;
            this.comboBoxCarrier.Location = new System.Drawing.Point(135, 43);
            this.comboBoxCarrier.Name = "comboBoxCarrier";
            this.comboBoxCarrier.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCarrier.TabIndex = 8;
            this.comboBoxCarrier.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarrier_SelectedIndexChanged);
            // 
            // textBoxFlightNo
            // 
            this.textBoxFlightNo.Location = new System.Drawing.Point(135, 97);
            this.textBoxFlightNo.Name = "textBoxFlightNo";
            this.textBoxFlightNo.Size = new System.Drawing.Size(200, 20);
            this.textBoxFlightNo.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Arrival Date/Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Destination";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Origin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departure Date/Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Flight Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Carrier";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxBusinessPrice);
            this.groupBox2.Controls.Add(this.textBoxEconomyPlusPrice);
            this.groupBox2.Controls.Add(this.textBoxEconomyPrice);
            this.groupBox2.Controls.Add(this.textBoxBusinessSeat);
            this.groupBox2.Controls.Add(this.textBoxEconomyPlusSeat);
            this.groupBox2.Controls.Add(this.textBoxEconomySeat);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(405, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 187);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seat Details";
            // 
            // textBoxBusinessPrice
            // 
            this.textBoxBusinessPrice.Location = new System.Drawing.Point(313, 142);
            this.textBoxBusinessPrice.Name = "textBoxBusinessPrice";
            this.textBoxBusinessPrice.Size = new System.Drawing.Size(89, 20);
            this.textBoxBusinessPrice.TabIndex = 23;
            // 
            // textBoxEconomyPlusPrice
            // 
            this.textBoxEconomyPlusPrice.Location = new System.Drawing.Point(313, 93);
            this.textBoxEconomyPlusPrice.Name = "textBoxEconomyPlusPrice";
            this.textBoxEconomyPlusPrice.Size = new System.Drawing.Size(89, 20);
            this.textBoxEconomyPlusPrice.TabIndex = 22;
            // 
            // textBoxEconomyPrice
            // 
            this.textBoxEconomyPrice.Location = new System.Drawing.Point(313, 51);
            this.textBoxEconomyPrice.Name = "textBoxEconomyPrice";
            this.textBoxEconomyPrice.Size = new System.Drawing.Size(89, 20);
            this.textBoxEconomyPrice.TabIndex = 21;
            // 
            // textBoxBusinessSeat
            // 
            this.textBoxBusinessSeat.Location = new System.Drawing.Point(186, 142);
            this.textBoxBusinessSeat.Name = "textBoxBusinessSeat";
            this.textBoxBusinessSeat.Size = new System.Drawing.Size(89, 20);
            this.textBoxBusinessSeat.TabIndex = 20;
            // 
            // textBoxEconomyPlusSeat
            // 
            this.textBoxEconomyPlusSeat.Location = new System.Drawing.Point(186, 94);
            this.textBoxEconomyPlusSeat.Name = "textBoxEconomyPlusSeat";
            this.textBoxEconomyPlusSeat.Size = new System.Drawing.Size(89, 20);
            this.textBoxEconomyPlusSeat.TabIndex = 19;
            // 
            // textBoxEconomySeat
            // 
            this.textBoxEconomySeat.Location = new System.Drawing.Point(186, 51);
            this.textBoxEconomySeat.Name = "textBoxEconomySeat";
            this.textBoxEconomySeat.Size = new System.Drawing.Size(89, 20);
            this.textBoxEconomySeat.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(324, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Price (USD)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Available Seats";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Business";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Economy Plus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Economy";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewCrews);
            this.groupBox3.Location = new System.Drawing.Point(405, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(598, 315);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Designated Crews";
            // 
            // dataGridViewCrews
            // 
            this.dataGridViewCrews.AllowUserToAddRows = false;
            this.dataGridViewCrews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCrews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCrews.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewCrews.MultiSelect = false;
            this.dataGridViewCrews.Name = "dataGridViewCrews";
            this.dataGridViewCrews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCrews.Size = new System.Drawing.Size(586, 290);
            this.dataGridViewCrews.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(780, 540);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 32);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(898, 540);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(99, 32);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // CreateNewFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 593);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateNewFlightForm";
            this.Text = "Create New Flight";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePickerArrival;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeparture;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.TextBox textBoxOrigin;
        private System.Windows.Forms.ComboBox comboBoxCarrier;
        private System.Windows.Forms.TextBox textBoxFlightNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBusinessPrice;
        private System.Windows.Forms.TextBox textBoxEconomyPlusPrice;
        private System.Windows.Forms.TextBox textBoxEconomyPrice;
        private System.Windows.Forms.TextBox textBoxBusinessSeat;
        private System.Windows.Forms.TextBox textBoxEconomyPlusSeat;
        private System.Windows.Forms.TextBox textBoxEconomySeat;
        private System.Windows.Forms.DataGridView dataGridViewCrews;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSubmit;
    }
}