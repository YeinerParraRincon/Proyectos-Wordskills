using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=DataBase;integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if(textBox1.Enabled == true)
                {
                    conexion.Open();
                    string slq = "SELECT ID,Username,Password FROM Users WHERE Username = @a AND Password = @p";
                    SqlCommand cmd = new SqlCommand(slq,conexion);
                    cmd.Parameters.AddWithValue("@a", textBox1.Text);
                    cmd.Parameters.AddWithValue("@p", textBox3.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    int id = 0;
                    if(reader.Read())
                    {
                        MessageBox.Show("Fue exitoso,Bienvenido Empleado");
                        id = Convert.ToInt32(reader["ID"]);
                        if (checkBox1.Checked)
                        {
                            File.WriteAllText("sesion.txt", $"empleado|{id}");
                        }else if (File.Exists("sesion.txt"))
                        {
                            File.Delete("sesion.txt");
                        }
                        Form2 form2 = new Form2(id);
                        form2.Show();
                        this.Hide();
                    }
                    conexion.Close();
                }else if(textBox2.Enabled == true)
                {
                    conexion.Open();
                    string slq = "SELECT ID,Username,Password FROM Users WHERE Username = @a AND Password = @p";
                    SqlCommand cmd = new SqlCommand(slq, conexion);
                    cmd.Parameters.AddWithValue("@a", textBox2.Text);
                    cmd.Parameters.AddWithValue("@p", textBox3.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    int id = 0;
                    if (reader.Read())
                    {
                        MessageBox.Show("Fue exitoso,Bienvenido Usuario");
                        id = Convert.ToInt32(reader["ID"]);
                        if (checkBox1.Checked)
                        {
                            File.WriteAllText("sesion.txt", $"usuario|{id}");
                        }
                        else if (File.Exists("sesion.txt"))
                        {
                            File.Delete("sesion.txt");
                        }
                        Form2 form2 = new Form2(id);
                        form2.Show();
                        this.Hide();
                    }
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error por favor volver intentar");
                    return;
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                textBox2.Enabled = false;
            }else if(textBox1.Text.Length == 0)
            {
                textBox2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
                textBox1.Enabled = false;
            }else if(textBox2.Text.Length == 0)
            {
                textBox1.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }
    }
}
