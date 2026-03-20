using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace prueba_api_1
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient cliente = new HttpClient();
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarTodoLosDatos();
        }

        private async Task CargarTodoLosDatos()
        {
            try
            {
                string url = "https://rickandmortyapi.com/api/character";
                HttpResponseMessage response = await cliente.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                CharacterResponse data = JsonConvert.DeserializeObject<CharacterResponse>(json);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = data.results;
                MessageBox.Show($"Se cargaron {data.results.Count} personajes");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }
    }
}
