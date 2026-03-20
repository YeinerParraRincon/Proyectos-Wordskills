using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreeELiminar
{
    public partial class Form2 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        int usuario;
        string plato;
        public Form2(int id,string nombre)
        {
            InitializeComponent();
            usuario = id;
            plato = nombre;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = plato;
            conexion.Open();
            var lista  = new List<(string imagen,int id)>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Quanty");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Cost");

            string sql = "SELECT r.time,r.descripcion,r.quanty,r.unit,c.nombre as ca,i.price,i.nombre as product,r.id_dishes,d.image FROM ingredientes as i " +
                "INNER JOIN recipes as r on r.id_ingredient = i.id_ingredientes " +
                "INNER JOIN dishes as d on d.id_dishes = r.id_dishes " +
                "INNER JOIN categorias as c on c.id_categorias = d.id_category " +
                "WHERE r.id_dishes = @l";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@l", usuario);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["ca"].ToString();
                textBox2.Text = reader["time"].ToString();
                textBox3.Text = reader["descripcion"].ToString();
                textBox4.Text = reader["price"].ToString();

                lista.Add((
                    reader["image"].ToString(),
                    1
                    ));
                
                string name = reader["product"].ToString();
                string quanty = reader["quanty"].ToString();
                string unit = reader["unit"].ToString();
                string cost = reader["price"].ToString();

                dt.Rows.Add(name, quanty, unit, cost);
            }
            foreach(var  item in lista)
            {
                var imagen = new PictureBox
                {
                    Width =200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                imagen.Click += (r, f) =>
                {
                    Form3 form1 = new Form3(usuario,plato);
                    form1.Show();
                    this.Hide();
                };

                var carpeta = Path.Combine(Application.StartupPath, "images");
                var ruta = Path.Combine(carpeta, item.imagen);

                if(File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }

                var panel = new FlowLayoutPanel
                {
                    Width = 200,
                    Height = 200,
                };

                panel.Controls.Add(imagen);

                flowLayoutPanel1.Controls.Add(panel);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            conexion.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Te enceuntras en esta vista");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Pronto estara");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
