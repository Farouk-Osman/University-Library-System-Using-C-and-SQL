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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class addBook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6BBNEFE\\SQLEXPRESS;Initial Catalog=University_Library;Integrated Security=True");

        public addBook()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addBook_Load(object sender, EventArgs e)
        {

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Book(ISBN, Title, Price, Publishing_Year, Added_byID, A_ID, P_ID) VALUES('" + textBox11.Text + "', '" + textBox22.Text + "','" + textBox33.Text + "', '" + dateTimePicker1.Value + "', '" + DBNull.Value+ "','" + textBox55.Text + "','" + textBox66.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("add sucssesfully");
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming con is your SqlConnection object
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Book(ISBN, Title, Price, Publishing_Year, Added_byID, P_ID) VALUES(@ISBN, @Title, @Price, @Publishing_Year, @Added_byID, @P_ID)", con))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@ISBN", textBox11.Text);
                cmd.Parameters.AddWithValue("@Title", textBox22.Text);
                cmd.Parameters.AddWithValue("@Price", textBox33.Text);
                cmd.Parameters.AddWithValue("@Publishing_Year", Convert.ToDateTime(dateTimePicker1.Value));
                cmd.Parameters.AddWithValue("@Added_byID", DBNull.Value); // Assuming Added_byID is nullable
                cmd.Parameters.AddWithValue("@P_ID", comboBox1.Text);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                textBox11.Text = "";
                textBox22.Text = "";
                textBox33.Text = "";
                comboBox1.Text = "";


                MessageBox.Show("Added successfully");

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
