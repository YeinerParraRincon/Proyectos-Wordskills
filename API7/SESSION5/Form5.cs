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
    public partial class Form5 : Form
    {
        private readonly HttpClient _httpClient;
        int order;
        int costumers;
        public Form5(int idOrders, int idCostumetrs)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/")
            };
            order = idOrders;
            costumers = idCostumetrs;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                var traerOrders = await _httpClient.GetFromJsonAsync<OrdersDTO>($"api/Orders/orders/{order}");
                var traerCostumers = await _httpClient.GetFromJsonAsync<CostumersDTO>($"api/Costumers/costumers/{costumers}");

                if (traerOrders != null && traerCostumers != null)
                {
                    label6.Text = traerOrders.TransactionId.ToString();
                    label7.Text = traerCostumers.FirstName.ToString();
                    label8.Text = traerCostumers.JoinDate.ToString();
                    label9.Text = traerOrders.Total.ToString();
                    label10.Text = traerOrders.Status.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            var visible = !button3.Visible;
            button3.Visible = visible;
            button4.Visible = visible;
            button5.Visible = visible;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var traerOrders = await _httpClient.PutAsync($"api/Orders/orders/{order}/complete",null);

                if (traerOrders.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso");

                    var orders = await _httpClient.GetFromJsonAsync<OrdersDTO>($"api/Orders/orders/{order}");

                    if(orders != null)
                    {
                        label10.Text = orders.Status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta en Proceso");
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var traerCostumers = await _httpClient.PutAsync($"api/Orders/orders/{order}/cancel", null);

                if (traerCostumers.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fue exitoso");

                    var traer = await _httpClient.GetFromJsonAsync<OrdersDTO>($"api/Orders/orders/{order}");

                    if(traer != null)
                    {
                        label10.Text = traer.Status;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
