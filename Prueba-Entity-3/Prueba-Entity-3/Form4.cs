using Prueba_Entity_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Entity_3
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

            var notifi = db.Notifications
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            foreach(var i in  notifi)
            {
                var tipo = "";
                var colortipo = Color.Black;
                var colorfondo = Color.White;

                if(i.NotificationTypeId == 1)
                {
                    tipo = "CAR UPDATE";
                    colortipo = Color.Orange;
                    colorfondo = Color.FromArgb(245, 248, 230);
                }else if( i.NotificationTypeId == 2)
                {
                    tipo = "CAR REMOVED";
                    colortipo = Color.Red;
                    colorfondo = Color.FromArgb(245, 235, 235);
                }

                var labelTipo = new Label
                {
                    Text = tipo,
                    ForeColor = colortipo,
                    Font = new Font("Segoe UI",12,FontStyle.Bold),
                    AutoSize = true,
                };

                var labelDescripcion = new Label
                {
                    Text = i.Description,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true
                };

                var labelFecha = new Label
                {
                    Text = i.CreatedAt.ToString("yyyy-MM-dd"),
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize =true
                };


                var labelPrincipal = new TableLayoutPanel
                {
                    BackColor = colorfondo,
                    Width = 550,
                    Height = 150,
                    ColumnCount = 2,
                    RowCount = 2,
                    Margin = new Padding(5),
                    Padding = new Padding(5),
                };

                labelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,70));
                labelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,30));

                labelPrincipal.Controls.Add(labelTipo,0,0);
                labelPrincipal.Controls.Add(labelDescripcion,0,1);
                labelPrincipal.Controls.Add(labelFecha,1,0);

                flowLayoutPanel1.Controls.Add(labelPrincipal);
            }
        }
    }
}
