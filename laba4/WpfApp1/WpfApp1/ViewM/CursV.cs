using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfUrlConverter.Model;
using WpfApp1.ViewM;
using WpfApp1.Repository;

namespace WpfUrlConverter.ViewModel
{
    class CursV : Base
    {
        private DateTime _Date;
        private double _Value, _Converted;
        private Valuta _Selected1, _Selected2;
        private Curs _curs;
        private ObservableCollection<Valuta> _ValuteList;

        private Connect _Conn;
        public DateTime Date
        {
            get => _Date;
            set
            {
                _Date = value;
                OnPropertyChanged();
                GetCurs(value);
            }
        }
        public double Value
        {
            get => _Value;
            set
            {
                _Value = value;
                OnPropertyChanged();
                Converted = _Value;
            }
        }
        public double Converted
        {
            get => _Converted;
            set
            {
                _Converted = Convert(value);
                OnPropertyChanged();
            }
        }
        public Valuta Selected1
        {
            get => _Selected1;
            set
            {
                _Selected1 = value;
                OnPropertyChanged();
                Value = Value;
            }
        }
        public Valuta Selected2
        {
            get => _Selected2;
            set
            {
                _Selected2 = value;
                OnPropertyChanged();
                Value = _Value;
            }
        }
        public Curs Curs
        {
            get => _curs;
            set
            {
                _curs = value;
                OnPropertyChanged();
                ValuteList = ToCollection(value.Valuta);
            }
        }

        public ObservableCollection<Valuta> ValuteList
        {
            get => _ValuteList;
            set
            {
                _ValuteList = value;
                OnPropertyChanged();
                Value = _Value;
            }
        }

        private double Convert(double value)

        {
            if (Selected1 == null || Selected2 == null)
                return 0;
            double Valute1RealValue = Selected1.Value_Double / Selected1.Nominal1;
            double Valute2RealValue = Selected2.Value_Double / Selected2.Nominal1;

            double result = Value * Valute1RealValue / Valute2RealValue;

            return result;
        }

        private ObservableCollection<Valuta> ToCollection(List<Valuta> list)
        {
            ObservableCollection<Valuta> collection = new ObservableCollection<Valuta>();
            foreach (Valuta val in list)
            {
                collection.Add(val);
            }
            return collection;
        }

        async private void GetCurs(DateTime? time)
        {
            Curs = await _Conn.GetCurs(time);
        }

        public CursV()
        {
            _Selected2 = _Selected1;
            _Date = DateTime.Now;
            _Conn = new Connect();
            GetCurs(null);
        }
    }
}
