using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
namespace RDZavia
{
    public partial class RegisterForm : System.Windows.Forms.Form
    {
  
        public RegisterForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("М");
            comboBox1.Items.Add("Ж");

        }
        private void SingUpButt_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);
            connection.Open();
            MySqlCommand addcommand = new MySqlCommand(SqlQueries.insertQuery, connection);
            MySqlCommand comand = new MySqlCommand();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            string d = textBox1.Text;
            comand.CommandText = @"SELECT * FROM Users WHERE Login = '"+ d+"';";
            comand.Connection = connection;
            adaptor.SelectCommand = comand;
            adaptor.Fill(dataset, "0");
            int count = dataset.Tables[0].Rows.Count;
            if (count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            else
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    addcommand.Parameters.AddWithValue("Login", textBox1.Text);
                    addcommand.Parameters.AddWithValue("Passwortd", textBox2.Text);
                    addcommand.Parameters.AddWithValue("UserName", textBox3.Text);
                    addcommand.Parameters.AddWithValue("SecondName", textBox4.Text);
                    addcommand.Parameters.AddWithValue("LastName", textBox5.Text);
                    addcommand.Parameters.AddWithValue("Data_", dateTimePicker1.Text);
                    addcommand.Parameters.AddWithValue("Sex", comboBox1.Text);
                    if (textBox2.Text != textBox8.Text)
                    {
                        MessageBox.Show("Пароли не совпадают!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        addcommand.ExecuteNonQuery();
                        connection.Close();
                        LoginForm fmrL = new LoginForm();
                        fmrL.Show();
                        this.Hide();
                    }
                }

                else { MessageBox.Show("Заполните обязательные поля"); }

                connection.Close();
            }
        }
        
        private void BackButt_Click(object sender, EventArgs e)
        {
            StartForm frm1 = new StartForm();
            frm1.Show();
            this.Hide();
        }
        private void SupportButt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пройдите регистрацию.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
