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

namespace SESSION5
{
    public partial class Form3 : Form
    {
        private readonly HttpClient _httpClient;
        public Form3()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/")
            };
            TraerDatos();
        }

        private async void TraerDatos()
        {
            try
            {
                var traerProductos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if (traerProductos != null)
                {
                    var filtrado = traerProductos.Select(p => p.Category).Distinct().ToList();

                    comboBox1.DataSource = filtrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var producto = new ProductoDTO
                {
                    Name = textBox1.Text,
                    Category = comboBox1.SelectedItem?.ToString() ?? "",
                    Price = (short)numericUpDown1.Value,
                    Cost = (short)numericUpDown2.Value,
                    Active = checkBox1.Checked,
                    Seasonal = checkBox2.Checked,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Descripcion = textBox2.Text,
                    Ingredients = textBox2.Text
                };

                var insertar = await _httpClient.PostAsJsonAsync("api/Producto/products", producto);

                if (insertar.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso el registro del producto");

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
