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
    public partial class Form2 : Form
    {
        private readonly HttpClient _httpClient;
        int idUsuario;
        public Form2(int id)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/")
            };
            idUsuario = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                var traerCombox = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                var traer = await _httpClient.GetFromJsonAsync<ProductoDTO>($"api/Producto/products/{idUsuario}");

                if (traer != null)
                {
                    var category = traerCombox?.Select(p => p.Category).ToList();
                    comboBox1.DataSource = category;
                    comboBox1.SelectedItem = traer;

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
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var traer = await _httpClient.GetFromJsonAsync<ProductoDTO>($"api/Producto/products/{idUsuario}");

                if(traer != null)
                {
                    traer.Name = textBox1.Text;
                    traer.Descripcion = textBox2.Text;
                    traer.Ingredients = textBox2.Text;

                    traer.Category = comboBox1.SelectedItem?.ToString() ?? "";
                    traer.Price = (short)numericUpDown1.Value;
                    traer.Cost = (short)numericUpDown2.Value;
                    traer.Active = checkBox1.Checked;
                    traer.Seasonal = checkBox2.Checked;
                    traer.Date = DateOnly.FromDateTime(dateTimePicker1.Value);

                    var actualizar = await _httpClient.PutAsJsonAsync($"api/Producto/products/{idUsuario}", traer);

                    if (actualizar.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Fue exitoso la actualizacion de los datos");

                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
