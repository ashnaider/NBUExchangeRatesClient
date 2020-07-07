using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Net;

namespace NBUExchangeRatesClient
{

    class XmlParser
    {
        String filePath;
        public XmlParser(String filePath)
        {
            this.filePath = filePath;
        }

        public const String linkToXML = "http://resources.finance.ua/ru/public/currency-cash.xml";
        public void getXMLSourseFile()
        {

            WebClient webClient = new WebClient();

            webClient.DownloadFile(linkToXML, filePath);
        }

        public TotalInfo ParseFile()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);

            TotalInfo totalInfo = new TotalInfo();

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                // go through organosations
                if (xnode.Name == "organizations")
                {
                    List<Organisation> orgList = new List<Organisation>(0);

                    foreach (XmlNode organisation in xnode)
                    {
                        Organisation org = new Organisation();

                        XmlNode org_id = organisation.Attributes.GetNamedItem("id");
                        XmlNode org_type = organisation.Attributes.GetNamedItem("org_type");

                        XmlNode title = organisation["title"].Attributes.GetNamedItem("value");
                        XmlNode region_id = organisation["region"].Attributes.GetNamedItem("id");
                        XmlNode city_id = organisation["city"].Attributes.GetNamedItem("id");
                        XmlNode phone = organisation["phone"].Attributes.GetNamedItem("value");
                        XmlNode address = organisation["address"].Attributes.GetNamedItem("value");


                        if (org_id != null && org_type != null && title != null
                            && region_id != null && city_id != null && phone != null && address != null)
                        {
                            org.org_id = org_id.Value;
                            org.org_type = int.Parse(org_type.Value);
                            org.title = title.Value;
                            org.region_id = region_id.Value;
                            org.city_id = region_id.Value;
                            org.phone = phone.Value;
                            org.address = address.Value;
                        }

                        List<Currency> currList = new List<Currency>(0);

                        foreach (XmlNode currencies in organisation)
                        {
                            if (currencies.Name == "currencies")
                            {
                                Currency curr = new Currency();
                                foreach (XmlNode c in currencies)
                                {
                                    XmlNode eng_id = c.Attributes.GetNamedItem("id");
                                    XmlNode purchase = c.Attributes.GetNamedItem("br");
                                    XmlNode sale = c.Attributes.GetNamedItem("ar");

                                    if (eng_id != null &&
                                        purchase != null &&
                                        sale != null)
                                    {
                                        curr.eng_id = eng_id.Value;
                                        curr.purchase = Convert.ToDouble(purchase.Value.Replace('.', ','));
                                        curr.sale = Convert.ToDouble(sale.Value.Replace('.', ','));

                                        Console.WriteLine(c.Name + " " + eng_id.Value + " " +
                                            purchase.Value + " " + sale.Value);
                                    }
                                    currList.Add(curr);
                                }
                                Console.WriteLine(currencies.Name + " here!!!\n");
                            }
                        }

                        org.currencies = currList;
                        orgList.Add(org);
                    }
                    totalInfo.organisations = orgList;
                }

                if (xnode.Name == "org_types")
                {
                    Console.WriteLine();

                    List<OrgType> orgTypeList = new List<OrgType>(0);

                    foreach (XmlNode orgType in xnode)
                    {
                        OrgType orgTypeStruct = new OrgType();

                        XmlNode id = orgType.Attributes.GetNamedItem("id");
                        XmlNode title = orgType.Attributes.GetNamedItem("title");

                        if (id != null && title != null)
                        {
                            orgTypeStruct.id = int.Parse(id.Value);
                            orgTypeStruct.title = title.Value;
                        }

                        orgTypeList.Add(orgTypeStruct);
                        Console.WriteLine(id.Value + " " + title.Value);
                    }

                    totalInfo.orgTypes = orgTypeList;
                }

                if (xnode.Name == "currencies")
                {
                    Console.WriteLine();

                    List<CurrInfo> currInfoList = new List<CurrInfo>(0);

                    foreach (XmlNode curr in xnode)
                    {
                        CurrInfo currInfo = new CurrInfo();

                        XmlNode eng_id = curr.Attributes.GetNamedItem("id");
                        XmlNode title = curr.Attributes.GetNamedItem("title");

                        if (eng_id != null && title != null)
                        {
                            currInfo.eng_id = eng_id.Value;
                            currInfo.title = title.Value;
                        }

                        currInfoList.Add(currInfo);

                        Console.WriteLine(eng_id.Value + " " + title.Value);
                    }

                    totalInfo.currenciesInfo = currInfoList;
                }

                if (xnode.Name == "regions")
                {
                    Console.WriteLine();

                    List<Region> regList = new List<Region>(0);

                    foreach (XmlNode reg in xnode)
                    {
                        Region regStruct = new Region();

                        XmlNode region_id = reg.Attributes.GetNamedItem("id");
                        XmlNode title = reg.Attributes.GetNamedItem("title");

                        if (region_id != null && title != null)
                        {
                            regStruct.region_id = region_id.Value;
                            regStruct.title = title.Value;
                        }

                        regList.Add(regStruct);

                        Console.WriteLine(region_id.Value + " " + title.Value);
                    }

                    totalInfo.regions = regList;
                }

                if (xnode.Name == "cities")
                {
                    Console.WriteLine();

                    List<City> cityList = new List<City>(0);

                    foreach (XmlNode city in xnode)
                    {
                        City cityStruct = new City();

                        XmlNode city_id = city.Attributes.GetNamedItem("id");
                        XmlNode title = city.Attributes.GetNamedItem("title");

                        if (city_id != null && title != null)
                        {
                            cityStruct.city_id = city_id.Value;
                            cityStruct.title = title.Value;
                        }

                        cityList.Add(cityStruct);

                        Console.WriteLine(city_id.Value + " " + title.Value);
                    }

                    totalInfo.cities = cityList;
                }

            }

            return totalInfo;
        }
    }

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
        public double sale;
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
        public List<OrgType> orgTypes;
        public List<CurrInfo> currenciesInfo;
        public List<Region> regions;
        public List<City> cities;
    }
}
