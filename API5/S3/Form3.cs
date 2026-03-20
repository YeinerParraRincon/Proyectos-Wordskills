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

namespace S3
{
    public partial class Form3 : Form
    {
        private HttpClient _httpClient;
        int usuario;
        public Form3(int idselecionado)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44324/")
            };
            usuario = idselecionado;
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                var traer = await _httpClient.GetFromJsonAsync<ProductoDTO>($"api/Producto/products/{usuario}");

                var traerComobx = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");
                if (traer != null)
                {
                    var categoria = traerComobx?.Select(p => p.Category).Distinct().ToList();

                    comboBox1.DataSource = categoria;
                    comboBox1.SelectedItem = traer.Category;

                    textBox1.Text = traer.Name;
                    textBox2.Text = traer.Descripcion;
                    numericUpDown1.Value = traer.Price;
                    numericUpDown2.Value = traer.Cost;
                    dateTimePicker1.Value = traer.Date.ToDateTime(TimeOnly.MinValue);
                    checkBox1.Checked = traer.Active;
                    checkBox2.Checked = traer.Seasonal;

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
                    Descripcion = textBox2.Text,
                    Ingredients = textBox2.Text,
                    Price = (short)numericUpDown1.Value,
                    Cost = (short)numericUpDown2.Value,
                    Active = checkBox1.Checked,
                    Seasonal = checkBox2.Checked,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Category = comboBox1.SelectedItem?.ToString() ?? ""
                };

                var insertarProducto = await _httpClient.PutAsJsonAsync($"api/Producto/products/{usuario}", producto);

                if (insertarProducto.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso la actualizacion de datos");

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
