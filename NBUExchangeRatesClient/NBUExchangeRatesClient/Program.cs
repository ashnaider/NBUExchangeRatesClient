using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBUExchangeRatesClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            String path = @"..\..\nbu_source.xml";
            XmlParser xmlParser = new XmlParser(path);

            xmlParser.getXMLSourseFile();

            xmlParser.ParseFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void testDb() 
        {
            DataBase db = new DataBase();
        }
    }
}
