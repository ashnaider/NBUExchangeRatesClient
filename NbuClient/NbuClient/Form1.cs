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
        bool isNotLoaded = true;
        public Form1()
        {
            InitializeComponent();
            if (!Connect())
            {
                this.Close();
            }
            isNotLoaded = false;
        }

        String GetPass()
        {
            return "zw5&gc%3hi";
        }
        bool Connect()
        {
            dbc = new DbController();

            String pass = "!!!! YOUR PATH TO DB !!!!";

            pass = GetPass();

            bool isConnToDbSuccess, isConnToXmlSuccess;
            dbc.Connect(pass, out isConnToDbSuccess, out isConnToXmlSuccess);
            bool exit = false;
            if (!isConnToDbSuccess)
            {
                MessageBox.Show("Error! Can not connect to Database!\n" +
                    "Check your if db exist or your password is correct");
                exit = true;
            }
            if (!isConnToXmlSuccess)
            {
                String message = "Error! Can not connect to XML source server!\n" +
                    "Check your internet connection\n";
                exit = true;
                if (isConnToDbSuccess)
                {
                    message += " Program will load latest info from db";
                    exit = false;
                }
                MessageBox.Show(message);
            }

            if (exit)
            {
                return false;
            }

            UpdateAllFromDb();
            return true;
        }

        void UpdateAllFromDb()
        {
            UpdateDateFromDb();
            UpdateCurrenciesFromDb();
            UpdateRegionsFromDb(new List<Region>(0));
            UpdateCitiesFromDb();
            UpdateSortByComboBox();
            UpdateOrgTypeFromDb();
        }
        void UpdateDateFromDb()
        {
            this.LastDateLabel.Text = dbc.GetDate();
        }

        void UpdateSortByComboBox()
        {
            SortByComboBox.Text = "All";
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

        void UpdateRegionsFromDb(List<Region> regs)
        {
            RegionComboBox.Items.Clear();
            if (regs.Count() == 0)
            {
                regs = dbc.GetAllRegions();
            }

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
            if (dbc.Update())
            { 
                UpdateAllFromDb();
            }
            else
            {
                MessageBox.Show("Error! Can not connect to XML source server!\n" +
                                "Check your internet connection or try later");
            }
        }

        UsersInput GetUsersInput()
        {
            UsersInput res = new UsersInput();

            res.Currency = CurrencyComboBox.Text.Split(' ')[0];
            res.Region = RegionComboBox.Text;
            res.City = CityComboBox.Text;
            res.OrgType = OrgTypeComboBox.Text;
            res.SortBy = SortByComboBox.Text;
            

            return res;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            // GetInputValues();
            // TODO: update all other combo boxes
            if (isNotLoaded)
            {
                return;
            }

            UsersInput ui = GetUsersInput();

            List<PublicOrganization> po = dbc.GetOrganizationsFilteredByValues(ui);
            
            if (po.Count() == 1)
            {
                try
                {
                    int tmp = po[0].Title.Length;
                    // MessageBox.Show("in find button try " + tmp);
                }
                catch
                {
                    clearBanksListView();
                    MessageBox.Show("There no banks with this filters");
                    return;
                }
                
            }
            // MessageBox.Show("in find button " + po.Count());

            fillBanksListView(dbc.GenerateListViewData(po));

        }

        private void clearBanksListView()
        {
            BanksListView.Items.Clear();
            BanksListView.Columns.Clear();
        }

        private void fillBanksListView(List<string []> list)
        {
            clearBanksListView();

            BanksListView.View = View.Details;
            BanksListView.LabelEdit = false;
            BanksListView.FullRowSelect = true;
            BanksListView.GridLines = true;

            BanksListView.Columns.Add("Title");
            BanksListView.Columns.Add("OrgType");
            BanksListView.Columns.Add("City");

            foreach (var it in list)
            {
                String bank = "";
                foreach (String b in it)
                {
                    bank += b + " ";
                }
                // MessageBox.Show(bank);
                ListViewItem oneItem = new ListViewItem(it);
                BanksListView.Items.Add(oneItem);
            }
            BanksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            BanksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
