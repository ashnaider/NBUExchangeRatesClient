using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuClient
{

    class DbController
    {
        String path = @"..\..\nbu_source.xml";

        String dbName = "nbu_client";
        String dbPass;

        XmlParser xp;

        DataBase db;
        public DbController(String file = "none")
        {
            if (file != "none")
            {
                this.path = file;
            }
        }

        public bool Connect(String pass)
        {

            xp = new XmlParser(path);

            db = new DataBase();

            this.dbPass = pass;
            if (!db.ConnectToDb(dbName, dbPass))
            {
                return false;
            }


            if (xp.getFile())
            {
                TotalInfo ti = xp.ParseFile();

                db.CreateTables();
                db.FillTables(ti);
            }
            else
            {
                if (!db.CheckIfDbExist(dbName))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Update()
        {
            if (xp.getFile())
            {
                TotalInfo ti = xp.ParseFile();

                db.CreateTables();
                db.FillTables(ti);
            }
            else
            {
                if (!db.CheckIfDbExist(dbName))
                {
                    return false;
                }
            }
            return true;
        }

        public List<PublicOrganization> GetAllOrganizations()
        {
            return db.GetOrganizations();
        }

        public List<PublicOrganization> GetBanks()
        {
            return db.GetOrganizations(true, false);
        }

        public List<PublicOrganization> GetExchangers()
        {
            return db.GetOrganizations(false, true);

        }

        public List<CurrInfo> GetAllCurrenciesInfo()
        {
            return db.GetCurrInfo();
        }

        public List<Region> GetAllRegions()
        {
            return db.GetRegions();
        }

        public List<City> GetAllCities()
        {
            return db.GetCities();
        }

        public List<OrgType> GetOrgTypes()
        {
            return db.GetOrgTypes();
        }
    }

}
