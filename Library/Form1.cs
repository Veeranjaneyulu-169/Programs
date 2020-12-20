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
    
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-9SDITJLE\\SQLEXPRESS;Initial Catalog=Student_Library;Integrated Security=True;Pooling=False");
        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open);
            {
                con.Close();
            }
            con.Open();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Login_Details where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(data);
            count = Convert.ToInt32(data.Rows.Count.ToString());
            if(count==0)
            {
                MessageBox.Show("Wrong Password");
            }
            else
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
                MessageBox.Show("Login Successful");
            }

        }
    }
}
