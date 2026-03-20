using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool sesion = false;

            if (File.Exists("sesion.txt"))
            {
                string[] data = File.ReadAllText("sesion.txt").Split('|');

                if(data.Length == 2)
                {
                    string rol = data[0];
                    int id = Convert.ToInt32(data[1]);

                    if(rol == "empleado")
                    {
                        Form2 form2 = new Form2(id);
                        Application.Run(form2);
                        sesion = true;
                    }else if(rol == "usuario")
                    {
                        Form2 form2 = new Form2(id);
                        Application.Run(form2);
                        sesion = true;
                    }

                }
            }else if (!sesion)
            {
                Application.Run(new Form1());
            }
        }
    }
}
