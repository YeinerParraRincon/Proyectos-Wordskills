using Microsoft.EntityFrameworkCore;
using Prueba_Entity_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_1
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

            var notificacion = db.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            foreach(var i in  notificacion)
            {
                string tipo = "";
                Color colortipo = Color.Black;
                Color colorFondo = Color.White;


                if(i.NotificationTypeId == 1)
                {
                    tipo = "CAR UPDATE";
                    colortipo = Color.Orange;
                    colorFondo = Color.FromArgb(255, 248, 230);
                }else if(i.NotificationTypeId == 2)
                {
                    tipo = "CAR REMOVED";
                    colortipo = Color.Red;
                    colorFondo = Color.FromArgb(255, 235, 235);
                }

                var labelTipo = new Label
                {
                    Text = tipo,
                    ForeColor = colortipo,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                };

                var labelDescripcion = new Label
                {
                    Text = i.Description,
                    Font = new Font("Segoe UI",10, FontStyle.Bold),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                var labelFecha = new Label
                {
                    Text = i.CreatedAt.ToString("yyyy-MM-dd"),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Font = new Font("Segoe UI",9, FontStyle.Bold)
                };

                var panelTotal = new TableLayoutPanel
                {
                    Width = 600,
                    Height = 100,
                    BackColor = colorFondo,
                    Padding = new Padding(15),
                    Margin = new Padding(15),
                    ColumnCount = 2,
                    RowCount = 2
                };

                panelTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                panelTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

                panelTotal.Controls.Add(labelTipo,0,0);
                panelTotal.Controls.Add(labelDescripcion,0,1);
                panelTotal.Controls.Add(labelFecha,1,0);

                flowLayoutPanel1.Controls.Add(panelTotal);
            }
        }
    }
}
