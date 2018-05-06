using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RDZavia
{
    public partial class StatusForm : System.Windows.Forms.Form
    {
        private MySqlDataAdapter RDZAviaAdapter;

        public object RDZAviaDataset { get; private set; }

        public StatusForm(string data2)
        {

            InitializeComponent();
            this.data2 = data2;
       
            MySqlDataAdapter RDZAviaAdapter = new MySqlDataAdapter();
            MySqlDataAdapter LibAdapter = new MySqlDataAdapter();
            MySqlDataAdapter PagesAdapter = new MySqlDataAdapter();
            DataSet RDZAviaDataset = new DataSet();
            DataSet LibDataset = new DataSet();
            DataSet PagesDataset = new DataSet();
            MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);
          

            MySqlCommand comand = new MySqlCommand();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
   



            connection.Open();

            comand.CommandText = @"SELECT * FROM DataGridSecond WHERE Login='" + data2 + "';";


            comand.Connection = connection;

            adaptor.SelectCommand = comand;
            adaptor.Fill(dataset, "0");
            int count = dataset.Tables[0].Rows.Count;

            if (count > 0)
            {
                

                MySqlConnection myConnection = new MySqlConnection(SqlQueries.connectQuery);

                myConnection.Open();

                string query = "SELECT Where_, Whence_ , Date_ ,Rate_ ,Price_ FROM DataGridSecond WHERE Login='" + data2 + "';";
                MySqlCommand command = new MySqlCommand(query, myConnection);

                MySqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }

                reader.Close();

                myConnection.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
        }
        string data2;
     
        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm frm1 = new SearchForm(this.data2);
            frm1.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void FIO ()
        {
   
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                MySqlConnection connection = new MySqlConnection(SqlQueries.connectQuery);

                connection.Open();
                MySqlCommand deletecommand = new MySqlCommand(SqlQueries.deleteQuery, connection);
                deletecommand.Parameters.AddWithValue("id", dataGridView1.CurrentCell.RowIndex + 1);
                deletecommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
