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

namespace Database2
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
              
                RDZAviaAdapter = new MySqlDataAdapter(SqlQueries.SSQuery1, connection);
            
                RDZAviaAdapter.Fill(RDZAviaDataset);
                dataGridView1.DataSource = RDZAviaDataset.Tables[0];


            }
            MySqlCommand cm = new MySqlCommand(SqlQueries.SSQuery2, connection);
            MySqlDataReader reader = cm.ExecuteReader();
            reader.Read();

            string f = reader["UserName"].ToString();
            string v = reader["SecondName"].ToString();
            string c = reader["LastName"].ToString();
            string x = reader["Sex"].ToString();
            string z = reader["Data_"].ToString();


            connection.Close();
            listBox1.Items.AddRange(new object[] { "Логин:"+ data2 +"", "Имя:" + f + "", "Отчество:" + v + "", "Фамилия:" + c + "", "Пол:" + x + "",
            "Дата рождения:"+ z +"",});
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
