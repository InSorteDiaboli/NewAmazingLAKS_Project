using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class Product
    {
        private string _selectedLaminate;

        #region PRODUCT

        public string Productname { get; set; }
        public string Productsize { get; set; }
        public int Amount { get; set; }
        public string Media { get; set; }
        public ObservableCollection<string> Folie { get; set; }
        public ObservableCollection<string> Producttype { get; set; }
        public double Productprice { get; set; }
        public double Levprice { get; set; }
        public int Levamount { get; set; }
        public double Procent { get; set; }
        public double DtpPrice { get; set; }    
        public ObservableCollection<string> Laminate { get; set; }

        public string SelectedLaminate
        {
            get { return _selectedLaminate; }
            set
            {
                _selectedLaminate = value;
                Debug.WriteLine($"Selected stuff set to {SelectedLaminate}");
            }
        }

        public string SelectedFolie { get; set; }

        public string SelectedType { get; set; }
        public bool Solv { get; set; }
        public bool SUV { get; set; }

        #endregion

        #region CONSTRUCTOR

        public Product(string productname, string productsize, int amount, string media, double productprice, double levprice, int levamount, double procent, double dtpPrice, bool solv, bool suv)
        {
            Productname = productname;
            Productsize = productsize;
            Amount = amount;
            Media = media;
            Folie = new ObservableCollection<string>();
            Laminate = new ObservableCollection<string>();
            Producttype = new ObservableCollection<string>();
            Productprice = productprice;
            Levprice = levprice;
            DtpPrice = dtpPrice;
            Levamount = levamount;
            Procent = Productprice + (Productprice/100*procent);
            Solv = solv;
            SUV = suv;
        }

        #endregion
    }
}
