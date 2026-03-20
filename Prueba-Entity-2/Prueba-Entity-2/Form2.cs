using Microsoft.EntityFrameworkCore;
using Prueba_Entity_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_2
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

            foreach(var r in  cars)
            {
                var owner = r.Rentals.FirstOrDefault()?.User?.FirstName ?? "No tiene Dueño";

                var imagen = new PictureBox
                {
                    Width = 150,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                var carpeta = @"C:\Users\h1484\Downloads\Final WS 2025 Colombia\P4\Datafiles\cars";
                var ruta = Path.Combine(carpeta, r.Image);

                if (File.Exists(ruta))
                {
                    imagen.Image = Image.FromFile(ruta);
                }
                else
                {
                    imagen.BackColor = Color.Gray;
                };

                var titulo = new Label
                {
                    AutoSize = true,
                    Text = $"{r.Brand.Name} {r.Model.Name}",
                    Font = new Font("Segoe UI", 10,FontStyle.Bold)
                };

                var hourprice = new Label { Text = $"Hour Price: {r.HourPrice}",AutoSize = true};
                var rentalAmerague = new Label { Text = $"Rental Averague Moth: {r.RentalsAverageByMonth}", AutoSize = true };
                var current = new Label { Text = $"{owner}", AutoSize = true };

                var panelTexto = new FlowLayoutPanel
                {
                    Width = 100,
                    Height = 50,
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true
                };

                panelTexto.Controls.Add(titulo);
                panelTexto.Controls.Add(hourprice);
                panelTexto.Controls.Add(rentalAmerague);
                panelTexto.Controls.Add(current);


                var botonesEliminar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Text = "❌",
                    FlatStyle = FlatStyle.Flat,
                    Tag = r.Id
                };

                botonesEliminar.Click += (e, m) =>
                {
                    int id = (int)((Button)e).Tag;
                    Eliminar(id);
                };

                var botonesActualizar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Text = "🖊️",
                    FlatStyle = FlatStyle.Flat,
                    Tag = r.Id
                };

                botonesActualizar.Click += (e, m) =>
                {
                    int id = (int)((Button)e).Tag;
                    Actualizar(id);
                };

                var panelBotones = new FlowLayoutPanel
                {
                    Width = 120,
                    Height = 120,
                    FlowDirection = FlowDirection.TopDown
                };


                panelBotones.Controls.Add(botonesActualizar);
                panelBotones.Controls.Add(botonesEliminar);

                var panelPrincinpal = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 2,
                    Width = 620,
                    Height = 150,
                    BackColor = Color.FromArgb(245,238,238),
                    Margin = new Padding(5),
                    Padding = new Padding(5)
                };

                panelPrincinpal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                panelPrincinpal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,70));
                panelPrincinpal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));


                panelPrincinpal.Controls.Add(panelBotones,0,0);
                panelPrincinpal.Controls.Add(panelTexto,1,0);
                panelPrincinpal.Controls.Add(imagen,2,0);

                flowLayoutPanel1.Controls.Add(panelPrincinpal);
            }
        }
        private void Eliminar ( int id)
        {
            var cars = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .FirstOrDefault(c => c.Id == id);

            if(cars == null)
            {
                MessageBox.Show("No se Encontro el Carro");
                return;
            }

            var mensajeConfirmacion = MessageBox.Show("¿Estas Seguro De Eliminar Este Carro?", "Confirmar", MessageBoxButtons.YesNo);

            if(mensajeConfirmacion != DialogResult.Yes)
            {
                return;
            }

            string descripcion = $"{cars.Brand.Name} {cars.Model.Name} Fue Eliminado Este Carro";

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
