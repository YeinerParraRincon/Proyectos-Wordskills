using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace preselecion
{
    public partial class Imagen : Form
    {

        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        int id;
        public Imagen(int anuncio)
        {
            InitializeComponent();
            id = anuncio;
        }

        private void Imagen_Load(object sender, EventArgs e)
        {
            conexion.Open();
            var lista = new List<(string categoria,string id)>();
            string sql = "SELECT   name,description FROM dishes WHERE id_dishes = @a";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@a", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                lista.Add((
                    reader["description"].ToString(),
                    reader["name"].ToString()
                    ));
            }
            foreach(var i in  lista)
            {
                textBox1.Text = i.categoria.ToString();
            }
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ver ver = new Ver(id);
            ver.Show();
            this.Hide();
        }
    }
}
