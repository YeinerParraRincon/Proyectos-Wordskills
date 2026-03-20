using Microsoft.EntityFrameworkCore;
using P4_Nacional_Entity.Models;

namespace P4_Nacional_Entity
{
    public partial class Form1 : Form
    {
        private readonly Sesion4Context db = new Sesion4Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            foreach (var car in cars)
            {
                string owner = car.Rentals.FirstOrDefault()?.User?.FirstName ?? "No current renter";

                var imagen = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(10)
                };

                var carpetaDestino = @"C:\Users\h1484\Downloads\Final WS 2025 Colombia\P4\Datafiles\cars";
                var ruta = Path.Combine(carpetaDestino, car.Image ?? "");

                if (File.Exists(ruta))
                    imagen.Image = Image.FromFile(ruta);
                else
                    imagen.BackColor = Color.Gray;

                var titulo = new Label
                {
                    Text = $"{car.Brand?.Name} {car.Model?.Name}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                };
                var hour = new Label { Text = $"Hour Price: {car.HourPrice}", AutoSize = true };
                var rental = new Label { Text = $"Rentals Avg/Month: {car.RentalsAverageByMonth}", AutoSize = true };
                var current = new Label { Text = $"Current Renter: {owner}", AutoSize = true };

                var botonEliminar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Tag = car.Id,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gold,
                    Text = "❌",
                };
                botonEliminar.Click += (r, m) =>
                {
                    int id = (int)((Button)r).Tag;
                    Eliminar(id);
                };

                var botonActualizar = new Button
                {
                    Width = 50,
                    Height = 50,
                    Tag = car.Id,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gold,
                    Text = "🖊️",
                };
                botonActualizar.Click += (r, m) =>
                {
                    int id = (int)((Button)r).Tag;
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
                    Height = 100,
                };
                panelTexto.Controls.Add(titulo);
                panelTexto.Controls.Add(hour);
                panelTexto.Controls.Add(rental);
                panelTexto.Controls.Add(current);

                var panelPrincipal = new TableLayoutPanel
                {
                    Width = 500,
                    Height = 150,
                    Margin = new Padding(5),
                    Padding = new Padding(5),
                    BackColor = Color.FromArgb(245, 245, 245),
                    ColumnCount = 3,
                    RowCount = 1,
                };
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

                panelPrincipal.Controls.Add(panelBotones, 0, 0);
                panelPrincipal.Controls.Add(panelTexto, 1, 0);
                panelPrincipal.Controls.Add(imagen, 2, 0);

                flowLayoutPanel1.Controls.Add(panelPrincipal);
            }
        }
        private void Eliminar(int id)
        {
             var car = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                MessageBox.Show("No se encontró el vehículo.");
                return;
            }

            var confirmar = MessageBox.Show("¿Seguro que quieres eliminar este vehículo?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar != DialogResult.Yes)
                return;

            string descripcion = $"{car.Brand?.Name} {car.Model?.Name} was removed from the list";

            var noti = new Notification
            {
                Description = descripcion,
                CreatedAt = DateTime.Now,
                CarId = car.Id,
                NotificationTypeId = 2
            };
            db.Notifications.Add(noti);

            var rentals = db.Rentals.Where(r => r.CarId == id);
            db.Rentals.RemoveRange(rentals);

            db.Cars.Remove(car);
            db.SaveChanges();

            MessageBox.Show("Vehículo eliminado exitosamente.");
            flowLayoutPanel1.Controls.Clear();
            Form1_Load(null, null);
        }
    }
}
