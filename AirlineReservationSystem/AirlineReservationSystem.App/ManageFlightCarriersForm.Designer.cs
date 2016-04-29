namespace AirlineReservationSystem.App
{
    partial class ManageFlightCarriersForm
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
            this.buttonUpdateCarrier = new System.Windows.Forms.Button();
            this.buttonDeleteFlightCarrier = new System.Windows.Forms.Button();
            this.buttonCreateFlightCarrier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewFlightCarriers = new System.Windows.Forms.DataGridView();
            this.buttonManageCrew = new System.Windows.Forms.Button();
            this.buttonManageCarrier = new System.Windows.Forms.Button();
            this.buttonManageFlights = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlightCarriers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonUpdateCarrier);
            this.groupBox1.Controls.Add(this.buttonDeleteFlightCarrier);
            this.groupBox1.Controls.Add(this.buttonCreateFlightCarrier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFilter);
            this.groupBox1.Controls.Add(this.dataGridViewFlightCarriers);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 512);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Flight Carriers";
            // 
            // buttonUpdateCarrier
            // 
            this.buttonUpdateCarrier.Location = new System.Drawing.Point(630, 458);
            this.buttonUpdateCarrier.Name = "buttonUpdateCarrier";
            this.buttonUpdateCarrier.Size = new System.Drawing.Size(171, 23);
            this.buttonUpdateCarrier.TabIndex = 5;
            this.buttonUpdateCarrier.Text = "Update Flight Carrier";
            this.buttonUpdateCarrier.UseVisualStyleBackColor = true;
            this.buttonUpdateCarrier.Click += new System.EventHandler(this.buttonUpdateCarrier_Click);
            // 
            // buttonDeleteFlightCarrier
            // 
            this.buttonDeleteFlightCarrier.Location = new System.Drawing.Point(428, 458);
            this.buttonDeleteFlightCarrier.Name = "buttonDeleteFlightCarrier";
            this.buttonDeleteFlightCarrier.Size = new System.Drawing.Size(171, 23);
            this.buttonDeleteFlightCarrier.TabIndex = 4;
            this.buttonDeleteFlightCarrier.Text = "Delete Flight Carriers";
            this.buttonDeleteFlightCarrier.UseVisualStyleBackColor = true;
            this.buttonDeleteFlightCarrier.Click += new System.EventHandler(this.buttonDeleteFlightCarrier_Click);
            // 
            // buttonCreateFlightCarrier
            // 
            this.buttonCreateFlightCarrier.Location = new System.Drawing.Point(228, 458);
            this.buttonCreateFlightCarrier.Name = "buttonCreateFlightCarrier";
            this.buttonCreateFlightCarrier.Size = new System.Drawing.Size(171, 23);
            this.buttonCreateFlightCarrier.TabIndex = 3;
            this.buttonCreateFlightCarrier.Text = "Create New Flight Carrier";
            this.buttonCreateFlightCarrier.UseVisualStyleBackColor = true;
            this.buttonCreateFlightCarrier.Click += new System.EventHandler(this.buttonCreateFlightCarrier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtered By";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(680, 29);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFilter.TabIndex = 1;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // dataGridViewFlightCarriers
            // 
            this.dataGridViewFlightCarriers.AllowUserToAddRows = false;
            this.dataGridViewFlightCarriers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlightCarriers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlightCarriers.Location = new System.Drawing.Point(6, 72);
            this.dataGridViewFlightCarriers.MultiSelect = false;
            this.dataGridViewFlightCarriers.Name = "dataGridViewFlightCarriers";
            this.dataGridViewFlightCarriers.ReadOnly = true;
            this.dataGridViewFlightCarriers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlightCarriers.Size = new System.Drawing.Size(795, 364);
            this.dataGridViewFlightCarriers.TabIndex = 0;
            this.dataGridViewFlightCarriers.VisibleChanged += new System.EventHandler(this.DataGridViewVisibleChanged);
            // 
            // buttonManageCrew
            // 
            this.buttonManageCrew.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCrew.Location = new System.Drawing.Point(553, 32);
            this.buttonManageCrew.Name = "buttonManageCrew";
            this.buttonManageCrew.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCrew.TabIndex = 6;
            this.buttonManageCrew.Text = "Manage Flight Crews";
            this.buttonManageCrew.UseVisualStyleBackColor = true;
            this.buttonManageCrew.Click += new System.EventHandler(this.buttonManageCrew_Click);
            // 
            // buttonManageCarrier
            // 
            this.buttonManageCarrier.Enabled = false;
            this.buttonManageCarrier.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCarrier.Location = new System.Drawing.Point(330, 32);
            this.buttonManageCarrier.Name = "buttonManageCarrier";
            this.buttonManageCarrier.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCarrier.TabIndex = 5;
            this.buttonManageCarrier.Text = "Manage Flight Carriers";
            this.buttonManageCarrier.UseVisualStyleBackColor = true;
            // 
            // buttonManageFlights
            // 
            this.buttonManageFlights.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageFlights.Location = new System.Drawing.Point(111, 32);
            this.buttonManageFlights.Name = "buttonManageFlights";
            this.buttonManageFlights.Size = new System.Drawing.Size(172, 53);
            this.buttonManageFlights.TabIndex = 4;
            this.buttonManageFlights.Text = "Manage Flights";
            this.buttonManageFlights.UseVisualStyleBackColor = true;
            this.buttonManageFlights.Click += new System.EventHandler(this.buttonManageFlights_Click);
            // 
            // ManageFlightCarriersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonManageCrew);
            this.Controls.Add(this.buttonManageCarrier);
            this.Controls.Add(this.buttonManageFlights);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageFlightCarriersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Flight Carriers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlightCarriers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUpdateCarrier;
        private System.Windows.Forms.Button buttonDeleteFlightCarrier;
        private System.Windows.Forms.Button buttonCreateFlightCarrier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.DataGridView dataGridViewFlightCarriers;
        private System.Windows.Forms.Button buttonManageCrew;
        private System.Windows.Forms.Button buttonManageCarrier;
        private System.Windows.Forms.Button buttonManageFlights;
    }
}