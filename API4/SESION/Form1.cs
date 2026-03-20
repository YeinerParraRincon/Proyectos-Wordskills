using DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SESION
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        int usuario;
        public Form1(int idSelecionado)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44373/")
            };
            usuario = idSelecionado;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var datosActualizar = new ProductsDTO
                {
                    Name = textBox2.Text,
                    Category = comboBox1.SelectedItem?.ToString() ?? "",
                    Price = (short)numericUpDown1.Value,
                    Cost = (short)numericUpDown2.Value,
                    Seasonal = checkBox2.Checked,
                    Active = checkBox1.Checked,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Descripcion = textBox1.Text
                };

                var actualizar = await _httpClient.PutAsJsonAsync($"api/Producto/products/{usuario}", datosActualizar);

                if (actualizar.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso la actualizacion de los datos");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<ProductsDTO>($"api/Producto/products/{usuario}");

                var listaProductos = await _httpClient.GetFromJsonAsync<List<ProductsDTO>>("api/Producto/products");
                if (productos != null)
                {
                    var categorias = listaProductos?.Select(p => p.Category).Distinct().ToList();
                    comboBox1.DataSource = categorias;

                    textBox1.Text = productos.Descripcion;
                    textBox2.Text = productos.Name;
                    numericUpDown1.Value = productos.Price;
                    numericUpDown2.Value = productos.Cost;
                    checkBox1.Checked = productos.Active;
                    checkBox2.Checked = productos.Seasonal;
                    dateTimePicker1.Value = productos.Date.ToDateTime(TimeOnly.MinValue);
                    comboBox1.SelectedItem = productos.Category;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
