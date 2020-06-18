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
    public partial class EditEmploy : Form
    {
        SqlConnection connection;
        string connectionString;
        public EditEmploy()
        {
            InitializeComponent();
            this.Size = new Size(988, 822);

            connectionString = ConfigurationManager.ConnectionStrings["CSC3032_Allstate_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;

            FindOutliers();
            showID();
            showchngJobID();
            pictureBox1.Image = Properties.Resources.Allstate_logo;
        }
 //------------------------------------------------------------------------------------------------------------------------------------The Button Click Events needed to navigate the various forms---------------------
 //-----------------------------------------------------------------------------------------------------------
        //closes the current page and then opens the Enter Employee page when the button is pressed
        private void EnterEmpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEmp En = new EnterEmp();
            En.Show();
        }
        //closes the current page and then opens the Enter Entitlement page when the button is pressed
        private void EnterBeneBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnterEntitlement En = new EnterEntitlement();
            En.Show();
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


//----------------------------------------------------------------------------------------------------------- Function used to find Outliers within the database by comparing an employee's entitlements with the entitlements of their job. If they match then they are not labeled an outlier but if there is a difference -------------------------------------they are labeled an outlier. ----------------------------------------- ----------------------------------------------------------------------------------------------------------
        private void FindOutliers()
        {
            String query = "" +
                "declare @x int; " + //The Employee's ID
                "declare @y int " + 
                "declare @z int " +
                "set @x = (select min(EmployeeID) from Employee); " + //x = lowest EmployeeID in database
                "while @x <= (select max(EmployeeID) from Employee) " + 
                "begin " + //While loop that continues until all employees have been checked
                "set @y = (select count(*) from((select EntitlementID from [Employee Benefits] where EmployeeID = @x) except (select EntitlementID from[Job Benefits] where JobID = (select JobID from Employee where EmployeeID = @x)))temp) " +//y = the number of benefits that the employee has that is not in their job. 
                "set @z = (select count(*) from (select EntitlementID from [Job Benefits] where JobID = (select JobID from Employee where EmployeeID = @x) except (select EntitlementID from [Employee Benefits] where EmployeeID = @x))temp)" +//z = the number of benefits that the employee doesnt have from their job.
                "if @y > 0 or @z > 0 " +
                "update Employee set Anomoly = 1 where EmployeeID = @x " +
                "else " + //if y or z are greater than 1,  
                "update Employee set Anomoly = 0 where EmployeeID = @x " +
                "set @x = @x + 1 " +
                "end";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



//----------------------------------------------------------------------------------------------------------
//---------------------Functions used that reley on the employee's ID---------------------------------------
//----------------------------------------------------------------------------------------------------------

        //Shows the ID Numbers of every employee working at the company inside of a dropdown box except those who have been removed from the database
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

        //Shows the ID numbers of every employee in the company who is listed as an outlier aka they either have an entitlement they should not have or they are missing a entitlement they should have.
        private void showOutliers()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employee where Anomoly = 1", connection))
            {
                DataTable OIDtable = new DataTable();
                adapter.Fill(OIDtable);

                IDBox.DisplayMember = "EmployeeID";
                IDBox.ValueMember = "JobID";
                IDBox.DataSource = OIDtable;
            }
        }

        //when the checkbox is checked it will change the ID box to reflect if the user is looking for outliers or not
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FindOutliers();

            if (checkBox1.Checked)
            {
                showOutliers();
            }
            else
            {
                showID();
            }
            showForeNames();
            showSurNames();
            showEmail();
            showJobSection();
            showJobs();
            showWUForeNames();
            showWUSurNames();
            showJobBenefits();
            showEmployeeBenefits();
            if (EmpBeneBox.Items.Count == 0)
            {
                EmpBeneDescBox.Clear();
            }
            if (JobBeneBox.Items.Count == 0)
            {
                JobBeneDescBox.Clear();
            }
        }

        //Shows the forename of the employee who's employee ID is in the ID box
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
                    ForeBox.Text = (cr["Forename"].ToString());

                }
                else
                {
                    ForeBox.Clear();
                }
            }

        }

        //Shows the surname of the employee who's employee ID is in the ID box
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
                    SurBox.Text = (cr["Surname"].ToString());
                }
                else
                {
                    SurBox.Clear();
                }
            }

        }

        //Shows the Email of the employee who's employee ID is in the ID box
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
                    EmailBox.Text = (cr["Email"].ToString());
                }
                else
                {
                    EmailBox.Clear();
                }
            }

        }

        //Shows what sector the employee who's employee ID is in the ID box works in
        private void showJobSection()
        {
            String query = "SELECT [Sector] FROM Jobs " +
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
                    SecTxtBox.Text = (cr["Sector"].ToString());
                }
                else
                {
                    SecTxtBox.Clear();
                }
            }
        }

        //Shows the Job title of the employee who's employee ID is in the ID box
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
                    JobBox.Text = (cr["Job Name"].ToString());
                }
                else
                {
                    JobBox.Clear();
                }
            }
        }

        //Shows the forename of the boss of the employee who's employee ID is in the ID box
        private void showWUForeNames()
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
                    WorkForeBox.Text = (cr["Forename"].ToString());
                }
                else
                {
                    WorkForeBox.Clear();
                }
            }
        }

        //Shows the surname of the boss of the employee who's employee ID is in the ID box
        private void showWUSurNames()
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
                    WorkSurBix.Text = (cr["Surname"].ToString());
                }
                else
                {
                    WorkSurBix.Clear();
                }

            }

        }

        //changes the values of the various text boxes when the value of the Employee ID box changes
        private void IDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showForeNames();
            showSurNames();
            showEmail();
            showJobs();
            showJobSection();
            showWUForeNames();
            showWUSurNames();
            showBenefits();
            showEmployeeBenefits();
            showJobBenefits();

            if (JobBeneBox.Items.Count == 0)
            {
                JobBeneDescBox.Clear();
            }
            if (EmpBeneBox.Items.Count == 0)
            {
                EmpBeneDescBox.Clear();
            }
        }

//---------------------------------------------------------------------------------------------------------------------- Allows the user to change an Employee's Job on the page so that ---------------------------- ------------ the Benefits can be added without having to swap forms ------------------------------------ -----------------------------------------------------------------------------------------------------------

        //Shows all of the Jobs names inside of a dropdown box so that an employees job can be changed using the job chosen
        private void showchngJobID()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Jobs except select * from Jobs where [Job Name] is null and [Job Description] is null and Sector is null order by JobID", connection))
            {
                DataTable JIDtable = new DataTable();
                adapter.Fill(JIDtable);

                ChngJobBox.DisplayMember = "Job Name";
                ChngJobBox.ValueMember = "JobID";
                ChngJobBox.DataSource = JIDtable;
            }
        }
        //shows description of the job selected so that the user can get a basic understanding of the job
        private void showchngJobDesc()
        {
            String query = "SELECT [Job Description] FROM Jobs where [Job Name] = @JobName";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@JobName", ChngJobBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    ChngJobDesc.Text = (cr["Job Description"].ToString());
                }
                else
                {
                    ChngJobDesc.Clear();
                }
            }
        }

        //Changes the current job of the chosen employee to the chosenjob in the dropdown box 
        private void JobUpdateBtn_Click(object sender, EventArgs e)
        {
            if (IDBox.Items.Count > 0)
            {
                if (ChngJobBox.Items.Count > 0)
                {
                    connection = new SqlConnection(connectionString);
                    String query = "Update [Employee] set JobID = (Select JobID from Jobs where [Job Name] = @JobName) where EmployeeID = @EmployeeID";
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@JobName", ChngJobBox.Text);
                        command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);

                        command.ExecuteScalar();
                    }
                    FindOutliers();
                    if (checkBox1.Checked)
                    {
                        string X = IDBox.Text;
                        showOutliers();
                        IDBox.Text = X;
                    }
                    showForeNames();
                    showSurNames();
                    showEmail();
                    showJobSection();
                    showJobs();
                    showWUForeNames();
                    showWUSurNames();
                    showJobBenefits();
                    showEmployeeBenefits();
                    if (EmpBeneBox.Items.Count == 0)
                    {
                        EmpBeneDescBox.Clear();
                    }
                    if (JobBeneBox.Items.Count == 0)
                    {
                        JobBeneDescBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("There are no Jobs to change into");
                }
            }
            else
            {
                MessageBox.Show("There are no employees");
            }

        }

        //reads the desription of the new job when the job in the drop down list is changed
        private void ChngJobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showchngJobDesc();
        }

        //----------------------------------------------------------------------------------------------------------   
        //Functions related to the allowing the user to give any benefit to any employee should the need arise -----------------------------------------------------------------------------------------------------------
        
        //Puts all benefit ID numbers in drop down menu
        private void showBenefits()
        {
            String query = "select [EntitlementID] from Entitlements except (Select EntitlementID from Entitlements where Description is null)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                AddBeneBox.DisplayMember = "EntitlementID";
                AddBeneBox.ValueMember = "JobID";
                AddBeneBox.DataSource = JobBeneTable;
            }

        }

        //Show description of benefit currently in benefits box
        private void showBenefitDescription()
        {
            BeneDescBox.Clear();
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", AddBeneBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    BeneDescBox.Text = (cr["Description"].ToString());
                }
            }
        }
        //reads the desription of the new benefit when new benefit in the dropdown box is chosen
        private void AddBeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBenefitDescription();
        }

        //Adds selected benefit to selected employees benefits
        private void AddBeneBut_Click(object sender, EventArgs e)
        {
            if (IDBox.Items.Count > 0)
            {
                if (AddBeneBox.Items.Count > 0)
                {


                    String query = "Insert into [Employee Benefits] Values (@EmployeeID, @EntitlementID)";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                        command.Parameters.AddWithValue("@EntitlementID", AddBeneBox.Text);
                        try
                        {
                            command.ExecuteNonQuery();

                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            MessageBox.Show("This Employee already has this entitlement and it cannot be entered in again. Please select a different entitlement. ");
                        }
                    }

                    FindOutliers();
                    if (checkBox1.Checked)
                    {
                        string X = IDBox.Text;
                        showOutliers();
                        IDBox.Text = X;
                    }
                    showForeNames();
                    showSurNames();
                    showEmail();
                    showJobSection();
                    showJobs();
                    showWUForeNames();
                    showWUSurNames();
                    showJobBenefits();
                    showEmployeeBenefits();
                    if (EmpBeneBox.Items.Count == 0)
                    {
                        EmpBeneDescBox.Clear();
                    }
                    if (JobBeneBox.Items.Count == 0)
                    {
                        JobBeneDescBox.Clear();
                    }
                }

                else
                {
                    MessageBox.Show("There are no Benefits to add");
                }
            }
            else
            {
                MessageBox.Show("There are no employees");
            }
        }

        //----------------------------------------------------------------------------------------------------------
        //Functions related to showing an employee's benefits and removing them if they have benefits they shouldn't have. 
        //-----------------------------------------------------------------------------------------------------------
        
        //shows all ID numbers of benefits the current employee has in a list box
        private void showEmployeeBenefits()
        {
            String query = "SELECT EntitlementID FROM [Employee Benefits] where EmployeeID = @EmployeeID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);

                DataTable EmpBenetable = new DataTable();
                adapter.Fill(EmpBenetable);



                EmpBeneBox.DisplayMember = "EntitlementID";
                EmpBeneBox.ValueMember = "JobID";
                EmpBeneBox.DataSource = EmpBenetable;
            }

        }


        //shows the description of the benefit currently highlighted in the employee benefit listbox
        private void showEmployeeBenefitDescription()
        {
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", EmpBeneBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    EmpBeneDescBox.Text = (cr["Description"].ToString());
                }
            }
        }

        //reads the desription of the new employee benefit when each benefit in the listbox is highlighted
        private void EmpBeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showEmployeeBenefitDescription();
        }

        //Removes the highlighted benefit from the chosen employee's benefits when the button is pressed
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (IDBox.Items.Count > 0)
            {
                if (EmpBeneBox.Items.Count > 0)
                {
                    String query = "Delete from [Employee Benefits] where EmployeeID = @EmployeeID and EntitlementID = @EntitlementID";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                        command.Parameters.AddWithValue("@EntitlementID", EmpBeneBox.Text);
                        try
                        {
                            command.ExecuteNonQuery();

                        }
                        catch
                        {

                        }
                    }

                    FindOutliers();
                    if (checkBox1.Checked)
                    {
                        string X = IDBox.Text;
                        showOutliers();
                        IDBox.Text = X;
                    }
                    showForeNames();
                    showSurNames();
                    showEmail();
                    showJobSection();
                    showJobs();
                    showWUForeNames();
                    showWUSurNames();
                    showJobBenefits();
                    showEmployeeBenefits();
                    if (EmpBeneBox.Items.Count == 0)
                    {
                        EmpBeneDescBox.Clear();
                    }
                    if (JobBeneBox.Items.Count == 0)
                    {
                        JobBeneDescBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("There are no benefits to remove");
                }
            }
            else
            {
                MessageBox.Show("There are no Employees");
            }
            
           
        }



//---------------------------------------------------------------------------------------------------------- Functions designed around showing the benefits of the job that the employee has and allowing the user to               add a benefit to an employee's benefits if they are missing it.
//-----------------------------------------------------------------------------------------------------------
        //shows the ID number of all benefits for the job of the employee in a listbox
        private void showJobBenefits()
        {
            String query = "select [EntitlementID] from [Job Benefits] " +
                "where JobID = (Select JobID from Employee where EmployeeID = @EmployeeID)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);

                DataTable JobBeneTable = new DataTable();
                adapter.Fill(JobBeneTable);

                JobBeneBox.DisplayMember = "EntitlementID";
                JobBeneBox.ValueMember = "JobID";
                JobBeneBox.DataSource = JobBeneTable;
            }

        }
        //shows the description of the job benefit in the listbox
        private void showJobBenefitDescription()
        {
            JobBeneDescBox.Clear();
            String query = "select [Description] from [Entitlements] where EntitlementID = @EntitlementID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@EntitlementID", JobBeneBox.Text);

                connection.Open();
                SqlDataReader cr = command.ExecuteReader();
                if (cr.Read())
                {
                    JobBeneDescBox.Text = (cr["Description"].ToString());
                }
            }
        }
        //reads the desription of the new job benefit when each benefit in the listbox is highlighted
        private void JobBeneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showJobBenefitDescription();
        }

        //Adds the highlighted benefit to the chosen employee's benefits when the button is clicked
        private void AddBenefitBtn_Click(object sender, EventArgs e)
        {
            if (IDBox.Items.Count > 0)
            {
                if (JobBeneBox.Items.Count > 0)
                {
                    String query = "Insert into [Employee Benefits] Values (@EmployeeID, @EntitlementID)";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", IDBox.Text);
                        command.Parameters.AddWithValue("@EntitlementID", JobBeneBox.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            MessageBox.Show("This Employee already has this entitlement and it cannot be entered in again. Please select a different entitlement. ");
                        }

                    }
                    FindOutliers();
                    if (checkBox1.Checked)
                    {
                        string X = IDBox.Text;
                        showOutliers();
                        IDBox.Text = X;
                    }
                    showForeNames();
                    showSurNames();
                    showEmail();
                    showJobSection();
                    showJobs();
                    showWUForeNames();
                    showWUSurNames();
                    showJobBenefits();
                    showEmployeeBenefits();
                    if (EmpBeneBox.Items.Count == 0)
                    {
                        EmpBeneDescBox.Clear();
                    }
                    if (JobBeneBox.Items.Count == 0)
                    {
                        JobBeneDescBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("There are no Benefits to add");
                }
            }
            else
            {
                MessageBox.Show("There are no employees");
            }
            
        }



//----------------------------------------------------------------------------------------------------------- Functions based around either clearing certain parts of the database or clearing the database as a whole
//-----------------------------------------------------------------------------------------------------------

        //Deletes all Employee benefits from the database
        private void ClearEmBeneBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("You pressed the button to completely clear all your employees of their current benefits. Are you sure you want to do this?", "Clear Employee Benefits", MessageBoxButtons.YesNo);

            if (Dr == DialogResult.Yes)
            {
                String query = "Delete from [Employee Benefits]; ";

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
        //Deletes all data in the database
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



        private void employee_BenefitsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employee_BenefitsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.database1DataSet.Employee);
            // TODO: This line of code loads data into the 'database1DataSet.Employee_Benefits' table. You can move, or remove it, as needed.
            this.employee_BenefitsTableAdapter.Fill(this.database1DataSet.Employee_Benefits);


        }

        private void EditEmploy_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width / (925 / 449);
            panel1.Height = this.Height / (772 / 172);
            panel1.Left = 0;
            panel1.Top = panel5.Bottom;

            panel3.Width = this.Width / (925 / 458);
            panel3.Height = this.Height / (772 / 172);
            panel3.Left = panel1.Right;
            panel3.Top = panel5.Bottom;

            panel4.Width = this.Width / (925 / 449);
            panel4.Height = panel2.Height + panel3.Height - panel1.Height;
            panel4.Left = 0;
            panel4.Top = panel1.Bottom;

            panel2.Width = this.Width / (925 / 458);
            panel2.Height = this.Height / (457 / 202);
            panel2.Left = panel4.Right;
            panel2.Top = panel1.Bottom;
        }
    }
}
