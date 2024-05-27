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
    public partial class Form2 : Form
    {
        DatabaseConnect con;
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnect database = new DatabaseConnect();
            var name = textBox1.Text;
            var password = textBox2.Text;
            if (name == "admin" && password == "admin")
            {
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide();
            }
            else
            {


                database.OpenConnection();
                SqlDataAdapter adap = new SqlDataAdapter();
                DataTable table = new DataTable();
                string query = $"select name, password from user1 where name = '{name}' and password = '{password}'";
                //SqlCommand comand = new SqlCommand(query,)
                //DatabaseConnect.GetConnection();
                SqlCommand command = new SqlCommand(query, database.GetConnection());
                adap.SelectCommand = command;
                adap.Fill(table);
                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 form3 = new Form3();

                    form3.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
