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
    public partial class Form2 : Form
    {
        private readonly HttpClient _httpClient;
        public Form2()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44373/")
            };
            this.Load += Form2_Load;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private async void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

           var idSelecionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "edit")
            {
                Form1 form1 = new Form1(idSelecionado);
                form1.Show();
                this.Hide();

            }else if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                try
                {
                    var productos = await _httpClient.DeleteAsync($"api/Producto/products/{idSelecionado}");

                    if (productos.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Producto Eliminado correctamente");

                        var ver = await _httpClient.GetFromJsonAsync<List<ProductsDTO>>("api/Producto/products");
                        dataGridView1.DataSource = ver;
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
        }

        private async void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<ProductsDTO>>("api/Producto/products");

                if (productos != null && productos.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = productos;

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

                    if (dataGridView1.Columns["delete"] == null)
                    {
                        var delete = new DataGridViewButtonColumn
                        {
                            Name = "delete",
                            Text = "Delete",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(delete);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron productos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consumir API: {ex.Message}");
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<ProductsDTO>>("api/Producto/products");

                var datoIngresado = textBox1.Text.ToLower();

                if (productos != null && productos.Count > 0)
                {
                    var productosFiltrado = productos.Where(p => p.Name.ToLower().Contains(datoIngresado)).ToList();

                    dataGridView1.DataSource = productosFiltrado;

                }
                else
                {
                    MessageBox.Show("No se encontraron productos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consumir API: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 fomr3 = new Form3();
            fomr3.Show();
            this.Hide();
        }
    }
}
