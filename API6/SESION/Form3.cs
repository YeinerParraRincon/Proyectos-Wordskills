using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SESION
{
    public partial class Form3 : Form
    {
        private HttpClient _httpClient;
        int ids;
        public Form3(int id)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
            ids = id;
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                var productoNuevo = await _httpClient.GetFromJsonAsync<ProductoDTO>($"api/Producto/products/{ids}");

                if (productoNuevo != null)
                {
                    var categoria = producto?.Select(p => p.Category).Distinct().ToList();
                    comboBox1.DataSource = categoria;

                    textBox1.Text = productoNuevo.Name;
                    textBox2.Text = productoNuevo.Descripcion;
                    comboBox1.SelectedItem = productoNuevo.Category;
                    dateTimePicker1.Value = productoNuevo.Date.ToDateTime(TimeOnly.MinValue);
                    numericUpDown1.Value = productoNuevo.Price;
                    numericUpDown2.Value = productoNuevo.Cost;
                    checkBox1.Checked = productoNuevo.Active;
                    checkBox2.Checked = productoNuevo.Seasonal;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var producto = new ProductoDTO
                {
                    Name = textBox1.Text,
                    Descripcion = textBox2.Text,
                    Ingredients = textBox2.Text,
                    Category = comboBox1.SelectedItem?.ToString() ?? "",
                    Price = (short)numericUpDown1.Value,
                    Cost = (short)numericUpDown2.Value,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Active = checkBox1.Checked,
                    Seasonal = checkBox2.Checked,
                };

                var productoInsertado = await _httpClient.PutAsJsonAsync($"api/Producto/products/{ids}", producto);

                if (productoInsertado.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso la actualizacion de datos");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); 
        }
    }
}
