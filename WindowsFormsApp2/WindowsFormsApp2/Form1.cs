using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=.;database=FlightSerivce;integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            
            string sql = @"
                DECLARE @fechaBase DATE;
                SELECT @fechaBase = MAX(Date) FROM Schedules;
                
                SELECT
                ISNULL(SUM(CASE WHEN confirmed = 1 THEN 1 ELSE 0 END),0) AS confirmados,
                ISNULL(SUM(CASE WHEN confirmed = 0 THEN 1 ELSE 0 END),0) AS cancelado,
                ISNULL(AVG(DATEDIFF(MINUTE,'00:00:00',[Time])),0) AS promedio 
                FROM Schedules 
                WHERE Date BETWEEN DATEADD(DAY,-30,@fechaBase) AND @fechaBase ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                label6.Text = reader["confirmados"].ToString();
                label7.Text = reader["cancelado"].ToString();
                label8.Text = reader["promedio"].ToString() + "Minutes";
            }
            reader.Close();

            string sql2 = @"SELECT TOP 3
            u.Firstname,
            COUNT(t.ID) as TotalTikets 
            FROM Tickets as t 
            INNER JOIN Users as u ON u.ID = t.UserID 
            GROUP BY u.Firstname
            ORDER BY TotalTikets DESC; ";
            SqlCommand cmds = new SqlCommand(sql2,conexion);
            SqlDataReader readers = cmds.ExecuteReader();
            int i = 0;
            while( readers.Read())
            {
                string nombre = readers["FirstName"].ToString();
                string total = readers["TotalTikets"].ToString();

                switch (i)
                {
                    case 0:
                        label11.Text = $"{nombre} ({total})";
                        break;
                    case 1:
                        label10.Text = $"{nombre} ({total})";
                        break;
                    case 2:
                        label9.Text = $"{nombre} ({total})";
                        break;
                }
                i++;
            }
            readers.Close();
            conexion.Close();
        }
    }
}
