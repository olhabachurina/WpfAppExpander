using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExpander
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private double _price;
        private DateTime _dateAdded;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; OnPropertyChanged(); }
        }

        public bool IsExpanded { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

