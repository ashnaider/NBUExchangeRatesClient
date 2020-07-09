using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NbuClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbController dbc = new DbController();
            String pass = "!!!! YOUR PATH TO DB !!!!";
            dbc.Connect(pass);

            List<PublicOrganization> po = dbc.GetExchangers();
            int a;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
