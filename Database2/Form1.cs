using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
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
        int RDZAviaNumber;


        public void Form1_Load(object sender, EventArgs e)
        {
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

        public void PagesLoad()
        {
            connection.Open();
            label1.Text = (SqlQueries.page + 1).ToString();
            PagesDataset.Clear();
            //PagesAdapter = new MySqlDataAdapter(string.Format(SqlQueries.PagesQuery, SqlQueries.page, numericUpDown1.Value), connection);
            MySqlCommandBuilder PagesBuilder = new MySqlCommandBuilder(PagesAdapter);
            PagesAdapter.Fill(PagesDataset);

            MySqlCommand count = new MySqlCommand(SqlQueries.PagesNumberQuery, connection);
            RDZAviaNumber = Convert.ToInt32(count.ExecuteScalar());

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PagesLoad();
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (SqlQueries.page != 0)
            {
                SqlQueries.page--;
                PagesLoad();
            }
        }

        //private void NextButton_Click(object sender, EventArgs e)
        //{
        //    if (SqlQueries.page <= (RDZAviaNumber-1) / numericUpDown1.Value - 1 )
        //    {
        //        SqlQueries.page++;
        //        PagesLoad();
        //    }
        //}

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
                addcommand.Parameters.AddWithValue("l", textBox6.Text);
                addcommand.Parameters.AddWithValue("w", textBox7.Text);
                //addcommand.Parameters.AddWithValue("a", textBox8.Text);
                //addcommand.Parameters.AddWithValue("RDZAvia_", textBox1.Text);
                await addcommand.ExecuteNonQueryAsync();
                ClearAllTBs();
                Form1_Load(sender, e);
                connection.Close();
            }
            catch(Exception ex)
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

        //private void Search_Click(object sender, EventArgs e)
        //{
        //    if (SearchTextBox.Text != string.Empty)
        //    {
        //        ClearSearchResults();
        //        for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
        //        {
        //            for (int cell = 1; cell < 2; cell++)
        //            {
        //                if (dataGridView1.Rows[row].Cells[cell].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()))
        //                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
        //            }
        //        }
        //        //SearchTextBox.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Empty field!");
        //    }
        //}

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
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SearchTextBox.Clear();
            ClearSearchResults();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.DefaultCellStyle.BackColor = DefaultBackColor;
                //SearchTextBox2.Clear();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cell = dataGridView2.CurrentCell.RowIndex;
            textBox6.Text = dataGridView2.Rows[Cell].Cells["l"].Value.ToString();
            textBox7.Text = dataGridView2.Rows[Cell].Cells["w"].Value.ToString();
            //textBox8.Text = dataGridView2.Rows[Cell].Cells["a"].Value.ToString();
            //textBox1.Text = dataGridView2.Rows[Cell].Cells["RDZAvia_"].Value.ToString();
        }

        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand updatecommand = new MySqlCommand(SqlQueries.updateQuery, connection);
                updatecommand.Parameters.AddWithValue("l", textBox6.Text);
                updatecommand.Parameters.AddWithValue("w", textBox7.Text);
                //updatecommand.Parameters.AddWithValue("a", textBox8.Text);
                //updatecommand.Parameters.AddWithValue("RDZAvia_", textBox1.Text);
                updatecommand.Parameters.AddWithValue("id", dataGridView2.CurrentCell.RowIndex + 1);
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

        private void SearchTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
