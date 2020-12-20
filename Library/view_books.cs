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

namespace Library
{
    public partial class view_books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-9SDITJLE\\SQLEXPRESS;Initial Catalog=Student_Library;Integrated Security=True;Pooling=False");
        public view_books()
        {
            InitializeComponent();
        }

        private void view_books_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books_Details";
                cmd.ExecuteNonQuery();
                DataTable data = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(data);
                searchBooksDataGridView.DataSource = data;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books_Details where name_of_book like('%" + booksTextBox.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable data = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(data);
                i = Convert.ToInt32(data.Rows.Count.ToString());

                searchBooksDataGridView.DataSource = data;
                con.Close();

                if (i == 0)
                {
                    MessageBox.Show("Book is not Available");
                }
                else
                    MessageBox.Show("Book is Available");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
