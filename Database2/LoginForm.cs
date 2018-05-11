using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database2
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        public LoginForm()
        {
            InitializeComponent();
           
        }

        private void SingInButt_Click(object sender, EventArgs e)
        {
          
            MySqlCommand comand = new MySqlCommand();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);



            connection.Open();
         
            comand.CommandText = @"SELECT * FROM Users WHERE Login='" + textBox1.Text + "'AND Passwortd='" + textBox2.Text + "';";
        

            comand.Connection = connection;

            adaptor.SelectCommand = comand;
            adaptor.Fill(dataset, "0");
            int count = dataset.Tables[0].Rows.Count;

            if (count > 0)
            {
                SearchForm fmr1 = new SearchForm(this.textBox1.Text);
                fmr1.Show();
                this.Hide();
            

            }
            else
            {

                MessageBox.Show("Некоректный логин или пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
        }
   

        private void BackButt_Click(object sender, EventArgs e)
        {
            StartForm frm2 = new StartForm();
            frm2.Show();
            this.Hide();
        }

        private void SupportButt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите логин и пароль,если их нет то зарегистрируйтесь.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
