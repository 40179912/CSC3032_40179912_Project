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
            showBenefits();
            pictureBox1.Image = Properties.Resources.Allstate_logo;
        }

        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEmp Ee = new EnterEmp();
            Ee.Show();
        }

        private void EditJobBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditJob Ej = new EditJob();
            Ej.Show();
        }

        private void EnterJobBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ej = new EnterJob();
            Ej.Show();
        }

        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }



        private void AddBeneBut_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(EntitlementTextBox.Text))
            {
                MessageBox.Show("You have not entered a description for this entitlement");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                String query = "declare @a int;" +
                    "declare @b int;" +
                    " declare @c int;" +
                    " set @c = (select max(EntitlementID) from Entitlements) " +
                    "set @a = (select count(*) from Entitlements where Description is null) " +
                    "if @a > 0  " +
                    "Begin  " +
                    "set @b = (select min(EntitlementID) from Entitlements where Description is null)  " +
                    "update Entitlements set Description = (@Description) where EntitlementID = @b " +
                    "end  " +
                    "else  " +
                    "begin  " +
                    "DBCC CHECKIDENT(Entitlements, RESEED, @c)  " +
                    "Insert into [Entitlements](Description) Values (@Description) " +
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

        private void showBenefitDescription()
        {
            BeneDescBox.Clear();
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


        private void DeleteBeneBtn_Click(object sender, EventArgs e)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
