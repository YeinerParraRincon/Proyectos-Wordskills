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
    public partial class Form2 : Form
    {
        private HttpClient _httpClient;
        public Form2()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44324/")
            };
            traer();
        }
        private async void traer()
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if(producto != null && producto.Count > 0)
                {
                    var escojido = producto.Select(p => p.Category).Distinct().ToList();

                    comboBox1.DataSource = escojido;
                }
            }catch(Exception ex)
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
                    Seasonal = checkBox2.Checked,
                    Active = checkBox1.Checked,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Category = comboBox1.SelectedItem?.ToString() ?? ""
                };

                var agregar = await _httpClient.PostAsJsonAsync("api/Producto/products", producto);

                if (agregar.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso el registro de la categoria");

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
