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
    public partial class EnterJob : Form
    {
        SqlConnection connection;
        string connectionString;

        public EnterJob()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CSC3032_Allstate_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;

            InitializeComponent();
            showSector();
            showJobs();
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

        private void EditJobBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditJob Ee = new EditJob();
            Ee.Show();
        }

        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }


        private void showSector()
        {
            String query = "select distinct [Sector] from Jobs";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                SectorBox.DisplayMember = "Sector";
                SectorBox.ValueMember = "JobID";
                SectorBox.DataSource = JobBeneTable;
            }
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

        private void showJobSector()
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
                    ShowSectorBox.Text = (cr["Sector"].ToString());
                }
                else
                {
                    ShowSectorBox.Clear();
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

        private void AddJobBut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(JobNameBox.Text))
            {
                MessageBox.Show("You have not entered a name for this job");
            }
            else
            {
                if (string.IsNullOrEmpty(JobDescTextBox.Text))
                {
                    MessageBox.Show("You have not entered a decription for this job");
                }
                else
                {
                    if (string.IsNullOrEmpty(SectorTextBox.Text))
                    {
                        if (string.IsNullOrEmpty(SectorBox.Text))
                        {
                            MessageBox.Show("You have not entered the name of the sector of this job");
                        }
                        else
                        {
                            connection = new SqlConnection(connectionString);
                            String query = "declare @a int; " +
                           "declare @b int; " +
                           "declare @c int; " +
                           "set @c = (select max(JobID) from Jobs) " +
                           "set @a = (select count(*) from Jobs where [Job Name] is null and [Job Description] is null and Sector is null) " +
                           "if @a > 0 " +
                           "Begin " +
                           "set @b = (select min(JobID) from Jobs where [Job Name] is null and [Job Description] is null and Sector is null) " +
                           "update Jobs set [Job Name] = (@JobName), [Job Description] = @Description, Sector = @Sector where JobID = @b " +
                           "end " +
                           "else " +
                           "begin " +
                           "DBCC CHECKIDENT(Jobs, RESEED, @c) " +
                           "Insert into [Jobs]([Job Name], [Job Description], [Sector]) Values (@JobName, @Description, @Sector); " +
                           "end";

                            using (connection = new SqlConnection(connectionString))
                            using (SqlCommand command = new SqlCommand(query, connection))
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@JobName", JobNameBox.Text);
                                command.Parameters.AddWithValue("@Description", JobDescTextBox.Text);
                                if (string.IsNullOrEmpty(SectorTextBox.Text))
                                {
                                    command.Parameters.AddWithValue("@Sector", SectorBox.Text);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@Sector", SectorTextBox.Text);
                                }
                                try
                                {
                                    command.ExecuteReader();
                                    MessageBox.Show("Job Entered");
                                }
                                catch (System.Data.SqlClient.SqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            showJobs();
                            showSector();
                            JobNameBox.Clear();
                            JobDescTextBox.Clear();
                            SectorTextBox.Clear();
                        }
                    }
                    else
                    {
                        connection = new SqlConnection(connectionString);
                        String query = "declare @a int; " +
                            "declare @b int; " +
                            "declare @c int; " +
                            "set @c = (select max(JobID) from Jobs) " +
                            "set @a = (select count(*) from Jobs where [Job Name] is null and [Job Description] is null and Sector is null) " +
                            "if @a > 0 " +
                            "Begin " +
                            "set @b = (select min(JobID) from Jobs where [Job Name] is null and [Job Description] is null and Sector is null) " +
                            "update Jobs set [Job Name] = (@JobName), [Job Description] = @Description, Sector = @Sector where JobID = @b " +
                            "end " +
                            "else " +
                            "begin " +
                            "DBCC CHECKIDENT(Jobs, RESEED, @c) " +
                            "Insert into [Jobs]([Job Name], [Job Description], [Sector]) Values (@JobName, @Description, @Sector); " +
                            "end";
                        using (connection = new SqlConnection(connectionString))
                        using (SqlCommand command = new SqlCommand(query, connection))
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@JobName", JobNameBox.Text);
                            command.Parameters.AddWithValue("@Description", JobDescTextBox.Text);
                            if (string.IsNullOrEmpty(SectorTextBox.Text))
                            {
                                command.Parameters.AddWithValue("@Sector", SectorBox.Text);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Sector", SectorTextBox.Text);
                            }
                            try
                            {
                                command.ExecuteReader();
                            }
                            catch (System.Data.SqlClient.SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        showJobs();
                        showSector();
                        JobNameBox.Clear();
                        JobDescTextBox.Clear();
                        SectorTextBox.Clear();
                    }
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
                    EditEmploy En = new EditEmploy();
                    En.Show();
                }
            }
        
    }

        private void ClearJobsBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear all your jobs from the database. Are you sure you want to do this?", "Clear Jobs", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                String query = "Delete from [Job Benefits]; " +
                    "Update Employee set JobID = NULL; " +
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
                EditEmploy En = new EditEmploy();
                En.Show();
            }
        }

        private void JobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showJobSector();
            showDescription();
        }

        private void DeleteJobBtn_Click(object sender, EventArgs e)
        {
            String query = " " +
                    "Delete from [Job Benefits] where JobID = (Select JobID from Jobs where [Job Name] = @ID);" +
                    "update Employee set JobID = NULL where JobID = (Select JobID from Jobs where [Job Name] = @ID);" +
                    "update Jobs set [Job Name] = NULL, [Job Description] = NULL, Sector = NULL where [Job Name] = @ID;" ;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@ID", JobBox.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Job Deleted");

                    showJobs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
