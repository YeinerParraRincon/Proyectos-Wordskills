using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PreeELiminar
{
    public partial class Form3 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=restaurante;integrated security = true");
        int id;
        string product;
        public Form3(int usuario,string plato)
        {
            InitializeComponent();
            id = usuario;
            product = plato;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conexion.Open();

            string sql = "SELECT r.id_recipes,d.id_dishes,r.descripcion FROM dishes as d " +
                "INNER JOIN recipes as r on r.id_dishes = d.id_dishes " +
                "WHERE r.id_dishes = @b";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@b", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               textBox1.Text = reader["descripcion"].ToString();
            }
            reader.Close();
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id,product);
            form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Te enceuntras en esta vista");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Estamos en progreso");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
