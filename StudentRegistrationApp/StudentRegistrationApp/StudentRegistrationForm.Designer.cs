﻿namespace StudentRegistrationApp
{
    partial class StudentRegistrationForm
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
            this.buttonRemoveStudent = new System.Windows.Forms.Button();
            this.buttonNewStudent = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.groupBoxStudentInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxEnrollmentType = new System.Windows.Forms.GroupBox();
            this.radioButtonPartTime = new System.Windows.Forms.RadioButton();
            this.radioButtonFullTime = new System.Windows.Forms.RadioButton();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.textBoxLast = new System.Windows.Forms.TextBox();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.buttonEditStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.groupBoxStudentInfo.SuspendLayout();
            this.groupBoxEnrollmentType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRemoveStudent
            // 
            this.buttonRemoveStudent.Location = new System.Drawing.Point(601, 115);
            this.buttonRemoveStudent.Name = "buttonRemoveStudent";
            this.buttonRemoveStudent.Size = new System.Drawing.Size(113, 23);
            this.buttonRemoveStudent.TabIndex = 10;
            this.buttonRemoveStudent.Text = "Remove Student";
            this.buttonRemoveStudent.UseVisualStyleBackColor = true;
            this.buttonRemoveStudent.Click += new System.EventHandler(this.buttonRemoveStudent_Click);
            // 
            // buttonNewStudent
            // 
            this.buttonNewStudent.Location = new System.Drawing.Point(601, 75);
            this.buttonNewStudent.Name = "buttonNewStudent";
            this.buttonNewStudent.Size = new System.Drawing.Size(113, 23);
            this.buttonNewStudent.TabIndex = 9;
            this.buttonNewStudent.Text = "New Student";
            this.buttonNewStudent.UseVisualStyleBackColor = true;
            this.buttonNewStudent.Click += new System.EventHandler(this.buttonNewStudent_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewStudents.Location = new System.Drawing.Point(19, 229);
            this.dataGridViewStudents.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowTemplate.Height = 24;
            this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.Size = new System.Drawing.Size(552, 289);
            this.dataGridViewStudents.TabIndex = 8;
            this.dataGridViewStudents.SelectionChanged += new System.EventHandler(this.HandleDataGridViewStudentsSelectionChanged);
            // 
            // groupBoxStudentInfo
            // 
            this.groupBoxStudentInfo.Controls.Add(this.groupBoxEnrollmentType);
            this.groupBoxStudentInfo.Controls.Add(this.comboBoxDepartment);
            this.groupBoxStudentInfo.Controls.Add(this.textBoxLast);
            this.groupBoxStudentInfo.Controls.Add(this.textBoxFirst);
            this.groupBoxStudentInfo.Controls.Add(this.textBoxID);
            this.groupBoxStudentInfo.Controls.Add(this.lblDepartment);
            this.groupBoxStudentInfo.Controls.Add(this.lblLastName);
            this.groupBoxStudentInfo.Controls.Add(this.lblFirstName);
            this.groupBoxStudentInfo.Controls.Add(this.lblStudentID);
            this.groupBoxStudentInfo.Location = new System.Drawing.Point(19, 28);
            this.groupBoxStudentInfo.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxStudentInfo.Name = "groupBoxStudentInfo";
            this.groupBoxStudentInfo.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxStudentInfo.Size = new System.Drawing.Size(552, 188);
            this.groupBoxStudentInfo.TabIndex = 7;
            this.groupBoxStudentInfo.TabStop = false;
            this.groupBoxStudentInfo.Text = "Student Info";
            // 
            // groupBoxEnrollmentType
            // 
            this.groupBoxEnrollmentType.Controls.Add(this.radioButtonPartTime);
            this.groupBoxEnrollmentType.Controls.Add(this.radioButtonFullTime);
            this.groupBoxEnrollmentType.Location = new System.Drawing.Point(275, 37);
            this.groupBoxEnrollmentType.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxEnrollmentType.Name = "groupBoxEnrollmentType";
            this.groupBoxEnrollmentType.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxEnrollmentType.Size = new System.Drawing.Size(234, 115);
            this.groupBoxEnrollmentType.TabIndex = 9;
            this.groupBoxEnrollmentType.TabStop = false;
            this.groupBoxEnrollmentType.Text = "Enrollment Type";
            // 
            // radioButtonPartTime
            // 
            this.radioButtonPartTime.AutoSize = true;
            this.radioButtonPartTime.Enabled = false;
            this.radioButtonPartTime.Location = new System.Drawing.Point(111, 50);
            this.radioButtonPartTime.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonPartTime.Name = "radioButtonPartTime";
            this.radioButtonPartTime.Size = new System.Drawing.Size(70, 17);
            this.radioButtonPartTime.TabIndex = 1;
            this.radioButtonPartTime.TabStop = true;
            this.radioButtonPartTime.Text = "Part Time";
            this.radioButtonPartTime.UseVisualStyleBackColor = true;
            // 
            // radioButtonFullTime
            // 
            this.radioButtonFullTime.AutoSize = true;
            this.radioButtonFullTime.Enabled = false;
            this.radioButtonFullTime.Location = new System.Drawing.Point(23, 50);
            this.radioButtonFullTime.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonFullTime.Name = "radioButtonFullTime";
            this.radioButtonFullTime.Size = new System.Drawing.Size(67, 17);
            this.radioButtonFullTime.TabIndex = 0;
            this.radioButtonFullTime.TabStop = true;
            this.radioButtonFullTime.Text = "Full Time";
            this.radioButtonFullTime.UseVisualStyleBackColor = true;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.Enabled = false;
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(119, 129);
            this.comboBoxDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(128, 21);
            this.comboBoxDepartment.TabIndex = 8;
            // 
            // textBoxLast
            // 
            this.textBoxLast.Location = new System.Drawing.Point(119, 98);
            this.textBoxLast.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLast.Name = "textBoxLast";
            this.textBoxLast.ReadOnly = true;
            this.textBoxLast.Size = new System.Drawing.Size(128, 20);
            this.textBoxLast.TabIndex = 7;
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Location = new System.Drawing.Point(119, 65);
            this.textBoxFirst.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.ReadOnly = true;
            this.textBoxFirst.Size = new System.Drawing.Size(128, 20);
            this.textBoxFirst.TabIndex = 6;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(119, 34);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(128, 20);
            this.textBoxID.TabIndex = 5;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(52, 134);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 3;
            this.lblDepartment.Text = "Department";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(52, 102);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(52, 69);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(52, 37);
            this.lblStudentID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID";
            // 
            // buttonEditStudent
            // 
            this.buttonEditStudent.Location = new System.Drawing.Point(601, 155);
            this.buttonEditStudent.Name = "buttonEditStudent";
            this.buttonEditStudent.Size = new System.Drawing.Size(113, 23);
            this.buttonEditStudent.TabIndex = 11;
            this.buttonEditStudent.Text = "Edit Student";
            this.buttonEditStudent.UseVisualStyleBackColor = true;
            this.buttonEditStudent.Click += new System.EventHandler(this.buttonEditStudent_Click);
            // 
            // StudentRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 547);
            this.Controls.Add(this.buttonEditStudent);
            this.Controls.Add(this.buttonRemoveStudent);
            this.Controls.Add(this.buttonNewStudent);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.groupBoxStudentInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentRegistrationForm";
            this.Text = "Student Registration Main Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.groupBoxStudentInfo.ResumeLayout(false);
            this.groupBoxStudentInfo.PerformLayout();
            this.groupBoxEnrollmentType.ResumeLayout(false);
            this.groupBoxEnrollmentType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRemoveStudent;
        private System.Windows.Forms.Button buttonNewStudent;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.GroupBox groupBoxStudentInfo;
        private System.Windows.Forms.GroupBox groupBoxEnrollmentType;
        private System.Windows.Forms.RadioButton radioButtonPartTime;
        private System.Windows.Forms.RadioButton radioButtonFullTime;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.TextBox textBoxLast;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Button buttonEditStudent;
    }
}