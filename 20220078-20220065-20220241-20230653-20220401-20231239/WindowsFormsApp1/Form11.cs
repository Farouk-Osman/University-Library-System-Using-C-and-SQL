using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Students : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6BBNEFE\\SQLEXPRESS;Initial Catalog=University_Library;Integrated Security=True");

        public Students()
        {
            InitializeComponent();
            Edit.Enabled = false;
            SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Student ON Student.S_ID = [User].U_ID", con);
            DataTable d = new DataTable();
            adapter1.Fill(d);
            dataGridView11.DataSource = d;
        }

 
        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure !") == DialogResult.OK)
            {
                SqlCommand cmd2 = new SqlCommand("delete from Student where S_ID='" + Convert.ToInt32(dataGridView11.CurrentRow.Cells[0].Value) + "'", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted !");
            }
        }

        /*private void Add_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET U_ID='"+Convert.ToInt32( textBox1.Text )+ "',First_Name='"+textBox2.Text+ "',Last_Name='"+textBox3.Text+ "', E_Mail='"+textBox4.Text+ "',Age='"+Convert.ToInt32(textBox5.Text)+ "' ", con);
            SqlCommand cmd3 = new SqlCommand("UPDATE Student SET City = '" + textBox6.Text + "',No_Building = '" + Convert.ToInt32(textBox7.Text) + "',Country = '" + textBox8.Text + "'", con);

            con.Open();
            cmd3.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Succsesfully !");
            SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Student ON Student.S_ID = [User].U_ID", con);
            DataTable d = new DataTable();
            adapter1.Fill(d);
            dataGridView11.DataSource = d;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            Edit.Enabled = false;

        }

*/

        private void Add_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("server=DESKTOP-TKCSHU9\\MSSQLSERVER1;DataBase=University_Library;Integrated Security=true;TrustServerCertificate=true"))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET First_Name=@First_Name, Last_Name=@Last_Name, " +
                                                  "E_Mail=@E_Mail, Age=@Age WHERE U_ID=@U_ID", con);
                cmd2.Parameters.AddWithValue("@First_Name", textBox2.Text);
                cmd2.Parameters.AddWithValue("@Last_Name", textBox3.Text);
                cmd2.Parameters.AddWithValue("@E_Mail", textBox4.Text);
                cmd2.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox5.Text));
                cmd2.Parameters.AddWithValue("@U_ID", Convert.ToInt32(textBox1.Text));

                SqlCommand cmd3 = new SqlCommand("UPDATE Student SET City=@City, No_Building=@No_Building, " +
                                                  "Country=@Country WHERE S_ID=(SELECT U_ID FROM [User] WHERE U_ID=@U_ID)", con);
                cmd3.Parameters.AddWithValue("@City", textBox6.Text);
                cmd3.Parameters.AddWithValue("@No_Building", Convert.ToInt32(textBox7.Text));
                cmd3.Parameters.AddWithValue("@Country", textBox8.Text);
                cmd3.Parameters.AddWithValue("@U_ID", Convert.ToInt32(textBox1.Text));

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                cmd2.Transaction = transaction;
                cmd3.Transaction = transaction;

                try
                {
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Edit Successfully!");
                    SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Student ON Student.S_ID = [User].U_ID", con);
                    DataTable d = new DataTable();
                    adapter1.Fill(d);
                    dataGridView11.DataSource = d;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    Edit.Enabled = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            // Clear text boxes and disable edit button
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            Edit.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView11_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView11.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView11.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView11.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView11.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView11.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView11.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView11.CurrentRow.Cells[9].Value.ToString();
            textBox8.Text = dataGridView11.CurrentRow.Cells[10].Value.ToString();
            Edit.Enabled = true;
        }


        private void Edit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("server=DESKTOP-TKCSHU9\\MSSQLSERVER1;DataBase=University_Library;Integrated Security=true;TrustServerCertificate=true"))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET First_Name=@First_Name, Last_Name=@Last_Name, " +
                                                  "E_Mail=@E_Mail, Age=@Age WHERE U_ID=@U_ID", con);
                cmd2.Parameters.AddWithValue("@First_Name", textBox2.Text);
                cmd2.Parameters.AddWithValue("@Last_Name", textBox3.Text);
                cmd2.Parameters.AddWithValue("@E_Mail", textBox4.Text);
                cmd2.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox5.Text));
                cmd2.Parameters.AddWithValue("@U_ID", Convert.ToInt32(textBox1.Text));

                SqlCommand cmd3 = new SqlCommand("UPDATE Student SET City=@City, No_Building=@No_Building, " +
                                                  "Country=@Country WHERE S_ID=(SELECT U_ID FROM [User] WHERE U_ID=@U_ID)", con);
                cmd3.Parameters.AddWithValue("@City", textBox6.Text);
                cmd3.Parameters.AddWithValue("@No_Building", Convert.ToInt32(textBox7.Text));
                cmd3.Parameters.AddWithValue("@Country", textBox8.Text);
                cmd3.Parameters.AddWithValue("@U_ID", Convert.ToInt32(textBox1.Text));

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                cmd2.Transaction = transaction;
                cmd3.Transaction = transaction;

                try
                {
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Edit Successfully!");
                    SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Student ON Student.S_ID = [User].U_ID", con);
                    DataTable d = new DataTable();
                    adapter1.Fill(d);
                    dataGridView11.DataSource = d;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    Edit.Enabled = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
