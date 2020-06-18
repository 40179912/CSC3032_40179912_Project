namespace CSC3032_Allstate_Project
{
    partial class EnterEntitlement
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
            this.label2 = new System.Windows.Forms.Label();
            this.EntitlementTextBox = new System.Windows.Forms.TextBox();
            this.AddBeneBut = new System.Windows.Forms.Button();
            this.BeneDescBox = new System.Windows.Forms.TextBox();
            this.EditJobBeneBtn = new System.Windows.Forms.Button();
            this.EnterJobBtn = new System.Windows.Forms.Button();
            this.EnterEmpBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EditEmployBeneBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearDatabaseBtn = new System.Windows.Forms.Button();
            this.ClearEntitleBtn = new System.Windows.Forms.Button();
            this.BeneBox = new System.Windows.Forms.ComboBox();
            this.DeleteBeneBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 22);
            this.label2.MaximumSize = new System.Drawing.Size(347, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 51);
            this.label2.TabIndex = 7;
            this.label2.Text = "To add an entitlement into the Database just enter in the description of what the" +
    " entitlement is, then press the button";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EntitlementTextBox
            // 
            this.EntitlementTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EntitlementTextBox.Location = new System.Drawing.Point(38, 79);
            this.EntitlementTextBox.Multiline = true;
            this.EntitlementTextBox.Name = "EntitlementTextBox";
            this.EntitlementTextBox.Size = new System.Drawing.Size(347, 132);
            this.EntitlementTextBox.TabIndex = 6;
            // 
            // AddBeneBut
            // 
            this.AddBeneBut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddBeneBut.Location = new System.Drawing.Point(163, 217);
            this.AddBeneBut.Name = "AddBeneBut";
            this.AddBeneBut.Size = new System.Drawing.Size(103, 23);
            this.AddBeneBut.TabIndex = 49;
            this.AddBeneBut.Text = "Add Benefit";
            this.AddBeneBut.UseVisualStyleBackColor = true;
            this.AddBeneBut.Click += new System.EventHandler(this.AddBeneBut_Click);
            // 
            // BeneDescBox
            // 
            this.BeneDescBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BeneDescBox.BackColor = System.Drawing.Color.White;
            this.BeneDescBox.Location = new System.Drawing.Point(81, 77);
            this.BeneDescBox.Multiline = true;
            this.BeneDescBox.Name = "BeneDescBox";
            this.BeneDescBox.ReadOnly = true;
            this.BeneDescBox.Size = new System.Drawing.Size(238, 132);
            this.BeneDescBox.TabIndex = 51;
            // 
            // EditJobBeneBtn
            // 
            this.EditJobBeneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditJobBeneBtn.Location = new System.Drawing.Point(634, 15);
            this.EditJobBeneBtn.Name = "EditJobBeneBtn";
            this.EditJobBeneBtn.Size = new System.Drawing.Size(130, 39);
            this.EditJobBeneBtn.TabIndex = 58;
            this.EditJobBeneBtn.Text = "Edit Job Benefits";
            this.EditJobBeneBtn.UseVisualStyleBackColor = true;
            this.EditJobBeneBtn.Click += new System.EventHandler(this.EditJobBeneBtn_Click);
            // 
            // EnterJobBtn
            // 
            this.EnterJobBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EnterJobBtn.Location = new System.Drawing.Point(462, 15);
            this.EnterJobBtn.Name = "EnterJobBtn";
            this.EnterJobBtn.Size = new System.Drawing.Size(130, 39);
            this.EnterJobBtn.TabIndex = 56;
            this.EnterJobBtn.Text = "Enter Job";
            this.EnterJobBtn.UseVisualStyleBackColor = true;
            this.EnterJobBtn.Click += new System.EventHandler(this.EnterJobBtn_Click);
            // 
            // EnterEmpBtn
            // 
            this.EnterEmpBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EnterEmpBtn.Location = new System.Drawing.Point(274, 15);
            this.EnterEmpBtn.Name = "EnterEmpBtn";
            this.EnterEmpBtn.Size = new System.Drawing.Size(130, 39);
            this.EnterEmpBtn.TabIndex = 55;
            this.EnterEmpBtn.Text = "Enter Employee";
            this.EnterEmpBtn.UseVisualStyleBackColor = true;
            this.EnterEmpBtn.Click += new System.EventHandler(this.EnterEmpBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.ImageLocation = "https://logo-logos.com/wp-content/uploads/2016/10/Allstate_logo.png";
            this.pictureBox1.Location = new System.Drawing.Point(-1, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // EditEmployBeneBtn
            // 
            this.EditEmployBeneBtn.Location = new System.Drawing.Point(38, 15);
            this.EditEmployBeneBtn.Name = "EditEmployBeneBtn";
            this.EditEmployBeneBtn.Size = new System.Drawing.Size(180, 39);
            this.EditEmployBeneBtn.TabIndex = 62;
            this.EditEmployBeneBtn.Text = "Edit Employee Benefits";
            this.EditEmployBeneBtn.UseVisualStyleBackColor = true;
            this.EditEmployBeneBtn.Click += new System.EventHandler(this.EditEmployBeneBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 5);
            this.label1.MaximumSize = new System.Drawing.Size(347, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 68);
            this.label1.TabIndex = 63;
            this.label1.Text = "To check to see if the entitlement was entered properly, simply scroll down to th" +
    "e bottom of the list and highlight the last ID and to delete your chosen entitle" +
    "ment, just press the delete button.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClearDatabaseBtn
            // 
            this.ClearDatabaseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearDatabaseBtn.Location = new System.Drawing.Point(674, 31);
            this.ClearDatabaseBtn.Name = "ClearDatabaseBtn";
            this.ClearDatabaseBtn.Size = new System.Drawing.Size(124, 25);
            this.ClearDatabaseBtn.TabIndex = 82;
            this.ClearDatabaseBtn.Text = "Clear Database";
            this.ClearDatabaseBtn.UseVisualStyleBackColor = true;
            this.ClearDatabaseBtn.Click += new System.EventHandler(this.ClearDatabaseBtn_Click);
            // 
            // ClearEntitleBtn
            // 
            this.ClearEntitleBtn.Location = new System.Drawing.Point(0, 31);
            this.ClearEntitleBtn.Name = "ClearEntitleBtn";
            this.ClearEntitleBtn.Size = new System.Drawing.Size(135, 25);
            this.ClearEntitleBtn.TabIndex = 84;
            this.ClearEntitleBtn.Text = "Clear Entitlements";
            this.ClearEntitleBtn.UseVisualStyleBackColor = true;
            this.ClearEntitleBtn.Click += new System.EventHandler(this.ClearEntitleBtn_Click);
            // 
            // BeneBox
            // 
            this.BeneBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BeneBox.DropDownHeight = 94;
            this.BeneBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BeneBox.FormattingEnabled = true;
            this.BeneBox.IntegralHeight = false;
            this.BeneBox.Location = new System.Drawing.Point(28, 77);
            this.BeneBox.Name = "BeneBox";
            this.BeneBox.Size = new System.Drawing.Size(53, 24);
            this.BeneBox.TabIndex = 87;
            this.BeneBox.SelectedIndexChanged += new System.EventHandler(this.BeneBox_SelectedIndexChanged);
            // 
            // DeleteBeneBtn
            // 
            this.DeleteBeneBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteBeneBtn.Location = new System.Drawing.Point(162, 213);
            this.DeleteBeneBtn.Name = "DeleteBeneBtn";
            this.DeleteBeneBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBeneBtn.TabIndex = 91;
            this.DeleteBeneBtn.Text = "Delete";
            this.DeleteBeneBtn.UseVisualStyleBackColor = true;
            this.DeleteBeneBtn.Click += new System.EventHandler(this.DeleteBeneBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.BeneDescBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BeneBox);
            this.panel1.Controls.Add(this.DeleteBeneBtn);
            this.panel1.Location = new System.Drawing.Point(420, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 250);
            this.panel1.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.EntitlementTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.AddBeneBut);
            this.panel2.Location = new System.Drawing.Point(-1, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 250);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.ClearEntitleBtn);
            this.panel3.Controls.Add(this.ClearDatabaseBtn);
            this.panel3.Location = new System.Drawing.Point(-1, 413);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 56);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel4.Controls.Add(this.EditEmployBeneBtn);
            this.panel4.Controls.Add(this.EnterEmpBtn);
            this.panel4.Controls.Add(this.EnterJobBtn);
            this.panel4.Controls.Add(this.EditJobBeneBtn);
            this.panel4.Location = new System.Drawing.Point(-1, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 70);
            this.panel4.TabIndex = 50;
            // 
            // EnterEntitlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 468);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EnterEntitlement";
            this.Text = "Enter Entitlements/Benefits";
            this.Resize += new System.EventHandler(this.EnterEntitlement_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EntitlementTextBox;
        private System.Windows.Forms.Button AddBeneBut;
        private System.Windows.Forms.TextBox BeneDescBox;
        private System.Windows.Forms.Button EditJobBeneBtn;
        private System.Windows.Forms.Button EnterJobBtn;
        private System.Windows.Forms.Button EnterEmpBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button EditEmployBeneBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearDatabaseBtn;
        private System.Windows.Forms.Button ClearEntitleBtn;
        private System.Windows.Forms.ComboBox BeneBox;
        private System.Windows.Forms.Button DeleteBeneBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}