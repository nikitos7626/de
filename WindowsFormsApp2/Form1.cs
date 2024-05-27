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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        DatabaseConnect con;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DatabaseConnect database = new DatabaseConnect();
            var name = textBox1.Text;
            var password = textBox2.Text;
            

                database.OpenConnection();
                SqlDataAdapter adap = new SqlDataAdapter();
                DataTable table = new DataTable();
                string query = $"insert into user1 (name,password) values  ('{name}', '{password}')";
                //SqlCommand comand = new SqlCommand(query,)
                //DatabaseConnect.GetConnection();
                SqlCommand command = new SqlCommand(query, database.GetConnection());
                adap.SelectCommand = command;
                adap.Fill(table);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private Boolean chekuser()
        {
            DatabaseConnect database = new DatabaseConnect();
            var name = textBox1.Text;
            var password = textBox2.Text;
            

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"select name, password from user1 where name = '{name}' and password = '{password}'";

            SqlCommand command = new SqlCommand(query, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }
            else
                return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
