﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Database2
{
    public partial class SearchForm : System.Windows.Forms.Form
    {
        public SearchForm(string data)
        {


            InitializeComponent();
            SqlQueries queries = new SqlQueries();
            this.data = data;
        }

        public SearchForm()
        {
        }

        string data;

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
            label5.Text = data;
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

       

        private async void AddLibButton_Click(object sender, EventArgs e)
        {
            StatusForm frm2 = new StatusForm(this.label5.Text);
            frm2.Show();
            this.Hide();
            //connection.Open();
            //try
            //{
            //    MySqlCommand addcommand = new MySqlCommand(SqlQueries.insertQuery, connection);
            //    //addcommand.Parameters.AddWithValue("l", textBox6.Text);
            //    //addcommand.Parameters.AddWithValue("w", textBox7.Text);
            //    //addcommand.Parameters.AddWithValue("a", textBox8.Text);
            //    //addcommand.Parameters.AddWithValue("RDZAvia_", textBox1.Text);
            //    await addcommand.ExecuteNonQueryAsync();
            //    ClearAllTBs();
            //    Form1_Load(sender, e);
            //    connection.Close();
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

        private void RejectButton_Click(object sender, EventArgs e)
        {
            RDZAviaDataset.RejectChanges();
        }



        private void ClearSearchResults()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

        }

    

        private  void ChangeButton_Click(object sender, EventArgs e)
      


            
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Where_"].Value);
                string b = Convert.ToString(selectedRow.Cells["Whence_"].Value);
                string c = Convert.ToString(selectedRow.Cells["Date_"].Value);
                string d = Convert.ToString(selectedRow.Cells["Rate_"].Value);
                string g = Convert.ToString(selectedRow.Cells["Price_"].Value);
           
                connection.Open();
                MySqlCommand updatecommand = new MySqlCommand(SqlQueries.insertQuery1, connection);

                updatecommand.Parameters.AddWithValue("Login", data);
                updatecommand.Parameters.AddWithValue("Where_", a);
                updatecommand.Parameters.AddWithValue("Whence_", b);
                updatecommand.Parameters.AddWithValue("Date_", c);
                updatecommand.Parameters.AddWithValue("Rate_", d);
                updatecommand.Parameters.AddWithValue("Price_", g);

             updatecommand.ExecuteNonQuery();
                connection.Close();
            }

        

       
    }
    

        private async void DeleteButton_Click(object sender, EventArgs e)
        {

            StartForm frm2 = new StartForm();
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
            dataGridView1.Rows[0].Cells[0].ReadOnly = true;
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
                   // else { MessageBox.Show("По вашему запросу билетов не найдено;("); break; }
                    }
                
                
            }
            else
            {
                MessageBox.Show("Заполните все поля и повторите запрос");
                
            }

            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}