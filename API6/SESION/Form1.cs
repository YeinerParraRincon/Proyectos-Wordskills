using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SESION
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
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
                    Seasonal = checkBox2.Checked
                };

                var insertarProducto = await _httpClient.PostAsJsonAsync("api/Producto/products", producto);

                if (insertarProducto.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso el registro del usuario");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if(producto != null && producto.Count > 0)
                {
                    var category = producto.Select(p => p.Category).Distinct().ToList();

                    comboBox1.DataSource = category;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
