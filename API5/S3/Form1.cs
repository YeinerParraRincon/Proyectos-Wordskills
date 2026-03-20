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
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44324/")
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private async void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) ;

            var idselecionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                try
                {
                    var eliminar = await _httpClient.DeleteAsync($"api/Producto/products/{idselecionado}");

                    if (eliminar.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Fue exitoso la eliminacion");

                        var productos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");
                        dataGridView1.DataSource = productos;
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "edit")
            {
                Form3 form3 = new Form3(idselecionado);
                form3.Show();
                this.Hide();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                if (products != null && products.Count > 0)
                {
                    dataGridView1.DataSource = products;
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

                if (products != null && products.Count > 0)
                {
                    dataGridView1.DataSource = products;
                    if (dataGridView1.Columns["edit"] == null)
                    {
                        var editar = new DataGridViewButtonColumn
                        {
                            Name = "edit",
                            Text = "Edit",
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

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

                var texbox = textBox1.Text.ToLower();

                if (products != null && products.Count > 0)
                {
                    var productoFiltrado = products.Where(p => p.Name.ToLower().Contains(texbox)).ToList();


                    dataGridView1.DataSource = productoFiltrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
