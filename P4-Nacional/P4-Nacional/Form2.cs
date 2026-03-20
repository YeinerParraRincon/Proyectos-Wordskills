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

namespace P4_Nacional
{
    public partial class Form2 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=sesion4;integrated security = true");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            conexion.Open();
            var lista = new List<(int id,double hour,int rental,string dueño,string marca,string model,string image)>();
            string sql = "SELECT c.Id,c.HourPrice as hour,c.RentalsAverageByMonth as rental,u.FirstName as dueño,b.Name as marca,m.Name as model,c.Image as image FROM Cars AS c " +
                "LEFT JOIN Rental AS ro ON ro.CarId = c.Id " +
                "LEFT JOIN Users AS u ON ro.Id = u.Id " +
                "INNER JOIN Brands AS b ON b.Id = c.BrandId " +
                "INNER JOIN Model AS m ON m.Id = c.ModelId ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                lista.Add((
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToDouble(reader["hour"]),
                    Convert.ToInt32(reader["rental"]),
                    reader["dueño"].ToString(),
                    reader["marca"].ToString(),
                    reader["model"].ToString(),
                    reader["image"].ToString()
                    ));
            }
            reader.Close();
            foreach(var i in lista)
            {
                var imagen = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(10,10,10,10)
                };

                var carpetaDestino = @"C:\Users\h1484\Downloads\Final WS 2025 Colombia\P4\Datafiles\cars";
                var ruta = Path.Combine(carpetaDestino,i.image);

                if(File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }
                else
                {
                    BackColor = Color.Gray;
                }

                var Titulo = new Label
                {
                    Text = $"{i.marca} {i.model}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                };
                var hour = new Label { Text = "Hour Price:" + i.hour,AutoSize = true };
                var renatl = new Label { Text = "Rental Averague / month:" + i.rental, AutoSize = true };
                var current = new Label { Text = "Current Rentar:" + i.dueño, AutoSize = true };

                var botonEliminar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Tag = i.id,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gold,
                    Text = "❌",
                };

                botonEliminar.Click += (r, m) =>
                {
                    var id = (int)((Button)r).Tag;
                    Eliminar(id);
                };

                var botonActualizar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Tag = i.id,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gold,
                    Text = "🖊️",
                };

                botonActualizar.Click += (r, m) =>
                {
                    var id = (int)((Button)r).Tag;
                    Form3 form3 = new Form3(id);
                    form3.Show();
                    this.Hide();
                };

                var panelBotones = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 100,
                    Height = 140,
                };

                panelBotones.Controls.Add(botonEliminar);
                panelBotones.Controls.Add(botonActualizar);

                var panelTexto = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Width = 300,
                    Height =100,
                };

                panelTexto.Controls.Add(Titulo);
                panelTexto.Controls.Add(hour);
                panelTexto.Controls.Add(renatl);
                panelTexto.Controls.Add(current);

                var panelPrincipal = new TableLayoutPanel
                {
                    Width = 500,
                    Height = 150,
                    Margin = new Padding(5),
                    Padding = new Padding(5),
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    BackColor = Color.FromArgb(245,245,245),
                    ColumnCount = 3,
                    RowCount = 2,
                    
                };


                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                panelPrincipal.Controls.Add(panelBotones, 0, 0);
                panelPrincipal.Controls.Add(panelTexto, 1, 0);
                panelPrincipal.Controls.Add(imagen,2, 0);

                flowLayoutPanel1.Controls.Add(panelPrincipal);
            }
            conexion.Close();
        }

        private void Eliminar(int id)
        {
            conexion.Open();
            var mensajeSeguro = MessageBox.Show("Confirmar", "¿Estas Seguro De Eliminar?", MessageBoxButtons.YesNo);

            if(mensajeSeguro == DialogResult.Yes)
            {

                string marca = "";
                string modelo = "";

                string consulta = "SELECT c.Id,b.Name as marca,m.Name as model FROM Model as m " +
                "INNER JOIN Cars AS c ON c.ModelId = m.Id " +
                "INNER JOIN Brands AS b ON b.Id = c.BrandId " +
                "WHERE c.Id = @a";
                SqlCommand cmdConsulta = new SqlCommand(consulta,conexion);
                cmdConsulta.Parameters.AddWithValue("@a", id);
                SqlDataReader readerConsulta = cmdConsulta.ExecuteReader();
                if(readerConsulta.Read())
                {
                    marca = readerConsulta["marca"].ToString();
                    modelo = readerConsulta["model"].ToString();
                }
                readerConsulta.Close();


                string descripcion = $"{marca}{modelo} was removed from the list";

                string insertarEstado = "INSERT INTO Notifications(Description,CreatedAt,CarId,NotificationTypeId)values(@d,@c,@ca,@n)";
                SqlCommand cmdEstado = new SqlCommand(insertarEstado, conexion);
                cmdEstado.Parameters.AddWithValue("@d", descripcion);
                cmdEstado.Parameters.AddWithValue("@c", DateTime.Now);
                cmdEstado.Parameters.AddWithValue("@ca", id);
                cmdEstado.Parameters.AddWithValue("@n", 2);
                cmdEstado.ExecuteNonQuery();

                string eliminarRental = "DELETE FROM Rental WHERE CarId = @id";
                SqlCommand cmdRental = new SqlCommand(eliminarRental,conexion);
                cmdRental.Parameters.AddWithValue("@id", id);
                cmdRental.ExecuteNonQuery();


                string eliminarCars = "DELETE FROM Cars WHERE Id = @id";
                SqlCommand cmdCars = new SqlCommand(eliminarCars,conexion);
                cmdCars.Parameters.AddWithValue("@id", id);
                cmdCars.ExecuteNonQuery();

                MessageBox.Show("Fue exitoso la Eliminacion del Vehiculo");



                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            conexion.Close();
        }
    }
}
