using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormssDB
{

    public partial class Form1 : Form
    {
        private string ConString = WinFormssDB.Properties.Settings.Default.StudentDataConnectionString;
        Student myStudent = new Student();
        public Form1()
        {
            InitializeComponent();
            studentDetailsDataGridView.DataSource = myStudent.GetStudentDetails();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            myStudent.StudentId = studentIDTextBox.Text;
            myStudent.StudentName = studentNameTextBox.Text;
            myStudent.StudentAge = ageNumericUpDown.Value.ToString();
            myStudent.StudentContactNo = contactNoTextBox.Text;
            myStudent.StudentGender = genderComboBox.SelectedItem.ToString();
            //call insert method
            bool retValue = myStudent.InsertStudentDetails(myStudent);
            if (retValue)
            {
                MessageBox.Show("Insertion successful");
                //refresh/update the data into the datagrid view
                studentDetailsDataGridView.DataSource = myStudent.GetStudentDetails();
                ClearControls();
            }
            else
                MessageBox.Show("Error: Insertion unsuccessful");
        }
        private void ClearControls()
        {
            studentIDTextBox.Text = "";
            studentNameTextBox.Text = "";
            ageNumericUpDown.Value = 18;
            contactNoTextBox.Text = "";
            genderComboBox.SelectedItem = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            myStudent.StudentId = studentIDTextBox.Text;
            bool retvalue = myStudent.DeleteStudentDetails(myStudent);
            if (retvalue)
            {
                MessageBox.Show("deletion successful");
                ClearControls();
                studentDetailsDataGridView.DataSource = myStudent.GetStudentDetails();
            }
            else
                MessageBox.Show("Error: Deletion Unsuccessful");

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            myStudent.StudentId = studentIDTextBox.Text;
            myStudent.StudentName = studentNameTextBox.Text;
            myStudent.StudentAge = ageNumericUpDown.Value.ToString();
            myStudent.StudentContactNo = contactNoTextBox.Text;
            myStudent.StudentGender = genderComboBox.SelectedItem.ToString();

            bool retValue = myStudent.UpdateStudentDetails(myStudent);
            if (retValue)
            {
                MessageBox.Show("updation is successful");
                ClearControls();
                studentDetailsDataGridView.DataSource = myStudent.GetStudentDetails();
            }
            else
                MessageBox.Show("Error:Updation Unsuccessful");

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            myStudent.StudentId = searchTextBox.Text;
            bool retValue = myStudent.SearchStudentDetails(myStudent);
            if (retValue)
                MessageBox.Show("Search successful");
            else
                MessageBox.Show("Search Unsuccessful");
        }

        class Student
        {
            private string ConString = WinFormssDB.Properties.Settings.Default.StudentDataConnectionString;
            public string StudentId { get; set; }
            public string StudentName { get; set; }
            public string StudentAge { get; set; }
            public string StudentContactNo { get; set; }
            public string StudentGender { get; set; }

            private const string selectQuery = "Select * from Student_Details";
            private const string searchQuery = "Select * from Student_Details where StudentId=@StudentId";
            private const string insertQuery = "Insert Into Student_Details(StudentId, StudentName, StudentAge, StudentContact, StudentGender) Values(@StudentId, @StudentName, @StudentAge, @StudentContact, @StudentGender)";
            private const string deleteQuery = "Delete from Student_Details where StudentId=@StudentId";
            private const string updateQuery = "Update Student_Details set StudentName=@StudentName, StudentAge=@StudentAge, StudentContact=@StudentContact, StudentGender=@StudentGender where StudentId=@StudentId";
            public DataTable GetStudentDetails()
            {
                var datatable = new DataTable();
                SqlConnection myConnection = new SqlConnection(ConString);
                myConnection.Open();
                SqlCommand com = new SqlCommand(selectQuery, myConnection);
                SqlDataAdapter myAdapter = new SqlDataAdapter(com);
                myAdapter.Fill(datatable);
                myConnection.Close();
                return datatable;
            }
            public bool InsertStudentDetails(Student myStudent)
            {
                int rows;
                SqlConnection myConnection = new SqlConnection(ConString);
                myConnection.Open();
                SqlCommand com = new SqlCommand(insertQuery, myConnection);
                com.Parameters.AddWithValue("@StudentId", myStudent.StudentId);
                com.Parameters.AddWithValue("@StudentName", myStudent.StudentName);
                com.Parameters.AddWithValue("@StudentAge", myStudent.StudentAge);
                com.Parameters.AddWithValue("@StudentContact", myStudent.StudentContactNo);
                com.Parameters.AddWithValue("@StudentGender", myStudent.StudentGender);
                rows = com.ExecuteNonQuery();
                myConnection.Close();
                if (rows > 0)
                    return true;
                else
                    return false;

            }

            public bool DeleteStudentDetails(Student myStudent)
            {
                int rows;
                SqlConnection myConnection = new SqlConnection(ConString);
                myConnection.Open();
                SqlCommand com = new SqlCommand(deleteQuery, myConnection);
                com.Parameters.AddWithValue("@StudentId", myStudent.StudentId);
                rows = com.ExecuteNonQuery();
                if (rows > 0)
                    return true;
                else
                    return false;
            }

            public bool UpdateStudentDetails(Student myStudent)
            {
                int rows;
                SqlConnection myConnection = new SqlConnection(ConString);
                myConnection.Open();
                SqlCommand com = new SqlCommand(updateQuery, myConnection);
                com.Parameters.AddWithValue("@StudentName", myStudent.StudentName);
                com.Parameters.AddWithValue("@StudentAge", myStudent.StudentAge);
                com.Parameters.AddWithValue("@StudentContact", myStudent.StudentContactNo);
                com.Parameters.AddWithValue("@StudentGender", myStudent.StudentGender);
                com.Parameters.AddWithValue("@StudentId", myStudent.StudentId);
                rows = com.ExecuteNonQuery();
                myConnection.Close();
                if (rows > 0)
                    return true;
                else
                    return false;
            }

            public bool SearchStudentDetails(Student myStudent)
            {
                int rows;
                var datatable = new DataTable();
                SqlConnection myConnection = new SqlConnection(ConString);
                myConnection.Open();
                SqlCommand com = new SqlCommand(searchQuery, myConnection);
                com.Parameters.AddWithValue("@StudentId", myStudent.StudentId);
                SqlDataAdapter myAdapter = new SqlDataAdapter(com);
                rows = myAdapter.Fill(datatable);
                myConnection.Close();
                if (rows > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}