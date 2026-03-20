using Microsoft.EntityFrameworkCore;
using Prueba_Entity_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_1
{
    public partial class Form2 : Form
    {
        private readonly Sesion4Context db = new Sesion4Context();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            var sql = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .Include(c => c.Rentals)
                .ThenInclude(r => r.User)
                .ToList();

            foreach(var r in sql)
            {
                var owner = r.Rentals.FirstOrDefault()?.User.FirstName ?? "No Tiene Dueño";

                var imagen = new PictureBox
                {
                    Width =100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom
                };


                var carpeta = @"C:\\Users\\h1484\\Downloads\\Final WS 2025 Colombia\\P4\\Datafiles\\cars";
                string ruta = Path.Combine(carpeta, r.Image);

                if(File.Exists(ruta) )
                {
                    imagen.Image = Image.FromFile(ruta);
                }
                else
                {
                    imagen.BackColor = Color.Gray;
                }

                var titulo = new Label
                {
                    Text = $"{r.Brand.Name} {r.Model.Name}",
                    AutoSize = true
                };

                var house = new Label { Text = $"Hour Price: {r.HourPrice}",AutoSize = true };
                var rantal = new Label { Text = $"Rental Averague: {r.RentalsAverageByMonth}",AutoSize=true };
                var current = new Label { Text = $"{owner}", AutoSize = true };

                var panelTexto = new FlowLayoutPanel
                {
                    AutoSize = true,
                    Width = 300,
                    Height = 200,
                    FlowDirection = FlowDirection.TopDown
                };

                panelTexto.Controls.Add(titulo);
                panelTexto.Controls.Add(house);
                panelTexto.Controls.Add(rantal);
                panelTexto.Controls.Add(current);


                var botonEliminar = new Button
                {
                    Width = 50,
                    Height = 50,
                    BackColor = Color.Red,
                    FlatStyle = FlatStyle.Flat,
                    Text = "❌",
                    Tag = r.Id
                };

                botonEliminar.Click += (a, m) =>
                {
                    int id = (int)((Button)a).Tag;
                    Eliminar(id);
                };

                var botonActualizar = new Button
                {
                    Width = 50,
                    Height = 50,
                    BackColor = Color.Red,
                    FlatStyle = FlatStyle.Flat,
                    Text = "🖊️",
                    Tag = r.Id
                };

                botonActualizar.Click += (a, m) =>
                {
                    int id = (int)((Button)a).Tag;
                    Actualizar(id);
                };

                var panelBotones = new FlowLayoutPanel
                {
                    Width = 120,
                    Height = 120,
                    FlowDirection = FlowDirection.LeftToRight
                };

                panelBotones.Controls.Add(botonEliminar);
                panelBotones.Controls.Add(botonActualizar);

                var panelPrincipal = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 1,
                    Width = 400,
                    Height = 200,
                    Margin = new Padding(5),
                    Padding = new Padding(5),
                    BackColor = Color.FromArgb(245,245,245)
                };

                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                panelPrincipal.Controls.Add(panelBotones,0,0);
                panelPrincipal.Controls.Add(panelTexto,1,0);
                panelPrincipal.Controls.Add(imagen, 2, 0);

                flowLayoutPanel1.Controls.Add(panelPrincipal);
            }
        }

        private void Eliminar(int id)
        {
            var eliminarCars = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .FirstOrDefault(c => c.Id == id);

            if(eliminarCars == null)
            {
                MessageBox.Show("No se encontro el carro");
                return;
            }

            var confirmacionEliminacion = MessageBox.Show("¿Estas Seguro Que Quieres Eliminar Este Vehiculo?", "Confirmar", MessageBoxButtons.YesNo);
            if(confirmacionEliminacion != DialogResult.Yes)
            {
                return;
            }

            string descripcion = $"{eliminarCars.Brand?.Name} {eliminarCars.Model.Name} fue remodido de la lista de carros";

            var notificacion = new Notification
            {
                Description = descripcion,
                CreatedAt = DateTime.Now,
                CarId = eliminarCars.Id,
                NotificationTypeId = 2
            };
            db.Notifications.Add(notificacion);

            var rental = db.Rentals.Where(r => r.CarId == id);
            db.Rentals.RemoveRange(rental);

            db.Cars.Remove(eliminarCars);
            db.SaveChanges();

            MessageBox.Show("Fue exitoso la eliminacion del carro");
            flowLayoutPanel1.Controls.Clear();
            Form2_Load(null, null);
        }

        private void Actualizar( int id)
        {
            Form3 form3 = new Form3(id);
            form3.Show();
            this.Hide();
        }
    }
}
