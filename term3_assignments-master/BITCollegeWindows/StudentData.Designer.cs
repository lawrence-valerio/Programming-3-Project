namespace BITCollegeWindows
{
    partial class StudentData
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            System.Windows.Forms.Label gradePointAverageLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label titleLabel;
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblReader = new System.Windows.Forms.Label();
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.mlblPostalCode = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.mlblProvince = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblGradePointAverage = new System.Windows.Forms.Label();
            this.lblOutstandingFees = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.mtbStudentNumber = new System.Windows.Forms.MaskedTextBox();
            this.gradePointStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCreditHours = new System.Windows.Forms.Label();
            this.lblCourseNumber = new System.Windows.Forms.Label();
            this.cbRegistrationNumber = new System.Windows.Forms.ComboBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            studentNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            this.grpStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradePointStateBindingSource)).BeginInit();
            this.grpRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(14, 27);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 6;
            studentNumberLabel.Text = "Student Number:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(14, 200);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(73, 13);
            dateCreatedLabel.TabIndex = 7;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(229, 202);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(93, 13);
            outstandingFeesLabel.TabIndex = 8;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(14, 242);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(109, 13);
            gradePointAverageLabel.TabIndex = 9;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(14, 159);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(27, 13);
            cityLabel.TabIndex = 11;
            cityLabel.Text = "City:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(229, 160);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(52, 13);
            provinceLabel.TabIndex = 12;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(356, 159);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex = 14;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(14, 68);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 16;
            fullNameLabel.Text = "Full Name:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(14, 111);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 18;
            addressLabel.Text = "Address:";
            // 
            // registrationNumberLabel
            // 
            registrationNumberLabel.AutoSize = true;
            registrationNumberLabel.Location = new System.Drawing.Point(14, 31);
            registrationNumberLabel.Name = "registrationNumberLabel";
            registrationNumberLabel.Size = new System.Drawing.Size(106, 13);
            registrationNumberLabel.TabIndex = 0;
            registrationNumberLabel.Text = "Registration Number:";
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(14, 63);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(83, 13);
            courseNumberLabel.TabIndex = 7;
            courseNumberLabel.Text = "Course Number:";
            // 
            // creditHoursLabel
            // 
            creditHoursLabel.AutoSize = true;
            creditHoursLabel.Location = new System.Drawing.Point(14, 100);
            creditHoursLabel.Name = "creditHoursLabel";
            creditHoursLabel.Size = new System.Drawing.Size(68, 13);
            creditHoursLabel.TabIndex = 8;
            creditHoursLabel.Text = "Credit Hours:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(251, 63);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 9;
            titleLabel.Text = "Title:";
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(341, 548);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(65, 13);
            this.lnkDetails.TabIndex = 5;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(164, 548);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(74, 13);
            this.lnkUpdate.TabIndex = 4;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.ForeColor = System.Drawing.Color.Red;
            this.lblReader.Location = new System.Drawing.Point(339, 27);
            this.lblReader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(191, 13);
            this.lblReader.TabIndex = 6;
            this.lblReader.Text = "RFID Unavailable - Enter Student Data";
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(this.lblDescription);
            this.grpStudent.Controls.Add(addressLabel);
            this.grpStudent.Controls.Add(this.lblAddress);
            this.grpStudent.Controls.Add(fullNameLabel);
            this.grpStudent.Controls.Add(this.lblFullName);
            this.grpStudent.Controls.Add(postalCodeLabel);
            this.grpStudent.Controls.Add(this.mlblPostalCode);
            this.grpStudent.Controls.Add(provinceLabel);
            this.grpStudent.Controls.Add(this.mlblProvince);
            this.grpStudent.Controls.Add(cityLabel);
            this.grpStudent.Controls.Add(this.lblCity);
            this.grpStudent.Controls.Add(gradePointAverageLabel);
            this.grpStudent.Controls.Add(this.lblGradePointAverage);
            this.grpStudent.Controls.Add(outstandingFeesLabel);
            this.grpStudent.Controls.Add(this.lblOutstandingFees);
            this.grpStudent.Controls.Add(dateCreatedLabel);
            this.grpStudent.Controls.Add(this.lblDateCreated);
            this.grpStudent.Controls.Add(studentNumberLabel);
            this.grpStudent.Controls.Add(this.mtbStudentNumber);
            this.grpStudent.Controls.Add(this.lblReader);
            this.grpStudent.Location = new System.Drawing.Point(32, 35);
            this.grpStudent.Margin = new System.Windows.Forms.Padding(2);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Padding = new System.Windows.Forms.Padding(2);
            this.grpStudent.Size = new System.Drawing.Size(553, 297);
            this.grpStudent.TabIndex = 7;
            this.grpStudent.TabStop = false;
            this.grpStudent.Text = "Student Data";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointState.Description", true));
            this.lblDescription.Location = new System.Drawing.Point(232, 242);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 20);
            this.lblDescription.TabIndex = 20;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_LV.Models.Student);
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Address", true));
            this.lblAddress.Location = new System.Drawing.Point(129, 111);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(404, 22);
            this.lblAddress.TabIndex = 19;
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(129, 68);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(401, 23);
            this.lblFullName.TabIndex = 17;
            // 
            // mlblPostalCode
            // 
            this.mlblPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblPostalCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "PostalCode", true));
            this.mlblPostalCode.Location = new System.Drawing.Point(451, 159);
            this.mlblPostalCode.Mask = "L0L 0L0";
            this.mlblPostalCode.Name = "mlblPostalCode";
            this.mlblPostalCode.Size = new System.Drawing.Size(79, 22);
            this.mlblPostalCode.TabIndex = 15;
            // 
            // mlblProvince
            // 
            this.mlblProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblProvince.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Province", true));
            this.mlblProvince.Location = new System.Drawing.Point(287, 160);
            this.mlblProvince.Mask = "LL";
            this.mlblProvince.Name = "mlblProvince";
            this.mlblProvince.Size = new System.Drawing.Size(45, 21);
            this.mlblProvince.TabIndex = 13;
            // 
            // lblCity
            // 
            this.lblCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "City", true));
            this.lblCity.Location = new System.Drawing.Point(129, 158);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(78, 22);
            this.lblCity.TabIndex = 12;
            // 
            // lblGradePointAverage
            // 
            this.lblGradePointAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGradePointAverage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointAverage", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.lblGradePointAverage.Location = new System.Drawing.Point(129, 242);
            this.lblGradePointAverage.Name = "lblGradePointAverage";
            this.lblGradePointAverage.Size = new System.Drawing.Size(77, 21);
            this.lblGradePointAverage.TabIndex = 10;
            this.lblGradePointAverage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOutstandingFees
            // 
            this.lblOutstandingFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutstandingFees.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblOutstandingFees.Location = new System.Drawing.Point(342, 202);
            this.lblOutstandingFees.Name = "lblOutstandingFees";
            this.lblOutstandingFees.Size = new System.Drawing.Size(81, 20);
            this.lblOutstandingFees.TabIndex = 9;
            this.lblOutstandingFees.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true));
            this.lblDateCreated.Location = new System.Drawing.Point(129, 201);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(77, 21);
            this.lblDateCreated.TabIndex = 8;
            // 
            // mtbStudentNumber
            // 
            this.mtbStudentNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.mtbStudentNumber.Location = new System.Drawing.Point(129, 27);
            this.mtbStudentNumber.Mask = "0000-0000";
            this.mtbStudentNumber.Name = "mtbStudentNumber";
            this.mtbStudentNumber.Size = new System.Drawing.Size(77, 20);
            this.mtbStudentNumber.TabIndex = 0;
            this.mtbStudentNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbStudentNumber.Leave += new System.EventHandler(this.mtbStudentNumber_Leave);
            // 
            // gradePointStateBindingSource
            // 
            this.gradePointStateBindingSource.DataSource = typeof(BITCollege_LV.Models.GradePointState);
            // 
            // grpRegistration
            // 
            this.grpRegistration.Controls.Add(titleLabel);
            this.grpRegistration.Controls.Add(this.lblTitle);
            this.grpRegistration.Controls.Add(creditHoursLabel);
            this.grpRegistration.Controls.Add(this.lblCreditHours);
            this.grpRegistration.Controls.Add(courseNumberLabel);
            this.grpRegistration.Controls.Add(this.lblCourseNumber);
            this.grpRegistration.Controls.Add(registrationNumberLabel);
            this.grpRegistration.Controls.Add(this.cbRegistrationNumber);
            this.grpRegistration.Location = new System.Drawing.Point(32, 352);
            this.grpRegistration.Margin = new System.Windows.Forms.Padding(2);
            this.grpRegistration.Name = "grpRegistration";
            this.grpRegistration.Padding = new System.Windows.Forms.Padding(2);
            this.grpRegistration.Size = new System.Drawing.Size(551, 159);
            this.grpRegistration.TabIndex = 8;
            this.grpRegistration.TabStop = false;
            this.grpRegistration.Text = "Registration Data";
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.lblTitle.Location = new System.Drawing.Point(287, 63);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(243, 23);
            this.lblTitle.TabIndex = 10;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_LV.Models.Registration);
            // 
            // lblCreditHours
            // 
            this.lblCreditHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreditHours.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CreditHours", true));
            this.lblCreditHours.Location = new System.Drawing.Point(126, 99);
            this.lblCreditHours.Name = "lblCreditHours";
            this.lblCreditHours.Size = new System.Drawing.Size(100, 23);
            this.lblCreditHours.TabIndex = 9;
            // 
            // lblCourseNumber
            // 
            this.lblCourseNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCourseNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.lblCourseNumber.Location = new System.Drawing.Point(126, 62);
            this.lblCourseNumber.Name = "lblCourseNumber";
            this.lblCourseNumber.Size = new System.Drawing.Size(100, 23);
            this.lblCourseNumber.TabIndex = 8;
            // 
            // cbRegistrationNumber
            // 
            this.cbRegistrationNumber.DataSource = this.registrationBindingSource;
            this.cbRegistrationNumber.DisplayMember = "RegistrationNumber";
            this.cbRegistrationNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegistrationNumber.FormattingEnabled = true;
            this.cbRegistrationNumber.Location = new System.Drawing.Point(126, 28);
            this.cbRegistrationNumber.Name = "cbRegistrationNumber";
            this.cbRegistrationNumber.Size = new System.Drawing.Size(100, 21);
            this.cbRegistrationNumber.TabIndex = 1;
            this.cbRegistrationNumber.ValueMember = "RegistrationNumber";
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(BITCollege_LV.Models.Course);
            // 
            // StudentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 604);
            this.Controls.Add(this.grpRegistration);
            this.Controls.Add(this.grpStudent);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.lnkUpdate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentData";
            this.Text = "Student";
            this.Load += new System.EventHandler(this.StudentData_Load);
            this.grpStudent.ResumeLayout(false);
            this.grpStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradePointStateBindingSource)).EndInit();
            this.grpRegistration.ResumeLayout(false);
            this.grpRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.GroupBox grpStudent;
        private System.Windows.Forms.GroupBox grpRegistration;
        private System.Windows.Forms.MaskedTextBox mtbStudentNumber;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label lblGradePointAverage;
        private System.Windows.Forms.Label lblOutstandingFees;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblCity;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblPostalCode;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblProvince;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cbRegistrationNumber;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private System.Windows.Forms.BindingSource gradePointStateBindingSource;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCreditHours;
        private System.Windows.Forms.Label lblCourseNumber;
        private System.Windows.Forms.Label lblDescription;
    }
}