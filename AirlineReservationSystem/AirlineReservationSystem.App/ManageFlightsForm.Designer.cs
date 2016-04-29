namespace AirlineReservationSystem.App
{
    partial class ManageFlightsForm
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
            this.buttonManageFlights = new System.Windows.Forms.Button();
            this.buttonManageCarrier = new System.Windows.Forms.Button();
            this.buttonManageCrew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonViewUpdateFlight = new System.Windows.Forms.Button();
            this.buttonDeleteFlight = new System.Windows.Forms.Button();
            this.buttonCreateFlight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewFlights = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonManageFlights
            // 
            this.buttonManageFlights.Enabled = false;
            this.buttonManageFlights.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageFlights.Location = new System.Drawing.Point(139, 51);
            this.buttonManageFlights.Name = "buttonManageFlights";
            this.buttonManageFlights.Size = new System.Drawing.Size(172, 53);
            this.buttonManageFlights.TabIndex = 0;
            this.buttonManageFlights.Text = "Manage Flights";
            this.buttonManageFlights.UseVisualStyleBackColor = true;
            // 
            // buttonManageCarrier
            // 
            this.buttonManageCarrier.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCarrier.Location = new System.Drawing.Point(358, 51);
            this.buttonManageCarrier.Name = "buttonManageCarrier";
            this.buttonManageCarrier.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCarrier.TabIndex = 1;
            this.buttonManageCarrier.Text = "Manage Flight Carriers";
            this.buttonManageCarrier.UseVisualStyleBackColor = true;
            this.buttonManageCarrier.Click += new System.EventHandler(this.buttonManageCarrier_Click);
            // 
            // buttonManageCrew
            // 
            this.buttonManageCrew.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCrew.Location = new System.Drawing.Point(581, 51);
            this.buttonManageCrew.Name = "buttonManageCrew";
            this.buttonManageCrew.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCrew.TabIndex = 2;
            this.buttonManageCrew.Text = "Manage Flight Crews";
            this.buttonManageCrew.UseVisualStyleBackColor = true;
            this.buttonManageCrew.Click += new System.EventHandler(this.buttonManageCrew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonViewUpdateFlight);
            this.groupBox1.Controls.Add(this.buttonDeleteFlight);
            this.groupBox1.Controls.Add(this.buttonCreateFlight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFilter);
            this.groupBox1.Controls.Add(this.dataGridViewFlights);
            this.groupBox1.Location = new System.Drawing.Point(12, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 512);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Flights";
            // 
            // buttonViewUpdateFlight
            // 
            this.buttonViewUpdateFlight.Location = new System.Drawing.Point(630, 458);
            this.buttonViewUpdateFlight.Name = "buttonViewUpdateFlight";
            this.buttonViewUpdateFlight.Size = new System.Drawing.Size(171, 23);
            this.buttonViewUpdateFlight.TabIndex = 5;
            this.buttonViewUpdateFlight.Text = "View/Update Flight Details";
            this.buttonViewUpdateFlight.UseVisualStyleBackColor = true;
            this.buttonViewUpdateFlight.Click += new System.EventHandler(this.buttonViewUpdateFlight_Click);
            // 
            // buttonDeleteFlight
            // 
            this.buttonDeleteFlight.Location = new System.Drawing.Point(428, 458);
            this.buttonDeleteFlight.Name = "buttonDeleteFlight";
            this.buttonDeleteFlight.Size = new System.Drawing.Size(171, 23);
            this.buttonDeleteFlight.TabIndex = 4;
            this.buttonDeleteFlight.Text = "Delete Flights";
            this.buttonDeleteFlight.UseVisualStyleBackColor = true;
            this.buttonDeleteFlight.Click += new System.EventHandler(this.buttonDeleteFlight_Click);
            // 
            // buttonCreateFlight
            // 
            this.buttonCreateFlight.Location = new System.Drawing.Point(228, 458);
            this.buttonCreateFlight.Name = "buttonCreateFlight";
            this.buttonCreateFlight.Size = new System.Drawing.Size(171, 23);
            this.buttonCreateFlight.TabIndex = 3;
            this.buttonCreateFlight.Text = "Create New Flight";
            this.buttonCreateFlight.UseVisualStyleBackColor = true;
            this.buttonCreateFlight.Click += new System.EventHandler(this.buttonCreateFlight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtered By";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(742, 29);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFilter.TabIndex = 1;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // dataGridViewFlights
            // 
            this.dataGridViewFlights.AllowUserToAddRows = false;
            this.dataGridViewFlights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlights.Location = new System.Drawing.Point(6, 72);
            this.dataGridViewFlights.MultiSelect = false;
            this.dataGridViewFlights.Name = "dataGridViewFlights";
            this.dataGridViewFlights.ReadOnly = true;
            this.dataGridViewFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlights.Size = new System.Drawing.Size(857, 364);
            this.dataGridViewFlights.TabIndex = 0;
            this.dataGridViewFlights.VisibleChanged += new System.EventHandler(this.DataGridVisibleChanged);
            // 
            // ManageFlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonManageCrew);
            this.Controls.Add(this.buttonManageCarrier);
            this.Controls.Add(this.buttonManageFlights);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageFlightsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Flights";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonManageFlights;
        private System.Windows.Forms.Button buttonManageCarrier;
        private System.Windows.Forms.Button buttonManageCrew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.DataGridView dataGridViewFlights;
        private System.Windows.Forms.Button buttonViewUpdateFlight;
        private System.Windows.Forms.Button buttonDeleteFlight;
        private System.Windows.Forms.Button buttonCreateFlight;
    }
}