namespace AirlineReservationSystem.App
{
    partial class ManageFlightCrewsForm
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
            this.buttonViewUpdateFlightCrew = new System.Windows.Forms.Button();
            this.buttonDeleteFlightCrew = new System.Windows.Forms.Button();
            this.buttonCreateFlightCrew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewFlightCrews = new System.Windows.Forms.DataGridView();
            this.buttonManageCrew = new System.Windows.Forms.Button();
            this.buttonManageCarrier = new System.Windows.Forms.Button();
            this.buttonManageFlights = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlightCrews)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonViewUpdateFlightCrew);
            this.groupBox1.Controls.Add(this.buttonDeleteFlightCrew);
            this.groupBox1.Controls.Add(this.buttonCreateFlightCrew);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFilter);
            this.groupBox1.Controls.Add(this.dataGridViewFlightCrews);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 512);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Flight Crews";
            // 
            // buttonViewUpdateFlightCrew
            // 
            this.buttonViewUpdateFlightCrew.Location = new System.Drawing.Point(630, 458);
            this.buttonViewUpdateFlightCrew.Name = "buttonViewUpdateFlightCrew";
            this.buttonViewUpdateFlightCrew.Size = new System.Drawing.Size(171, 23);
            this.buttonViewUpdateFlightCrew.TabIndex = 5;
            this.buttonViewUpdateFlightCrew.Text = "View/Update Flight Crew Details";
            this.buttonViewUpdateFlightCrew.UseVisualStyleBackColor = true;
            this.buttonViewUpdateFlightCrew.Click += new System.EventHandler(this.buttonViewUpdateFlightCrew_Click);
            // 
            // buttonDeleteFlightCrew
            // 
            this.buttonDeleteFlightCrew.Location = new System.Drawing.Point(428, 458);
            this.buttonDeleteFlightCrew.Name = "buttonDeleteFlightCrew";
            this.buttonDeleteFlightCrew.Size = new System.Drawing.Size(171, 23);
            this.buttonDeleteFlightCrew.TabIndex = 4;
            this.buttonDeleteFlightCrew.Text = "Delete Flight Crew";
            this.buttonDeleteFlightCrew.UseVisualStyleBackColor = true;
            this.buttonDeleteFlightCrew.Click += new System.EventHandler(this.buttonDeleteFlightCrew_Click);
            // 
            // buttonCreateFlightCrew
            // 
            this.buttonCreateFlightCrew.Location = new System.Drawing.Point(228, 458);
            this.buttonCreateFlightCrew.Name = "buttonCreateFlightCrew";
            this.buttonCreateFlightCrew.Size = new System.Drawing.Size(171, 23);
            this.buttonCreateFlightCrew.TabIndex = 3;
            this.buttonCreateFlightCrew.Text = "Create New Flight Crew";
            this.buttonCreateFlightCrew.UseVisualStyleBackColor = true;
            this.buttonCreateFlightCrew.Click += new System.EventHandler(this.buttonCreateFlightCrew_Click);
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
            // dataGridViewFlightCrews
            // 
            this.dataGridViewFlightCrews.AllowUserToAddRows = false;
            this.dataGridViewFlightCrews.AllowUserToDeleteRows = false;
            this.dataGridViewFlightCrews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlightCrews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlightCrews.Location = new System.Drawing.Point(6, 72);
            this.dataGridViewFlightCrews.MultiSelect = false;
            this.dataGridViewFlightCrews.Name = "dataGridViewFlightCrews";
            this.dataGridViewFlightCrews.ReadOnly = true;
            this.dataGridViewFlightCrews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlightCrews.Size = new System.Drawing.Size(795, 364);
            this.dataGridViewFlightCrews.TabIndex = 0;
            this.dataGridViewFlightCrews.VisibleChanged += new System.EventHandler(this.DataGridVisibleChanged);
            // 
            // buttonManageCrew
            // 
            this.buttonManageCrew.Enabled = false;
            this.buttonManageCrew.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCrew.Location = new System.Drawing.Point(553, 32);
            this.buttonManageCrew.Name = "buttonManageCrew";
            this.buttonManageCrew.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCrew.TabIndex = 6;
            this.buttonManageCrew.Text = "Manage Flight Crews";
            this.buttonManageCrew.UseVisualStyleBackColor = true;
            // 
            // buttonManageCarrier
            // 
            this.buttonManageCarrier.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonManageCarrier.Location = new System.Drawing.Point(330, 32);
            this.buttonManageCarrier.Name = "buttonManageCarrier";
            this.buttonManageCarrier.Size = new System.Drawing.Size(172, 53);
            this.buttonManageCarrier.TabIndex = 5;
            this.buttonManageCarrier.Text = "Manage Flight Carriers";
            this.buttonManageCarrier.UseVisualStyleBackColor = true;
            this.buttonManageCarrier.Click += new System.EventHandler(this.buttonManageCarrier_Click);
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
            // ManageFlightCrewsForm
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
            this.Name = "ManageFlightCrewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Flight Crews";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlightCrews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonViewUpdateFlightCrew;
        private System.Windows.Forms.Button buttonDeleteFlightCrew;
        private System.Windows.Forms.Button buttonCreateFlightCrew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.DataGridView dataGridViewFlightCrews;
        private System.Windows.Forms.Button buttonManageCrew;
        private System.Windows.Forms.Button buttonManageCarrier;
        private System.Windows.Forms.Button buttonManageFlights;
    }
}