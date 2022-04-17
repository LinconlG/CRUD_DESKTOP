using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControladorGRD.Forms;

namespace ControladorGRD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string user;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin active = new FormLogin();
            Application.Run(active);
            user = active.User();
            if (active.pass == true)
            {
                Application.Run(new Form1(active));
            }
            
        }
    }
}
