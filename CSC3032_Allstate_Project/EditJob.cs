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

 //------------------------------------------------------------------------------------------------------------------------------------The Button Click Events needed to navigate the various forms---------------------
//----------------------------------------------------------------------------------------------------------

        //closes the current page and then opens the Enter Employee page when the button is pressed
        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEmp Ee = new EnterEmp();
            Ee.Show();
        }
        //closes the current page and then opens the Enter Entitlement page when the button is pressed
        private void EnterBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEntitlement Ee = new EnterEntitlement();
            Ee.Show();
        }
        //closes the current page and then opens the Edit Employee page when the button is pressed
        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }
        //closes the current page and then opens the Edit Job page when the button is pressed
        private void EnterJobBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ej = new EnterJob();
            Ej.Show();
        }

        //Takes all job names from the database and puts them into a drop down box
        private void showJobs()
        {
            String query = "select * from Jobs except select * from Jobs where [Job Name] is null and [Job Description] is null and Sector is null order by JobID";

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
        //Shows the sector of the job in the drop down box in a textbox
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
        //shows the description of the job in the drop down box in a text box
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
        //shows the entitlements of the job in the drop down box in a list box
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
        //shows the description of the entitlement in the list box in a text box
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
        //Takes all entitlements from the database and puts them into a drop down box
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
        //changes the text in the text box when the value in the drop down box changes
        private void RemvBeneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            showJobBenefitDescription();
        }

        //Gives the chosen entitlement to the chosen Job
        private void InsrtBeneBtn_Click(object sender, EventArgs e)
        {
            if (JobBox.Items.Count > 0)
            {
                if (InsrtBeneBox.Items.Count > 0)
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
                else
                {
                    MessageBox.Show("No Benefits to add");
                }
            }
            else
            {
                MessageBox.Show("No Jobs to insert benefits into.");
            }

        }

        //Removes the chosen entitlement from the chosen Job
        private void RemvBeneBtn_Click(object sender, EventArgs e)
        {
            if (JobBox.Items.Count > 0)
            {
                if (RemvBeneList.Items.Count > 0)
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
                else
                {
                    MessageBox.Show("No Benefits to remove");
                }
            }
            else
            {
                MessageBox.Show("No Job to remove benefits from.");

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
                    EditJob En = new EditJob();
                    En.Show();
                }
            }
        
    }
        //Deletes everything in the job benefits table
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

        //changes the contents in the textboxes and listboxes when the value in the drop down box changes
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

        //changes the text in the text box when the value in the drop down box changes
        private void InsrtBeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBenefitDescription();
        }
    }
}
