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
        public string Amount { get; set; }
        public string Media { get; set; }
        public ObservableCollection<string> Folie { get; set; }
        public ObservableCollection<string> Producttype { get; set; }
        public string Productprice { get; set; }
        public string Levprice { get; set; }
        public string Levamount { get; set; }
        public string Procent { get; set; }
        public string DtpPrice { get; set; }    
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

        public Product(string productname, string productsize, string amount, string media, string productprice, string levprice, string levamount, string procent, string dtpPrice, bool solv, bool suv)
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
            Procent = procent;
            Solv = solv;
            SUV = suv;
        }

        #endregion
    }
}
