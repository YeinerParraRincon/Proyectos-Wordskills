using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace preselecion
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
            traeigo();
        }

        private void traeigo()
        {
            string Conexion = "server=.;database=restaurante;integrated security = true";
            string sql = "SELECT * FROM categoria";
            using(SqlConnection conexion = new SqlConnection(Conexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dT = new DataTable();
                    adap.Fill(dT);

                    comboBox1.DataSource = dT;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "id_categoria";
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "ver")
            {
                Ver ver = new Ver(id);
                ver.Show();
                this.Hide();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Se desarrollara mas tarde");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name Of Dish");
            dt.Columns.Add("Porsotion Price");

            string sql = "SELECT id_dishes,name,price FROM dishes";
            SqlCommand cmdDIshes = new SqlCommand(sql,conexion);
            SqlDataReader reader = cmdDIshes.ExecuteReader();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string name = reader["name"].ToString();
                string price = reader["price"].ToString();

                dt.Rows.Add(id, name, price);
            }
            if (dataGridView1.Columns["ver"] == null)
            {
                var ver = new DataGridViewButtonColumn
                {
                    Name = "ver",
                    Text = "Ver",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(ver);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            reader.Close();
            conexion.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name Of Dish");
            dt.Columns.Add("Porsotion Price");

            string sql = "SELECT id_dishes,name,price FROM dishes WHERE name like @a";
            SqlCommand cmdDIshes = new SqlCommand(sql, conexion);
            cmdDIshes.Parameters.AddWithValue("@a","%"+textBox1.Text+"%");
            SqlDataReader reader = cmdDIshes.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string name = reader["name"].ToString();
                string price = reader["price"].ToString();

                dt.Rows.Add(id, name, price);
            }
            if (dataGridView1.Columns["ver"] == null)
            {
                var ver = new DataGridViewButtonColumn
                {
                    Name = "ver",
                    Text = "View",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(ver);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            conexion.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name Of Dish");
            dt.Columns.Add("Porsotion Price");

            string sql = "SELECT id_dishes,name,price FROM dishes WHERE price like @a";
            SqlCommand cmdDIshes = new SqlCommand(sql, conexion);
            cmdDIshes.Parameters.AddWithValue("@a", "%" + numericUpDown1.Value + "%");
            SqlDataReader reader = cmdDIshes.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string name = reader["name"].ToString();
                string price = reader["price"].ToString();

                dt.Rows.Add(id, name, price);
            }
            if (dataGridView1.Columns["ver"] == null)
            {
                var ver = new DataGridViewButtonColumn
                {
                    Name = "ver",
                    Text = "Ver",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(ver);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            conexion.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaDeLosIngredientes ingredientes = new ListaDeLosIngredientes();
            ingredientes.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ya te encuentras en esta vista");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
