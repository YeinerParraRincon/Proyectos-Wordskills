using Microsoft.EntityFrameworkCore;
using Prueba_Entity_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_3
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
            

            var cars = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .Include(c => c.Rentals)
                .ThenInclude(r => r.User)
                .ToList();

            foreach(var i in  cars)
            {
                var owner = db.Rentals.FirstOrDefault()?.User?.FirstName ?? "No tiene Dueño";

                var imagen = new PictureBox
                {
                    Width = 150,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                var carpeta = @"C:\Users\h1484\Downloads\Final WS 2025 Colombia\P4\Datafiles\cars";
                var ruta = Path.Combine(carpeta, i.Image);

                if(File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }
                else
                {
                    imagen.BackColor = Color.Gray;
                }

                var titulo = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI",10,FontStyle.Bold),
                    Text = $"{i.Brand.Name} {i.Model.Name}"
                };

                var houseprice = new Label
                {
                    AutoSize = true,
                    Text = $"House Price:  {i.HourPrice}"
                };

                var rentalaverague = new Label
                {
                    AutoSize = true,
                    Text = $"Rental Averague Moth: {i.RentalsAverageByMonth}"
                };

                var current = new Label
                {
                    AutoSize = true,
                    Text = $"{owner}"
                };

                var panelTitulo = new FlowLayoutPanel
                {
                    Width = 100,
                    Height = 100,
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true
                };

                panelTitulo.Controls.Add(titulo);
                panelTitulo.Controls.Add(houseprice);
                panelTitulo.Controls.Add(rentalaverague);
                panelTitulo.Controls.Add(current);

                var botonEliminar = new Button
                {
                    Text = "❌",
                    FlatStyle = FlatStyle.Flat,
                    Width = 50,
                    Height = 50,
                    Tag = i.Id
                };

                botonEliminar.Click += (s, m) =>
                {
                    int id = (int)((Button)s).Tag;
                    Eliminar(id);
                };

                var botonActualizar = new Button
                {
                    Text = "🖊️",
                    FlatStyle = FlatStyle.Flat,
                    Width = 50,
                    Height = 50,
                    Tag = i.Id
                };

                botonActualizar.Click += (s, m) =>
                {
                    int id = (int)((Button)s).Tag;
                    Actualizar(id);
                };

                var panelBotones = new FlowLayoutPanel
                {
                    Width = 110,
                    Height = 110,
                    FlowDirection = FlowDirection.TopDown
                };

                panelBotones.Controls.Add(botonEliminar);
                panelBotones.Controls.Add(botonActualizar);


                var panelPrincipal = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 2,
                    Width = 650,
                    Height = 100,
                    BackColor = Color.FromArgb(245,235,235),
                    Margin = new Padding(5),
                    Padding = new Padding(5)
                };

                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,70));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,30));


                panelPrincipal.Controls.Add(panelBotones,0,0);
                panelPrincipal.Controls.Add(panelTitulo,1,0);
                panelPrincipal.Controls.Add(imagen,2,0);

                flowLayoutPanel1.Controls.Add(panelPrincipal);
            }
        }

        private void Eliminar(int id)
        {
            var cars = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .FirstOrDefault(c => c.Id == id);


            if(cars == null)
            {
                MessageBox.Show("Fue Eliminado Correctamente");
                return;
            }


            var MensajeDeConfirmacion = MessageBox.Show("¿Estas Seguro De Eliminar Este Vehiculo?", "Confirmar", MessageBoxButtons.YesNo);

            if(MensajeDeConfirmacion != DialogResult.Yes)
            {
                return;
            }


            var descripcion = $"{cars.Brand.Name} {cars.Model.Name} Fue Remodido este vehiculo";

            var notifi = new Notification
            {
                Description = descripcion,
                CreatedAt = DateTime.Now,
                CarId = cars.Id,
                NotificationTypeId = 2
            };
            db.Notifications.Add(notifi);

            var rental = db.Rentals.Where(c => c.CarId == id);
            db.Rentals.RemoveRange(rental);

            db.Cars.Remove(cars);
            db.SaveChanges();

            MessageBox.Show("Fue Eliminado Correctamente");
            flowLayoutPanel1.Controls.Clear();
            Form2_Load(null, null);
        }

        private void Actualizar(int id)
        {
            Form3 form3 = new Form3(id);
            form3.Show();
            this.Hide();
        }
    }
}
