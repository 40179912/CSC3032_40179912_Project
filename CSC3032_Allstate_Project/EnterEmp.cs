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
    public partial class EnterEmp : Form
    {
        SqlConnection connection;
        string connectionString;
        public EnterEmp()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["CSC3032_Allstate_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
            showchngJobName();
            showWID();
            showID();
            pictureBox1.Image = Properties.Resources.Allstate_logo;
        }

        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }

        private void EditJobBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditJob Ee = new EditJob();
            Ee.Show();
        }

        private void EnterBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEntitlement Ee = new EnterEntitlement();
            Ee.Show();
        }

        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ee = new EnterJob();
            Ee.Show();
        }

        private void showchngJobName()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Jobs", connection))
            {
                DataTable JIDtable = new DataTable();
                adapter.Fill(JIDtable);

                JobBox.DisplayMember = "Job Name";
                JobBox.ValueMember = "JobID";
                JobBox.DataSource = JIDtable;
            }
        }

        private void showchngJobID()
        {
            String query = "SELECT [JobID] FROM Jobs where [Job Name] = @JobName";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@JobName", JobBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    JobIDBox.Text = (cr["JobID"].ToString());
                }
                else
                {
                    JobIDBox.Clear();
                }
            }
        }

        private void showWID()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employee except (Select * from Employee where Forename is null and Surname is null and Email is null)", connection))
            {
                DataTable IDtable = new DataTable();
                adapter.Fill(IDtable);

                WUIDBox.DisplayMember = "EmployeeID";
                WUIDBox.ValueMember = "JobID";
                WUIDBox.DataSource = IDtable;
            }
        }

        private void showWUForeNames()
        {
            String query = "select Forename from Employee" +
                " where EmployeeID = @EmployeeID";


            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", WUIDBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    WUForeBox.Text = (cr["Forename"].ToString());
                }
                else
                {
                    WUForeBox.Clear();
                }
            }
        }

        private void showWUSurNames()
        {
            String query = "select Surname from Employee" +
                " where EmployeeID = @EmployeeID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", WUIDBox.Text);
                connection.Open();

                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    WUSurBox.Text = (cr["Surname"].ToString());
                }
                else
                {
                    WUSurBox.Clear();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ForeTextBox.Text))
            {
                MessageBox.Show("You have not entered the forename of this new employee");
            }
            else
            {
                if (string.IsNullOrEmpty(SurTextBox.Text))
                {
                    MessageBox.Show("You have not entered the surname of this new employee");
                }
                else
                {
                    if (string.IsNullOrEmpty(MailTextBox.Text))
                    {
                        MessageBox.Show("You have not entered the email of this new employee");
                    }
                    else
                    {
                        if (!MailTextBox.Text.Contains("@"))
                        {
                            MessageBox.Show("You have not entered the email of this new employee correctly");
                        }
                        else { 
                            connection = new SqlConnection(connectionString);


                            String query = "declare @a int; " +
                                "declare @b int; " +
                                "declare @c int; " +
                                "set @c = (select max(EmployeeID) from Employee) " +
                                "set @a = (select count(*)  from Employee where Forename is null and Surname is null and Email is null) " +
                                "if @a > 0 " +
                                "Begin " +
                                "set @b = (select min(EmployeeID) from Employee where Forename is null and Surname is null and Email is null) " +
                                "update Employee set Forename = (@Forename), Surname = @Surname, Email = @Email, JobID = @JobID, [Works Under] = @WorksUnder where EmployeeID = @b  " +
                                "end " +
                                "else " +
                                "begin " +
                                "DBCC CHECKIDENT(Employee, RESEED, @c) " +
                                "Insert into [Employee](Forename, Surname, Email, JobID, [Works Under]) Values (@Forename, @Surname, @Email, @JobID, @WorksUnder); " +
                                "end";

                            using (connection = new SqlConnection(connectionString))
                            using (SqlCommand command = new SqlCommand(query, connection))
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                connection.Open();

                                command.Parameters.AddWithValue("@Forename", ForeTextBox.Text);
                                command.Parameters.AddWithValue("@Surname", SurTextBox.Text);
                                command.Parameters.AddWithValue("@Email", MailTextBox.Text);
                                if (string.IsNullOrEmpty(JobIDBox.Text))
                                {
                                    command.Parameters.AddWithValue("@JobID", DBNull.Value);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@JobID", JobIDBox.Text);
                                }
                                    
                                if (string.IsNullOrEmpty(WUIDBox.Text))
                                {
                                    command.Parameters.AddWithValue("@WorksUnder", DBNull.Value);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@WorksUnder", WUIDBox.Text);
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
                            ForeTextBox.Clear();
                            SurTextBox.Clear();
                            MailTextBox.Clear();
                            showchngJobName();
                            showID();
                            showWID();
                        }
                    }
                }
            }

        }


        private void JobListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showchngJobID();
        }

        private void showID()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employee except (select * from Employee where Forename is null and Surname is null and Email is null)", connection))
            {
                DataTable IDtable = new DataTable();
                adapter.Fill(IDtable);

                IDBox.DisplayMember = "EmployeeID";
                IDBox.ValueMember = "JobID";
                IDBox.DataSource = IDtable;
            }

        }

        private void showForeNames()
        {
            String query = "SELECT Forename FROM Employee where EmployeeID = @EmployeeID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);


                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    showForeBox.Text = (cr["Forename"].ToString());

                }
                else
                {
                    showForeBox.Clear();
                }
            }

        }

        private void showSurNames()
        {
            String query = "SELECT Surname FROM Employee where EmployeeID = @EmployeeID";


            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    showSurBox.Text = (cr["Surname"].ToString());
                }
                else
                {
                    showSurBox.Clear();
                }
            }

        }

        private void showEmail()
        {
            String query = "SELECT Email FROM Employee where EmployeeID = @EmployeeID";


            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    showMailBox.Text = (cr["Email"].ToString());
                }
                else
                {
                    showMailBox.Clear();
                }
            }

        }


        private void showJobs()
        {
            String query = "SELECT [Job Name] FROM Jobs " +
                "where JobID = (Select JobID From Employee where EmployeeID = @EmployeeID)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);


                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    showJobBox.Text = (cr["Job Name"].ToString());
                }
                else
                {
                    showJobBox.Clear();
                }
            }
        }

        private void showWUForeName()
        {
            String query = "select Forename from Employee" +
                " where EmployeeID = (Select [Works Under] from Employee where EmployeeID = @EmployeeID)";


            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    showWUForeBox.Text = (cr["Forename"].ToString());
                }
                else
                {
                    showWUForeBox.Clear();
                }
            }
        }

        private void showWUSurName()
        {
            String query = "select Surname from Employee" +
                " where EmployeeID = (Select [Works Under] from Employee where EmployeeID = @EmployeeID)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                connection.Open();

                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    ShowWUSurBox.Text = (cr["Surname"].ToString());
                }
                else
                {
                    ShowWUSurBox.Clear();
                }

            }

        }

        private void IDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showForeNames();
            showSurNames();
            showEmail();
            showJobs();
            showWUForeName();
            showWUSurName();
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
                    EnterEmp En = new EnterEmp();
                    En.Show();
                }
            }

        }

        private void ClearEmpBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear all your employees from the database. Are you sure you want to do this?", "Clear Job Benefits", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                String query = " " +
                    "Delete from [Employee Benefits]; " +
                    "Delete from Employee;";

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
                EnterEmp En = new EnterEmp();
                En.Show();
            }
        }

        private void IDBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            showForeNames();
            showSurNames();
            showEmail();
            showJobs();
            showWUForeName();
            showWUSurName();
        }

        private void WUIDBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            showWUForeNames();
            showWUSurNames();
        }

        private void JobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showchngJobID();
        }

        private void DeleteEmpBtn_Click(object sender, EventArgs e)
        {
            String query = " " +
                    "Delete from [Employee Benefits] where EmployeeID = @ID; " +
                    "update Employee set [Works Under] = NULL where [Works Under] = @ID " +
                    "update Employee set Forename = NULL, Surname = NULL, Email = NULL, JobID = NULL, [Works Under] = NULL where EmployeeID = @ID;";



            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@ID", IDBox.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    showID();
                    showWID();
                    MessageBox.Show("Employee Deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
