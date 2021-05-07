using WpfApp1.Models;
using WpfApp1.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfUrlConverter.Model;
using Converter.Repozit;

namespace WpfApp1.Repository

{
    public class Connect : Interface
    {
        public static readonly string baseURL;
        public static Dictionary<String, Curs> way;

        static Connect()
        {
            way = new Dictionary<string, Curs>();
            baseURL = @"http://www.cbr.ru/scripts/XML_daily.as";
        }
        public async Task<Curs> GetCurs()
        {
            return await GetCurs(null);
        }

        public async Task<Curs> GetCurs(DateTime? date)
        {
            if (date != null)
            {
                if (way.ContainsKey(date.Value.ToShortDateString()))
                {
                    return way[date.Value.ToShortDateString()];
                }
            }

            string reqURL = date == null ? baseURL : $"{baseURL}?date_rec={date.Value.ToShortDateString()}";

            var request = (HttpWebRequest)WebRequest.Create(reqURL);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
                using (Stream response_stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(response_stream, Encoding.GetEncoding(1251)))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Curs));
                        Curs val = (Curs)serializer.Deserialize(reader);

                        val.Valuta.Add(new Valuta(1, "Рубль РФ", 1));

                        if (!way.ContainsKey(val.Date))
                        {
                            way.Add(val.Date, val);
                        }
                        return val;
                    }
                }
            else
                Console.WriteLine(response.StatusCode);
            return null;
        }
    }
}
