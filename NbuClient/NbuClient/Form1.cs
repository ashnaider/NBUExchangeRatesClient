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

        bool allCurrs = true;

        List<PublicOrganization> currOrganizations;

        public Form1()
        {
            InitializeComponent();
            if (!Connect())
            {
                this.Close();
            }
            isNotLoaded = false;

            SortByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CurrencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OrgTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            SetValuesForComboBoxes(new UsersInput
            {
                FullCurrTitle = "All",
                City = "All",
                OrgType = "All",
                SortBy = "All"
            });

            GetDataAndFillBanksListView();
        }

        bool Connect()
        {
            dbc = new DbController();
            
            String pass = "!!!! YOUR PASS TO DB !!!!";


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
            SortByComboBox.Items.Clear();

            SortByComboBox.Items.Add("All");
            SortByComboBox.Items.Add("Min Purchase");
            SortByComboBox.Items.Add("Max Sale");
        }

        void UpdateCurrenciesFromDb()
        {
            CurrencyComboBox.Items.Clear();
            List<CurrInfo> currInfo = dbc.GetAllCurrenciesInfo();
            this.CurrencyComboBox.Items.Add("All");
            // this.CurrencyComboBox.Text = "All";

            foreach (CurrInfo ci in currInfo)
            {
                this.CurrencyComboBox.Items.Add(ci.eng_id + " " + ci.title);
            }
        }

        void UpdateCitiesFromDb()
        {
            CityComboBox.Items.Clear();
            List<City> cities = dbc.GetAllCities();
            this.CityComboBox.Items.Add("All");
            // this.CityComboBox.Text = "All";
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
            // OrgTypeComboBox.Text = "All";

            foreach (OrgType t in ot)
            {
                OrgTypeComboBox.Items.Add(t.title);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UsersInput ui = GetUsersInput();
            if (dbc.Update())
            { 
                UpdateAllFromDb();
                SetValuesForComboBoxes(ui);
                // MessageBox.Show("setted ui back");
                FindOrganizations();
            }
            else
            {
                MessageBox.Show("Error! Can not connect to XML source server!\n" +
                                "Check your internet connection or try later");
                SetValuesForComboBoxes(ui);
            }
        }

        private void SetValuesForComboBoxes(UsersInput ui)
        {
            UpdateSortByComboBox();
            
            CurrencyComboBox.Text = ui.FullCurrTitle;
            CityComboBox.Text = ui.City;
            OrgTypeComboBox.Text = ui.OrgType;
            SortByComboBox.Text = ui.SortBy;

            // MessageBox.Show(ui.SortBy);
        }

        UsersInput GetUsersInput()
        {
            UsersInput res = new UsersInput();

            res.Currency = CurrencyComboBox.Text.Split(' ')[0];
            res.FullCurrTitle = CurrencyComboBox.Text;
            res.City = CityComboBox.Text;
            res.OrgType = OrgTypeComboBox.Text;
            res.SortBy = SortByComboBox.Text;

            // MessageBox.Show(res.Currency + " " + res.City + " " + res.SortBy + " " + res.OrgType);
            

            return res;
        }

        private List<string[]> GenerateListViewData(List<PublicOrganization> source, bool withCurrs = false)
        {
            // TODO: make four digits after coma
            List<string[]> res = new List<string[]>();
            foreach (PublicOrganization po in source)
            {
                String purchase = String.Format("{0:0.0000}", po.PublicCurrencies[0].Purchase);
                String sale = String.Format("{0:0.0000}", po.PublicCurrencies[0].Sale);
                res.Add(new string[] { po.Title, po.orgType, po.City,
                po.PublicCurrencies[0].EngTitle, 
                purchase,
                sale });
            }
            return res;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindOrganizations();
        }

        private void FindOrganizations()
        {
            if (isNotLoaded)
            {
                return;
            }

            GetDataAndFillBanksListView();
            ClearCurrsListView();
        }

        private void GetDataAndFillBanksListView()
        {
            UsersInput ui = GetUsersInput();

            //List<PublicOrganization> po = dbc.GetOrganizationsFilteredByValues(ui);
            currOrganizations = dbc.GetOrganizationsFilteredByValues(ui);

            if (currOrganizations.Count() == 1)
            {
                try
                {
                    int tmp = currOrganizations[0].Title.Length;
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

            fillBanksListView(GenerateListViewData(currOrganizations));
        }

        private void clearBanksListView()
        {
            BanksListView.Items.Clear();
            BanksListView.Columns.Clear();
        }

        private void fillBanksListView(List<string[]> list)
        {
            clearBanksListView();

            BanksListView.View = View.Details;
            BanksListView.LabelEdit = false;
            BanksListView.FullRowSelect = true;
            BanksListView.GridLines = true;

            BanksListView.Columns.Add("Title");
            BanksListView.Columns.Add("OrgType");
            BanksListView.Columns.Add("City");

            if (!allCurrs)
            {
                BanksListView.Columns.Add("Currency");
                BanksListView.Columns.Add("Purchase");
                BanksListView.Columns.Add("Sale");

            }

            foreach (var row in list)
            {
                //String bank = "";
                //foreach (String b in it)
                //{
                //    bank += b + " ";
                //}
                // MessageBox.Show(bank);
                ListViewItem oneItem = new ListViewItem(row);
                BanksListView.Items.Add(oneItem);
            }
            BanksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            BanksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void CurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortByComboBox.Items.Remove("Min Purchase");
            SortByComboBox.Items.Remove("Max Sale");
            SortByComboBox.Text = "All";
            allCurrs = true;

            if (CurrencyComboBox.Text != "All")
            {
                SortByComboBox.Items.Add("Min Purchase");
                SortByComboBox.Items.Add("Max Sale");
                allCurrs = false;
            }
        }


        private void BanksListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // MessageBox.Show("poiupoiu");
            if (BanksListView.SelectedItems.Count > 0)
            {
                String orgName = BanksListView.SelectedItems[0].Text;
                // MessageBox.Show(orgName);
                ShowCurrentOrgCurrencies(orgName);
            }

        }
        
        List<string[]> GenerateCurrsData(List<PublicCurrency> currs)
        {
            List<string[]> res = new List<string[]>();
            foreach (PublicCurrency pc in currs)
            {
                String purchase = String.Format("{0:0.0000}", pc.Purchase);
                String sale = String.Format("{0:0.0000}", pc.Sale);
                res.Add(new string[]
                {
                    pc.EngTitle, 
                    purchase, 
                    sale
                }) ;
            }
            return res;
        }

        private void ClearCurrsListView()
        {
            CurrencyListView.Items.Clear();
            CurrencyListView.Columns.Clear();
        }

        private void ShowCurrentOrgCurrencies(String orgTitle)
        {
            ClearCurrsListView();

            CurrencyListView.View = View.Details;
            CurrencyListView.LabelEdit = false;
            CurrencyListView.FullRowSelect = true;
            CurrencyListView.GridLines = true;

            CurrencyListView.Columns.Add("Currency");
            CurrencyListView.Columns.Add("Purchase");
            CurrencyListView.Columns.Add("Sale");

            List<string[]> currs = new List<string[]>();
            if (currOrganizations.Count() > 0)
            {
                foreach (PublicOrganization po in currOrganizations)
                {
                    if (orgTitle == po.Title)
                    {
                        currs = GenerateCurrsData(po.PublicCurrencies);
                    }
                }
            }

            foreach (var row in currs)
            {
                ListViewItem item = new ListViewItem(row);
                CurrencyListView.Items.Add(item);
            }

            CurrencyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            CurrencyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void BanksListView_MouseUp(object sender, MouseEventArgs e)
        {
            bool match = false;
            int counter = -1;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (ListViewItem item in BanksListView.Items)
                {
                    ++counter;
                    if (item.Bounds.Contains(new Point(e.X, e.Y)))
                    {

                        match = true;
                        break;
                    }
                }
                if (match)
                { 
                    if (BanksListView.SelectedItems.Count > 0)
                    {
                        String orgName = "";
                        orgName += "Title:\t" + currOrganizations[counter].Title + "\n" +
                                   "Region:\t" + currOrganizations[counter].Region + "\n" +
                                   "City:\t" + currOrganizations[counter].City + "\n" +
                                   "Address:\t" + currOrganizations[counter].Address + "\n" +
                                   "OrgType:\t" + currOrganizations[counter].orgType + "\n" +
                                   "Phone:\t" + currOrganizations[counter].Phone ;
                        MessageBox.Show(orgName);
                    }
                }
            }
        }
    }
}


//  some code of feature

//private void UpdateComboBoxes(UsersInput ui)
//{
//    SortHeaders sh = dbc.GetNewSortHeaders(ui);
//    UpdateCurrenciesComboBox(sh.Currencies);
//    UpdateCitiesComboBox(sh.Cities);
//    UpdateOrgTypesComboBox(sh.OrgTypes);
//}

//private void UpdateCurrenciesComboBox(SortedSet<String> currs)
//{
//    CurrencyComboBox.Items.Clear();
//    CurrencyComboBox.Items.Add("All");
//    if (++counter <= 4)
//    {

//    CurrencyComboBox.Text = "All";
//    }

//    foreach (String curr in currs)
//    {
//        // MessageBox.Show(curr);
//        CurrencyComboBox.Items.Add(curr);
//    }
//}
//private void UpdateCitiesComboBox(SortedSet<String> cities)
//{
//    CityComboBox.Items.Clear();
//    CityComboBox.Items.Add("All");
//    if (++counter <= 4)
//    {
//    CityComboBox.Text = "All";

//    }

//    foreach (String city in cities)
//    {
//        // MessageBox.Show(city);

//        CityComboBox.Items.Add(city);
//    }
//}
//private void UpdateOrgTypesComboBox(SortedSet<String> orgTypes)
//{
//    OrgTypeComboBox.Items.Clear();
//    OrgTypeComboBox.Items.Add("All");

//    if (++counter <= 4)
//    {
//    OrgTypeComboBox.Text = "All";

//    }

//    foreach (String orgType in orgTypes)
//    {
//        // MessageBox.Show(orgType);

//        OrgTypeComboBox.Items.Add(orgType);
//    }
//}

//private void CurrencyComboBox_SelectionChangeCommitted(object sender, EventArgs e)
//{
//    if (isNotLoaded)
//    {
//        isNotLoaded = false;
//        return;
//    }
//    // UpdateComboBoxes(GetUsersInput());
//}

//private void CityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
//{
//    if (isNotLoaded)
//    {
//        isNotLoaded = false;
//        return;
//    }
//    // UpdateComboBoxes(GetUsersInput());
//}

//private void OrgTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
//{
//    if (isNotLoaded)
//    {
//        isNotLoaded = false;
//        return;
//    }
//    // UpdateComboBoxes(GetUsersInput());
//}