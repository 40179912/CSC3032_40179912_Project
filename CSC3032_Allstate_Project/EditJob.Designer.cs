namespace CSC3032_Allstate_Project
{
    partial class EditJob
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
            this.JobDescBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SectorTextBox = new System.Windows.Forms.TextBox();
            this.RemvBeneBox = new System.Windows.Forms.TextBox();
            this.RemvBeneBtn = new System.Windows.Forms.Button();
            this.RemvBeneList = new System.Windows.Forms.ListBox();
            this.InsrtBeneDesc = new System.Windows.Forms.TextBox();
            this.InsrtBeneBtn = new System.Windows.Forms.Button();
            this.EnterJobBtn = new System.Windows.Forms.Button();
            this.EnterBeneBtn = new System.Windows.Forms.Button();
            this.EditEmployBeneBtn = new System.Windows.Forms.Button();
            this.EnterEmpBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearDatabaseBtn = new System.Windows.Forms.Button();
            this.ClearJobBeneBtn = new System.Windows.Forms.Button();
            this.JobBox = new System.Windows.Forms.ComboBox();
            this.InsrtBeneBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // JobDescBox
            // 
            this.JobDescBox.Location = new System.Drawing.Point(123, 276);
            this.JobDescBox.Multiline = true;
            this.JobDescBox.Name = "JobDescBox";
            this.JobDescBox.Size = new System.Drawing.Size(222, 252);
            this.JobDescBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Job Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Job Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sector";
            // 
            // SectorTextBox
            // 
            this.SectorTextBox.Location = new System.Drawing.Point(123, 257);
            this.SectorTextBox.Multiline = true;
            this.SectorTextBox.Name = "SectorTextBox";
            this.SectorTextBox.Size = new System.Drawing.Size(222, 20);
            this.SectorTextBox.TabIndex = 7;
            // 
            // RemvBeneBox
            // 
            this.RemvBeneBox.BackColor = System.Drawing.Color.White;
            this.RemvBeneBox.Location = new System.Drawing.Point(436, 412);
            this.RemvBeneBox.Multiline = true;
            this.RemvBeneBox.Name = "RemvBeneBox";
            this.RemvBeneBox.ReadOnly = true;
            this.RemvBeneBox.Size = new System.Drawing.Size(221, 116);
            this.RemvBeneBox.TabIndex = 34;
            // 
            // RemvBeneBtn
            // 
            this.RemvBeneBtn.Location = new System.Drawing.Point(674, 462);
            this.RemvBeneBtn.Name = "RemvBeneBtn";
            this.RemvBeneBtn.Size = new System.Drawing.Size(126, 26);
            this.RemvBeneBtn.TabIndex = 33;
            this.RemvBeneBtn.Text = "Remove Benefit";
            this.RemvBeneBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemvBeneBtn.UseVisualStyleBackColor = true;
            this.RemvBeneBtn.Click += new System.EventHandler(this.RemvBeneBtn_Click);
            // 
            // RemvBeneList
            // 
            this.RemvBeneList.FormattingEnabled = true;
            this.RemvBeneList.ItemHeight = 16;
            this.RemvBeneList.Location = new System.Drawing.Point(384, 412);
            this.RemvBeneList.Name = "RemvBeneList";
            this.RemvBeneList.Size = new System.Drawing.Size(53, 116);
            this.RemvBeneList.TabIndex = 32;
            this.RemvBeneList.SelectedIndexChanged += new System.EventHandler(this.RemvBeneList_SelectedIndexChanged);
            // 
            // InsrtBeneDesc
            // 
            this.InsrtBeneDesc.BackColor = System.Drawing.Color.White;
            this.InsrtBeneDesc.Location = new System.Drawing.Point(436, 233);
            this.InsrtBeneDesc.Multiline = true;
            this.InsrtBeneDesc.Name = "InsrtBeneDesc";
            this.InsrtBeneDesc.ReadOnly = true;
            this.InsrtBeneDesc.Size = new System.Drawing.Size(221, 116);
            this.InsrtBeneDesc.TabIndex = 37;
            // 
            // InsrtBeneBtn
            // 
            this.InsrtBeneBtn.Location = new System.Drawing.Point(685, 280);
            this.InsrtBeneBtn.Name = "InsrtBeneBtn";
            this.InsrtBeneBtn.Size = new System.Drawing.Size(93, 26);
            this.InsrtBeneBtn.TabIndex = 36;
            this.InsrtBeneBtn.Text = "Add Benefit";
            this.InsrtBeneBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InsrtBeneBtn.UseVisualStyleBackColor = true;
            this.InsrtBeneBtn.Click += new System.EventHandler(this.InsrtBeneBtn_Click);
            // 
            // EnterJobBtn
            // 
            this.EnterJobBtn.Location = new System.Drawing.Point(467, 102);
            this.EnterJobBtn.Name = "EnterJobBtn";
            this.EnterJobBtn.Size = new System.Drawing.Size(101, 39);
            this.EnterJobBtn.TabIndex = 63;
            this.EnterJobBtn.Text = "Enter Job";
            this.EnterJobBtn.UseVisualStyleBackColor = true;
            this.EnterJobBtn.Click += new System.EventHandler(this.EnterJobBtn_Click);
            // 
            // EnterBeneBtn
            // 
            this.EnterBeneBtn.Location = new System.Drawing.Point(622, 102);
            this.EnterBeneBtn.Name = "EnterBeneBtn";
            this.EnterBeneBtn.Size = new System.Drawing.Size(111, 39);
            this.EnterBeneBtn.TabIndex = 62;
            this.EnterBeneBtn.Text = "Enter Benefit";
            this.EnterBeneBtn.UseVisualStyleBackColor = true;
            this.EnterBeneBtn.Click += new System.EventHandler(this.EnterBeneBtn_Click);
            // 
            // EditEmployBeneBtn
            // 
            this.EditEmployBeneBtn.Location = new System.Drawing.Point(45, 102);
            this.EditEmployBeneBtn.Name = "EditEmployBeneBtn";
            this.EditEmployBeneBtn.Size = new System.Drawing.Size(180, 39);
            this.EditEmployBeneBtn.TabIndex = 61;
            this.EditEmployBeneBtn.Text = "Edit Employee Benefits";
            this.EditEmployBeneBtn.UseVisualStyleBackColor = true;
            this.EditEmployBeneBtn.Click += new System.EventHandler(this.EditEmployBeneBtn_Click);
            // 
            // EnterEmpBtn
            // 
            this.EnterEmpBtn.Location = new System.Drawing.Point(271, 102);
            this.EnterEmpBtn.Name = "EnterEmpBtn";
            this.EnterEmpBtn.Size = new System.Drawing.Size(132, 39);
            this.EnterEmpBtn.TabIndex = 60;
            this.EnterEmpBtn.Text = "Enter Employee";
            this.EnterEmpBtn.UseVisualStyleBackColor = true;
            this.EnterEmpBtn.Click += new System.EventHandler(this.EnterEmpBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.ImageLocation = "https://logo-logos.com/wp-content/uploads/2016/10/Allstate_logo.png";
            this.pictureBox1.Location = new System.Drawing.Point(1, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(823, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 179);
            this.label4.MaximumSize = new System.Drawing.Size(347, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 34);
            this.label4.TabIndex = 64;
            this.label4.Text = "Choose the Job you wish to add an entitlement to from the list";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 179);
            this.label5.MaximumSize = new System.Drawing.Size(347, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 51);
            this.label5.TabIndex = 65;
            this.label5.Text = "If you want to add a new entitlement to a specific job, choose the specific entit" +
    "lement you want from the list then press the button.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 358);
            this.label6.MaximumSize = new System.Drawing.Size(347, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 51);
            this.label6.TabIndex = 66;
            this.label6.Text = "To remove an entitlement from the Job just choose the specific entitlement from t" +
    "he list, then press the button";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClearDatabaseBtn
            // 
            this.ClearDatabaseBtn.Location = new System.Drawing.Point(703, 559);
            this.ClearDatabaseBtn.Name = "ClearDatabaseBtn";
            this.ClearDatabaseBtn.Size = new System.Drawing.Size(124, 25);
            this.ClearDatabaseBtn.TabIndex = 83;
            this.ClearDatabaseBtn.Text = "Clear Database";
            this.ClearDatabaseBtn.UseVisualStyleBackColor = true;
            this.ClearDatabaseBtn.Click += new System.EventHandler(this.ClearDatabaseBtn_Click);
            // 
            // ClearJobBeneBtn
            // 
            this.ClearJobBeneBtn.Location = new System.Drawing.Point(1, 559);
            this.ClearJobBeneBtn.Name = "ClearJobBeneBtn";
            this.ClearJobBeneBtn.Size = new System.Drawing.Size(151, 25);
            this.ClearJobBeneBtn.TabIndex = 84;
            this.ClearJobBeneBtn.Text = "Clear Job Benefits";
            this.ClearJobBeneBtn.UseVisualStyleBackColor = true;
            this.ClearJobBeneBtn.Click += new System.EventHandler(this.ClearJobBeneBtn_Click);
            // 
            // JobBox
            // 
            this.JobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JobBox.FormattingEnabled = true;
            this.JobBox.IntegralHeight = false;
            this.JobBox.Location = new System.Drawing.Point(123, 234);
            this.JobBox.Name = "JobBox";
            this.JobBox.Size = new System.Drawing.Size(222, 24);
            this.JobBox.TabIndex = 85;
            this.JobBox.SelectedIndexChanged += new System.EventHandler(this.JobBox_SelectedIndexChanged);
            // 
            // InsrtBeneBox
            // 
            this.InsrtBeneBox.DropDownHeight = 67;
            this.InsrtBeneBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsrtBeneBox.FormattingEnabled = true;
            this.InsrtBeneBox.IntegralHeight = false;
            this.InsrtBeneBox.Location = new System.Drawing.Point(383, 233);
            this.InsrtBeneBox.Name = "InsrtBeneBox";
            this.InsrtBeneBox.Size = new System.Drawing.Size(53, 24);
            this.InsrtBeneBox.TabIndex = 86;
            this.InsrtBeneBox.SelectedIndexChanged += new System.EventHandler(this.InsrtBeneBox_SelectedIndexChanged);
            // 
            // EditJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 583);
            this.Controls.Add(this.InsrtBeneBox);
            this.Controls.Add(this.JobBox);
            this.Controls.Add(this.ClearJobBeneBtn);
            this.Controls.Add(this.ClearDatabaseBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EnterJobBtn);
            this.Controls.Add(this.EnterBeneBtn);
            this.Controls.Add(this.EditEmployBeneBtn);
            this.Controls.Add(this.EnterEmpBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InsrtBeneDesc);
            this.Controls.Add(this.InsrtBeneBtn);
            this.Controls.Add(this.RemvBeneBox);
            this.Controls.Add(this.RemvBeneBtn);
            this.Controls.Add(this.RemvBeneList);
            this.Controls.Add(this.SectorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JobDescBox);
            this.Name = "EditJob";
            this.Text = "Edit Job Benefits";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox JobDescBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SectorTextBox;
        private System.Windows.Forms.TextBox RemvBeneBox;
        private System.Windows.Forms.Button RemvBeneBtn;
        private System.Windows.Forms.ListBox RemvBeneList;
        private System.Windows.Forms.TextBox InsrtBeneDesc;
        private System.Windows.Forms.Button InsrtBeneBtn;
        private System.Windows.Forms.Button EnterJobBtn;
        private System.Windows.Forms.Button EnterBeneBtn;
        private System.Windows.Forms.Button EditEmployBeneBtn;
        private System.Windows.Forms.Button EnterEmpBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ClearDatabaseBtn;
        private System.Windows.Forms.Button ClearJobBeneBtn;
        private System.Windows.Forms.ComboBox JobBox;
        private System.Windows.Forms.ComboBox InsrtBeneBox;
    }
}