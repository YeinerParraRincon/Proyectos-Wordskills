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

namespace preselecion
{
    public partial class Ver : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        int anuncio;
        public Ver(int id)
        {
            InitializeComponent();
            anuncio = id;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Se desarrollara mas tarde");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Ver_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Quanty");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Cost");


            string sql = "SELECT c.name as ca,i.base,i.description,i.price,i.quanty,i.unit,g.name as ingredinetes FROM ingredientes as g " +
                "INNER JOIN dishes as i on i.ingredientes = g.id_ingredientes " +
                "INNER JOIN categoria as c on c.id_categoria = i.category " +
                "WHERE i.id_dishes = @a";
            SqlCommand cmd = new SqlCommand(sql,conexion);
            cmd.Parameters.AddWithValue("@a", anuncio);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string nombre = reader["ingredinetes"].ToString();
                string quanty = reader["quanty"].ToString();
                string unit = reader["unit"].ToString();
                string precio = reader["price"].ToString();

                dt.Rows.Add(nombre,quanty,unit,precio);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();


            var lista = new List<(string categoria,string time,string descripcion,string total,string imagen)>();
            string slq = "SELECT a.name as category,i.quanty,i.description,i.price,i.image FROM categoria as a " +
                "INNER JOIN dishes as i on i.category = a.id_categoria " +
                "WHERE i.id_dishes = @a";
            SqlCommand cmds = new SqlCommand(slq,conexion);
            cmds.Parameters.AddWithValue("@a", anuncio);
            SqlDataReader readers = cmds.ExecuteReader();
            while(readers.Read())
            {
                lista.Add((
                    readers["category"].ToString(),
                    readers["quanty"].ToString(),
                    readers["description"].ToString(),
                    readers["price"].ToString(),
                    readers["image"].ToString()
                    ));
            }
            foreach(var i in lista)
            {
                textBox1.Text = i.categoria.ToString();
                textBox2.Text = i.time.ToString();
                textBox3.Text = i.descripcion.ToString();
                textBox4.Text = i.total.ToString();

                var imagen = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                var carptea = Path.Combine(Application.StartupPath, "images");
                var ruta = Path.Combine(carptea, i.imagen);

                if(File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }

                var panel = new FlowLayoutPanel
                {
                    Width= 200,
                    Height = 200,
                };

                panel.Controls.Add(imagen);

                flowLayoutPanel1.Controls.Add(panel);
            }
            conexion.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
      
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Imagen ir = new Imagen(anuncio);
            ir.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaDeLosIngredientes ingredientes = new ListaDeLosIngredientes();
            ingredientes.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
