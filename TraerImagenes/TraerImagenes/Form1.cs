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
using System.Xml;

namespace TraerImagenes
{
    public partial class Form1 : Form
    {
        SqlConnection conexiob = new SqlConnection("server=.;database=Praticar;integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            conexiob.Open();
            var lista = new List<(int id,string imagen)>();
            string sql = "SELECT * FROM carro";
            SqlCommand cmd = new SqlCommand(sql, conexiob);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add((
                    Convert.ToInt32(reader["id_carro"]),
                    reader["imagen"].ToString()
                    ));
            }

            foreach(var i in lista)
            {


                var imagen = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                var boton = new Button
                {
                    Width = 100,
                    Height = 40,
                    Text = "🚮 Eliminar",
                    BackColor = Color.FromArgb(255, 80, 80),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = i.id,
                    Margin = new Padding(10, 70, 10, 10)
                };

                boton.Click += (r, l) =>
                {
                    int id = (int)((Button)r).Tag;
                    eliminar(id);
                };

                var carpetaRuta = @"C:\Users\h1484\OneDrive\Imágenes\imagenes";
                var ruta = Path.Combine(carpetaRuta, i.imagen);

                if(File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }

                var panel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400,
                    Height = 200,
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke
                };

                panel.Controls.Add(boton);
                panel.Controls.Add(imagen);

                flowLayoutPanel1.Controls.Add(panel);
            }
            conexiob.Close();
        }

        private void eliminar(int id)
        {
            conexiob.Open();
            string slq = "DELETE FROM carro WHERE id_carro = @a";
            SqlCommand cmd = new SqlCommand(slq,conexiob);
            cmd.Parameters.AddWithValue("@a", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fue exitoso la eliminacion de la imagen");
            conexiob.Close();
        }
    }
}
