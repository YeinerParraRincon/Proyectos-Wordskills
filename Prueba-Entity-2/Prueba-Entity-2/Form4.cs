using Microsoft.EntityFrameworkCore;
using Prueba_Entity_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_2
{
    public partial class Form4 : Form
    {
        private readonly Sesion4Context db = new Sesion4Context();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Padding = new Padding(20);


            var cars = db.Notifications
                .OrderByDescending(c => c.CreatedAt)
                .ToList();


            foreach(var i in cars)
            {
                string tipo = "";
                var colortipo = Color.Black;
                var colorFondo = Color.White;

                if(i.NotificationTypeId == 1)
                {
                    tipo = "CAR UPDATE";
                    colortipo = Color.Orange;
                    colorFondo = Color.FromArgb(245, 248, 230);
                }else if(i.NotificationTypeId == 2)
                {
                    tipo = "CAR REMOVE";
                    colortipo = Color.Red;
                    colorFondo = Color.FromArgb(245, 235, 235);
                }

                var labelTipo = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Text = tipo,
                    ForeColor = colortipo
                };

                var labelDescripcion = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Text = i.Description,
                    Font = new Font("Segoe UI",10,FontStyle.Bold)
                };

                var labelFecha = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Text = i.CreatedAt.ToString("yyyy-MM-dd"),
                    Font = new Font("Segoe UI",9,FontStyle.Bold)
                };

                var panelPrincipal = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    RowCount = 2,
                    Width = 550,
                    Height = 100,
                    BackColor = colorFondo,
                    Margin = new Padding(15),
                    Padding = new Padding(15)
                };

                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,70));
                panelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,30));


                panelPrincipal.Controls.Add(labelTipo,0,0);
                panelPrincipal.Controls.Add(labelDescripcion,0,1);
                panelPrincipal.Controls.Add(labelFecha,1,0);

                flowLayoutPanel1.Controls.Add(panelPrincipal);
            }
        }
    }
}
