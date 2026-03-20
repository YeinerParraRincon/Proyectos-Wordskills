using DTO;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:58211/")
            };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var traer = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/products");

            if(traer != null)
            {
                dataGridView1.DataSource = traer;
            }
        }
    }
}
