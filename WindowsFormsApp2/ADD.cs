using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ADD : Form
    {
        DatabaseConnect database = new DatabaseConnect();
        public ADD()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.OpenConnection();
            var name = textBox1.Text;
            var password = textBox2.Text;
            var comand = $"insert into user1 (name,password) values ('{name}','{password}')";
            //var Comand = new SqlCommand()
            var command = new SqlCommand(comand, database.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("кайф");
            database.CloseConnection();
            Admin form4 = new Admin();
            form4.Show();
            this.Hide();
        }
    }
}
