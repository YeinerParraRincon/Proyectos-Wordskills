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
    public partial class Form4 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        public Form4()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var ids = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "eli")
            {
                conexion.Open();
                string eliminar = "DELETE FROM recipes WHERE id_ingredient = @b";
                SqlCommand cmds = new SqlCommand(eliminar,conexion);
                cmds.Parameters.AddWithValue("@b", ids);
                cmds.ExecuteNonQuery();
                MessageBox.Show("Fue exitoso");

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name of Ingredient");
                dt.Columns.Add("Price");
                dt.Columns.Add("Unit");

                string sql = "SELECT r.id_ingredient,i.nombre,i.price,r.unit FROM ingredientes as i " +
                    "INNER JOIN recipes as r on r.id_ingredient = i.id_ingredientes ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id_ingredient"]);
                    string titulo = reader["nombre"].ToString();
                    string price = reader["price"].ToString();
                    string unit = reader["unit"].ToString();

                    dt.Rows.Add(id, titulo, price, unit);
                }
                if (dataGridView1.Columns["eli"] == null)
                {
                    var ver = new DataGridViewButtonColumn
                    {
                        Name = "eli",
                        Text = "Delete",
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

        private void Form4_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name of Ingredient");
            dt.Columns.Add("Price");
            dt.Columns.Add("Unit");

            string sql = "SELECT r.id_ingredient,i.nombre,i.price,r.unit FROM ingredientes as i " +
                "INNER JOIN recipes as r on r.id_ingredient = i.id_ingredientes ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_ingredient"]);
                string titulo = reader["nombre"].ToString();
                string price = reader["price"].ToString();
                string unit = reader["unit"].ToString();

                dt.Rows.Add(id, titulo, price,unit);
            }
            if (dataGridView1.Columns["eli"] == null)
            {
                var ver = new DataGridViewButtonColumn
                {
                    Name = "eli",
                    Text = "Delete",
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
