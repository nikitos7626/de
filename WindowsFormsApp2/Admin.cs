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
using Microsoft.VisualBasic;
namespace WindowsFormsApp2
{
    public partial class Admin : Form
    {
        DataSet ds;
    

        public Admin()
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select name,password from user1",database.GetConnection());//вывод данных из бд
            database.OpenConnection();
            adapter.Fill(ds, "user1");
            dataGridView1.DataSource = ds.Tables["user1"];
            database.CloseConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }


        void DeleteUser()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string name = dataGridView1.Rows[selectedRowIndex].Cells["name"].Value.ToString();

                DatabaseConnect database = new DatabaseConnect();
                database.OpenConnection();

                string query = "DELETE FROM user1 WHERE name = @name";
                SqlCommand command = new SqlCommand(query, database.GetConnection());
                command.Parameters.AddWithValue("@name", name);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Пользователь удален успешно!");
                    GetUser(); // Обновляем данные в dataGridView1
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении пользователя.");
                }

                database.CloseConnection();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string name = dataGridView1.Rows[selectedRowIndex].Cells["name"].Value.ToString();
                string password = dataGridView1.Rows[selectedRowIndex].Cells["password"].Value.ToString();

                // Открываем диалоговое окно для редактирования пользователя
                string newName = Interaction.InputBox("Введите новое имя пользователя:", "Редактирование пользователя", name);
                string newPassword = Interaction.InputBox("Введите новый пароль:", "Редактирование пользователя", password);


                // Обновляем данные пользователя в базе данных
                DatabaseConnect database = new DatabaseConnect();
                database.OpenConnection();

                string query = "UPDATE user1 SET name = @newName, password = @newPassword WHERE name = @name";
                SqlCommand command = new SqlCommand(query, database.GetConnection());
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@name", name);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Пользователь отредактирован успешно!");
                    GetUser(); // Обновляем данные в dataGridView1
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании пользователя.");
                }

                database.CloseConnection();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для редактирования.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADD form5 = new ADD();
            form5.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchUser();
        }


        private void SearchUser()
        {
            string searchName = textBox1.Text; 

            DatabaseConnect database = new DatabaseConnect();
            database.OpenConnection();

            string query = "SELECT name,password FROM user1 WHERE name LIKE @searchName";
            SqlCommand command = new SqlCommand(query, database.GetConnection());
            command.Parameters.AddWithValue("@searchName", "%" + searchName + "%");

            DataTable searchResults = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(searchResults);

            dataGridView1.DataSource = searchResults;

            database.CloseConnection();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
