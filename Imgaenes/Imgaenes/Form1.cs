using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Imgaenes
{
    public partial class Form1 : Form
    {
        private List<datos> datosos;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "datos.json");

                if(!File.Exists(ruta))
                {
                    MessageBox.Show("Ese json no esta ubicado o no existe");
                    return;
                }

                string json = File.ReadAllText(ruta);

                foreach(var l in datosos)
                {
                    var nombre = l.nombre;
                    var nombreIngresado =textBox1.Text;

                    if(nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase))
                    {
                        var imagen = new PictureBox
                        {
                            Width = 100,
                            Height = 100,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        var rutaImagen = Path.Combine(Application.StartupPath, l.imagen);
                        if(File.Exists(rutaImagen))
                        {
                            imagen.Image = Image.FromFile(rutaImagen);
                        }

                        var nom = new Label {Text = l.nombre };
                        var edad = new Label {Text = l.edad.ToString() };

                        var panel = new FlowLayoutPanel
                        {
                            Width = 150,
                            Height = 150,
                        };

                        panel.Controls.Add(imagen);
                        panel.Controls.Add(nom);
                        panel.Controls.Add(edad);

                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "datos.json");

                if (!File.Exists(ruta))
                {
                    MessageBox.Show("No se encontre un json en ese destino");
                    return;
                }

                string json = File.ReadAllText(ruta);
                datosos = JsonConvert.DeserializeObject<List<datos>>(json);

                flowLayoutPanel2.Controls.Clear();

                foreach(var j in datosos)
                {
                    var imagen = new PictureBox { 
                    Height = 100,
                    Width = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    string rutaImgane = Path.Combine(Application.StartupPath, j.imagen);
                    if (File.Exists(rutaImgane))
                    {
                        imagen.Image = Image.FromFile(rutaImgane);  
                    }

                    var nombre = new Label { Text = j.nombre };
                    var edad = new Label { Text= j.edad.ToString() };
            

                    var panel = new FlowLayoutPanel
                    {
                        Width = 145,
                        Height = 145
                    };

                    panel.Controls.Add(imagen);
                    panel.Controls.Add(nombre);
                    panel.Controls.Add(edad);

                    flowLayoutPanel2.Controls.Add(panel);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
