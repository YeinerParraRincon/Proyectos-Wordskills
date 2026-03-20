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
    public partial class ListaDeLosIngredientes : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        public ListaDeLosIngredientes()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)return;

            int idIngrediente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

            conexion.Open();


            string sql = "DELETE FROM ingredientesp WHERE id_ingredientes = @a";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@a", idIngrediente);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fue eliminado correctamente");

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre del ingrediente");
            dt.Columns.Add("precio");
            dt.Columns.Add("Unit");

            string sqls = "SELECT * FROM ingredientesp";
            SqlCommand cmds = new SqlCommand(sqls, conexion);
            SqlDataReader reader = cmds.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_ingredientes"]);
                string nombre = reader["name"].ToString();
                string precio = reader["price"].ToString();
                string unit = reader["stock"].ToString();

                dt.Rows.Add(id, nombre, precio, unit);
            }
            if (dataGridView1.Columns["dele"] == null)
            {
                var eliminar = new DataGridViewButtonColumn
                {
                    Text = "Eliminar",
                    Name = "dele",
                    UseColumnTextForButtonValue = true,
                };
                dataGridView1.Columns.Add(eliminar);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();

            conexion.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 enviar = new Form1();
            enviar.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("ya te encuentra en esta vista");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Esta en Desarrollo");
        }

        private void ListaDeLosIngredientes_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre del ingrediente");
            dt.Columns.Add("precio");
            dt.Columns.Add("Unit");

            string sql = "SELECT * FROM ingredientesp";
            SqlCommand cmds = new SqlCommand(sql,conexion);
            SqlDataReader reader = cmds.ExecuteReader();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["id_ingredientes"]);
                string nombre = reader["name"].ToString();
                string precio = reader["price"].ToString();
                string unit = reader["stock"].ToString();

                dt.Rows.Add(id, nombre, precio, unit);
            }
            if (dataGridView1.Columns["dele"] == null)
            {
                var eliminar = new DataGridViewButtonColumn
                {
                    Text = "Eliminar",
                    Name = "dele",
                    UseColumnTextForButtonValue = true,
                };
                dataGridView1.Columns.Add(eliminar);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            conexion.Close();
        }
    }
}
