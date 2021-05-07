using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.Models
{
    [Serializable]
    public class Valuta
    {
        private double Value;
        private string Name;
        private int Nominal;


        public Valuta()
        {

        }

        public Valuta(double Value, string Name, int Nominal)
        {
            this.Value_Double = Value;
            this.Name1 = Name;
            this.Nominal1 = Nominal;
        }

        [XmlElement("Value")]
        public string Value1 { get => Value.ToString(); set => Value = Double.Parse(value); }
        [XmlElement("Name")]
        public string Name1 { get => Name; set => Name = value; }
        [XmlElement("Nominal")]
        public int Nominal1 { get => Nominal; set => Nominal = value; }
        [XmlIgnore]
        public double Value_Double
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
            }
        }
    }
}
