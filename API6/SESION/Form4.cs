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

namespace SESION
{
    public partial class Form4 : Form
    {
        private HttpClient _httpClient;
        public Form4()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private  void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TransactionId"].Value);
                var idC = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CustomerId"].Value);

                if (dataGridView1.Columns[e.ColumnIndex].Name == "view")
                {
                    Form5 form = new Form5(id,idC);
                    form.Show();
                    this.Hide();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<OrderseseDTO>>("api/Orders/orders");
                var costumers = await _httpClient.GetFromJsonAsync<List<CostumerseDTO>>("api/Costumerse/customers"); 
                if (productos != null && productos.Count > 0 && costumers != null)
                {
                    var especifico = from o in productos
                                     join c in costumers on o.CustomerId equals c.CustomerId
                                     select new 
                                     {
                                         o.TransactionId,
                                         o.CustomerId,
                                         Cliente = c.FirstName + "" + c.LastName,
                                         c.JoinDate,
                                         o.Total,
                                         o.Status
                                     };


                    dataGridView1.DataSource = especifico.ToList();
                    if (dataGridView1.Columns["view"] == null)
                    {
                        var ver = new DataGridViewButtonColumn
                        {
                            Name = "view",
                            Text = "View Details",
                            UseColumnTextForButtonValue = true,
                        };
                        dataGridView1.Columns.Add(ver);
                    }

                    if (dataGridView1.Columns["CustomerId"] != null)
                    {
                        dataGridView1.Columns["CustomerId"].Visible = false;
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
                var orders = await _httpClient.GetFromJsonAsync<List<OrderseseDTO>>("api/Orders/orders");
                var costumers = await _httpClient.GetFromJsonAsync<List<CostumerseDTO>>("api/Costumerse/customers");

                var campo = textBox1.Text.ToLower();

                if(orders != null &&  orders.Count > 0 && costumers != null)
                {
                    var lista = from o in orders
                                join c in costumers on o.CustomerId equals c.CustomerId
                                where c.FirstName.ToLower().Contains(campo) 
                                select new
                                {
                                    o.TransactionId,
                                    o.CustomerId,
                                    Cliente = c.FirstName + "" + c.LastName,
                                    c.JoinDate,
                                    o.Total,
                                    o.Status
                                };

                    dataGridView1.DataSource = lista.ToList();

                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
