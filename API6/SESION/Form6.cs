using DTO;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Form6 : Form
    {
        private HttpClient _httpClient;
        public Form6()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44362/")
            };
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private async void CargarDatos()
        {
            try
            {
                var costumers = await _httpClient.GetFromJsonAsync<List<CostumerseDTO>>($"api/Costumerse/customers");

                if (costumers != null)
                {
                    IEnumerable<CostumerseDTO> ordenados;

                    if (checkBox1.Checked)
                    {
                        checkBox1.Text = "ascendente";
                        ordenados = costumers.OrderBy(p => p.CustomerId);
                    }
                    else
                    {
                        checkBox1.Text = "descendente";
                        ordenados = costumers.OrderByDescending(p => p.CustomerId);
                    }

                    var especifico = ordenados.Select(p => new
                    {
                        p.CustomerId,
                        p.FirstName,
                        p.LastName,
                        p.Email,
                        p.MembershipStatus,
                        p.TotalSpending
                    }).ToList();

                    dataGridView1.DataSource = especifico;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                var Costumers = await _httpClient.GetFromJsonAsync<List<CostumerseDTO>>($"api/Costumerse/customers");

                if (Costumers != null && Costumers.Count > 0)
                {

                    var especifico = Costumers.OrderByDescending(p => p.CustomerId).Select
                        (p => new
                        {
                            p.CustomerId,
                            p.FirstName,
                            p.LastName,
                            p.Email,
                            p.MembershipStatus,
                            p.TotalSpending
                        }).ToList();


                    dataGridView1.DataSource = especifico;
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
                var order = await _httpClient.GetFromJsonAsync<List<CostumerseDTO>>($"api/Costumerse/customers");
                var campo = textBox1.Text.ToLower();
                if (order != null)
                {
                    var filtrado = order.Where(p => p.Email.ToLower().Contains(campo) ||
                    p.FirstName.ToLower().Contains(campo)
                    ).OrderByDescending(p => p.CustomerId).Select(p => new
                    {
                        p.CustomerId,
                        p.FirstName,
                        p.LastName,
                        p.Email,
                        p.MembershipStatus,
                        p.TotalSpending
                    }).ToList();

                    dataGridView1.DataSource = filtrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
