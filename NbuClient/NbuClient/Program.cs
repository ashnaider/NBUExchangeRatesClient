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

            pass = "zw5&gc%3hi";

            dbc.Connect(pass);

            List<PublicOrganization> po = dbc.GetExchangers();

            dbc.Update();

            List<CurrInfo> ci = dbc.GetAllCurrenciesInfo();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
