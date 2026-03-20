using DTOS;
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
        private readonly HttpClient _httpClient;
        public Form3()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44373/")
            };
            traer();
        }

        private async void traer()
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<ProductsDTO>>("api/Producto/products");

                if(productos != null && productos.Count > 0)
                {
                    var categorias = productos.Select(p => p.Category).Distinct().ToList();

                    comboBox1.DataSource = categorias;
                    comboBox1.SelectedIndex = - 1;
                }
            }catch(Exception ex)
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var producto = new ProductsDTO
                {
                    Name = textBox2.Text,
                    Category = comboBox1.SelectedItem?.ToString() ?? "",
                    Price = (short)numericUpDown1.Value,
                    Cost = (short)numericUpDown2.Value,
                    Seasonal = checkBox2.Checked,
                    Active = checkBox1.Checked,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Descripcion = textBox1.Text,
                    Ingredients = textBox1.Text
                };

                var response = await _httpClient.PostAsJsonAsync("api/Producto/products", producto);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto Agregado Correctamente");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al insertar el producto");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
