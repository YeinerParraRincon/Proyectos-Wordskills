using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_Nacional
{
    public partial class Form3 : Form
    {
        int car;
        public Form3(int id)
        {
            InitializeComponent();
            car = id;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
