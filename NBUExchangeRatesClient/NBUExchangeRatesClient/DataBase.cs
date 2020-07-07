using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace NBUExchangeRatesClient
{
    struct OrgType
    {
        public int id;
        public String title;
    }

    struct CurrInfo
    {
        public String eng_id;
        public String title;
    }

    struct Region
    {
        public String region_id;
        public String title;
    }

    struct City
    {
        public String city_id;
        public String title;
    }

    struct Currency
    {
        public String eng_id;
        public double purchase;
        public double sell;
    }

    struct Organisation
    {
        public String org_id;
        public int org_type;
        public String title;
        public String region_id;
        public String city_id;
        public String phone;
        public String address;
        public List<Currency> currencies;
    }

    struct TotalInfo
    {
        public List<Organisation> organisations;
        public List<CurrInfo> currenciesInfo;
        public List<Region> regions;
        public List<City> cities;
    }

    class DataBase
    {

        bool isUpdateRequired = false;

        String connectionString;
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader rdr;

        List<String> tables = new List<string> { "org_type", "region", "city", "curr_info", "organisation", "currency" };

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

        public void CreateTables()
        {

            List<String> commands = new List<String>(0);

            commands.Add("CREATE TABLE org_type ( id SERIAL NOT NULL PRIMARY KEY, title VARCHAR(50) );");

            commands.Add("CREATE TABLE region ( id SERIAL NOT NULL PRIMARY KEY, title VARCHAR(100) );");

            commands.Add("CREATE TABLE city ( id SERIAL NOT NULL PRIMARY KEY, title VARCHAR(100) );");

            commands.Add("CREATE TABLE curr_info (" +
                "id SERIAL NOT NULL PRIMARY KEY," +
                "end_title VARCHAR(4)," +
                "rus_title VARCHAR(100) );");

            commands.Add("CREATE TABLE organisation (" +
                    "id SERIAL NOT NULL PRIMARY KEY," +
                    "org_type_id INTEGER REFERENCES org_type(id)," +
                    "title VARCHAR(100)," +
                    "phone VARCHAR(20)," +
                    "address VARCHAR(100)," +
                    "region_id INTEGER REFERENCES region(id)," +
                    "city_id INTEGER REFERENCES city(id) );");

            commands.Add("CREATE TABLE currency ( " +
                "id SERIAL NOT NULL PRIMARY KEY," +
                "purchase DOUBLE PRECISION," +
                "sell DOUBLE PRECISION, " +
                "org_id INTEGER REFERENCES organisation(id), " +
                "curr_info_id INTEGER REFERENCES curr_info(id) );");

            int tableNameId = 0;
            foreach (String command in commands)
            {
                cmd.CommandText = "DROP TABLE IF EXISTS " + tables[tableNameId++] + " CASCADE;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
        }

        public void FillOrgType()
        {
            // заглушка
            String tableName = "org_type";

            String command = "INSERT INTO " + tableName + " (id, title) VALUES (@id, @title);";

            cmd.Parameters.AddWithValue("1", "Банки");
            cmd.Parameters.AddWithValue("2", "Обменники");


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
