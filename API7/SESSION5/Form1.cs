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
using DTO;

namespace SESSION5
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/")
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private async void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value);

                if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
                {
                    var eliminar = await _httpClient.DeleteAsync($"api/Producto/products/{id}");

                    if (eliminar.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Fue exitoso la Eliminacion");

                        var traerProducto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                        if (traerProducto != null && traerProducto.Count > 0)
                        {
                            dataGridView1.DataSource = traerProducto;
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "edit")
                {
                    Form2 form2 = new Form2(id);
                    form2.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var traerProducto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if (traerProducto != null && traerProducto.Count > 0)
                {
                    dataGridView1.DataSource = traerProducto;

                    if (dataGridView1.Columns["delete"] == null)
                    {
                        var nueva = new DataGridViewButtonColumn
                        {
                            Text = "Delete",
                            Name = "delete",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(nueva);
                    }
                    if (dataGridView1.Columns["edit"] == null)
                    {
                        var nueva = new DataGridViewButtonColumn
                        {
                            Text = "Edit Details",
                            Name = "edit",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(nueva);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var traerProductos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                var campo = textBox1.Text.ToLower();

                if (traerProductos != null)
                {
                    var filtrado = traerProductos.Where(P => P.Name.ToLower().Contains(campo)).ToList();

                    dataGridView1.DataSource = filtrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
