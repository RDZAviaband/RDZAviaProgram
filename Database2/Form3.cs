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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            MySqlCommand comand = new MySqlCommand();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);



            connection.Open();
         
            comand.CommandText = @"SELECT * FROM Users WHERE UserName='" + textBox1.Text + "'AND Passwortd='" + textBox2.Text + "';";
        

            comand.Connection = connection;

            adaptor.SelectCommand = comand;
            adaptor.Fill(dataset, "0");
            int count = dataset.Tables[0].Rows.Count;

            if (count > 0)
            {
                Form1 fmr1 = new Form1();
                fmr1.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Не коректный логен или пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}
