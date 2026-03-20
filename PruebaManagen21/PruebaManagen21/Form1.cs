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

namespace PruebaManagen21
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=usuario;integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string nombre = textBox1.Text.Trim();

            string insertar = "INSERT INTO usuario(nombre)values(@n)";
            SqlCommand cmd = new SqlCommand(insertar, conexion);
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fue exitoso el registro del usuario");
            conexion.Close();
        }
    }
}
