
using Newtonsoft.Json;


using System;
using System.Collections.Generic;
using System.Net.Http;      
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace PRUEBA_API_RICKY
{
    public partial class Form1 : Form
    {
        // Creamos un HttpClient estático para reutilizar la conexión
        private static readonly HttpClient client = new HttpClient();

        
        public Form1()
        {
            InitializeComponent();

            // Conectamos el evento Load del formulario
            this.Load += Form1_Load;
        }

        
        private async void Form1_Load(object sender, EventArgs e)
        {
            // Llamamos al método que carga los personajes
            await CargarTodosLosPersonajes();
        }


        // Método asíncrono que consume la API
        private async Task CargarTodosLosPersonajes()
        {
            try
            {
                // URL de la API que vamos a consumir
                string url = "https://rickandmortyapi.com/api/character";

                // Hacemos la petición GET a la API
                HttpResponseMessage response = await client.GetAsync(url);

                // Si ocurre un error (ej: 404), lanza excepción
                response.EnsureSuccessStatusCode();

                // Leemos la respuesta en formato texto (JSON)
                string json = await response.Content.ReadAsStringAsync();

                // Convertimos el JSON en un objeto C#
                CharacterResponse data =
                    JsonConvert.DeserializeObject<CharacterResponse>(json);

                // Genera automáticamente las columnas del DataGridView
                dataGridView1.AutoGenerateColumns = true;

                // Asignamos la lista de personajes al DataGridView
                dataGridView1.DataSource = data.results;

                // Mostramos cuántos personajes se cargaron
                MessageBox.Show($"Se cargaron {data.results.Count} personajes");
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos en pantalla
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}