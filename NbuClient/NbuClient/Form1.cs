using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NbuClient
{
    public partial class Form1 : Form
    {
        DbController dbc;

        public Form1()
        {
            dbc = new DbController();

            String pass = "!!!! YOUR PATH TO DB !!!!";

            pass = "zw5&gc%3hi";

            dbc.Connect(pass);


            InitializeComponent();

            UpdateAllFromDb();
        }

        void UpdateAllFromDb()
        {
            UpdateDateFromDb();
            UpdateCurrenciesFromDb();
            UpdateRegionsFromDb();
            UpdateCitiesFromDb();
            UpdateOrgTypeFromDb();
        }
        void UpdateDateFromDb()
        {
            this.LastDateLabel.Text = dbc.GetDate();
        }

        void UpdateCurrenciesFromDb()
        {
            CurrencyComboBox.Items.Clear();
            List<CurrInfo> currInfo = dbc.GetAllCurrenciesInfo();
            this.CurrencyComboBox.Items.Add("All");
            this.CurrencyComboBox.Text = "All";

            foreach (CurrInfo ci in currInfo)
            {
                this.CurrencyComboBox.Items.Add(ci.eng_id + " " + ci.title);
            }
        }

        void UpdateRegionsFromDb()
        {
            RegionComboBox.Items.Clear();
            List<Region> regs = dbc.GetAllRegions();
            this.RegionComboBox.Items.Add("All");
            this.RegionComboBox.Text = "All";

            foreach (Region r in regs)
            {
                this.RegionComboBox.Items.Add(r.title);
            }
        }

        void UpdateCitiesFromDb()
        {
            CityComboBox.Items.Clear();
            List<City> cities = dbc.GetAllCities();
            this.CityComboBox.Items.Add("All");
            this.CityComboBox.Text = "All";
            foreach (City c in cities)
            {
                this.CityComboBox.Items.Add(c.title);
            }
        }

        void UpdateOrgTypeFromDb()
        {
            OrgTypeComboBox.Items.Clear();
            List<OrgType> ot = dbc.GetOrgTypes();
            OrgTypeComboBox.Items.Add("All");
            OrgTypeComboBox.Text = "All";

            foreach (OrgType t in ot)
            {
                OrgTypeComboBox.Items.Add(t.title);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            dbc.Update();
            UpdateAllFromDb();
        }

        List<String> GetInputValues()
        {
            List<String> res = new List<String>(0);
            res.Add(CurrencyComboBox.Text.Split(' ')[0]);

            res.Add(RegionComboBox.Text);
            res.Add(CityComboBox.Text);
            res.Add(SortByComboBox.Text);
            res.Add(OrgTypeComboBox.Text);
            
            String values = "";
            foreach (String t in res)
            {
                values += t + "\n";
            }
            MessageBox.Show(values);

            return res;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            GetInputValues();
        }
    }
}
