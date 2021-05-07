using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace WpfUrlConverter.Model
{
    [XmlRoot("Curs")]
    public class Curs

    {
        private DateTime _date;
        [XmlAttribute("Date")]

        public string Date
        {
            set
            {
                _date = DateTime.Parse(value, CultureInfo.GetCultureInfo("ru-RU"));
            }
            get
            {
                return _date.ToShortDateString();
            }
        }
        [XmlElement]
        public List<Valuta> Valuta;
        public Curs()
        {
        }
    }
}
