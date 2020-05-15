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

//------------------------------------------------------------------------------------------------------------------------------------The Button Click Events needed to navigate the various forms----------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------

        //closes the current page and then opens the Edit Employee page when the button is pressed
        private void EditEmployBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmploy Ee = new EditEmploy();
            Ee.Show();
        }
        //closes the current page and then opens the Edit Job page when the button is pressed
        private void EditJobBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditJob Ee = new EditJob();
            Ee.Show();
        }
        //closes the current page and then opens the Enter Entitlement page when the button is pressed
        private void EnterBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEntitlement Ee = new EnterEntitlement();
            Ee.Show();
        }
        //closes the current page and then opens the Enter Employee page when the button is pressed
        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterJob Ee = new EnterJob();
            Ee.Show();
        }

        //puts the names of all jobs in the database into a drop down menu
        private void showchngJobName()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Jobs except select * from Jobs where [Job Name] is null and [Job Description] is null and Sector is null order by JobID", connection))
            {
                DataTable JIDtable = new DataTable();
                adapter.Fill(JIDtable);

                JobBox.DisplayMember = "Job Name";
                JobBox.ValueMember = "JobID";
                JobBox.DataSource = JIDtable;
            }
        }
        //changes the text of an invisible text box to the ID number of the job in the drop down menu
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
        //puts the ID numbers of all employees in the database into a drop down menu
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
        //shows the forename of the employee who's ID is in the WUIDBox
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
        //shows the surname of the employee who's ID is in the WUIDBox
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
        //enters in the details of the textboxes as a new employee or replacing a deleted employee
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ForeTextBox.Text))//Employee won't be entered if Forename text box is empty
            {
                MessageBox.Show("You have not entered the forename of this new employee");
            }
            else
            {
                if (string.IsNullOrEmpty(SurTextBox.Text))//Employee won't be entered if Surname text box is empty
                {
                    MessageBox.Show("You have not entered the surname of this new employee");
                }
                else
                {
                    if (string.IsNullOrEmpty(MailTextBox.Text))//Employee won't be entered if Email text box is empty
                    {
                        MessageBox.Show("You have not entered the email of this new employee");
                    }
                    else
                    {
                        if (!MailTextBox.Text.Contains("@"))//Employee won't be entered if Email text box does not contain @
                        {
                            MessageBox.Show("You have not entered the email of this new employee correctly");
                        }
                        else { 
                            connection = new SqlConnection(connectionString);


                            String query = "declare @a int; " +
                                "declare @b int; " +
                                "declare @c int; " +
                                "if ((select count(*) from Employee) > 0) Begin set @c = (select max(EmployeeID) from Employee) end else Begin set @c = 0 end " + // if there are no employees in the table c = 0 but if there's at least 1 employee, c = the highest employee ID in the table
                                "set @a = (select count(*)  from Employee where Forename is null and Surname is null and Email is null) " +//a = the number of jobs with no details except the EmployeeID
                                "if @a > 0 " +
                                "Begin " +
                                "set @b = (select min(EmployeeID) from Employee where Forename is null and Surname is null and Email is null) " + //b = the ID number of the employee with the lowest ID number with no other details
                                "update Employee set Forename = (@Forename), Surname = @Surname, Email = @Email, JobID = @JobID, [Works Under] = @WorksUnder where EmployeeID = @b  " + //updates the details of the Employee with the EmployeeID of b with the details from the text boxes
                                "end " +
                                "else " +
                                "begin " +
                                "DBCC CHECKIDENT(Employee, RESEED, @c) " +
                                "Insert into [Employee](Forename, Surname, Email, JobID, [Works Under]) Values (@Forename, @Surname, @Email, @JobID, @WorksUnder); " + //inserts the details from the text boxes at the end of the table
                                "end";

                            using (connection = new SqlConnection(connectionString))
                            using (SqlCommand command = new SqlCommand(query, connection))
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                connection.Open();

                                command.Parameters.AddWithValue("@Forename", ForeTextBox.Text);
                                command.Parameters.AddWithValue("@Surname", SurTextBox.Text);
                                command.Parameters.AddWithValue("@Email", MailTextBox.Text);
                                if (string.IsNullOrEmpty(JobIDBox.Text))//allows the employee to be entered if there are no jobs since there is the chance that the user will chose to enter in the employees first
                                {
                                    command.Parameters.AddWithValue("@JobID", DBNull.Value);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@JobID", JobIDBox.Text);
                                }
                                    
                                if (string.IsNullOrEmpty(WUIDBox.Text))//allows the employee to be entered if there are no other employees since there will be no other employees when the database is cleared
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
                                    MessageBox.Show("Employee Entered");
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

        //changes the value of the unseen textbox when the value in the drop down box 
        private void JobListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showchngJobID();
        }

        //puts the ID number of all employees into a drop down menu
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

        //puts the forename of the employee in the IDBox in a textbox
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
        //puts the Surname of the employee in the IDBox in a textbox
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
        //puts the Email of the employee in the IDBox in a textbox
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

        //puts the Job Name of the employee in the IDBox in a textbox
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

        //puts the forename of the employee who the employee in the IDBox works for in a textbox
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

        //puts the surname of the employee who the employee in the IDBox works for in a textbox
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
        //changes the text in the text boxes when the ID number in the drop down box changes.
        private void IDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showForeNames();
            showSurNames();
            showEmail();
            showJobs();
            showWUForeName();
            showWUSurName();
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
                    EnterEmp En = new EnterEmp();
                    En.Show();
                }
            }

        }
        //deletes everything in the employee benefits and employee tables
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
        //changes the text in the text boxes when the value in the ID drop down box changes
        private void IDBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            showForeNames();
            showSurNames();
            showEmail();
            showJobs();
            showWUForeName();
            showWUSurName();
        }

        //changes the text in the text boxes when the value in the WUID drop down box changes
        private void WUIDBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            showWUForeNames();
            showWUSurNames();
        }
        //changes the text in the unseen text box when the name of the job in the drop down box is changed
        private void JobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showchngJobID();
        }
        //Deletes all benefits owned by the selected employee, anyone who worked under them has their Works Under field set to NULL and sets all their details to NULL
        private void DeleteEmpBtn_Click(object sender, EventArgs e)
        {
            if (IDBox.Items.Count > 0)
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
                        showForeNames();
                        showSurNames();
                        showEmail();
                        showJobs();
                        showWUForeName();
                        showWUSurName();
                        showWID();
                        showWUForeNames();
                        showWUSurNames();
                        MessageBox.Show("Employee Deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Employee to Delete");
            }            
        }
    }
}
