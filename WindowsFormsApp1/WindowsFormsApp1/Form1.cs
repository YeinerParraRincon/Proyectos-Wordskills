using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string estado = "";
        public Form1()
        {
            InitializeComponent();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 2;
            trackBar1.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            switch (trackBar1.Value)
            {
                case 0:
                    estado = "Feliz";
                break;

                    case 1:
                    estado = "Medio";
                    break;

                    case 2:
                    estado = "Triste";
                    break;
            }
            label1.Text = $"Animos : {estado}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = estado;
        }
    }
}
