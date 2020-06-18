using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CSC3032_Allstate_Project
{
    public partial class EnterEntitlement : Form
    {
        SqlConnection connection;
        string connectionString;
        public EnterEntitlement()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CSC3032_Allstate_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;

            InitializeComponent();
            this.Size = new Size(815, 515);

            showBenefits();
            pictureBox1.Image = Properties.Resources.Allstate_logo;
        }

//------------------------------------------------------------------------------------------------------------------------------------The Button Click Events needed to navigate the various forms---------------------
//----------------------------------------------------------------------------------------------------------

        //closes the current page and then opens the Enter Employee page when the button is pressed
        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEmp Ee = new EnterEmp();
            Ee.Show();
        }
        //closes the current page and then opens the Edit Job page when the button is pressed
        private void EditJobBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditJob Ej = new EditJob();
            Ej.Show();
        }
        //closes the current page and then opens the Enter Job page when the button is pressed
        private void EnterJobBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ej = new EnterJob();
            Ej.Show();
        }
        //closes the current page and then opens the Edit Employee page when the button is pressed
        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }


        //enters new entitlements into the database
        private void AddBeneBut_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(EntitlementTextBox.Text))//Entitlement won't be entered if Description text box is empty
            {
                MessageBox.Show("You have not entered a description for this entitlement");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                String query = "declare @a int;" +
                    "declare @b int;" +
                    " declare @c int;" +
                    "if ((select count(*) from Entitlements) > 0) Begin set @c = (select max(EntitlementID) from Entitlements) end else Begin set @c = 0 end " +// if there are no entitlements in the table c = 0 but if there's at least 1 entitlement, c = the highest entitlement ID in the table
                    "set @a = (select count(*) from Entitlements where Description is null) " +//a = the number of entitlements with no descrition
                    "if @a > 0  " +
                    "Begin  " +
                    "set @b = (select min(EntitlementID) from Entitlements where Description is null)  " +//b = the entitlement with no description with the lowest ID                                                                                                  number
                    "update Entitlements set Description = (@Description) where EntitlementID = @b " +//the description at b is replaced with the description in the text                                                                                    box.
                    "end  " +
                    "else  " +
                    "begin  " +
                    "DBCC CHECKIDENT(Entitlements, RESEED, @c)  " +
                    "Insert into [Entitlements](Description) Values (@Description) " +//a new entitlement is created at the end of the table using the description in the text box
                    "end;";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Description", EntitlementTextBox.Text);
                    try
                    {
                        command.ExecuteReader();
                        MessageBox.Show("Entitlement Entered");

                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                showBenefits();
                EntitlementTextBox.Clear();
            }
            
        }

        //puts the ID number of all entitlements into a drop down menu
        private void showBenefits()
        {
            String query = "select [EntitlementID] from Entitlements except (Select EntitlementID from Entitlements where Description is null)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                BeneBox.DisplayMember = "EntitlementID";
                BeneBox.ValueMember = "JobID";
                BeneBox.DataSource = JobBeneTable;
            }

        }

        //puts the description of the job with the ID number in the drop down box into a text box
        private void showBenefitDescription()
        {
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", BeneBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    BeneDescBox.Text = (cr["Description"].ToString());
                }
            }
        }
        //deletes everything in the database
        private void ClearDatabaseBtn_Click(object sender, EventArgs e)
        {

            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear your database of all data. Are you sure you want to do this?", "Clear Database", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                DialogResult dr = MessageBox.Show("Are you completely sure that you wish to clear your database? You cannot retrieve your database and it will be deleted forever", "Clear Database", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    String query = "Delete from [Employee Benefits]; " +
                    "Delete from [Job Benefits]; " +
                    "Delete from Entitlements; " +
                    "Delete from Employee; " +
                    "Delete from Jobs;";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    this.Hide();
                    EnterEntitlement En = new EnterEntitlement();
                    En.Show();
                }
            }
        
    }
        //Deletes everything from the employee benefits, job benefits and entitlement tables
        private void ClearEntitleBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear all your entitlements from the database. Are you sure you want to do this?", "Clear Job Benefits", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                String query = "Delete from [Job Benefits]; " +
                    "Delete from [Employee Benefits]; " +
                    "Delete from [Entitlements];";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                this.Hide();
                EnterEntitlement En = new EnterEntitlement();
                En.Show();
            }
        }

        private void BeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBenefitDescription();
        }

        //Deletes any use of a chosen entitlement from the employee benefits and job benefits and sets all fields of the entitlement, except the ID number, to NULL
        private void DeleteBeneBtn_Click(object sender, EventArgs e)
        {
            if (BeneBox.Items.Count > 0)
            {
                String query = " " +
                    "Delete from [Employee Benefits] where EntitlementID = @ID; " +
                    "Delete from [Job Benefits] where EntitlementID = @ID;" +
                    "update Entitlements set Description = NULL where EntitlementID = @ID;";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@ID", BeneBox.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Entitlement Deleted");
                        showBenefits();
                        if (BeneBox.Items.Count == 0)
                        {
                            BeneDescBox.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("No Benefit to delete");
            }
            
        }

        private void EnterEntitlement_Resize(object sender, EventArgs e)
        {
            panel2.Width = this.Width/2;
            panel2.Left = 0;

            panel1.Width = this.Width / 2;
            panel1.Left = panel2.Right;
        }
    }
}
