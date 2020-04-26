namespace CSC3032_Allstate_Project
{
    partial class EditEmploy
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.JobBeneBox = new System.Windows.Forms.ListBox();
            this.EmpBeneBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.AddBenefitBtn = new System.Windows.Forms.Button();
            this.JobUpdateBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.EmpBeneDescBox = new System.Windows.Forms.TextBox();
            this.JobBeneDescBox = new System.Windows.Forms.TextBox();
            this.ForeBox = new System.Windows.Forms.TextBox();
            this.WorkForeBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.WorkSurBix = new System.Windows.Forms.TextBox();
            this.SurBox = new System.Windows.Forms.TextBox();
            this.JobBox = new System.Windows.Forms.TextBox();
            this.ChngJobDesc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SecTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EnterEmpBtn = new System.Windows.Forms.Button();
            this.database1DataSet = new CSC3032_Allstate_Project.Database1DataSet();
            this.employee_BenefitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employee_BenefitsTableAdapter = new CSC3032_Allstate_Project.Database1DataSetTableAdapters.Employee_BenefitsTableAdapter();
            this.tableAdapterManager = new CSC3032_Allstate_Project.Database1DataSetTableAdapters.TableAdapterManager();
            this.employeeTableAdapter = new CSC3032_Allstate_Project.Database1DataSetTableAdapters.EmployeeTableAdapter();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BeneDescBox = new System.Windows.Forms.TextBox();
            this.AddBeneBut = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.EnterJobBtn = new System.Windows.Forms.Button();
            this.EnterBeneBtn = new System.Windows.Forms.Button();
            this.EditJobBeneBtn = new System.Windows.Forms.Button();
            this.ClearDatabaseBtn = new System.Windows.Forms.Button();
            this.ClearEmBeneBtn = new System.Windows.Forms.Button();
            this.IDBox = new System.Windows.Forms.ComboBox();
            this.AddBeneBox = new System.Windows.Forms.ComboBox();
            this.ChngJobBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_BenefitsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Job";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "EmployeeID";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 159);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 21);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Only Outliers";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(618, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Works Under";
            // 
            // JobBeneBox
            // 
            this.JobBeneBox.FormattingEnabled = true;
            this.JobBeneBox.ItemHeight = 16;
            this.JobBeneBox.Location = new System.Drawing.Point(462, 570);
            this.JobBeneBox.Name = "JobBeneBox";
            this.JobBeneBox.Size = new System.Drawing.Size(52, 116);
            this.JobBeneBox.TabIndex = 21;
            this.JobBeneBox.SelectedIndexChanged += new System.EventHandler(this.JobBeneBox_SelectedIndexChanged);
            // 
            // EmpBeneBox
            // 
            this.EmpBeneBox.FormattingEnabled = true;
            this.EmpBeneBox.ItemHeight = 16;
            this.EmpBeneBox.Location = new System.Drawing.Point(462, 367);
            this.EmpBeneBox.Name = "EmpBeneBox";
            this.EmpBeneBox.Size = new System.Drawing.Size(53, 116);
            this.EmpBeneBox.TabIndex = 20;
            this.EmpBeneBox.SelectedIndexChanged += new System.EventHandler(this.EmpBeneBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 330);
            this.label5.MaximumSize = new System.Drawing.Size(314, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 34);
            this.label5.TabIndex = 19;
            this.label5.Text = "If an Employee has a benefit they should not have, highlight the benefit then pre" +
    "ss the button";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 508);
            this.label7.MaximumSize = new System.Drawing.Size(314, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 51);
            this.label7.TabIndex = 22;
            this.label7.Text = "If the employee is missing a benefit from their current job: highlight the missin" +
    "g benefit then press the button.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(751, 414);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(129, 26);
            this.RemoveBtn.TabIndex = 25;
            this.RemoveBtn.Text = "Remove Benefit";
            this.RemoveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // AddBenefitBtn
            // 
            this.AddBenefitBtn.Location = new System.Drawing.Point(740, 612);
            this.AddBenefitBtn.Name = "AddBenefitBtn";
            this.AddBenefitBtn.Size = new System.Drawing.Size(93, 23);
            this.AddBenefitBtn.TabIndex = 26;
            this.AddBenefitBtn.Text = "Add Benefit";
            this.AddBenefitBtn.UseVisualStyleBackColor = true;
            this.AddBenefitBtn.Click += new System.EventHandler(this.AddBenefitBtn_Click);
            // 
            // JobUpdateBtn
            // 
            this.JobUpdateBtn.Location = new System.Drawing.Point(325, 414);
            this.JobUpdateBtn.Name = "JobUpdateBtn";
            this.JobUpdateBtn.Size = new System.Drawing.Size(114, 25);
            this.JobUpdateBtn.TabIndex = 30;
            this.JobUpdateBtn.Text = "Change Job";
            this.JobUpdateBtn.UseVisualStyleBackColor = true;
            this.JobUpdateBtn.Click += new System.EventHandler(this.JobUpdateBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 330);
            this.label8.MaximumSize = new System.Drawing.Size(341, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 34);
            this.label8.TabIndex = 27;
            this.label8.Text = "If you wish to change an employee\'s job. Choose the appropriate job from the list" +
    " then press the button";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EmpBeneDescBox
            // 
            this.EmpBeneDescBox.BackColor = System.Drawing.Color.White;
            this.EmpBeneDescBox.Location = new System.Drawing.Point(514, 367);
            this.EmpBeneDescBox.Multiline = true;
            this.EmpBeneDescBox.Name = "EmpBeneDescBox";
            this.EmpBeneDescBox.ReadOnly = true;
            this.EmpBeneDescBox.Size = new System.Drawing.Size(221, 116);
            this.EmpBeneDescBox.TabIndex = 31;
            // 
            // JobBeneDescBox
            // 
            this.JobBeneDescBox.BackColor = System.Drawing.Color.White;
            this.JobBeneDescBox.Location = new System.Drawing.Point(513, 570);
            this.JobBeneDescBox.Multiline = true;
            this.JobBeneDescBox.Name = "JobBeneDescBox";
            this.JobBeneDescBox.ReadOnly = true;
            this.JobBeneDescBox.Size = new System.Drawing.Size(221, 116);
            this.JobBeneDescBox.TabIndex = 32;
            // 
            // ForeBox
            // 
            this.ForeBox.BackColor = System.Drawing.Color.White;
            this.ForeBox.Location = new System.Drawing.Point(118, 212);
            this.ForeBox.Name = "ForeBox";
            this.ForeBox.ReadOnly = true;
            this.ForeBox.Size = new System.Drawing.Size(212, 22);
            this.ForeBox.TabIndex = 34;
            // 
            // WorkForeBox
            // 
            this.WorkForeBox.BackColor = System.Drawing.Color.White;
            this.WorkForeBox.Location = new System.Drawing.Point(621, 270);
            this.WorkForeBox.Name = "WorkForeBox";
            this.WorkForeBox.ReadOnly = true;
            this.WorkForeBox.Size = new System.Drawing.Size(220, 22);
            this.WorkForeBox.TabIndex = 35;
            // 
            // EmailBox
            // 
            this.EmailBox.BackColor = System.Drawing.Color.White;
            this.EmailBox.Location = new System.Drawing.Point(621, 212);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.ReadOnly = true;
            this.EmailBox.Size = new System.Drawing.Size(220, 22);
            this.EmailBox.TabIndex = 36;
            // 
            // WorkSurBix
            // 
            this.WorkSurBix.BackColor = System.Drawing.Color.White;
            this.WorkSurBix.Location = new System.Drawing.Point(621, 291);
            this.WorkSurBix.Name = "WorkSurBix";
            this.WorkSurBix.ReadOnly = true;
            this.WorkSurBix.Size = new System.Drawing.Size(220, 22);
            this.WorkSurBix.TabIndex = 37;
            // 
            // SurBox
            // 
            this.SurBox.BackColor = System.Drawing.Color.White;
            this.SurBox.Location = new System.Drawing.Point(118, 270);
            this.SurBox.Name = "SurBox";
            this.SurBox.ReadOnly = true;
            this.SurBox.Size = new System.Drawing.Size(212, 22);
            this.SurBox.TabIndex = 38;
            // 
            // JobBox
            // 
            this.JobBox.BackColor = System.Drawing.Color.White;
            this.JobBox.Location = new System.Drawing.Point(352, 270);
            this.JobBox.Name = "JobBox";
            this.JobBox.ReadOnly = true;
            this.JobBox.Size = new System.Drawing.Size(220, 22);
            this.JobBox.TabIndex = 39;
            // 
            // ChngJobDesc
            // 
            this.ChngJobDesc.BackColor = System.Drawing.Color.White;
            this.ChngJobDesc.Location = new System.Drawing.Point(84, 390);
            this.ChngJobDesc.Multiline = true;
            this.ChngJobDesc.Name = "ChngJobDesc";
            this.ChngJobDesc.ReadOnly = true;
            this.ChngJobDesc.Size = new System.Drawing.Size(221, 93);
            this.ChngJobDesc.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.ImageLocation = "https://logo-logos.com/wp-content/uploads/2016/10/Allstate_logo.png";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(906, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // SecTxtBox
            // 
            this.SecTxtBox.BackColor = System.Drawing.Color.White;
            this.SecTxtBox.Location = new System.Drawing.Point(352, 212);
            this.SecTxtBox.Name = "SecTxtBox";
            this.SecTxtBox.ReadOnly = true;
            this.SecTxtBox.Size = new System.Drawing.Size(221, 22);
            this.SecTxtBox.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Sector";
            // 
            // EnterEmpBtn
            // 
            this.EnterEmpBtn.Location = new System.Drawing.Point(43, 106);
            this.EnterEmpBtn.Name = "EnterEmpBtn";
            this.EnterEmpBtn.Size = new System.Drawing.Size(127, 39);
            this.EnterEmpBtn.TabIndex = 45;
            this.EnterEmpBtn.Text = "Enter Employee";
            this.EnterEmpBtn.UseVisualStyleBackColor = true;
            this.EnterEmpBtn.Click += new System.EventHandler(this.EnterEmpBtn_Click);
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employee_BenefitsBindingSource
            // 
            this.employee_BenefitsBindingSource.DataMember = "Employee Benefits";
            this.employee_BenefitsBindingSource.DataSource = this.database1DataSet;
            // 
            // employee_BenefitsTableAdapter
            // 
            this.employee_BenefitsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Employee_BenefitsTableAdapter = this.employee_BenefitsTableAdapter;
            this.tableAdapterManager.EmployeeTableAdapter = this.employeeTableAdapter;
            this.tableAdapterManager.EntitlementsTableAdapter = null;
            this.tableAdapterManager.Job_BenefitsTableAdapter = null;
            this.tableAdapterManager.JobsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CSC3032_Allstate_Project.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.database1DataSet;
            // 
            // BeneDescBox
            // 
            this.BeneDescBox.BackColor = System.Drawing.Color.White;
            this.BeneDescBox.Location = new System.Drawing.Point(84, 593);
            this.BeneDescBox.Multiline = true;
            this.BeneDescBox.Name = "BeneDescBox";
            this.BeneDescBox.ReadOnly = true;
            this.BeneDescBox.Size = new System.Drawing.Size(221, 86);
            this.BeneDescBox.TabIndex = 49;
            // 
            // AddBeneBut
            // 
            this.AddBeneBut.Location = new System.Drawing.Point(336, 612);
            this.AddBeneBut.Name = "AddBeneBut";
            this.AddBeneBut.Size = new System.Drawing.Size(103, 23);
            this.AddBeneBut.TabIndex = 48;
            this.AddBeneBut.Text = "Add Benefit";
            this.AddBeneBut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddBeneBut.UseVisualStyleBackColor = true;
            this.AddBeneBut.Click += new System.EventHandler(this.AddBeneBut_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 491);
            this.label10.MaximumSize = new System.Drawing.Size(310, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(308, 68);
            this.label10.TabIndex = 46;
            this.label10.Text = "If a specific benefit needs to be added i.e. if an employee will be working in a " +
    "different job for a joined project, choose the appropriate one from the list the" +
    "n press the button";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(116, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 50;
            this.label11.Text = "Surname";
            // 
            // EnterJobBtn
            // 
            this.EnterJobBtn.Location = new System.Drawing.Point(271, 106);
            this.EnterJobBtn.Name = "EnterJobBtn";
            this.EnterJobBtn.Size = new System.Drawing.Size(127, 39);
            this.EnterJobBtn.TabIndex = 51;
            this.EnterJobBtn.Text = "Enter Job";
            this.EnterJobBtn.UseVisualStyleBackColor = true;
            this.EnterJobBtn.Click += new System.EventHandler(this.EnterJobBtn_Click);
            // 
            // EnterBeneBtn
            // 
            this.EnterBeneBtn.Location = new System.Drawing.Point(501, 106);
            this.EnterBeneBtn.Name = "EnterBeneBtn";
            this.EnterBeneBtn.Size = new System.Drawing.Size(112, 39);
            this.EnterBeneBtn.TabIndex = 52;
            this.EnterBeneBtn.Text = "Enter Benefit";
            this.EnterBeneBtn.UseVisualStyleBackColor = true;
            this.EnterBeneBtn.Click += new System.EventHandler(this.EnterBeneBtn_Click);
            // 
            // EditJobBeneBtn
            // 
            this.EditJobBeneBtn.Location = new System.Drawing.Point(714, 106);
            this.EditJobBeneBtn.Name = "EditJobBeneBtn";
            this.EditJobBeneBtn.Size = new System.Drawing.Size(127, 39);
            this.EditJobBeneBtn.TabIndex = 53;
            this.EditJobBeneBtn.Text = "Edit Job Benefits";
            this.EditJobBeneBtn.UseVisualStyleBackColor = true;
            this.EditJobBeneBtn.Click += new System.EventHandler(this.EditJobBeneBtn_Click);
            // 
            // ClearDatabaseBtn
            // 
            this.ClearDatabaseBtn.Location = new System.Drawing.Point(785, 701);
            this.ClearDatabaseBtn.Name = "ClearDatabaseBtn";
            this.ClearDatabaseBtn.Size = new System.Drawing.Size(124, 25);
            this.ClearDatabaseBtn.TabIndex = 83;
            this.ClearDatabaseBtn.Text = "Clear Database";
            this.ClearDatabaseBtn.UseVisualStyleBackColor = true;
            this.ClearDatabaseBtn.Click += new System.EventHandler(this.ClearDatabaseBtn_Click);
            // 
            // ClearEmBeneBtn
            // 
            this.ClearEmBeneBtn.Location = new System.Drawing.Point(0, 700);
            this.ClearEmBeneBtn.Name = "ClearEmBeneBtn";
            this.ClearEmBeneBtn.Size = new System.Drawing.Size(188, 25);
            this.ClearEmBeneBtn.TabIndex = 84;
            this.ClearEmBeneBtn.Text = "Clear Employee Benefits";
            this.ClearEmBeneBtn.UseVisualStyleBackColor = true;
            this.ClearEmBeneBtn.Click += new System.EventHandler(this.ClearEmBeneBtn_Click);
            // 
            // IDBox
            // 
            this.IDBox.BackColor = System.Drawing.Color.White;
            this.IDBox.DropDownHeight = 67;
            this.IDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.IDBox.FormattingEnabled = true;
            this.IDBox.IntegralHeight = false;
            this.IDBox.Location = new System.Drawing.Point(7, 210);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(83, 24);
            this.IDBox.TabIndex = 85;
            this.IDBox.SelectedIndexChanged += new System.EventHandler(this.IDBox_SelectedIndexChanged);
            // 
            // AddBeneBox
            // 
            this.AddBeneBox.BackColor = System.Drawing.Color.White;
            this.AddBeneBox.DropDownHeight = 67;
            this.AddBeneBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddBeneBox.FormattingEnabled = true;
            this.AddBeneBox.IntegralHeight = false;
            this.AddBeneBox.Location = new System.Drawing.Point(84, 570);
            this.AddBeneBox.Name = "AddBeneBox";
            this.AddBeneBox.Size = new System.Drawing.Size(221, 24);
            this.AddBeneBox.TabIndex = 86;
            this.AddBeneBox.SelectedIndexChanged += new System.EventHandler(this.AddBeneBox_SelectedIndexChanged);
            // 
            // ChngJobBox
            // 
            this.ChngJobBox.BackColor = System.Drawing.Color.White;
            this.ChngJobBox.DropDownHeight = 67;
            this.ChngJobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChngJobBox.FormattingEnabled = true;
            this.ChngJobBox.IntegralHeight = false;
            this.ChngJobBox.Location = new System.Drawing.Point(84, 367);
            this.ChngJobBox.Name = "ChngJobBox";
            this.ChngJobBox.Size = new System.Drawing.Size(221, 24);
            this.ChngJobBox.TabIndex = 88;
            this.ChngJobBox.SelectedIndexChanged += new System.EventHandler(this.ChngJobBox_SelectedIndexChanged);
            // 
            // EditEmploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 725);
            this.Controls.Add(this.ChngJobBox);
            this.Controls.Add(this.AddBeneBox);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.ClearEmBeneBtn);
            this.Controls.Add(this.ClearDatabaseBtn);
            this.Controls.Add(this.EditJobBeneBtn);
            this.Controls.Add(this.EnterBeneBtn);
            this.Controls.Add(this.EnterJobBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BeneDescBox);
            this.Controls.Add(this.AddBeneBut);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.EnterEmpBtn);
            this.Controls.Add(this.SecTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChngJobDesc);
            this.Controls.Add(this.JobBox);
            this.Controls.Add(this.SurBox);
            this.Controls.Add(this.WorkSurBix);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.WorkForeBox);
            this.Controls.Add(this.ForeBox);
            this.Controls.Add(this.JobBeneDescBox);
            this.Controls.Add(this.EmpBeneDescBox);
            this.Controls.Add(this.JobUpdateBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddBenefitBtn);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.JobBeneBox);
            this.Controls.Add(this.EmpBeneBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditEmploy";
            this.Text = "Edit Employee Benefits and see Outliers";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_BenefitsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox JobBeneBox;
        private System.Windows.Forms.ListBox EmpBeneBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button AddBenefitBtn;
        private System.Windows.Forms.Button JobUpdateBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EmpBeneDescBox;
        private System.Windows.Forms.TextBox JobBeneDescBox;
        private System.Windows.Forms.TextBox ForeBox;
        private System.Windows.Forms.TextBox WorkForeBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox WorkSurBix;
        private System.Windows.Forms.TextBox SurBox;
        private System.Windows.Forms.TextBox JobBox;
        private System.Windows.Forms.TextBox ChngJobDesc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox SecTxtBox;
        private System.Windows.Forms.Label label9;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource employee_BenefitsBindingSource;
        private Database1DataSetTableAdapters.Employee_BenefitsTableAdapter employee_BenefitsTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Database1DataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.Button EnterEmpBtn;
        private System.Windows.Forms.TextBox BeneDescBox;
        private System.Windows.Forms.Button AddBeneBut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button EnterJobBtn;
        private System.Windows.Forms.Button EnterBeneBtn;
        private System.Windows.Forms.Button EditJobBeneBtn;
        private System.Windows.Forms.Button ClearDatabaseBtn;
        private System.Windows.Forms.Button ClearEmBeneBtn;
        private System.Windows.Forms.ComboBox IDBox;
        private System.Windows.Forms.ComboBox AddBeneBox;
        private System.Windows.Forms.ComboBox ChngJobBox;
    }
}

