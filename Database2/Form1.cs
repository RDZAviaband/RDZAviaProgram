using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Database2
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
            SqlQueries queries = new SqlQueries();
        }

        MySqlDataAdapter RDZAviaAdapter = new MySqlDataAdapter();
        MySqlDataAdapter LibAdapter = new MySqlDataAdapter();
        MySqlDataAdapter PagesAdapter = new MySqlDataAdapter();
        DataSet RDZAviaDataset = new DataSet();
        DataSet LibDataset = new DataSet();
        DataSet PagesDataset = new DataSet();
        MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);




        public void Form1_Load(object sender, EventArgs e)
        {
            Otkyda.Items.Add("Воронеж");
            Otkyda.Items.Add("Москва");
            Kuda.Items.Add("Москва");
            Kuda.Items.Add("Сочи");
            Kuda.Items.Add("Владивосток");
            Tarif.Items.Add("Эконом-класс");
            Tarif.Items.Add("Бизнес-класс");
            Tarif.Items.Add("Премиум-класс");


            try
            {
                RDZAviaLoad();
                LibLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void RDZAviaLoad()
        {
            RDZAviaDataset.Clear();
            RDZAviaAdapter = new MySqlDataAdapter(SqlQueries.SSQuery, connection);
            MySqlCommandBuilder RDZAviaBuilder = new MySqlCommandBuilder(RDZAviaAdapter);
            RDZAviaAdapter.Fill(RDZAviaDataset);
            dataGridView1.DataSource = RDZAviaDataset.Tables[0];
            connection.Close();
        }

        public void LibLoad()
        {
            //LibDataset.Clear();
            //LibAdapter = new MySqlDataAdapter(SqlQueries.SLQuery, connection);
            //MySqlCommandBuilder LibBuilder = new MySqlCommandBuilder(LibAdapter);
            //LibAdapter.Fill(LibDataset);
            //dataGridView2.DataSource = LibDataset.Tables[0];

            //connection.Close();
        }








        private void AcceptButton_Click(object sender, EventArgs e)
        {
            RDZAviaAdapter.Update(RDZAviaDataset.Tables[0]);
            Form1_Load(sender, e);
        }

        private void ClearAllTBs()
        {
            foreach (Control c in Controls)
                if (c is TextBox)
                    ((TextBox)c).Text = string.Empty;
        }

        private async void AddLibButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                MySqlCommand addcommand = new MySqlCommand(SqlQueries.insertQuery, connection);
                //addcommand.Parameters.AddWithValue("l", textBox6.Text);
                //addcommand.Parameters.AddWithValue("w", textBox7.Text);
                //addcommand.Parameters.AddWithValue("a", textBox8.Text);
                //addcommand.Parameters.AddWithValue("RDZAvia_", textBox1.Text);
                await addcommand.ExecuteNonQueryAsync();
                ClearAllTBs();
                Form1_Load(sender, e);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            RDZAviaDataset.RejectChanges();
        }



        //private void Search2_Click(object sender, EventArgs e)
        //{
        //    //if (SearchTextBox2.Text != string.Empty)

        //        ClearSearchResults();
        //        for (int row = 0; row < dataGridView2.Rows.Count; row++)
        //        {
        //            for (int cell = 1; cell < 2; cell++)
        //            {
        //                if (dataGridView2.Rows[row].Cells[cell].Value.ToString().ToLower().Contains(SearchTextBox2.Text.ToLower()))
        //                    dataGridView2.Rows[row].DefaultCellStyle.BackColor = Color.Red;
        //            }
        //        }
        //        //SearchTextBox2.Clear();

        //    else
        //    {
        //        MessageBox.Show("Empty field!");
        //    }
        //}

        private void ClearSearchResults()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    textBox6.Clear();
        //    ClearSearchResults();
        //}

        //private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    foreach (DataGridViewRow row in dataGridView2.Rows)
        //    {
        //        row.DefaultCellStyle.BackColor = DefaultBackColor;
        //        //SearchTextBox2.Clear();
        //    }
        //}

        //private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int Cell = dataGridView2.CurrentCell.RowIndex;
        //    textBox6.Text = dataGridView2.Rows[Cell].Cells["l"].Value.ToString();
        //    textBox7.Text = dataGridView2.Rows[Cell].Cells["w"].Value.ToString();
        //    //textBox8.Text = dataGridView2.Rows[Cell].Cells["a"].Value.ToString();
        //    //textBox1.Text = dataGridView2.Rows[Cell].Cells["RDZAvia_"].Value.ToString();
        //}

        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand updatecommand = new MySqlCommand(SqlQueries.updateQuery, connection);
                //updatecommand.Parameters.AddWithValue("l", textBox6.Text);
                //updatecommand.Parameters.AddWithValue("w", textBox7.Text);
                //updatecommand.Parameters.AddWithValue("a", textBox8.Text);
                //updatecommand.Parameters.AddWithValue("RDZAvia_", textBox1.Text);
                //updatecommand.Parameters.AddWithValue("id", dataGridView2.CurrentCell.RowIndex + 1);
                await updatecommand.ExecuteNonQueryAsync();
                connection.Close();
                ClearAllTBs();
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private async void DeleteButton_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
            //try
            //{
            //    connection.Open();
            //    MySqlCommand deletecommand = new MySqlCommand(SqlQueries.deleteQuery, connection);
            //    deletecommand.Parameters.AddWithValue("id", dataGridView2.CurrentCell.RowIndex + 1);
            //    await deletecommand.ExecuteNonQueryAsync();
            //    connection.Close();
            //    ClearAllTBs();
            //    LibLoad();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     
       

            

        private void Search2_Click(object sender, EventArgs e) 
        {
            

            if (Otkyda.Text != string.Empty && Kuda.Text != string.Empty  && Tarif.Text != string.Empty && dateTime.Text != string.Empty)
            {
                ClearSearchResults();
                for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                {

                    if (dataGridView1.Rows[row].Cells["Where_"].Value.ToString().ToLower().Contains(Otkyda.Text.ToLower()) &&
                        dataGridView1.Rows[row].Cells["Whence_"].Value.ToString().ToLower().Contains(Kuda.Text.ToLower()) &&
                        dataGridView1.Rows[row].Cells["Date_"].Value.ToString().ToLower().Contains(dateTime.Text.ToLower()) &&
                        dataGridView1.Rows[row].Cells["Rate_"].Value.ToString().ToLower().Contains(Tarif.Text.ToLower()))
                        dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                    else { MessageBox.Show("По вашему запросу билетов не найдено;("); break; }
                    }
                
                
            }
            else
            {
                MessageBox.Show("Заполните все поля и повторите запрос");
                
            }

            
        }
        
    
        


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
