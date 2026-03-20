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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SESION
{
    public partial class Form5 : Form
    {
        private HttpClient _httpClient;
        int user;
        int c;
        public Form5(int id, int idC)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
            user = id;
            c = idC;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<OrderseseDTO>($"api/Orders/orders/{user}");
                var costumers = await _httpClient.GetFromJsonAsync<CostumerseDTO>($"api/Costumerse/customers/{c}");
                if (orders != null && costumers != null)
                {
                    label7.Text = orders.TransactionId.ToString();
                    label8.Text = costumers.FirstName + " " + costumers.LastName;
                    label9.Text = costumers.JoinDate.ToString();
                    label10.Text = orders.Total.ToString();
                    label11.Text = orders.Status.ToString();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            bool visible = !button3.Visible;

            button3.Visible = visible;
            button4.Visible = visible;
            button5.Visible = visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Esta En Proceso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var completar = await _httpClient.PutAsync($"api/Orders/orders/{user}/complete", null);

                if (completar.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ordern Cambiada Correctamente");

                    var refrescar = await _httpClient.GetFromJsonAsync<OrderseseDTO>($"api/Orders/orders/{user}");

                    if (refrescar != null)
                    {
                        label11.Text = refrescar.Status;
                    }
                }
                else
                {
                    MessageBox.Show("Error al completar: " + completar.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var cancelar = await _httpClient.PutAsync($"api/Orders/orders/{user}/cancel", null);

                if(cancelar.IsSuccessStatusCode)
                {
                    MessageBox.Show("Orden Cambiada Correctamente");

                    var refrescar = await _httpClient.GetFromJsonAsync<OrderseseDTO>($"api/Orders/orders/{user}");

                    if(refrescar != null)
                    {
                        label11.Text = refrescar.Status;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
