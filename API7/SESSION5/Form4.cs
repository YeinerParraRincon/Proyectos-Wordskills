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
    public partial class Form4 : Form
    {
        private readonly HttpClient _httpClient;
        public Form4()
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
            if (e.RowIndex < 0) return;

            var idOrders = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TransactionId"].Value);
            var idCostumetrs = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CustomerId"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "view")
            {
                Form5 form5 = new Form5(idOrders,idCostumetrs);
                form5.Show();
                this.Hide();
            }
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                var traerOrders = await _httpClient.GetFromJsonAsync<List<OrdersDTO>>("api/Orders/orders");
                var traerCostumers = await _httpClient.GetFromJsonAsync<List<CostumersDTO>>("api/Costumers/costumers");

                if (traerOrders != null && traerCostumers != null)
                {
                    var filtrado = from o in traerOrders
                                   join c in traerCostumers on o.CustomerId equals c.CustomerId
                                   select new
                                   {
                                       o.TransactionId,
                                       o.CustomerId,
                                       c.FirstName,
                                       c.JoinDate,
                                       o.Total,
                                       o.Status
                                   };

                    dataGridView1.DataSource = filtrado.ToList();
                    if (dataGridView1.Columns["CustomerId"] != null)
                    {
                        dataGridView1.Columns["CustomerId"].Visible = false;
                    }
                    if (dataGridView1.Columns["view"] == null)
                    {
                        var crear = new DataGridViewButtonColumn
                        {
                            Name = "view",
                            Text = "View Details",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridView1.Columns.Add(crear);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
