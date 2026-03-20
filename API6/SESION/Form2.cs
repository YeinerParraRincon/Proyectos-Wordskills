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

namespace SESION
{
    public partial class Form2 : Form
    {
        private HttpClient _httpClient;
        public Form2()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private async void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "editar")
            {
                Form3 form3 = new Form3(id);
                form3.Show();
                this.Hide();
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                var eliminarProducto = await _httpClient.DeleteAsync($"api/Producto/products/{id}");
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if (eliminarProducto.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso la eliminacion del producto");

                    dataGridView1.DataSource = producto;
                }
            }
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if (producto != null && producto.Count > 0)
                {
                    dataGridView1.DataSource = producto;
                    if (dataGridView1.Columns["editar"] == null)
                    {
                        var editar = new DataGridViewButtonColumn
                        {
                            Name = "editar",
                            Text = "Edit",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(editar);
                    }

                    if (dataGridView1.Columns["delete"] == null)
                    {
                        var editar = new DataGridViewButtonColumn
                        {
                            Name = "delete",
                            Text = "Delete",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(editar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                var productoIngresado = textBox1.Text.ToLower();
                if(producto != null && producto.Count > 0)
                {
                    var final = producto.Where(p => p.Name.ToLower().Contains(productoIngresado)).ToList();

                    dataGridView1.DataSource=final;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
