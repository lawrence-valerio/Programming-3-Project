namespace BITCollegeWindows
{
    partial class Grading
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label courseTypeLabel;
            System.Windows.Forms.Label gradeLabel;
            this.gbStudent = new System.Windows.Forms.GroupBox();
            this.gbGrading = new System.Windows.Forms.GroupBox();
            this.lblExisting = new System.Windows.Forms.Label();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mlblStudentNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mlblCourseNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblCourseType = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbGrade = new System.Windows.Forms.TextBox();
            studentNumberLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            courseTypeLabel = new System.Windows.Forms.Label();
            gradeLabel = new System.Windows.Forms.Label();
            this.gbStudent.SuspendLayout();
            this.gbGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbStudent
            // 
            this.gbStudent.Controls.Add(descriptionLabel);
            this.gbStudent.Controls.Add(this.lblDescription);
            this.gbStudent.Controls.Add(this.lblFullName);
            this.gbStudent.Controls.Add(studentNumberLabel);
            this.gbStudent.Controls.Add(this.mlblStudentNumber);
            this.gbStudent.Location = new System.Drawing.Point(20, 39);
            this.gbStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbStudent.Name = "gbStudent";
            this.gbStudent.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbStudent.Size = new System.Drawing.Size(542, 111);
            this.gbStudent.TabIndex = 0;
            this.gbStudent.TabStop = false;
            this.gbStudent.Text = "Student Data";
            // 
            // gbGrading
            // 
            this.gbGrading.Controls.Add(gradeLabel);
            this.gbGrading.Controls.Add(this.tbGrade);
            this.gbGrading.Controls.Add(this.lblTitle);
            this.gbGrading.Controls.Add(courseTypeLabel);
            this.gbGrading.Controls.Add(this.lblCourseType);
            this.gbGrading.Controls.Add(courseNumberLabel);
            this.gbGrading.Controls.Add(this.mlblCourseNumber);
            this.gbGrading.Controls.Add(this.lblExisting);
            this.gbGrading.Controls.Add(this.lnkReturn);
            this.gbGrading.Controls.Add(this.lnkUpdate);
            this.gbGrading.Location = new System.Drawing.Point(75, 171);
            this.gbGrading.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbGrading.Name = "gbGrading";
            this.gbGrading.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbGrading.Size = new System.Drawing.Size(441, 265);
            this.gbGrading.TabIndex = 1;
            this.gbGrading.TabStop = false;
            this.gbGrading.Text = "Grading Information";
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(236, 162);
            this.lblExisting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(185, 13);
            this.lblExisting.TabIndex = 2;
            this.lblExisting.Text = "Existing grades cannot be overridden.";
            this.lblExisting.Visible = false;
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(236, 225);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(117, 13);
            this.lnkReturn.TabIndex = 1;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(108, 225);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(74, 13);
            this.lnkUpdate.TabIndex = 0;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_LV.Models.Student);
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(35, 28);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 0;
            studentNumberLabel.Text = "Student Number:";
            // 
            // mlblStudentNumber
            // 
            this.mlblStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblStudentNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.mlblStudentNumber.Location = new System.Drawing.Point(128, 28);
            this.mlblStudentNumber.Mask = "0000-0000";
            this.mlblStudentNumber.Name = "mlblStudentNumber";
            this.mlblStudentNumber.Size = new System.Drawing.Size(100, 23);
            this.mlblStudentNumber.TabIndex = 1;
            this.mlblStudentNumber.Text = "    -";
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(249, 28);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(227, 23);
            this.lblFullName.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(35, 68);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "AcademicProgram.Description", true));
            this.lblDescription.Location = new System.Drawing.Point(128, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(191, 23);
            this.lblDescription.TabIndex = 4;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_LV.Models.Registration);
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(31, 32);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(83, 13);
            courseNumberLabel.TabIndex = 3;
            courseNumberLabel.Text = "Course Number:";
            // 
            // mlblCourseNumber
            // 
            this.mlblCourseNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblCourseNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.mlblCourseNumber.Location = new System.Drawing.Point(120, 32);
            this.mlblCourseNumber.Name = "mlblCourseNumber";
            this.mlblCourseNumber.Size = new System.Drawing.Size(100, 23);
            this.mlblCourseNumber.TabIndex = 4;
            // 
            // courseTypeLabel
            // 
            courseTypeLabel.AutoSize = true;
            courseTypeLabel.Location = new System.Drawing.Point(31, 69);
            courseTypeLabel.Name = "courseTypeLabel";
            courseTypeLabel.Size = new System.Drawing.Size(70, 13);
            courseTypeLabel.TabIndex = 5;
            courseTypeLabel.Text = "Course Type:";
            // 
            // lblCourseType
            // 
            this.lblCourseType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCourseType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseType", true));
            this.lblCourseType.Location = new System.Drawing.Point(120, 69);
            this.lblCourseType.Name = "lblCourseType";
            this.lblCourseType.Size = new System.Drawing.Size(100, 23);
            this.lblCourseType.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.lblTitle.Location = new System.Drawing.Point(239, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 23);
            this.lblTitle.TabIndex = 8;
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new System.Drawing.Point(31, 162);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new System.Drawing.Size(39, 13);
            gradeLabel.TabIndex = 8;
            gradeLabel.Text = "Grade:";
            // 
            // tbGrade
            // 
            this.tbGrade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Grade", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "p2"));
            this.tbGrade.Location = new System.Drawing.Point(120, 159);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(100, 20);
            this.tbGrade.TabIndex = 9;
            // 
            // Grading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 457);
            this.Controls.Add(this.gbGrading);
            this.Controls.Add(this.gbStudent);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Grading";
            this.Text = "Grading";
            this.Load += new System.EventHandler(this.Grading_Load);
            this.gbStudent.ResumeLayout(false);
            this.gbStudent.PerformLayout();
            this.gbGrading.ResumeLayout(false);
            this.gbGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStudent;
        private System.Windows.Forms.GroupBox gbGrading;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label lblFullName;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblStudentNumber;
        private System.Windows.Forms.TextBox tbGrade;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCourseType;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblCourseNumber;
    }
}