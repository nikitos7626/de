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
    public partial class Form4 : Form
    {
        DataSet ds;
        DatabaseConnect con;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            GetUser();
        }

        void GetUser()
        {
            ds = new DataSet();
            DatabaseConnect database = new DatabaseConnect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select name,password from user1",database.GetConnection());
            database.OpenConnection();
            adapter.Fill(ds, "user1");
            dataGridView1.DataSource = ds.Tables["user1"];
            database.CloseConnection();
        }
    }
}
