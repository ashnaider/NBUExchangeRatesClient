using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace NbuClient
{

    struct PublicOrganization
    {
        public String orgType;
        public String Title;
        public String Region;
        public String City;
        public String Phone;
        public String Address;
        public List<PublicCurrency> PublicCurrencies;
    }

    struct PublicCurrency
    {
        public String EngTitle;
        public String FullRusTitle;
        public double Purchase;
        public double Sale;
    }



    class DataBase
    {

        bool isUpdateRequired = false;

        String connectionString;
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader rdr;

        List<String> tables = new List<string> { "org_type", "region", "city", "curr_info", "organization", "currency", "date" };

        String CurrDbName;

        public bool CheckIfDbExist(String dbName)
        {
            String checkDbStr = "SELECT datname FROM pg_catalog.pg_database WHERE lower(datname) = lower(@dbname);";

            cmd.CommandText = checkDbStr;
            cmd.Parameters.AddWithValue("dbname", dbName);
            cmd.Prepare();


            rdr = cmd.ExecuteReader();

            String foundDbName;
            while (rdr.Read())
            {
                foundDbName = rdr.GetString(0);
                Console.WriteLine(foundDbName);
                if (foundDbName == dbName)
                {
                    Console.WriteLine("Database {0} is exist!", dbName);
                    rdr.Close();
                    return true;
                }
            }

            Console.WriteLine("Database {0} does not exist!", dbName);
            rdr.Close();
            return false;
        }

        public bool ConnectToDb(String DbName, String Password)
        {
            connectionString = "Host=localhost;Username=postgres;Password=" + Password
                + ";Database=" + DbName + ";";

            CurrDbName = DbName;

            try
            {
                conn = new NpgsqlConnection(connectionString);
                conn.Open();
            }
            catch
            {
                return false;
            }

            cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            return true;
        }

        public String GetDate()
        {
            String command = "SELECT date from date;";
            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return rdr.GetString(0);
            }
            return "";
        }

        public List<OrgType> GetOrgTypes()
        {
            String command = "SELECT * FROM org_type;";

            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            List<OrgType> res = new List<OrgType>(0);
            while (rdr.Read())
            {
                OrgType tmp = new OrgType();

                tmp.id = rdr.GetInt16(1);
                tmp.title = rdr.GetString(2);

                res.Add(tmp);
            }
            rdr.Close();
            return res;
        }

        public List<Region> GetRegions()
        {
            String command = "SELECT region_id, title FROM region;";
            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            List<Region> res = new List<Region>(0);
            while (rdr.Read())
            {
                Region tmp = new Region();
                tmp.region_id = rdr.GetString(0);
                tmp.title = rdr.GetString(1);

                res.Add(tmp);
            }
            rdr.Close();
            return res;
        }

        public List<City> GetCities()
        {
            String command = "SELECT city_id, title FROM city;";
            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            List<City> res = new List<City>(0);
            while (rdr.Read())
            {
                City tmp = new City();
                tmp.city_id = rdr.GetString(0);
                tmp.title = rdr.GetString(1);

                res.Add(tmp);
            }
            rdr.Close();
            return res;
        }

        public List<CurrInfo> GetCurrInfo()
        {
            String command = "SELECT eng_title, rus_title FROM curr_info;";
            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            List<CurrInfo> res = new List<CurrInfo>(0);
            while (rdr.Read())
            {
                CurrInfo tmp = new CurrInfo();
                tmp.eng_id = rdr.GetString(0);
                tmp.title = rdr.GetString(1);

                res.Add(tmp);
            }

            rdr.Close();
            return res;
        }

        public List<PublicOrganization> GetOrganizations(bool Banks = true, bool Exchangers = true)
        {
            String command = "select * from organization " +
                "inner join org_type on org_type.org_type_id = organization.org_type_id " +
                "inner join region on region.region_id = organization.region_id " +
                "inner join city on city.city_id = organization.city_id " +
                "inner join currency on currency.org_id = organization.id " +
                "inner join curr_info on curr_info.eng_title = currency.curr_id " +
                "order by organization.id;";

            cmd.CommandText = command;
            rdr = cmd.ExecuteReader();

            int counter = 0;
            List<PublicOrganization> res = new List<PublicOrganization>(0);

            List<PublicCurrency> publicCurrList = new List<PublicCurrency>(0);

            bool isFirst = true;

            int id = -1; // 1

            PublicOrganization publicOrgTmp = new PublicOrganization();

            PublicCurrency publicCurrTmp = new PublicCurrency();

            while (rdr.Read())
            {
                if ((!Banks && rdr.GetString(9) == "Банки") || (!Exchangers && rdr.GetString(9) == "Обменники"))
                {
                    continue;
                }
                ++counter;
                int new_id = rdr.GetInt32(0);

                if (isFirst)
                {
                    id = new_id;
                    isFirst = false;
                }

                if (new_id != id)
                {
                    id = new_id;
                    publicOrgTmp.PublicCurrencies = publicCurrList;

                    res.Add(publicOrgTmp);
                    publicCurrList = new List<PublicCurrency>(0);

                }

                publicOrgTmp = new PublicOrganization();

                publicOrgTmp.Title = rdr.GetString(2);
                publicOrgTmp.Phone = rdr.GetString(3);
                publicOrgTmp.Address = rdr.GetString(4);
                publicOrgTmp.orgType = rdr.GetInt32(8).ToString();

                publicOrgTmp.Region = rdr.GetString(12);
                publicOrgTmp.City = rdr.GetString(15);


                publicCurrTmp = new PublicCurrency();
                publicCurrTmp.EngTitle = rdr.GetString(23);
                publicCurrTmp.FullRusTitle = rdr.GetString(24);
                publicCurrTmp.Purchase = rdr.GetDouble(18);
                publicCurrTmp.Sale = rdr.GetDouble(19);

                publicCurrList.Add(publicCurrTmp);


                // res.Add(publicOrgTmp);
            }

            publicOrgTmp.PublicCurrencies = publicCurrList;
            res.Add(publicOrgTmp);

            rdr.Close();

            return res;
        }


        public void FillTables(TotalInfo totalInfo)
        {
            // fill date
            this.InsertIntoWithValues("date",
                new List<String> { "date" },
                new List<String> { totalInfo.Date });

            // fill org_type
            foreach (OrgType ot in totalInfo.orgTypes)
            {
                this.InsertIntoWithValues("org_type",
                    new List<String> { "org_type_id", "title" },
                    new List<String> { ot.id.ToString(), ot.title });
            }

            // fill region
            foreach (Region r in totalInfo.regions)
            {
                this.InsertIntoWithValues("region",
                    new List<String> { "region_id, title" },
                    new List<String> { r.region_id, r.title });
            }

            // fill city
            foreach (City c in totalInfo.cities)
            {
                this.InsertIntoWithValues("city",
                    new List<String> { "city_id", "title" },
                    new List<string> { c.city_id, c.title });
            }

            // fill curr_info
            foreach (CurrInfo ci in totalInfo.currenciesInfo)
            {
                this.InsertIntoWithValues("curr_info",
                    new List<String> { "eng_title", "rus_title" },
                    new List<String> { ci.eng_id, ci.title });
            }

            // fill organization 

            foreach (Organisation org in totalInfo.organisations)
            {
                int org_id = this.InsertIntoWithValues("organization",
                    new List<String> { "org_type_id",
                                       "title",
                                       "phone",
                                       "address",
                                       "region_id",
                                       "city_id",
                                       },

                    new List<String> { org.org_type.ToString(),
                                       org.title,
                                       org.phone,
                                       org.address,
                                       org.region_id,
                                       org.city_id,
                                        });

                Console.WriteLine("ID - " + org_id);

                foreach (Currency curr in org.currencies)
                {
                    int curr_id = this.InsertIntoWithValues("currency",
                        new List<String> { "curr_id",
                                           "purchase",
                                           "sale" },
                        new List<string> { curr.eng_id,
                                           curr.purchase,
                                           curr.sale });

                    String update = "UPDATE currency SET org_id = " + org_id + " WHERE id = " + curr_id + ";";

                    Console.WriteLine(update);

                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public int InsertIntoWithValues(String table, List<String> titles, List<String> values)
        {
            String command = "INSERT INTO " + table + " " +
                GenerateListWithSeparator(titles) +
                " values " +
                GenerateListWithSeparator(values, true) + " RETURNING id;";

            cmd.CommandText = command;

            Console.WriteLine(command);

            int res = 0;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                res = rdr.GetInt16(0);
            }
            rdr.Close();
            return res;
        }

        public static String GenerateListWithSeparator(List<String> l, bool withQuotes = false, char sep = ',')
        {

            String res = "(";
            foreach (String s in l)
            {
                if (withQuotes)
                {
                    res += "'" + s + "'";
                }
                else
                {
                    res += s;
                }
                res += sep + " ";
            }
            res = res.Remove(res.Length - 2, 2);
            res += ")";
            return res;
        }


        public void CreateTables()
        {

            List<String> commands = new List<String>(0);

            commands.Add("CREATE TABLE org_type ( id SERIAL NOT NULL PRIMARY KEY, org_type_id INTEGER, title VARCHAR(50) );");

            commands.Add("CREATE TABLE region ( " +
                "id SERIAL NOT NULL PRIMARY KEY, " +
                "region_id VARCHAR(100), " +
                "title VARCHAR(100) );");

            commands.Add("CREATE TABLE city ( " +
                "id SERIAL NOT NULL PRIMARY KEY, " +
                "city_id VARCHAR(100), " +
                "title VARCHAR(100) );");

            commands.Add("CREATE TABLE curr_info (" +
                "id SERIAL NOT NULL PRIMARY KEY," +
                "eng_title VARCHAR(4)," +
                "rus_title VARCHAR(100) );");

            commands.Add("CREATE TABLE organization (" +
                    "id SERIAL NOT NULL PRIMARY KEY," +
                    "org_type_id INTEGER, " +// REFERENCES org_type(id)," +
                    "title VARCHAR(100)," +
                    "phone VARCHAR(20)," +
                    "address VARCHAR(100)," +
                    "region_id VARCHAR(100)," +
                    "city_id VARCHAR(100) );");

            commands.Add("CREATE TABLE currency ( " +
                "id SERIAL NOT NULL PRIMARY KEY," +
                "curr_id VARCHAR(4), " +
                "purchase DOUBLE PRECISION," +
                "sale DOUBLE PRECISION, " +
                "org_id INTEGER, " +
                "curr_info_id INTEGER REFERENCES curr_info(id) );");

            commands.Add("CREATE TABLE date ( " +
                "id SERIAL NOT NULL PRIMARY KEY, " +
                "date VARCHAR(50) );");

            int tableNameId = 0;
            foreach (String command in commands)
            {
                cmd.CommandText = "DROP TABLE IF EXISTS " + tables[tableNameId++] + " CASCADE;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckIfTableExist(String tableName)
        {
            String findTableCommand = "SELECT to_regclass('" + tableName + "')";
            cmd.CommandText = findTableCommand;
            rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                try
                {
                    if (rdr.GetString(0) == tableName)
                    {
                        rdr.Close();
                        return true;
                    }
                }
                catch
                {
                    rdr.Close();
                    return false;
                }
            }
            rdr.Close();
            return false;
        }

        String GetCurrDbName()
        {
            String getCurrDbNameStr = "SELECT current_database();";
            cmd.CommandText = getCurrDbNameStr;
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            String result = "null";
            while (rdr.Read())
            {

                result = rdr.GetString(0);
            }
            rdr.Close();
            return result;
        }

    }


}