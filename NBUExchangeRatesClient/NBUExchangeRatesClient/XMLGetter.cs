using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // for http web request

namespace NBUExchangeRatesClient
{
    class XMLGetter
    {
        public const String linkToXML = "http://resources.finance.ua/ru/public/currency-cash.xml";
        public const String defaultPathWhereToSave = @"..\..\nbu_source.xml";
        public static void getXMLSourseFile(String pathWhereSave = defaultPathWhereToSave) 
        {

            WebClient webClient = new WebClient();

            webClient.DownloadFile(linkToXML, pathWhereSave);
        }
    }
}
