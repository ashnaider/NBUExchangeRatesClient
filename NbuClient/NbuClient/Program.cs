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
            ParserAndDbApiExample();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void ParserAndDbApiExample()
        {
            String path = @"..\..\nbu_source.xml";

            XmlParser xp = new XmlParser(path);


            DataBase db = new DataBase();
            String dbName = "nbu_client";
            String dbPass = " --- YOUR LOCAL POSTGRESQL DATABASE PASSWORD ----";


            if (db.ConnectToDb(dbName, dbPass))
            {
                // Debug.WriteLine("connected");

            }
            else
            {
                // Debug.WriteLine("error with database");
                return;
            }


            if (xp.getFile())
            {
                TotalInfo ti = xp.ParseFile();

                db.CreateTables();
                db.FillTables(ti);
            }


            // printCurrInfo(ti.currenciesInfo);

            //printOrgTypes(db.GetOrgTypes());

            //printRegions(db.GetRegions());

            //printCities(db.GetCities());

            //printCurrInfo(db.GetCurrInfo());

            //printOrganizations(db.GetOrganizations());
        }

        static void printOrgTypes(List<OrgType> l)
        {
            Console.WriteLine("\n\nOrg types:");
            foreach (OrgType ot in l)
            {
                Console.WriteLine(ot.id + " " + ot.title);
            }
        }

        static void printRegions(List<Region> l)
        {
            Console.WriteLine("\n\nRegions:");
            foreach (Region r in l)
            {
                Console.WriteLine(r.region_id + " " + r.title);
            }
        }

        static void printCities(List<City> l)
        {
            Console.WriteLine("\n\nCities:");
            foreach (City c in l)
            {
                Console.WriteLine(c.city_id + " " + c.title);
            }
        }

        static void printCurrInfo(List<CurrInfo> l)
        {
            Console.WriteLine("\n\nCurrencies info:");
            foreach (CurrInfo c in l)
            {
                Console.WriteLine(c.eng_id + " " + c.title);
            }
        }

        static void printOrganizations(List<PublicOrganization> l)
        {
            Console.WriteLine("\n\nOrganizations: ");
            int i = 0;
            foreach (PublicOrganization org in l)
            {
                Console.WriteLine(++i + ") " + org.Title + " " + org.orgType + " " +
                    org.Region + " " + org.City + " " +
                    org.Address);

                foreach (PublicCurrency pc in org.PublicCurrencies)
                {
                    Console.WriteLine("\t" + pc.EngTitle + " " + pc.Purchase + " " + pc.Sale + " " + pc.FullRusTitle);
                }
            }
            Console.WriteLine();
        }
    }
}
