using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=DataBase;integrated security = true");
        int user;
        public Form2(int id)
        {
            InitializeComponent();
            user = id;
            dataGridView2.CellClick += DataGridView2_CellClick;
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["ID"].Value);

            if (dataGridView2.Columns[e.ColumnIndex].Name == "edit")
            {
                MessageBox.Show("OK");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Capacity");
            dt.Columns.Add("Area");
            dt.Columns.Add("Type");
            string sql = "SELECT types.Name as item,a.Name as area,i.Title,i.Capacity FROM Areas as a " +
                "INNER JOIN Items AS i ON i.AreaID = a.ID " +
                "INNER JOIN ItemTypes AS types ON types.ID = i.ItemTypeID ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string titulo = reader["Title"].ToString();
                string capacidad = reader["Capacity"].ToString();
                string areas = reader["area"].ToString();
                string tipos = reader["item"].ToString();

                dt.Rows.Add(titulo, capacidad, areas, tipos);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();

            DataTable dts = new DataTable();
            dts.Columns.Add("ID");
            dts.Columns.Add("Title");
            dts.Columns.Add("Capacity");
            dts.Columns.Add("Area");
            dts.Columns.Add("Type");
            string sqls = "SELECT types.Name as item,a.Name as area,i.Title,i.Capacity,i.UserID,i.ID FROM Areas as a " +
                "INNER JOIN Items AS i ON i.AreaID = a.ID " +
                "INNER JOIN ItemTypes AS types ON types.ID = i.ItemTypeID " +
                "WHERE i.UserID = @i";
            SqlCommand cmds = new SqlCommand(sqls, conexion);
            cmds.Parameters.AddWithValue("@i", user);
            SqlDataReader readers = cmds.ExecuteReader();
            while (readers.Read())
            {
                int id = Convert.ToInt32(readers["ID"]);
                string titulo = readers["Title"].ToString();
                string capacidad = readers["Capacity"].ToString();
                string areas = readers["area"].ToString();
                string tipos = readers["item"].ToString();

                dts.Rows.Add(id,titulo, capacidad, areas, tipos);
            }
            dataGridView2.DataSource = dts;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Columns["ID"].Visible = false;
            if (dataGridView2.Columns["edit"] == null)
            {
                var nuevo = new DataGridViewButtonColumn
                {
                    Name = "edit",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                };
                dataGridView2.Columns.Add(nuevo);
            }
            readers.Close();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("sesion.txt"))
            {
                File.Delete("sesion.txt");
            }
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Capacity");
            dt.Columns.Add("Area");
            dt.Columns.Add("Type");
            string sql = "SELECT types.Name as item,a.Name as area,i.Title,i.Capacity FROM Areas as a " +
                "INNER JOIN Items AS i ON i.AreaID = a.ID " +
                "INNER JOIN ItemTypes AS types ON types.ID = i.ItemTypeID " +
                "WHERE a.Name LIKE @i";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@i", "%" + textBox1.Text.Trim() + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string titulo = reader["Title"].ToString();
                string capacidad = reader["Capacity"].ToString();
                string areas = reader["area"].ToString();
                string tipos = reader["item"].ToString();

                dt.Rows.Add(titulo, capacidad, areas, tipos);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(user);
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;

                if(dataGridView1.CurrentRow.DefaultCellStyle.BackColor == Color.Red)
                {

                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    string slq = "UPDATE Users SET activo = 0 WHERE ID = @a";
                    SqlCommand cmd = new SqlCommand(slq,conexion);
                    cmd.Parameters.AddWithValue("@a", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fue desactivado");  
                }
            }
        }
    }
}
