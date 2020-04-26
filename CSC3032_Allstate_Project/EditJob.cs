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
    public partial class EditJob : Form
    {
        SqlConnection connection;
        string connectionString;
        public EditJob()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CSC3032_Allstate_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;

            InitializeComponent();
            showJobs();
            showBenefits();
            pictureBox1.Image = Properties.Resources.Allstate_logo;

        }

        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEmp Ee = new EnterEmp();
            Ee.Show();
        }

        private void EnterBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEntitlement Ee = new EnterEntitlement();
            Ee.Show();
        }

        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }

        private void EnterJobBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ej = new EnterJob();
            Ej.Show();
        }

        private void showJobs()
        {
            String query = "select [Job Name] from Jobs except (select [Job Name] from Jobs where [Job Name] is null and [Job Description] is null and Sector is null)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                JobBox.DisplayMember = "Job Name";
                JobBox.ValueMember = "JobID";
                JobBox.DataSource = JobBeneTable;
            }

        }

        private void showSector()
        {
            String query = "select [Sector] from Jobs where [Job Name] = @JobName";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@JobName", JobBox.Text);


                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    SectorTextBox.Text = (cr["Sector"].ToString());
                }
                else
                {
                    SectorTextBox.Clear();
                }
            }

        }

        private void showDescription()
        {
            String query = "select [Job Description] from Jobs where [Job Name] = @JobName";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@JobName", JobBox.Text);


                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    JobDescBox.Text = (cr["Job Description"].ToString());
                }
                else
                {
                    JobDescBox.Clear();
                }
            }

        }

        private void showJobBenefits()
        {
            String query = "select [EntitlementID] from [Job Benefits] where JobID = (Select JobID from Jobs where [Job Name] = @JobName)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@JobName", JobBox.Text);


                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                RemvBeneList.DisplayMember = "EntitlementID";
                RemvBeneList.ValueMember = "JobID";
                RemvBeneList.DataSource = JobBeneTable;
            }

        }

        private void showJobBenefitDescription()
        {
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", RemvBeneList.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    RemvBeneBox.Text = (cr["Description"].ToString());
                }
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

                InsrtBeneBox.DisplayMember = "EntitlementID";
                InsrtBeneBox.ValueMember = "JobID";
                InsrtBeneBox.DataSource = JobBeneTable;
            }

        }

        private void showBenefitDescription()
        {
            InsrtBeneDesc.Clear();
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", InsrtBeneBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    InsrtBeneDesc.Text = (cr["Description"].ToString());
                }
            }
        }

        private void RemvBeneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            showJobBenefitDescription();
        }

        private void InsrtBeneBtn_Click(object sender, EventArgs e)
        {
            String query = "Insert into [Job Benefits] Values ((Select JobID from Jobs where [Job Name] = @JobName), @EntitlementID)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                command.Parameters.AddWithValue("@JobName", JobBox.Text);
                command.Parameters.AddWithValue("@EntitlementID", InsrtBeneBox.Text);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            showJobBenefits();
        }

        private void RemvBeneBtn_Click(object sender, EventArgs e)
        {
            String query = "Delete from [Job Benefits] where JobID = (Select [JobID] from Jobs where [Job Name] = @JobName) and EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                command.Parameters.AddWithValue("@JobName", JobBox.Text);
                command.Parameters.AddWithValue("@EntitlementID", RemvBeneList.Text);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            showJobBenefits();
            if (RemvBeneList.Items.Count == 0)
            {
                RemvBeneBox.Clear();
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
                    EditJob En = new EditJob();
                    En.Show();
                }
            }
        
    }

        private void ClearJobBeneBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear all your jobs of their current benefits. Are you sure you want to do this?", "Clear Job Benefits", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                String query = "Delete from [Job Benefits]; ";

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
                EditJob En = new EditJob();
                En.Show();
            }
        }

        private void JobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSector();
            showDescription();
            showJobBenefits();
            if (RemvBeneList.Items.Count == 0)
            {
                RemvBeneBox.Clear();
            }
        }

        private void InsrtBeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBenefitDescription();
        }
    }
}
