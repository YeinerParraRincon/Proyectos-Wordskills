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

namespace PreeELiminar
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        public Form1()
        {
            InitializeComponent();
            categorias();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            var nombre = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Name of Dish"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "ver")
            {
                Form2 form2 = new Form2(id,nombre);
                form2.Show();
                this.Hide();
            }

        }

        private void categorias()
        {
            string Conexion = "server =.; database = restaurante; integrated security = true";
            string sql = "SELECT * FROM categorias";
            using (SqlConnection conexion = new SqlConnection(Conexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "nombre";
                    comboBox1.ValueMember = "id_categorias";
                    comboBox1.SelectedItem = null;
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ya estas ubicado en esta session");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Esta en desarrollo");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name of Dish");
            dt.Columns.Add("Portion Price");

            string sql = "SELECT id_dishes,nombre,total FROM dishes";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string titulo = reader["nombre"].ToString();
                string price = reader["total"].ToString();

                dt.Rows.Add(id, titulo, price);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                conexion.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name of Dish");
                dt.Columns.Add("Portion Price");

                string sql = "SELECT d.id_dishes,d.nombre,d.total,c.id_categorias FROM categorias as c " +
                    "INNER JOIN dishes as d on d.id_category = c.id_categorias " +
                    "WHERE c.id_categorias like @b";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@b", "%" + comboBox1.SelectedValue + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id_dishes"]);
                    string titulo = reader["nombre"].ToString();
                    string price = reader["total"].ToString();

                    dt.Rows.Add(id, titulo, price);
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name of Dish");
            dt.Columns.Add("Portion Price");

            string sql = "SELECT id_dishes,nombre,total FROM dishes " +
                "WHERE nombre like @b";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@b", "%" + textBox1.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string titulo = reader["nombre"].ToString();
                string price = reader["total"].ToString();

                dt.Rows.Add(id, titulo, price);
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name of Dish");
            dt.Columns.Add("Portion Price");

            string sql = "SELECT id_dishes,nombre,total FROM dishes " +
                "WHERE total <= @b";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@b",trackBar1.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_dishes"]);
                string titulo = reader["nombre"].ToString();
                string price = reader["total"].ToString();

                dt.Rows.Add(id, titulo, price);
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
