namespace AirlineReservationSystem.App
{
    partial class SearchFlightForm
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
            this.buttonEnableDeparture = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonShowFlights = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerDepart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCarrier = new System.Windows.Forms.ComboBox();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.comboBoxOrigin = new System.Windows.Forms.ComboBox();
            this.textBoxFlightNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.GroupBox();
            this.buttonViewDetails = new System.Windows.Forms.Button();
            this.dataGridViewFlights = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEnableDeparture);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonShowFlights);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.dateTimePickerDepart);
            this.groupBox1.Controls.Add(this.comboBoxCarrier);
            this.groupBox1.Controls.Add(this.comboBoxDestination);
            this.groupBox1.Controls.Add(this.comboBoxOrigin);
            this.groupBox1.Controls.Add(this.textBoxFlightNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Flights";
            // 
            // buttonEnableDeparture
            // 
            this.buttonEnableDeparture.Location = new System.Drawing.Point(425, 158);
            this.buttonEnableDeparture.Name = "buttonEnableDeparture";
            this.buttonEnableDeparture.Size = new System.Drawing.Size(124, 23);
            this.buttonEnableDeparture.TabIndex = 17;
            this.buttonEnableDeparture.Text = "Enable Departure Date";
            this.buttonEnableDeparture.UseVisualStyleBackColor = true;
            this.buttonEnableDeparture.Click += new System.EventHandler(this.buttonEnableDeparture_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(685, 90);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 33);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonShowFlights
            // 
            this.buttonShowFlights.Location = new System.Drawing.Point(685, 140);
            this.buttonShowFlights.Name = "buttonShowFlights";
            this.buttonShowFlights.Size = new System.Drawing.Size(102, 33);
            this.buttonShowFlights.TabIndex = 12;
            this.buttonShowFlights.Text = "Show All Flights";
            this.buttonShowFlights.UseVisualStyleBackColor = true;
            this.buttonShowFlights.Click += new System.EventHandler(this.buttonShowFlights_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(685, 43);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(103, 33);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerDepart
            // 
            this.dateTimePickerDepart.Enabled = false;
            this.dateTimePickerDepart.Location = new System.Drawing.Point(158, 160);
            this.dateTimePickerDepart.Name = "dateTimePickerDepart";
            this.dateTimePickerDepart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDepart.TabIndex = 10;
            // 
            // comboBoxCarrier
            // 
            this.comboBoxCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarrier.FormattingEnabled = true;
            this.comboBoxCarrier.Location = new System.Drawing.Point(144, 99);
            this.comboBoxCarrier.Name = "comboBoxCarrier";
            this.comboBoxCarrier.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCarrier.TabIndex = 9;
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Location = new System.Drawing.Point(425, 103);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(124, 21);
            this.comboBoxDestination.TabIndex = 8;
            // 
            // comboBoxOrigin
            // 
            this.comboBoxOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrigin.FormattingEnabled = true;
            this.comboBoxOrigin.Location = new System.Drawing.Point(425, 43);
            this.comboBoxOrigin.Name = "comboBoxOrigin";
            this.comboBoxOrigin.Size = new System.Drawing.Size(124, 21);
            this.comboBoxOrigin.TabIndex = 7;
            // 
            // textBoxFlightNo
            // 
            this.textBoxFlightNo.Location = new System.Drawing.Point(144, 43);
            this.textBoxFlightNo.Name = "textBoxFlightNo";
            this.textBoxFlightNo.Size = new System.Drawing.Size(121, 20);
            this.textBoxFlightNo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Departure Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Flight Carrier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Number";
            // 
            // Result
            // 
            this.Result.Controls.Add(this.buttonViewDetails);
            this.Result.Controls.Add(this.dataGridViewFlights);
            this.Result.Location = new System.Drawing.Point(12, 238);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(844, 325);
            this.Result.TabIndex = 1;
            this.Result.TabStop = false;
            this.Result.Text = "Search Result";
            // 
            // buttonViewDetails
            // 
            this.buttonViewDetails.Location = new System.Drawing.Point(707, 254);
            this.buttonViewDetails.Name = "buttonViewDetails";
            this.buttonViewDetails.Size = new System.Drawing.Size(131, 23);
            this.buttonViewDetails.TabIndex = 14;
            this.buttonViewDetails.Text = "View Flight Details";
            this.buttonViewDetails.UseVisualStyleBackColor = true;
            this.buttonViewDetails.Click += new System.EventHandler(this.buttonViewDetails_Click);
            // 
            // dataGridViewFlights
            // 
            this.dataGridViewFlights.AllowUserToAddRows = false;
            this.dataGridViewFlights.AllowUserToDeleteRows = false;
            this.dataGridViewFlights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlights.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewFlights.MultiSelect = false;
            this.dataGridViewFlights.Name = "dataGridViewFlights";
            this.dataGridViewFlights.ReadOnly = true;
            this.dataGridViewFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlights.Size = new System.Drawing.Size(831, 229);
            this.dataGridViewFlights.TabIndex = 0;
            this.dataGridViewFlights.VisibleChanged += new System.EventHandler(this.dataGridViewVisibleChanged);
            // 
            // SearchFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 575);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchFlightForm";
            this.Text = "Search Flights";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDepart;
        private System.Windows.Forms.ComboBox comboBoxCarrier;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.ComboBox comboBoxOrigin;
        private System.Windows.Forms.TextBox textBoxFlightNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonShowFlights;
        private System.Windows.Forms.GroupBox Result;
        private System.Windows.Forms.Button buttonViewDetails;
        private System.Windows.Forms.DataGridView dataGridViewFlights;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonEnableDeparture;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}