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
    public partial class Form3 : Form
    {
        private readonly Sesion4Context db = new Sesion4Context();
        private int CarId;
        private Car CarActual;
        public Form3(int id)
        {
            InitializeComponent();
            CarId = id;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CarActual = db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .FirstOrDefault(c => c.Id == CarId);

            if (CarActual == null)
            {
                MessageBox.Show("Ese Carro No Se Encontro");
                Close();
                return;
            }

            textBox1.Text = CarActual.Brand.Name;
            textBox1.Enabled = false;


            comboBox1.Items.Clear();
            comboBox1.Items.Add(CarActual.Model.Name == "No tiene Items");
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;

            numericUpDown1.Value = CarActual.RentalsAverageByMonth;
            textBox2.Text = ((decimal)CarActual.HourPrice).ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!decimal.TryParse(textBox2.Text,out decimal result))
            {
                MessageBox.Show("Valor Ingresado Incorrecto");
                return;
            };

            CarActual.RentalsAverageByMonth = (int)numericUpDown1.Value;
            CarActual.HourPrice = result;

            db.Cars.Update(CarActual);

            var notifi = new Notification
            {
                Description = $"{CarActual.Brand.Name} {CarActual.Model.Name} Se Actualizo los Datos",
                CreatedAt = DateTime.Now,
                CarId = CarActual.Id,
                NotificationTypeId = 1
            };

            db.Notifications.Add(notifi);
            db.SaveChanges();

            MessageBox.Show("Fue exitoso la Actualizacion de los datos");
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
